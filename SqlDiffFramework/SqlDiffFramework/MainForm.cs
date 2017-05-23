using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using CleanCode.Data;
using CleanCode.DataGridViewControls;
using CleanCode.Diagnostics;
using CleanCode.Forms;
using CleanCode.GeneralComponents.Dialogs;
using CleanCode.GeneralComponents.Support;
using CleanCode.IO;
using CleanCode.SqlEditorControls;

using Algorithm.Diff;
using HertelDiffEngine;
using LukeSw.Windows.Forms;
using PotterDiffEngine;

namespace SqlDiffFramework
{

    /* NB: Watch out for presence of CheckState being generated in x.Designer.cs file.
     * This causes state buttons to always start as "on".
     * Usually happens when button.Checked is set to true in designer,
     * instead of just using the default from the config file.
     */

    public partial class MainForm : Form, IDisplayCommands
    {

        #region constants

        private const string PROG_PATTERN = "SqlDiffFramework*.exe";
        private const string WINDOW_PREFIX = "SqlDiffFramework";
        // Link to the user guide
        private const string DOWNLOAD_URL = "https://github.com/msorens/SqlDiffFramework/wiki/UserGuide";
        private const string USERGUIDE_NAME = "SqlDiffFramework UserGuide.pdf";
        // Stub PDF file is about 34K from one pdf printer, but 125K from Word.
        // Give a generous buffer and say that up to 250K is still a stub.
        private const int USERGUIDE_STUB_LIMIT = 250000;
        private string userGuideFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), USERGUIDE_NAME);
        private const string READY_MSG = "Ready";
        private const string UNKNOWN_DB_LABEL = "*UNKNOWN*";

        // Specifies relative location from the window top for the current context.
        private const double CONTEXT_POSITION = 0.20;

        private const string NO_DATA_TOKEN = "--";

        private Color DIFF_COLOR = Color.LightGreen;
        private Color OMITTED_COLOR = Color.BurlyWood;
        private Color FINER_DIFF_COLOR = Color.GreenYellow;

        private Color CURRENT_DIFF_COLOR = Color.LightSalmon;
        private Color CURRENT_OMITTED_COLOR = Color.Yellow;
        private Color CURRENT_FINER_DIFF_COLOR = Color.OrangeRed;

        private Color STANDARD_COLOR = Color.White;
        private Dictionary<Color, Color> colorMap = new Dictionary<Color, Color>();

        private Color STALE_QUERY_COLOR = Color.LightSteelBlue;

        private Font italicFont;
        private Font boldFont;

        #endregion constants

        #region fields

        private List<string> matchColumns = new List<string>();

        private ToolStripDropDownManager statusMsgMgr;

        private List<DiffChunk> hunkList;
        private int hunkPointer;

        // used for making the currently selected row be the current diff
        private Dictionary<SqlEditor, Dictionary<int, int>> hunkLookup =
            new Dictionary<SqlEditor, Dictionary<int, int>>();

        private static StructuredTraceSource tracer;
        private static StructuredTraceSource tracerData;

        /// <summary>
        /// Track as the mouse enters the left or the right pane
        /// for contextual operations.
        /// </summary>
        private SqlEditor lastAccessed;

        private List<SqlEditor> sqlEditors;

        /// <summary>
        /// When user first launches a new version, UpgradeSettings() migrates
        /// persistent settings from the prior version during component initialization.
        /// Later, in the form load, we also need to know if it is a first launch,
        /// but the migration would have erased that information. This variable, then,
        /// saves that bit of data.
        /// </summary>
        private bool newVersionNoticed;

        private int queriesDone;
        private bool queriesGood;

        private MemoryGauge memoryGauge;
        private ProgressBarForm progressBarForm;
        private WindowRestorer windowRestorer;
        private SDFOptionsForm optForm;

        private Dictionary<SqlEditor, string[]> dataCache =
            new Dictionary<SqlEditor, string[]>(2);
        private Dictionary<SqlEditor, int> lastFormattedRow =
            new Dictionary<SqlEditor, int>(2);

        private enum DisplayChoice : byte
        { // these need to be bitwise exclusive
            Added = 1,
            Missing = 2,
            Changed = 4
        }
        private DisplayChoice displayCategory;

        #endregion fields

        static MainForm()
        {
            AlignedTextWriterTraceListener.EventIdLength = 0;
            AlignedTextWriterTraceListener.TraceEventTypeLength = 0;
            tracer = new StructuredTraceSource("main");
            tracerData = new StructuredTraceSource("diffCheck");
        }

        public MainForm()
        {
            InitializeComponent();
            UpgradeSettings();

            memoryGauge = new MemoryGauge(this, memoryStatusLabel);
            windowRestorer = new WindowRestorer(this,
                Properties.Settings.Default.WindowPosition,
                Properties.Settings.Default.WindowState);

            statusMsgMgr = new ToolStripDropDownManager(msgDropDown);
            statusMsgMgr.MaxLength = 100;

            progressBarForm = new ProgressBarForm(this);
            progressBarForm.VisibleChanged += progressBarForm_VisibleChanged;

            batchForm.Execute += batchForm_Execute;

            // wire up the two SqlEditors to be aware of each other
            leftSqlEditor.Partner = rightSqlEditor;
            rightSqlEditor.Partner = leftSqlEditor;
            hunkLookup[leftSqlEditor] = new Dictionary<int, int>();
            hunkLookup[rightSqlEditor] = new Dictionary<int, int>();
            lastAccessed = leftSqlEditor; // pick one arbitrarily
            sqlEditors = new List<SqlEditor> { leftSqlEditor, rightSqlEditor };
            WireSqlEditorEventHandlers();

            InitUserCommands();

            italicFont = new Font(
                leftSqlEditor.DataGridViewControl.DefaultCellStyle.Font, FontStyle.Italic);
            boldFont = new Font(italicFont, FontStyle.Bold);

            colorMap[DIFF_COLOR] = FINER_DIFF_COLOR;
            colorMap[CURRENT_DIFF_COLOR] = CURRENT_FINER_DIFF_COLOR;
            LegendCurrentDiffLabel.BackColor = CURRENT_DIFF_COLOR;
            LegendNonCurrentDiffLabel.BackColor = DIFF_COLOR;
            LegendCurrentOmittedLabel.BackColor = CURRENT_OMITTED_COLOR;
            LegendNonCurrentOmittedLabel.BackColor = OMITTED_COLOR;

            diffEngineStyle = taubererDiffMenuItem; // default to this engine
            taubererDiffMenuItem.Checked = true;
            WireDiffEngineChoicesEventHandlers();

            UserCommandsTitle = "SqlDiffFramework Quick Reference";
            // These are static so only need to be set once:
            leftSqlEditor.UserCommandsTitle = "DB Pane Quick Reference";
            leftSqlEditor.QueryTextBox.UserCommandsTitle = "Input Quick Reference";
            leftSqlEditor.DataGridViewControl.UserCommandsTitle = "Output Quick Reference";
        }

        # region user commands

        private Collection<IDisplayElement> userCommands;

        private void InitUserCommands()
        {
            userCommands = new Collection<IDisplayElement>
        {
            new CategoryElement("DIFFERENCE NAVIGATION"),
            new CommandElement("First difference",
                "[k]Alt[k][k]Home[k] or [b]First Diff button[b]",null,firstDiffButton),
            new CommandElement("Last difference",
                "[k]Alt[k][k]End[k] or [b]Last Diff button[b]","",lastDiffButton),
            new CommandElement("Previous difference",
                "[k]Alt[k][k]UpArrow[k] or [b]Previous Diff button[b]","",previousDiffButton),
            new CommandElement("Next difference",
                "[k]Alt[k][k]DownArrow[k] or [b]Next Diff button[b]","",nextDiffButton),
            new CommandElement("Current difference",
                "[k]Alt[k][k]Enter[k] or [b]Current Diff button[b]","",currentDiffButton),
            new CommandElement("Set current difference to cursor",
                "[k]Alt[k][k]Period[k] or [b]Set Current Diff button[b]","",setCurrentDiffButton),
            new CommandElement("Limit traversal to added, missing, and/or changed rows",
                "[k]Added[k] or [k]Missing[k] or [k]Changed[k]"),

            new CategoryElement("QUERY LOAD/SAVE"),
            new CommandElement("Open query","[k]Alt[k][k]O[k]"),
            new CommandElement("New query","[k]Alt[k][k]W[k]"),
            new CommandElement("Save LEFT query","[k]Ctrl[k][k]F8[k]"),
            new CommandElement("Save RIGHT query","[k]Ctrl[k][k]F9[k]"),

            new CategoryElement("VIEW"),
            new CommandElement("Expand LEFT pane to full width","[k]Ctrl[k][k]1[k]"),
            new CommandElement("Expand RIGHT pane to full width","[k]Ctrl[k][k]2[k]"),
            new CommandElement("Display both panes equally","[k]Ctrl[k][k]3[k]"),

            new CategoryElement("MODES"),
            new CommandElement("Turbo-sort", "[b]Turbo-sort button[b]",
                turboSortButton.ToolTipText, turboSortButton),
            new CommandElement("Tandem", "[b]Tandem button[b]",
                tandemButton.ToolTipText, tandemButton),
            new CommandElement("Diff", "[b]Diff(Diff button)[b]",
                autoDiffButton.ToolTipText, autoDiffButton),
            new CommandElement("Show Progress Monitor", "[b]Show Progress Monitor button[b]",
                showProgressButton.ToolTipText, showProgressButton),

            new CategoryElement("MISCELLANEOUS"),
            new CommandElement("New workspace", "[k]Ctrl[k][k]N[k]"),
            new CommandElement("Maximize across multiple monitors", "[k]Ctrl[k][b]Maximize[b]"),
            new CommandElement("Edit connections", "[k]Ctrl[k][k]F3[k]"),
            new CommandElement("Open meta-query selector", "[k]Ctrl[k][k]F2[k]"),
            new CommandElement("View absolute or percentage memory used", "Click memory indicator",
                "Click to toggle between the two modes")

        };
        }

        public void ShowUserCommands()
        {
            DisplayCommandsForm userCommandsForm
                = new DisplayCommandsForm(userCommands);
            //userCommandsForm.Description = USER_COMMANDS_DESCRIPTION;
            userCommandsForm.Owner = this;
            userCommandsForm.ShowList(userCommandsTitle);
        }

        /// <summary>
        /// Gets or sets the title for the user commands quick reference form.
        /// </summary>
        /// <value>The user commands title.</value>
        public string UserCommandsTitle
        {
            get { return userCommandsTitle; }
            set { userCommandsTitle = value; }
        }
        private static string userCommandsTitle;

        # endregion user commands

        /********************************************************************/

        #region event handlers

        # region CultureInfo monitoring

        // from http://msdn.microsoft.com/en-us/magazine/cc163824.aspx

        private const int WM_SETTINGCHANGE = 0x001A;

        [System.Runtime.InteropServices.DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern int GetUserDefaultLCID();

        CultureInfo m_ciOld = new CultureInfo(GetUserDefaultLCID());

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // change in a systemwide or policy setting
                case WM_SETTINGCHANGE:

                    if (m.LParam != IntPtr.Zero)
                    {
                        int localeCur = GetUserDefaultLCID();
                        string val = Marshal.PtrToStringAuto(m.LParam);

                        if (val == "intl")
                        {
                            // change in locale settings
                            Thread thread = Thread.CurrentThread;

                            if (thread.CurrentCulture.LCID != localeCur &&
                              thread.CurrentCulture.LCID == m_ciOld.LCID)
                            {
                                // user default locale has changed — so
                                // change the current culture.
                                thread.CurrentCulture = new CultureInfo(localeCur);
                            }
                            else
                            {
                                // Some individual setting has changed — so
                                // clear the cached data to pick up that change.
                                thread.CurrentCulture.ClearCachedData();
                            }

                            m_ciOld = new CultureInfo(localeCur);
                        }
                    }
                    break;
            }

            base.WndProc(ref m);
        }

        # endregion CultureInfo monitoring

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys keyCode = (keyData & Keys.KeyCode);
            Keys modifiers = (keyData & Keys.Modifiers);

            // Need to manually process Ctrl+F2 to allow with or without shift key
            // (used to indicate to optionally reload library first)
            if ((modifiers == Keys.Control || modifiers == (Keys.Control | Keys.Shift))
                && (keyCode == Keys.F2) )
            {
                lastAccessed.PerformMetaQuery(); return true;
            }

            // Need to manually process these to allow with or without ctrl key
            // (used to override tandem mode)
            if (modifiers == Keys.Alt || modifiers == (Keys.Control | Keys.Alt))
            {
                switch (keyCode)
                {
                    case Keys.O: lastAccessed.PerformOpenQueryFile(); return true;
                    case Keys.W: lastAccessed.PerformNewEmptyQuery(); return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region form

        private void MainForm_Load(object sender, EventArgs e)
        {
            Show();

            statusMsgMgr.Message("Initializing...");
            memoryUsageTimer.Start();

            if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift)
            { // skip if shift depressed
                CheckNewVersionUse();
                if (Properties.Settings.Default.UpdateCheckInterval > 0)
                { CheckForUpdates(); }
            }
            else { tracer.TraceInformation("Network check override by user"); }

            statusMsgMgr.Message("Checking connection settings...");
            Refresh();
            InitializeValuesFromSettings();

            statusMsgMgr.Message(READY_MSG);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if (windowRestorer != null) windowRestorer.TrackWindow();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (windowRestorer != null)
            {
                windowRestorer.MultipleMonitorMaximize();
                windowRestorer.TrackWindow();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = DoCleanup();
        }

        private void restoreSettingsMenuItem_Click(object sender, EventArgs e)
        {
            VDialog vDialog = new VDialog();
            vDialog.Buttons = new VDialogButton[]
            {
                new VDialogButton(VDialogResult.Yes, "Restore Factory Defaults"),
                new VDialogButton(VDialogResult.No, "Restore Last Saved Settings"),
                new VDialogButton(VDialogResult.Cancel, "Cancel")
            };
            vDialog.DefaultButton = VDialogDefaultButton.Button3;
            vDialog.WindowTitle = "Confirm Restore Settings";
            vDialog.MainIcon = VDialogIcon.Question;
            vDialog.MainInstruction =
                "Restores your paths, modes, and DB connections to" +
                Environment.NewLine +
                "the first time or the last time you started this program." +
                Environment.NewLine + Environment.NewLine;
            vDialog.Content =
                "Select 'Restore Factory Defaults' to reset your settings to out-of-the-box." +
                Environment.NewLine +
                "Select 'Restore Last Saved Settings' to restore your settings" +
                Environment.NewLine +
                "back to when you last closed the program." +
                Environment.NewLine + Environment.NewLine +
                "(Note: If you wish to retain your list of DB connections, open the" +
                Environment.NewLine +
                "connection editor and export them to a file." +
                Environment.NewLine +
                "After you restore settings here, then re-import those settings.)";
            VDialogResult result = vDialog.Show();
            if (result == VDialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                InitializeValuesFromSettings();
                MessageBox.Show("Factory Settings Restored", "Operation Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == VDialogResult.No)
            {
                Properties.Settings.Default.Reload();
                InitializeValuesFromSettings();
                MessageBox.Show("Last Saved Settings Restored", "Operation Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /* else cancelled */
        }

        #endregion form

        #region miscellaneous

        private void memoryUsageTimer_Tick(object sender, EventArgs e)
        {
            memoryGauge.UpdateUsage();
        }

        private void memoryStatusLabel_Click(object sender, EventArgs e)
        {
            // Clicking the memory gauge does two things:
            // (1) Toggle the format between absolute and percentage.
            memoryGauge.ShowRelative = !memoryGauge.ShowRelative;

            // (2) Put a visual marker in the log.
            tracerData.TraceInformation("------");
        }

        private void turboSortButton_Click(object sender, EventArgs e)
        {
            statusMsgMgr.Message("TurboSort " + (turboSortButton.Checked ? "enabled" : "disabled"));
            leftSqlEditor.TurboSortMode = turboSortButton.Checked;
            rightSqlEditor.TurboSortMode = turboSortButton.Checked;
        }

        private void tandemButton_Click(object sender, EventArgs e)
        {
            statusMsgMgr.Message("Tandem mode " + (tandemButton.Checked ? "enabled" : "disabled"));
            leftSqlEditor.TandemMode = tandemButton.Checked;
            rightSqlEditor.TandemMode = tandemButton.Checked;
        }

        private void mirrorQueryMenuItem_Click(object sender, EventArgs e)
        {
            VDialog vDialog = new VDialog();
            vDialog.Buttons = new VDialogButton[]
            {
                new VDialogButton(VDialogResult.Yes, "Toggle Local"),
                new VDialogButton(VDialogResult.No, "Retain Local"),
                new VDialogButton(VDialogResult.Cancel, "Cancel")
            };
            vDialog.DefaultButton = VDialogDefaultButton.Button1;
            vDialog.WindowTitle = "Confirm Mirror Operation";
            vDialog.MainIcon = VDialogIcon.Question;
            vDialog.MainInstruction =
                "The MIRROR operation changes one pane to match the other pane, " +
                Environment.NewLine +
                "copying paths, connections, modes, and the query text." +
                Environment.NewLine + Environment.NewLine;
            vDialog.Content =
                "Often this is used to compare live data to local data, " +
                Environment.NewLine +
                "so for convenience, the 'Toggle Local' button lets you set this up immediately. " +
                Environment.NewLine +
                "If you want to mirror the local mode as well, select 'Retain Local' instead.";
            VDialogResult result = vDialog.Show();
            if (result == VDialogResult.Yes) MirrorPane(true);
            else if (result == VDialogResult.No) MirrorPane(false);
            /* else cancelled */
        }

        private void MirrorPane(bool invertLocalMode)
        {
            // Handle standard user check for unsaved file
            lastAccessed.Partner.FilenameChanged -= sqlEditor_FilenameChanged;
            if (lastAccessed.Partner.PerformNewEmptyQuery())
            {

                lastAccessed.Partner.DbConnectionName = lastAccessed.DbConnectionName;
                lastAccessed.Partner.SqlPath = lastAccessed.SqlPath;
                lastAccessed.Partner.CsvPath = lastAccessed.CsvPath;
                lastAccessed.Partner.AutoHighlightMode = lastAccessed.AutoHighlightMode;
                lastAccessed.Partner.AutoExecuteMode = lastAccessed.AutoExecuteMode;
                lastAccessed.Partner.TurboSortMode = lastAccessed.TurboSortMode;
                lastAccessed.Partner.TandemMode = lastAccessed.TandemMode;

                lastAccessed.Partner.LocalMode = invertLocalMode ?
                    !lastAccessed.LocalMode : lastAccessed.LocalMode;

                // load same query but *not* tied to the filename
                lastAccessed.Partner.PerformLoadQuery(lastAccessed.QueryTextBox.Text);
            }
            lastAccessed.Partner.FilenameChanged += sqlEditor_FilenameChanged;
        }

        private void tabBehaviorButton_Click(object sender, EventArgs e)
        {
        }

        // Currently disabled due to more work needed:
        // This method properly sets the child control states,
        // but the child controls do not set this menu item.
        // Also, what if the two SqlEditors have different settings...?
        private void tabLeavesControlMenuItem_Click(object sender, EventArgs e)
        {
            foreach (SqlEditor sqlEditor in sqlEditors)
            {
                sqlEditor.TabLeavesControl = tabLeavesControlMenuItem.Checked;
            }
        }

        // Currently disabled due to more work needed:
        // This method properly sets the child control states,
        // but the child controls do not set this menu item.
        // Also, what if the two SqlEditors have different settings...?
        private void tabInsertsSpacesMenuItem_Click(object sender, EventArgs e)
        {
            foreach (SqlEditor sqlEditor in sqlEditors)
            {
                sqlEditor.QueryTextBox.ExpandTab = tabInsertsSpacesMenuItem.Checked;
            }
        }

        private void showMainKeyReferenceMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserCommands();
        }

        private void showEditorPaneKeyReferenceMenuItem_Click(object sender, EventArgs e)
        {
            lastAccessed.ShowUserCommands();
        }
        
        private void showOutputKeyReferenceMenuItem_Click(object sender, EventArgs e)
        {
            lastAccessed.DataGridViewControl.ShowUserCommands();
        }

        private void showInputKeyReferenceMenuItem_Click(object sender, EventArgs e)
        {
            lastAccessed.QueryTextBox.ShowUserCommands();
        }

        private bool IsUserGuideInstalled()
        {
            bool userGuideInstalled;
            try { userGuideInstalled = (new FileInfo(userGuideFileName).Length > USERGUIDE_STUB_LIMIT ); }
            catch (Exception) { userGuideInstalled = false; }
            return userGuideInstalled;
        }

        private bool InstallUserGuide()
        {
            bool clipboardLoaded = true;
            try { Clipboard.SetDataObject(userGuideFileName); }
            catch (System.Runtime.InteropServices.ExternalException) { clipboardLoaded = false; }
            string NL = Environment.NewLine;

            VDialog vDialog = new VDialog();
            vDialog.Buttons = new VDialogButton[]
                {
                    new VDialogButton(VDialogResult.OK, "I have downloaded the user guide--open it!"),
                    new VDialogButton(VDialogResult.Cancel, "Cancel")
                };
            vDialog.DefaultButton = VDialogDefaultButton.Button2;
            vDialog.WindowTitle = "SqlDiffFramework User Guide";
            vDialog.MainIcon = VDialogIcon.Warning;
            vDialog.MainInstruction =
                "You have not yet installed the User Guide" + NL + NL;
            string website_link_text = "SqlDiffFramework website";
            vDialog.Content =
                "Because it is ten times larger than the application itself, the user guide is not installed by default." + NL + NL +
                "Download the user guide from the " + website_link_text + " and save it to this file name:" + NL +
                userGuideFileName
                + (clipboardLoaded ?
                NL + NL + "(The file path and name have been preloaded on your clipboard--just paste into your browser's 'file save' dialog.)" : "");
            vDialog.ContentLinks.Add(vDialog.Content.IndexOf(website_link_text), website_link_text.Length);
            vDialog.LinkClicked += vDialog_LinkClicked;

            // Take the user on faith that, if OK is pressed, he/she has downloaded the user guide.
            // If one attempts to open it and did not download it, one will just get a pop-up indicator.
            return (vDialog.Show() == VDialogResult.OK);
        }

        private void ShowUserGuide()
        {
            try { Process.Start(userGuideFileName); }
            catch (Exception ex) { MessageBox.Show("Cannot open user guide: " + ex.Message); }
        }

        private void vDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try { Process.Start(DOWNLOAD_URL); }
            catch (Exception ex) { MessageBox.Show("Cannot open website: " + ex.Message); }
        }

        #endregion miscellaneous

        # region menu commands

        private void showProgressMenuItem_Click(object sender, EventArgs e)
        {
            showProgressButton.Checked = showProgressMenuItem.Checked;
            progressBarForm.AutoDisplay = !showProgressMenuItem.Checked;
        }

        private void showProgressButton_Click(object sender, EventArgs e)
        {
            showProgressMenuItem.Checked = showProgressButton.Checked;
            progressBarForm.AutoDisplay = !showProgressMenuItem.Checked;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void userGuideMenuItem_Click(object sender, EventArgs e)
        {
            if (IsUserGuideInstalled() || InstallUserGuide())
            { ShowUserGuide(); }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            // Tried using just Show() first but since main window grabs focus
            // with mouse movements it made the About window disappear.
            new AboutBox().ShowDialog();
        }

        private void newWorkspaceMenuItem_Click(object sender, EventArgs e)
        {
            SaveUserSettings();
            ProcessStartInfo psi = new ProcessStartInfo(Application.ExecutablePath);
            Process.Start(psi);
        }

        private void metaQueriesMenuItem_Click(object sender, EventArgs e)
        {
            lastAccessed.PerformMetaQuery();
        }

        private void editConnectionsMenuItem_Click(object sender, EventArgs e)
        {
            // Either left or right instance will yield the same result here
            leftSqlEditor.EditConnections();
        }

        private void newQueryMenuItem_Click(object sender, EventArgs e)
        {
            lastAccessed.PerformNewEmptyQuery();
        }

        private void openQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastAccessed.PerformOpenQueryFile();
        }

        private void saveLeftQueryMenuItem_Click(object sender, EventArgs e)
        {
            leftSqlEditor.PerformSaveQuery();
        }

        private void saveRightQueryMenuItem_Click(object sender, EventArgs e)
        {
            rightSqlEditor.PerformSaveQuery();
        }

        private void executeQueryMenuItem_Click(object sender, EventArgs e)
        {
            lastAccessed.PerformExecuteQuery();
        }

        private void executeBatchMenuItem_Click(object sender, EventArgs e)
        {
            DisplayBatchPalette();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastAccessed.QueryTextBox.ShowSearchDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastAccessed.QueryTextBox.ShowReplaceDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optForm == null) { optForm = new SDFOptionsForm(); }
            optForm.ShowDialog(this);

            // propagate settings that were already provided to components, if any
            foreach (SqlEditor sqlEditor in sqlEditors)
            { 
                sqlEditor.CommandTimeout = (int)Properties.Settings.Default.CommandTimeout;
                sqlEditor.MaxColumnWidth = (int)Properties.Settings.Default.MaxColumnWidth;
            }
        }

        # endregion menu commands

        #region diff navigation

        private void nextDiffButton_Click(object sender, EventArgs e)
        {
            DisplayHunk(1);
        }
        private void nextDifferenceMenuItem_Click(object sender, EventArgs e)
        {
            nextDiffButton_Click(sender, e);
        }

        private void previousDiffButton_Click(object sender, EventArgs e)
        {
            DisplayHunk(-1);
        }
        private void previousDifferenceMenuItem_Click(object sender, EventArgs e)
        {
            previousDiffButton_Click(sender, e);
        }

        private void currentDiffButton_Click(object sender, EventArgs e)
        {
            DisplayHunk(0);
        }
        private void currentDifferenceMenuItem_Click(object sender, EventArgs e)
        {
            currentDiffButton_Click(sender, e);
        }

        private void setCurrentDiffButton_Click(object sender, EventArgs e)
        {
            MoveToSelectedDiff();
        }
        private void setCurrentDifferenceMenuItem_Click(object sender, EventArgs e)
        {
            MoveToSelectedDiff();
        }

        private void firstDiffButton_Click(object sender, EventArgs e)
        {
            hunkPointer = 0;
            DisplayHunk(0);
        }

        private void firstDifferenceMenuItem_Click(object sender, EventArgs e)
        {
            firstDiffButton_Click(sender, e);
        }

        private void lastDiffButton_Click(object sender, EventArgs e)
        {
            hunkPointer = hunkList.Count - 1;
            DisplayHunk(0);
        }

        private void lastDifferenceMenuItem_Click(object sender, EventArgs e)
        {
            lastDiffButton_Click(sender, e);
        }

        private void autoDiffButton_Click(object sender, EventArgs e)
        {
            // Change of strategy: just set state
            // DiffDGV();
        }

        private ToolStripMenuItem diffEngineStyle;

        #endregion diff navigation

        #region DataGridView cells, rows, and splitters

        /* .Net 2.0 Bug?
         * List<T>.Contains() uses default equality comparer for type T. With strings,
         * this means that the case must match.
         * In IdentifyMatchColumns() however, where DataGridView.Column[x].Contains()
         * is used to fill matchColumns, that Contains() method is case-insensitive!
         * Solution: Use ToUpper() in both places as a workaround.
         */
        private void dataGridView_CellFormatting(
            object sender, DataGridViewCellFormattingEventArgs e)
        {
            var thisSqlEditor = (SqlEditor)sender;
            var dgv = thisSqlEditor.DataGridViewControl;

            // mark matching columns that are *not* to be compared
            if (!matchColumns.Contains(dgv.Columns[e.ColumnIndex].Name.ToUpper()))
            {
                e.CellStyle.ForeColor = Color.Gray;
                e.CellStyle.Font = italicFont;
            }

            // refresh each row's height in case user changed it
            if (lastFormattedRow[thisSqlEditor] != e.RowIndex)
            { dgv.Rows[e.RowIndex].Height = dgv.RowTemplate.Height; }

            // SqlServer represents Booleans first as CheckBoxes; when that is suppressed,
            // it then uses "True" or "False" literals. This maps them to "0" and "1"
            // for display purposes but does not help with the underlying comparison,
            // so I am not using this. 
            //if (dgv.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewTextBoxColumn)
            //    && e.Value != null && e.Value.GetType() == typeof(bool))
            //{
            //    e.Value = ((bool)e.Value) ? "1" : "0";
            //    e.FormattingApplied = true;
            //}

            lastFormattedRow[thisSqlEditor] = e.RowIndex;
        }

        private void showLeftPaneMenuItem_Click(object sender, EventArgs e)
        {
            mainSplitContainer.SplitterDistance = mainSplitContainer.Size.Width - 1;
        }

        private void showRightPaneMenuItem_Click(object sender, EventArgs e)
        {
            mainSplitContainer.SplitterDistance = 0;
        }

        private void showBothPanesMenuItem_Click(object sender, EventArgs e)
        {
            // subtract a smidgen to allow for borders, etc.
            mainSplitContainer.SplitterDistance = mainSplitContainer.Size.Width / 2 - 4;
        }

        private void dataGridView_FilterChanged(object sender, EventArg<FilterChangedData> e)
        {
            // Event fires only once whether tandem mode or not.
            // Upon completion of filtering, redo the diff.
            tracer.TraceEnter();
            var thisSqlEditor = (SqlEditor)sender;
            dataCache[thisSqlEditor] = null;
            lastFormattedRow[thisSqlEditor] = -1;
            if (tandemButton.Checked)
            {
                dataCache[thisSqlEditor.Partner] = null;
                lastFormattedRow[thisSqlEditor.Partner] = -1;
            }
            DiffDGV();
            tracer.TraceLeave();
        }

        private void sqlEditor_Sorted(object sender, EventArgs e)
        {
            SqlEditor thisSqlEditor = (SqlEditor)sender;
            dataCache[thisSqlEditor] = null;

            // sort column: thisSqlEditor.DataGridViewControl.SortedColumn
            DiffDGV(); // redo diff if appropriate
        }

        #endregion DataGridView cells, rows, and splitters

        #region SqlEditor

        private void sqlEditor_ExecuteQueryFinish(object sender, EventArg<StatusData> e)
        {
            tracer.TraceEnterEventHandler(sender);
            queriesGood &= e.Data.success;
            SqlEditor thisSqlEditor = (SqlEditor)sender;
            dataCache[thisSqlEditor] = null;
            lastFormattedRow[thisSqlEditor] = -1;
            CheckCacheValidity(thisSqlEditor);
            tracer.TraceInformation("Queries left = " + (queriesDone-1));

            // TODO: When including orphans in batch mode, queriesDone is not initialized for a left-side orphan,
            // but it is harmless.
            if ((--queriesDone == 0) && queriesGood) { DiffDGV(); }
            else { ClearDiff(); } // cleanup previous run details, if any
            if (queriesDone <= 0) { SetBusyIcon(false); }
            tracer.TraceLeaveEventHandler(sender);
        }

        private void sqlEditor_ExecuteQueryStart(object sender, EventArg<StatusData> e)
        {
            tracer.TraceEnterEventHandler(sender);
            queriesDone = e.Data.tandemMode? 2 : 1; // number of SqlEditors to wait for
            tracer.TraceInformation("Setting pending queries left to " + queriesDone);
            queriesGood = true;
            SetBusyIcon(true);
            tracer.TraceLeaveEventHandler(sender);
        }

        private void sqlEditor_FilenameChanged(object sender, EventArg<FilenameChangedData> e)
        {
            this.Text = e.Data.filename.Equals(NO_DATA_TOKEN) ? WINDOW_PREFIX :
                WINDOW_PREFIX + " - " + e.Data.filename;
        }

        private void sqlEditor_MouseEnter(object sender, EventArgs e)
        {
            lastAccessed = (SqlEditor)sender;
            // Getting here means we refocused a pane, burying the progress monitor if visible;
            // bring it back on top if user requested it.
            if (showProgressMenuItem.Checked)
            { progressBarForm.Focus(); }
        }

        private void progressBarForm_VisibleChanged(object sender, EventArgs e)
        {
            // when user closes the mini-form, turn off the user's display request (if present).
            if (!progressBarForm.Visible)
            {
                showProgressMenuItem.Checked = false;
                showProgressButton.Checked = false;
            }
        }

        private void sqlEditor_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "DbConnectionName":
                    if (((SqlEditor)sender) == leftSqlEditor)
                    { batchForm.LeftSystemLabel = ((SqlEditor)sender).DbConnectionName; }
                    else { batchForm.RightSystemLabel = ((SqlEditor)sender).DbConnectionName; }
                    break;
                case "SqlPath":
                    if (((SqlEditor)sender) == leftSqlEditor)
                    { batchForm.LeftSourceLabel = ((SqlEditor)sender).SqlPath; }
                    else { batchForm.RightSourceLabel = ((SqlEditor)sender).SqlPath; }
                    break;
                case "CsvPath":
                    if (((SqlEditor)sender) == leftSqlEditor)
                    { batchForm.LeftSnapshotLabel = ((SqlEditor)sender).CsvPath; }
                    else { batchForm.RightSnapshotLabel = ((SqlEditor)sender).CsvPath; }
                    break;
            }
        }

        #endregion

        #endregion event handlers

        /********************************************************************/

        # region admin

        /* UpgradeSettings and CheckNewVersionUse could in theory be done together.
         * However, UpgradeSettings must be done in the constructor,
         * not the form load event, so no form I/O, and thus we want it to be quick.
         * CheckNewVersionUse could be slow (e.g. if no network access),
         * so we want to show a status message, therefore that goes in the form load.
         */

        private void UpgradeSettings()
        {
            tracer.TraceInformation("Checking for new install...");
            if (Properties.Settings.Default.NewVersion)
            {
                tracer.TraceInformation("Version is new--upgrading settings from prior version.");
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.NewVersion = false;
                newVersionNoticed = true; // for CheckNewVersionUse
            }
            else
            {
                tracer.TraceInformation("Version is NOT new.");
            }
        }

        private void CheckNewVersionUse()
        {
            if (newVersionNoticed)
            {
                statusMsgMgr.Message("Checking for new version...");
                Refresh();

                if (Properties.Settings.Default.UnreachableRepository > 0)
                {
                    tracer.TraceInformation("Recording first use of this version in the catalog file");
                    UsageTracker tracker = new UsageTracker(
                        Properties.Settings.Default.UpdateRepository,
                        Properties.Settings.Default.UpdateCatalogFile);
                    try { tracker.RecordFirstUse(Assembly.GetExecutingAssembly()); }
                    catch (SystemException ex)
                    { tracer.TraceInformation("Catalog file update failed: " + ex.Message); }
                }

                statusMsgMgr.Message("Resetting file resources...");
                Refresh();
                tracer.TraceInformation("Resetting file resources:");
                string fileList = ResetFileResources();
                tracer.TraceInformation(fileList);

                if (!IsUserGuideInstalled())
                {
                    string NL = Environment.NewLine;
                    VDialog vDialog = new VDialog();
                    vDialog.Buttons = new VDialogButton[] { new VDialogButton(VDialogResult.OK, "OK") };
                    vDialog.DefaultButton = VDialogDefaultButton.Button2;
                    vDialog.WindowTitle = "Important Note on the User Guide";
                    vDialog.MainIcon = VDialogIcon.Information;
                    vDialog.MainInstruction = "Welcome to SqlDiffFramework!";
                    vDialog.Content =
                        "The User Guide is not installed automatically; " + NL +
                        "you will likely find it instrumental in getting started, though. " + NL + NL +
                        "Please go to 'Help menu >> User Guide' for details on installing it.";
                    vDialog.Show();
                }
            }
        }

        private string ResetFileResources()
        {
            Collection<string> l = ResourceMgr.ResetAllResources(this);
            var exceptionList = from name in l where name.StartsWith("***") select name.Substring(3).Trim();
            foreach (var msg in  exceptionList) { statusMsgMgr.Error(msg); }
            return l.Where(name => name.Length > 0 && !name.StartsWith("***")).Select(name => name).ToTokenString();
        }

        private void CheckForUpdates()
        {
            statusMsgMgr.Message("Checking for updates...");
            Refresh();
            tracer.TraceInformation("Checking for program updates...");

            if (Properties.Settings.Default.UnreachableRepository == 0) {
                tracer.TraceInformation("Repository is marked as permanently unreachable");
                return;
            }

            UpdateCheck updateCheck = new UpdateCheck(
                    Assembly.GetExecutingAssembly(),
                    Properties.Settings.Default.UpdateRepository,
                    PROG_PATTERN);
            DateTime lastUpdateCheck;
            int updateCheckInterval = (int)Properties.Settings.Default.UpdateCheckInterval;
            try // this could fail on a clean installation
            { lastUpdateCheck = Properties.Settings.Default.UpdateChecked; }
            catch (NullReferenceException)
            {
                lastUpdateCheck = DateTime.Now -
                  new TimeSpan(updateCheckInterval + 1, 0, 0, 0);
            }
            if (updateCheck.RemindNewerVersion(updateCheckInterval, lastUpdateCheck))
            {
                Properties.Settings.Default.UpdateChecked = DateTime.Now.Date;
                tracer.TraceInformation("Program update is available; will remind again in "
                    + updateCheckInterval + " days");
            }
            else { tracer.TraceInformation("Program update is not available OR too soon to check again."); }

            if (updateCheck.AccessFailure)
            {   // If it ever fails 5 times, it will never check again.
                // This makes startup faster in a location that is not connected to repository
                Properties.Settings.Default.UnreachableRepository--;
                tracer.TraceInformation("Repository unreachable this pass; " +
                    Properties.Settings.Default.UnreachableRepository + " attempts left");
            }
            else
            { // a good access; reset the doomsday counter
                Properties.Settings.Default.UnreachableRepository = 5;
            }
        }

        private void WireSqlEditorEventHandlers()
        {
            foreach (SqlEditor sqlEditor in sqlEditors)
            {
                sqlEditor.CellFormatting +=
                        new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
                sqlEditor.ExecuteQueryFinish +=
                    new ExecuteQueryEventHandler(sqlEditor_ExecuteQueryFinish);
                sqlEditor.ExecuteQueryStart +=
                    new ExecuteQueryEventHandler(sqlEditor_ExecuteQueryStart);
                sqlEditor.FilenameChanged +=
                    new FilenameChangedEventHandler(sqlEditor_FilenameChanged);
                sqlEditor.FilterChanged += dataGridView_FilterChanged;
                sqlEditor.Sorted += sqlEditor_Sorted;
                sqlEditor.MouseEnter += sqlEditor_MouseEnter;
                sqlEditor.PropertyChanged += sqlEditor_PropertyChanged;
            }
        }

        private void InitializeValuesFromSettings()
        {
            progressBarForm.ShowElapsedTimes = Properties.Settings.Default.ShowElapsedTimes;
            showProgressButton.Checked = false;

            tandemButton.Checked = Properties.Settings.Default.TandemButton_Checked;
            turboSortButton.Checked = Properties.Settings.Default.TurboSortButton_Checked;
            autoDiffButton.Checked = Properties.Settings.Default.AutoDiffButton_Checked;

            #region editor panes


            // Note on SuppressAltNavigation:
            // Want Alt+Up/Down to walk through diffs only.
            // When those shortcuts are disabled (e.g. by reaching the last diff)
            // then the DataGridView's handler takes over, where these keys
            // simply walk the grid. This switch turns off that behavior.

            foreach (SqlEditor sqlEditor in sqlEditors)
            {
                // first group: set and forget
                sqlEditor.ConnectionList    = Properties.Settings.Default.ConnectionList;
                sqlEditor.AutoHighlightMode = Properties.Settings.Default.AutoHighlightButton_Checked;
                sqlEditor.AutoExecuteMode   = Properties.Settings.Default.AutoExecuteButton_Checked;
                sqlEditor.LocalMode         = Properties.Settings.Default.UseLocalDataButton_Checked;
                sqlEditor.TurboSortMode     = turboSortButton.Checked;
                sqlEditor.TandemMode        = tandemButton.Checked;
                sqlEditor.DataGridViewControl.SuppressAltNavigation = true;

                // second group: initialize now; update if changed on options form
                sqlEditor.CommandTimeout = (int)Properties.Settings.Default.CommandTimeout;
                sqlEditor.MaxColumnWidth = (int)Properties.Settings.Default.MaxColumnWidth;

                lastFormattedRow[sqlEditor] = -1;
            }
            leftSqlEditor.DbConnectionName = Properties.Settings.Default.LeftConnectionName;
            leftSqlEditor.SqlPath = Properties.Settings.Default.LeftSqlDirectory;
            leftSqlEditor.CsvPath = Properties.Settings.Default.LeftCsvDirectory;
            leftSqlEditor.UniqueNameHint = "left";

            rightSqlEditor.DbConnectionName = Properties.Settings.Default.RightConnectionName;
            rightSqlEditor.SqlPath = Properties.Settings.Default.RightSqlDirectory;
            rightSqlEditor.CsvPath = Properties.Settings.Default.RightCsvDirectory;
            rightSqlEditor.UniqueNameHint = "right";
            #endregion editor panes
        }

        private void SaveUserSettings()
        {
            Properties.Settings.Default.TandemButton_Checked = tandemButton.Checked;
            Properties.Settings.Default.TurboSortButton_Checked = turboSortButton.Checked;
            Properties.Settings.Default.AutoDiffButton_Checked = autoDiffButton.Checked;

            Properties.Settings.Default.LeftConnectionName = leftSqlEditor.DbConnectionName;
            Properties.Settings.Default.LeftSqlDirectory = leftSqlEditor.SqlPath;
            Properties.Settings.Default.LeftCsvDirectory = leftSqlEditor.CsvPath;

            Properties.Settings.Default.RightConnectionName = rightSqlEditor.DbConnectionName;
            Properties.Settings.Default.RightSqlDirectory = rightSqlEditor.SqlPath;
            Properties.Settings.Default.RightCsvDirectory = rightSqlEditor.CsvPath;

            // The two SqlEditors may differ, so grab from the most recently used.
            Properties.Settings.Default.ConnectionList = lastAccessed.ConnectionList;
            Properties.Settings.Default.AutoHighlightButton_Checked = lastAccessed.AutoHighlightMode;
            Properties.Settings.Default.AutoExecuteButton_Checked = lastAccessed.AutoExecuteMode;
            Properties.Settings.Default.UseLocalDataButton_Checked = lastAccessed.LocalMode;

            Properties.Settings.Default.WindowPosition = windowRestorer.WindowPosition;
            Properties.Settings.Default.WindowState = windowRestorer.WindowState;

            Properties.Settings.Default.Save();
        }

        private bool DoCleanup()
        {
            // returns state indicating whether user has cancelled or not.
            if (leftSqlEditor.CheckSavingQuery()) { return true; }
            if (rightSqlEditor.CheckSavingQuery()) { return true; }

            memoryUsageTimer.Stop();
            SaveUserSettings();
            tracer.TraceInformation("***** Program terminated by user.");
            return false;
        }

        private bool BothSidesHaveData
        {
            get
            {
                return (leftSqlEditor.DataGridViewControl.RowCount > 0
                && rightSqlEditor.DataGridViewControl.RowCount > 0);
            }
        }

        private bool NeitherSideHasData
        {
            get
            {
                return (leftSqlEditor.DataGridViewControl.RowCount == 0
                && rightSqlEditor.DataGridViewControl.RowCount == 0);
            }
        }

        # endregion admin

        # region mutually exclusive checked menu items

        private void WireDiffEngineChoicesEventHandlers()
        {
            // wire up all choices to the same handler 
            foreach (ToolStripMenuItem diffEngineStyleItem in autoDiffSplitButton.DropDownItems)
            {
                diffEngineStyleItem.Click += DiffEngineStyleItem_Click;
            }
        }

        // Non-optimal solution: fails if one clicks the already checked item
        //object checkChangedLock = new object();
        //private void DiffEngineStyleItem_CheckedChanged(object sender, EventArgs e)
        //{
        //    // menu items should have CheckOnClick enabled.
        //    ToolStripMenuItem item = sender as ToolStripMenuItem;
        //    if (item != null && item.Checked)
        //    {
        //        lock (checkChangedLock)
        //        {
        //            foreach (ToolStripMenuItem subItem in item.Owner.Items)
        //            {
        //                if (!item.Equals(subItem) && subItem != null)
        //                {
        //                    subItem.Checked = false;
        //                }
        //            }
        //        }
        //    }
        //}

        private void DiffEngineStyleItem_Click(object sender, EventArgs e)
        {
            // menu items should *not* have CheckOnClick enabled.
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (!item.Checked)
            {
                foreach (ToolStripMenuItem siblingItem in item.Owner.Items)
                {
                    if (!item.Equals(siblingItem) && siblingItem != null)
                    { siblingItem.Checked = false; }
                }
                item.Checked = true;
                diffEngineStyle = item;
                // re-invoke the diff
                DiffDGV();
            }
        }

        # endregion mutually exclusive checked menu items

        # region batch processing

        private BatchSetupForm batchForm = new BatchSetupForm();

        private void DisplayBatchPalette()
        {
            batchForm.Owner = this;
            batchForm.Show();
            if (batchForm.WindowState == FormWindowState.Minimized)
            { batchForm.WindowState = FormWindowState.Normal; }
        }

        private void batchForm_Execute(object sender, EventArgs e)
        {
            // Usually does not make sense to diff without tandem execution...
            if (autoDiffButton.Checked && !tandemButton.Checked)
            {
                VDialog vDialog = new VDialog();
                vDialog.Buttons = new VDialogButton[]
                {
                    new VDialogButton(VDialogResult.OK, "Continue"),
                    new VDialogButton(VDialogResult.Cancel, "Cancel")
                };
                vDialog.DefaultButton = VDialogDefaultButton.Button2;
                vDialog.WindowTitle = "Inconsistent Settings";
                vDialog.MainIcon = VDialogIcon.Warning;
                vDialog.MainInstruction =
                    "Are you sure you want Auto-Diff enabled and Tandem disabled?" +
                    Environment.NewLine + Environment.NewLine;
                vDialog.Content =
                    "Select 'Cancel' to go back and adjust your settings (in the *main* window).";
                if (vDialog.Show() == VDialogResult.Cancel) { return; }
            }

            // Must have this switched on
            foreach (SqlEditor sqlEditor in sqlEditors) { sqlEditor.AutoExecuteMode = true; }

            foreach (var filename in batchForm.FileList)
            {
                batchForm.StartedFile(filename);
                ProcessFileUnattended(filename);
                batchForm.FinishedFile();
                if (batchForm.Cancelled) { batchForm.InterruptedSequence(); break; }
            }
        }

        private void ProcessFileUnattended(string fileName)
        {
            tracer.TraceEnter();
            tracer.TraceInformation(">>>>>>>>> Processing file " + fileName);
            DateTime startTime = DateTime.Now;
            leftSqlEditor.SetFile(fileName);
            TimeSpan elapsed = (DateTime.Now - startTime);
            //tracer.TraceInformation(string.Join(",",
            //    new string[] {
            //        filename,
            //        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //        string.Format("{0:00}:{1:00}", elapsed.Minutes, elapsed.Seconds),
            //        leftSqlEditor.DataGridViewControl.Rows.Count.ToString(),
            //        rightSqlEditor.DataGridViewControl.Rows.Count.ToString(),
            //        diffCountLabel.Text,
            //        addedLinesLabel.Text,
            //        missingLinesLabel.Text,
            //        changedLinesLabel.Text,
            //        matchPercentageLabel.Text,
            //        memoryStatusLabel.Text
            //        }
            //    ));
            batchForm.DataTable.Rows.Add(new object[] {
                    Path.GetFileName(fileName),
                    DateTime.Now,
                    new RoundedTimeSpan(elapsed.Ticks, 1).ToString(),
                    (leftSqlEditor.Successful? leftSqlEditor.DataGridViewControl.Rows.Count : -1),
                    (rightSqlEditor.Successful? rightSqlEditor.DataGridViewControl.Rows.Count : -1),
                    SafeParse(diffCountLabel.Text),
                    SafeParse(addedLinesLabel.Text),
                    SafeParse(missingLinesLabel.Text),
                    SafeParse(changedLinesLabel.Text),
                    matchPercentageLabel.Text,
                    memoryStatusLabel.Text
            });
            if (batchForm.SaveSnapshots)
            {
                string csvName = Path.GetFileName(fileName.Replace("sql", "csv"));
                leftSqlEditor.SendGridToCsv(Path.Combine(leftSqlEditor.CsvPath, csvName));
                rightSqlEditor.SendGridToCsv(Path.Combine(rightSqlEditor.CsvPath, csvName));
            }
            tracer.TraceLeave();
        }

        private int SafeParse(string label)
        {
            int result;
            return int.TryParse(label, out result) ? result : -1;
        }

        # endregion batch processing

        /********************************************************************/

        #region difference engine

        private void ClearDiff()
        {
            hunkList = new List<DiffChunk>();
            hunkPointer = -1;
            diffCountLabel.Text = NO_DATA_TOKEN;
            currentDiffLabel.Text = NO_DATA_TOKEN;
            matchPercentageLabel.Text = NO_DATA_TOKEN;
            addedLinesLabel.Text = NO_DATA_TOKEN;
            missingLinesLabel.Text = NO_DATA_TOKEN;
            changedLinesLabel.Text = NO_DATA_TOKEN;
            EnableDiffButtons();
        }

        private bool DiffDGV()
        {
            tracer.TraceEnter();
            Cursor = Cursors.WaitCursor;
            ClearDiff();
            SetBusyIcon(true);
            bool success = true;
            bool neitherSideStale =
                 (!leftSqlEditor.StaleQuery && !rightSqlEditor.StaleQuery);
            if (autoDiffButton.Checked
                && (BothSidesHaveData || NeitherSideHasData)
                && neitherSideStale)
            {
                List<string> ignoreList = GetIgnoreList();
                if (ignoreList.Count > 0)
                {
                    statusMsgMgr.Warning("Ignoring columns: " + ignoreList.ToTokenString());
                }
                matchColumns = IdentifyMatchColumns(ignoreList);
                if (matchColumns.Count == 0)
                { statusMsgMgr.Warning("No matching columns"); }
                else
                {
                    try
                    {
                        progressBarForm.ReportInitialMessage("Executing queries");
                        UpdateDiffStatus("Scanning left pane data");
                        GenerateDataList(leftSqlEditor);
                        UpdateDiffStatus("Scanning right pane data");
                        GenerateDataList(rightSqlEditor);
                        UpdateDiffStatus("Generating differences");
                        tracer.TraceInformation("Generating differences...");
                        if (diffEngineStyle.Equals(hertelDiffMenuItem))
                        { NormalizeHertelDiff(GenerateHertelDiffList()); }
                        else if (diffEngineStyle.Equals(potterDiffMenuItem))
                        { NormalizePotterDiff(GeneratePotterDiffList()); }
                        else
                        { NormalizeTaubererDiff(GenerateTaubererDiffList()); }
                        UpdateDiffStatus("Evaluating differences");
                        EvaluateDiffs();
                        progressBarForm.FinishLastMessage();
                        statusMsgMgr.Message(READY_MSG);
                    }
                    catch (CancelledException)
                    { statusMsgMgr.Message("Operation cancelled."); }
                    catch (OutOfMemoryException ex)
                    { statusMsgMgr.Error(ex.Message); }
                }
            }
            Cursor = Cursors.Default;
            SetBusyIcon(false);
            tracer.TraceLeave();
            return success;
        }

        private void SetBusyIcon(bool busy)
        {
            Icon = busy ? Properties.Resources.Logo_32x32_twisted : Properties.Resources.SqlDiffFramework;
            tracer.TraceInformation("setting busy icon to " + busy.ToString().ToUpper());
            Refresh();
        }

        private void UpdateDiffStatus(string msg)
        {
            statusMsgMgr.Message(msg + "...");
            progressBarForm.UpdateProgress(msg);
            memoryGauge.UpdateUsage();
        }

        private List<string> GetIgnoreList()
        {
            string IGNORE_TOKEN = @"--\s*:IGNORE:(.*?)$";
            RegexOptions reOptions = RegexOptions.IgnoreCase | RegexOptions.Multiline;
            Match m = Regex.Match(leftSqlEditor.QueryTextBox.Text, IGNORE_TOKEN, reOptions);
            string fragment = m.Groups.Count > 1 ? m.Groups[1].ToString().Trim() : "";
            if (fragment.Length == 0)
            {
                m = Regex.Match(rightSqlEditor.QueryTextBox.Text, IGNORE_TOKEN, reOptions);
                fragment = m.Groups.Count > 1 ? m.Groups[1].ToString().Trim() : "";
            }
            if (fragment.Length == 0) { return new List<string>(0); }
            List<string> l = new List<string>(Regex.Split(fragment, @"\s*,\s*"));

            // Convert to uppercase for canonical form used by IdentifyMatchColumns
            // (this allows matching ignore columns case-insensitively).
            // Also parse for brackets or quotes and trim any leftover whitespace.
            var result = l.Select(s =>
                {
                    Match mx = Regex.Match(s.Trim(),
                        @"^(?:('|"")(.*?)\1|\[(.*?)\])$", RegexOptions.Singleline);
                    string name = mx.Success ? (mx.Groups[2].ToString() + mx.Groups[3].ToString()) : s;
                    return name.Trim().ToUpper();
                }
            ).ToList<string>();

            // Technique for earlier C# 2.0:
            //List<string> result = l.ConvertAll<string>(delegate(string s) { return s.ToUpper(); });
            statusMsgMgr.Warning("Ignoring: " + result.ToTokenString());
            return result;
        }

        private List<string> IdentifyMatchColumns(List<string> ignoreList)
        {
            List<string> l = new List<string>();
            foreach (DataGridViewColumn col in leftSqlEditor.DataGridViewControl.Columns)
            {
                if (rightSqlEditor.DataGridViewControl.Columns.Contains(col.Name)
                    // ignoreList is finicky so use canonical uppercase
                    && !ignoreList.Contains(col.Name.ToUpper()))
                {
                    l.Add(col.Name.ToUpper());
                }
            }
            return l;
        }

        private void CheckCacheValidity(SqlEditor thisSqlEditor)
        {
            string newColumnNameMashup = string.Join("", IdentifyMatchColumns(GetIgnoreList()).ToArray());
            if (!newColumnNameMashup.Equals(string.Join("", matchColumns.ToArray())))
            {
                // invalidate partner cache on change of data shape
                tracer.TraceInformation(thisSqlEditor.Partner.Name
                    + ": invalidating cache due to data shape change");
                dataCache[thisSqlEditor.Partner] = null;
            }
        }

        private void GenerateDataList(SqlEditor sqlEditor)
        {
            tracer.TraceEnter();
            DataGridView dgv = sqlEditor.DataGridViewControl;
            string[] dataList = dataCache[sqlEditor];
            if (dataList == null)
            {
                tracer.TraceInformation("{0}: processing {1} rows",
                    sqlEditor.Name, dgv.Rows.Count);
                dataList = new string[dgv.Rows.Count];
                string[] tempList = new string[matchColumns.Count];
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < matchColumns.Count; j++)
                    {
                        string colName = matchColumns[j];
                        tempList[j] = NormalizedCellValue(dgv.Rows[i].Cells[colName]);
                    }
                    dataList[i] = string.Join(",", tempList);
                }
            }
            else
            { // just clear rows; do not need to build data list
                tracer.TraceInformation(sqlEditor.Name + ": using data cache");

                // This is one of probably many ways that forces cell repainting
                // in a DataGridView. Since the diff-coloring is not applied through
                // the cellFormatting event but is just transitory, this erases
                // all the coloring instantly.
                object holdDataSource = sqlEditor.DataGridViewControl.DataSource;
                sqlEditor.DataGridViewControl.DataSource = null;
                sqlEditor.DataGridViewControl.DataSource = holdDataSource;
                // This approach, on the other hand, takes a very long time...
                //for (int i = 0; i < dgv.Rows.Count; i++)
                //{
                //    ColorizeRow(dgv, i, STANDARD_COLOR);
                //    ResetRowFont(dgv, i);
                //}
            }
            tracer.TraceLeave();
            dataCache[sqlEditor] = dataList;
        }

        private string NormalizedCellValue(DataGridViewCell dgvCell)
        {
            // TODO: determine if FormattedValue is a performance hit over Value
            object cellValue = dgvCell.ValueType.Equals(typeof(System.DateTime)) ?
                            dgvCell.FormattedValue : dgvCell.Value;

            // The Oracle data set renders booleans as strings of "0" or "1",
            // whereas the SqlServer data set renders booleans as booleans,
            // with string values of "True" or "False".
            // The boolean conversion here compensates for these differences.

            return
                (cellValue == null) ? "" :
                (cellValue is bool) ? (((bool)cellValue) ? "1" : "0") :
                cellValue.ToString();
        }

        # region Tauberer Difference Engine

        private Diff GenerateTaubererDiffList()
        {
            tracer.TraceEnter();
            Diff diff = new Diff(
                dataCache[leftSqlEditor], dataCache[rightSqlEditor], true, true);
            tracer.TraceLeave();
            return diff;
        }

        private void NormalizeTaubererDiff(Diff diff)
        {
            statusMsgMgr.Warning("Using Tauberer diff");
            foreach (Diff.Hunk hunk in diff)
            {
                if (!hunk.Same) { hunkList.Add(new DiffChunk(hunk)); }
            }
        }

        # endregion Tauberer Difference Engine

        # region Hertel Difference Engine

        private HertelDiff.Item[] GenerateHertelDiffList()
        {
            tracer.TraceEnter();
            HertelDiff hDiffEngine = new HertelDiff();
            HertelDiff.Item[] diff =
                hDiffEngine.DiffText(dataCache[leftSqlEditor], dataCache[rightSqlEditor]);
            tracer.TraceLeave();
            return diff;
        }

        private void NormalizeHertelDiff(HertelDiff.Item[] diff)
        {
            statusMsgMgr.Warning("Using Hertel diff");
            foreach (HertelDiff.Item hertelHunk in diff)
            {
                hunkList.Add(new DiffChunk(
                    hertelHunk.StartA, hertelHunk.StartB,
                    hertelHunk.deletedA, hertelHunk.insertedB));
            }
        }

        # endregion Hertel Difference Engine

        # region Potter Difference Engine

        private ArrayList GeneratePotterDiffList()
        {
            tracer.TraceEnter();
            ArrayList diff = null;
            DiffEngineLevel diffLevel = DiffEngineLevel.FastImperfect; // TODO: parameterize
            try
            {
                PotterDiff pDiffEngine = new PotterDiff();
                double time = pDiffEngine.ProcessDiff(
                    new PotterDiffAdapter(dataCache[leftSqlEditor]),
                    new PotterDiffAdapter(dataCache[rightSqlEditor]), diffLevel);
                diff = pDiffEngine.DiffReport();
            }
            catch (Exception ex) { statusMsgMgr.Error(ex.Message); }
            tracer.TraceLeave();
            return diff;
        }

        private void NormalizePotterDiff(ArrayList diff)
        {
            statusMsgMgr.Warning("Using Potter diff");
            int leftIndex = 0, rightIndex = 0;
            foreach (DiffResultSpan drs in diff)
            {
                if (drs.Status != DiffResultSpanStatus.NoChange)
                {
                    //Console.WriteLine("status={0}, length={1}, left={2}, right={3}",
                    //    drs.Status, drs.Length, leftIndex, rightIndex);
                    DiffChunk hunk = new DiffChunk(drs.Status, drs.Length, leftIndex, rightIndex);
                    hunkList.Add(hunk);
                }
                switch (drs.Status)
                {
                    case DiffResultSpanStatus.AddDestination:
                        rightIndex += drs.Length;
                        break;
                    case DiffResultSpanStatus.DeleteSource:
                        leftIndex += drs.Length;
                        break;
                    case DiffResultSpanStatus.NoChange:
                        leftIndex += drs.Length;
                        rightIndex += drs.Length;
                        break;
                    case DiffResultSpanStatus.Replace:
                        leftIndex += drs.Length;
                        rightIndex += drs.Length;
                        break;
                }
            }
        }

        # endregion Potter Difference Engine

        private void EvaluateDiffs()
        {
            tracer.TraceEnter();
            int diffLineCount = 0;
            int changedCount = 0, addedCount = 0, missingCount = 0;
            int discrepancyCount = 0;
            int refinedLineCount = 0;
            tracer.TraceInformation("Counting and colorizing diffs...");
            hunkLookup[leftSqlEditor].Clear();
            hunkLookup[rightSqlEditor].Clear();
            int hunkCount = 0;
            foreach (DiffChunk hunk in hunkList)
            {
                // map starting rows to hunk pointer (for use by set-diff-to-cursor operation)
                hunkLookup[leftSqlEditor][hunk.Left.Start] = hunkCount;
                hunkLookup[rightSqlEditor][hunk.Right.Start] = hunkCount;
                hunkCount++;

                ColorizeHunk(hunk, DiffState.NonCurrent);

                refinedLineCount += CalculateRowsToRefine(hunk);
                if (refinedLineCount < Properties.Settings.Default.MaxHighlightedRowsTotal)
                {
                    discrepancyCount += ShowIndividualCellDifferences(hunk, false);
                }
                int leftCount = hunk.Left.End - hunk.Left.Start + 1;
                if (leftCount > 0) { diffLineCount += leftCount; }
                int rightCount = hunk.Right.End - hunk.Right.Start + 1;
                if (rightCount > 0) { diffLineCount += rightCount; }
                if (leftCount > 0 && rightCount > 0)
                {
                    changedCount += Math.Min(leftCount, rightCount);
                    if (leftCount > rightCount) { addedCount += leftCount - rightCount; }
                    else { missingCount += rightCount - leftCount; }
                }
                else if (leftCount > 0) { addedCount += leftCount; }
                else if (rightCount > 0) { missingCount += rightCount; }
            }
            diffCountLabel.Text = hunkList.Count.ToString();
            currentDiffLabel.Text = NO_DATA_TOKEN;
            addedLinesLabel.Text = addedCount.ToString();
            missingLinesLabel.Text = missingCount.ToString();
            changedLinesLabel.Text = changedCount.ToString() + ((discrepancyCount > 0) ? "*" : "");
            changedLinesLabel.ToolTipText = (discrepancyCount > 0) ?
                discrepancyCount.ToString() + " discrepancies" : "";
            SetMatchPercentage(diffLineCount);
            EnableDiffButtons();
            tracer.TraceLeave();
        }

        private void SetMatchPercentage(int diffLines)
        {
            int totalLines = (leftSqlEditor.DataGridViewControl.Rows.Count + rightSqlEditor.DataGridViewControl.Rows.Count);
            int percentage = totalLines == 0 ? 100 : (int)Math.Round(100.0 * (totalLines - diffLines) / totalLines);
            matchPercentageLabel.Text =
                (percentage == 100 && diffLines > 0) ?
                    "99+%" : string.Format("{0}%", percentage);
            matchPercentageLabel.ToolTipText =
                string.Format("{0} mismatches out of {1}", diffLines, totalLines);
        }

        private void MoveToSelectedDiff()
        {
            tracer.TraceEnter();
            int selectedRow = lastAccessed.DataGridViewControl.SelectedCells[0].RowIndex;
            try
            {
                int closestDiffStartRow = 
                    lastAccessed.Equals(leftSqlEditor) ?
                        hunkList
                            .Where(hunk => hunk.Left.Start <= selectedRow)
                            .Max(hunk => hunk.Left.Start)
                        : hunkList
                            .Where(hunk => hunk.Right.Start <= selectedRow)
                            .Max(hunk => hunk.Right.Start);

                // Find target hunk: technique #1
                //Hunk maxHunk = hunkList
                //    .Where(hunk => hunk.Left.Start == closestDiffStartRow)
                //    .Single();

                // Find target hunk: technique #2
                //Hunk maxHunk = (from h in hunkList
                //          orderby h.Left.Start descending
                //          where h.Left.Start <= selectedRow
                //          select h).First<Hunk>();

                int newHunkPointer = hunkLookup[lastAccessed][closestDiffStartRow];
                tracer.TraceInformation(
                    "{0} pane: selected row={1}, closest row={2}, hunk#={3}",
                    lastAccessed.Name, selectedRow, closestDiffStartRow, newHunkPointer);

                RecolorAndScroll(newHunkPointer, true);
            }
            catch (InvalidOperationException)
            { /* no hunk before selection */ }
            tracer.TraceLeave();
        }

        private void DisplayHunk(int increment)
        {
            // The loop allows advancing more than one diff chunk at a time. Two cases:
            // (1) False positives in Tauberer difference engine--automatically skipped.
            // (2) Specific diff category selected (added/missing/changed) by user.
            // In either case, Shift may be used to override and go just to next one.
            bool noDiffsFound;
            msgDropDown.Text = "";
            SetDisplayCategoryFilter();
            do
            {
                RecolorAndScroll(increment, false);
                noDiffsFound = (ShowIndividualCellDifferences(hunkList[hunkPointer], true) > 0);
                // direct access to status message as a progress indicator
                if (msgDropDown.Text.Length < 50) { msgDropDown.Text += "."; Refresh(); }
            } while (increment != 0 && // only once for current diff
                    ((Control.ModifierKeys & Keys.Shift) != Keys.Shift) && // only once with Shift
                    (noDiffsFound || !CategoryMatches()) &&
                    NotAtBoundary(increment)
                );
            statusMsgMgr.Message(READY_MSG);
        }

        private void RecolorAndScroll(int increment, bool absolute)
        {
            HilightCurrentDiff(increment, absolute);
            EnableDiffButtons();
            ScrollDiffContext(leftSqlEditor, hunkList[hunkPointer].Left);
            ScrollDiffContext(rightSqlEditor, hunkList[hunkPointer].Right);

        }

        private void SetDisplayCategoryFilter()
        {
            displayCategory = 0;
            if (addedLinesButton.Checked) { displayCategory |= DisplayChoice.Added; }
            if (missingLinesButton.Checked) { displayCategory |= DisplayChoice.Missing; }
            if (changedLinesButton.Checked) { displayCategory |= DisplayChoice.Changed; }
        }

        private bool CategoryMatches()
        {
            if (displayCategory == 0) return true;
            DiffChunk hunk = hunkList[hunkPointer];
            int leftCount = hunk.Left.End - hunk.Left.Start + 1;
            int rightCount = hunk.Right.End - hunk.Right.Start + 1;
            if (((displayCategory & DisplayChoice.Added) > 0) && (leftCount > rightCount)) return true;
            if (((displayCategory & DisplayChoice.Missing) > 0) && (rightCount > leftCount)) return true;
            if (((displayCategory & DisplayChoice.Changed) > 0) && (rightCount > 0 && leftCount > 0)) return true;
            return false;
        }

        private bool NotAtBoundary(int increment)
        {
            return (increment > 0 && hunkPointer < hunkList.Count - 1) ||
                     (increment < 0 && hunkPointer > 0);
        }

        private void HilightCurrentDiff(int increment, bool absolute)
        {
            if (hunkPointer >= 0)  // uncolor current hunk, if any...
            {
                ColorizeHunk(hunkList[hunkPointer], DiffState.NonCurrent);
            }
            if (absolute) { hunkPointer = increment; }
            else
            {
                hunkPointer += (increment > 0 ? 1 : increment < 0 ? -1 : 0); // advance...
            }
            currentDiffLabel.Text = (hunkPointer + 1).ToString();
            currentDiffLabel.ToolTipText = string.Format(
                "LEFT: {0} @ {1} / RIGHT {2} @ {3}",
                ApplyCardinality(hunkList[hunkPointer].Left.Count, "line", "s"), hunkList[hunkPointer].Left.Start+1,
                ApplyCardinality(hunkList[hunkPointer].Right.Count, "line", "s"), hunkList[hunkPointer].Right.Start+1);
            ColorizeHunk(hunkList[hunkPointer], DiffState.Current); // ...color next hunk
        }

        private string ApplyCardinality(int value, string s, string suffix)
        {
            return string.Format("{0} {1}", value, (value == 1 ? s : s + suffix));
        }

        private void ColorizeHunk(DiffChunk hunk, DiffState diffState)
        {
            // Initially all hunks are colored with DIFF_COLOR at the start.
            // As user moves through, each diff is highlighted as the current one,
            // resetting the one we are moving off.
            ColorizeHalfHunk(leftSqlEditor.DataGridViewControl, hunk.Left, diffState);
            ColorizeHalfHunk(rightSqlEditor.DataGridViewControl, hunk.Right, diffState);
        }

        enum DiffState { Current, NonCurrent };

        private void ColorizeHalfHunk(DataGridView dgv, DiffChunk.Range range, DiffState diffState)
        {
            // If *no* rows to color, mark two surrounding rows to give visual cue.
            // If moving off of this hunk change to STANDARD_COLOR.
            // If moving onto this hunk, change to highlighted OMITTED_COLOR.
            // Note that usually this highlights two rows, but if there is an
            // added/missing row as the first or last, it will just be one row.
            if (range.Start > range.End)
            {
                Color diffColor = diffState.Equals(DiffState.Current) ?
                    CURRENT_OMITTED_COLOR : OMITTED_COLOR;

                int rowAfter = range.Start;
                if (rowAfter < dgv.Rows.Count)
                { ColorizeRow(dgv, rowAfter, diffColor); }

                int rowBefore = rowAfter - 1;
                if (rowBefore < dgv.Rows.Count && rowBefore >= 0)
                { ColorizeRow(dgv, rowBefore, diffColor); }
            }
            else
            {
                Color diffColor = diffState.Equals(DiffState.Current) ?
                    CURRENT_DIFF_COLOR : DIFF_COLOR;
                for (int i = range.Start; i <= range.End; i++)
                {
                    ColorizeRow(dgv, i, diffColor);
                }
            }
        }

        private void ColorizeRow(DataGridView dgv, int i, Color color)
        {
            // Normally this will colorize rows with the background color (STANDARD_COLOR),
            // OMITTED_COLOR, DIFF_COLOR, or CURRENT_DIFF_COLOR.
            // However, when a row is initially colorized the individual cell
            // differences are highlighted with the FINER_xxx color (a richer shade
            // to point out the cell differences).
            // If a particular cell is so differentiated, we keep it that way
            // when moving on to or off of it.
            foreach (DataGridViewCell cell in dgv.Rows[i].Cells)
            {
                cell.Style.BackColor =
                    ((cell.Style.BackColor == CURRENT_FINER_DIFF_COLOR
                    || cell.Style.BackColor == FINER_DIFF_COLOR)
                    && colorMap.ContainsKey(color)) ? colorMap[color] : color;
            }
        }

        private void ResetRowFont(DataGridView dgv, int i)
        {
            foreach (DataGridViewCell cell in dgv.Rows[i].Cells)
            {
                cell.Style.Font = dgv.DefaultCellStyle.Font;
            }
        }

        private void ScrollDiffContext(SqlEditor sqlEditor, DiffChunk.Range range)
        {
            DataGridView dgv = sqlEditor.DataGridViewControl;
            int lastDisplayedRow = dgv.FirstDisplayedScrollingRowIndex + dgv.DisplayedRowCount(true);
            int rowTolerance = (int)Math.Truncate(dgv.DisplayedRowCount(true) * CONTEXT_POSITION);

            // Scroll only if next target is off screen or too close to screen bottom...
            if (range.Start >= (lastDisplayedRow - rowTolerance)
                //&& range.Start < dgv.RowCount)
                // ... or if next target is off screen or too close to screen top.
                || range.Start <= (dgv.FirstDisplayedScrollingRowIndex + rowTolerance))
            {
                int rowIndex = Math.Max(0, (range.Start - rowTolerance));
                sqlEditor.ScrollWithoutPartner(rowIndex);
                //tracer.TraceInformation("{0}: displaying rows {1} - {2}",
                //    sqlEditor.Name, dgv.FirstDisplayedScrollingRowIndex,
                //    dgv.FirstDisplayedScrollingRowIndex + dgv.DisplayedRowCount(true));
            }
        }

        private int ShowIndividualCellDifferences(DiffChunk hunk, bool currentDiff)
        {
            int discrepancies = 0;
            int limit = CalculateRowsToRefine(hunk);

            // must have non-empty halves
            if (hunk.Left.Start <= hunk.Left.End
                && hunk.Right.Start <= hunk.Right.End)
            {
                for (int i = 0; i < limit; i++)
                {
                    DataGridViewRow leftRow = leftSqlEditor.DataGridViewControl.Rows[hunk.Left.Start + i];
                    DataGridViewRow rightRow = rightSqlEditor.DataGridViewControl.Rows[hunk.Right.Start + i];
                    bool foundMismatch = false;
                    foreach (string colName in matchColumns)
                    {
                        object leftValue = NormalizedCellValue(leftRow.Cells[colName]);
                        object rightValue = NormalizedCellValue(rightRow.Cells[colName]);

                        if (!leftValue.Equals(rightValue))
                        {
                            foundMismatch = true;
                            ColorCell(leftRow.Cells[colName], currentDiff);
                            ColorCell(rightRow.Cells[colName], currentDiff);
                        }
                    }
                    // known issue with Tauberer diff engine appears intermittently
                    if (!foundMismatch) { discrepancies++; }
                }
            }
            // For the currentDiff, just want to know whether a discrepancy was found.
            // Otherwise, return the count of discrepancies.
            return currentDiff ? (discrepancies == limit && hunk.Left.Count == hunk.Right.Count ? 1 : -1) : discrepancies;
        }

        private static int CalculateRowsToRefine(DiffChunk hunk)
        {
            int limit = Math.Min(hunk.Left.Count, hunk.Right.Count);
            if (Properties.Settings.Default.MaxHighlightedRowsPerChunk > 0)
            {
                limit = Math.Min(limit, (int)Properties.Settings.Default.MaxHighlightedRowsPerChunk);
            }
            return limit;
        }

        private string DumpRow(DataGridViewRow row)
        {
            List<string> l = new List<string>();
            foreach (DataGridViewCell cell in row.Cells)
            { l.Add(cell.Value.ToString()); }
            return string.Join(",", l.ToArray());
        }

        private void ColorCell(DataGridViewCell dataGridViewCell, bool currentDiff)
        {
            // Use background color to also cover empty or blank cells.
            dataGridViewCell.Style.BackColor =
                currentDiff ? CURRENT_FINER_DIFF_COLOR : FINER_DIFF_COLOR;
            // Also use bold for color-blind and for secondary difference
            dataGridViewCell.Style.Font = boldFont;

        }

        private void EnableDiffButtons()
        {
            firstDiffButton.Enabled = (hunkPointer != 0 && hunkList.Count > 0);
            firstDifferenceMenuItem.Enabled = firstDiffButton.Enabled;

            lastDiffButton.Enabled = (hunkPointer < hunkList.Count - 1);
            lastDifferenceMenuItem.Enabled = lastDiffButton.Enabled;

            previousDiffButton.Enabled = (hunkPointer > 0);
            previousDifferenceMenuItem.Enabled = previousDiffButton.Enabled;

            nextDiffButton.Enabled = (hunkPointer < hunkList.Count - 1);
            nextDifferenceMenuItem.Enabled = nextDiffButton.Enabled;

            currentDiffButton.Enabled = (hunkPointer >= 0);
            currentDifferenceMenuItem.Enabled = currentDiffButton.Enabled;

            setCurrentDiffButton.Enabled = BothSidesHaveData && (hunkList.Count > 0);
            setCurrentDifferenceMenuItem.Enabled = setCurrentDiffButton.Enabled;
        }

        #endregion difference engine


        /********************************************************************/

    }

}
