using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CleanCode.Forms;
using System.Text.RegularExpressions;

namespace SqlDiffFramework.Forms
{
    public partial class BatchSetupForm : Form
    {
        
        # region properties

        public string LeftSystemLabel
        { get { return leftSystemLabel.Text; } set { leftSystemLabel.Text = value; } }

        public string RightSystemLabel
        { get { return rightSystemLabel.Text; } set { rightSystemLabel.Text = value; } }

        public string LeftSourceLabel
        {
            get { return leftSourceLabel.Text; }
            set
            {
                leftSourceLabel.Text = value;
                fileMask.SourceDirectory = value;
            }
        }

        public string RightSourceLabel
        { get { return rightSourceLabel.Text; } set { rightSourceLabel.Text = value; } }

        public string LeftSnapshotLabel
        { get { return leftSnapshotLabel.Text; } set { leftSnapshotLabel.Text = value; } }

        public string RightSnapshotLabel
        { get { return rightSnapshotLabel.Text; } set { rightSnapshotLabel.Text = value; } }

        public IEnumerable<string> FileList
        {
            get
            { 
                if (!includeOrphansCheckBox.Checked) return fileMask.FileList;

                // Special mode to include orphans from either side.
                // Skip the RestrictionLambda and collect files from both sides.
                IEnumerable<string> partialList =
                    from f in Directory.GetFiles(LeftSourceLabel).Concat(Directory.GetFiles(RightSourceLabel))
                    where fileMask.FitsOneOfMultipleMasks(Path.GetFileName(f))
                    orderby Path.GetFileName(f)
                    select f;
                // Now eliminate duplicates and normalize with path from left (whether or not it exists!).
                return partialList
                    .GroupBy(f => Path.GetFileName(f))
                    .Select(g => Path.Combine(LeftSourceLabel, Path.GetFileName(g.First())));
            }
        }

        public DataTable DataTable { get; private set; }

        public bool Cancelled { get; private set; }

        public bool SaveSnapshots
        {
            get { return saveSnapshotsCheckBox.Checked; }
            set { saveSnapshotsCheckBox.Checked = value; }
        }

        # endregion properties

        private RichTextBoxHelper textBoxHelper;
        private BatchResultsForm resultsForm = new BatchResultsForm();

        public BatchSetupForm()
        {
            InitializeComponent();
            textBoxHelper = new RichTextBoxHelper(outputTextBox);

            fileMask.Mask = "*.*";

            // Add additional restriction on selecting files requiring
            // file to *also* exist in companion directory
            // *and* to exclude names containing "deprecated".
            fileMask.RestrictionLambda =
                (f => File.Exists(Path.Combine(RightSourceLabel, Path.GetFileName(f)))
                    && !Path.GetFileName(f).ToLower().Contains("deprecated"));
        }

        # region status indicating states

        public void FinishedFile()
        {
            outputTextBox.AppendText("Done.\n");
            outputTextBox.ScrollToCaret();
            Refresh();
            resultsForm.Refresh();
        }

        public void StartedFile(string fileName)
        {
            outputTextBox.AppendText(Path.GetFileName(fileName) + "...");
            outputTextBox.ScrollToCaret();
            Refresh();
        }

        public void InterruptedSequence()
        {
            textBoxHelper.AppendStylizedText("Sequence interrupted by user", Color.Red);
            Cancelled = false; // reset it!
        }

        # endregion status indicating states

        # region event handlers

        protected override void OnActivated(EventArgs e)
        {
            fileMask.UpdateFileMatches();
            SetErrorProviders();
            base.OnActivated(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            Cancelled = false;
            if (Visible)
            {
                WindowRestorer.SetSubWindowRelativeLocation(this);
                fileMask.UpdateFileMatches();
                SetErrorProviders();
                resultsForm.Owner = Owner;
            }
            base.OnVisibleChanged(e);
            Refresh();
        }

        private void saveSnapshotsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetErrorProviders();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide();
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) { resultsForm.Hide(); }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            { Hide(); e.Cancel = true; }
            else { Close(); }
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) { resultsForm.Hide(); }
            base.OnFormClosing(e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Cancelled = true;
        }

        private void showResultsButton_Click(object sender, EventArgs e)
        {
            resultsForm.Show();
            if (resultsForm.WindowState == FormWindowState.Minimized)
            { resultsForm.WindowState = FormWindowState.Normal; }
        }

        private void nonZeroCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            resultsForm.FlagNonZero = nonZeroCheckBox.Checked;
        }

        private void SetErrorProviders()
        {
            errorProvider.SetError(systemRowLabel,
                (Regex.IsMatch(leftSystemLabel.Text, "^(--|)$") || Regex.IsMatch(rightSystemLabel.Text, "^(--|)$")) ?
                "Select connections on main form to set target systems" : "");
            errorProvider.SetError(sourceRowLabel,
                (Regex.IsMatch(leftSourceLabel.Text, @"^(\.|)$") || Regex.IsMatch(rightSourceLabel.Text, @"^(.|)$")) ?
                "Open initial queries on main form to set SQL source directories" : "");
            errorProvider.SetError(snapshotRowLabel,
                (SaveSnapshots && 
                (leftSnapshotLabel.Text == "" || rightSnapshotLabel.Text == "")) ?
                "Save grids manually on main form to set CSV snapshot directories" : "");
        }

        # endregion event handlers

        # region execution

        public event EventHandler Execute;

        private void executeButton_Click(object sender, EventArgs e)
        {
            if (errorProvider.GetError(systemRowLabel).Length > 0
                || errorProvider.GetError(sourceRowLabel).Length > 0
                || errorProvider.GetError(snapshotRowLabel).Length > 0)
            {
                MessageBox.Show("Cannot proceed until displayed errors are corrected",
                    "Batch Settings Uninitialized",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Execute == null)
            {
                MessageBox.Show("No consumers found to execute the sequence!",
                    "Batch Programming Issue",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                executeButton.Enabled = false;
                cancelButton.Enabled = true;

                textBoxHelper.AppendStylizedText(
                    string.Format("\nStarting Run of {0} files at {1}\n",
                       FileList.Count(), DateTime.Now), Color.Magenta);
                SetupDataGridView();
                resultsForm.Show();
                Refresh();

                Execute(this, new EventArgs());

                executeButton.Enabled = true;
                cancelButton.Enabled = false;
            }
        }

        private void SetupDataGridView()
        {
            DataTable = new DataTable();
            BindingSource bs = new BindingSource();
            bs.DataMember = null;
            bs.DataSource = DataTable;
            resultsForm.DataGridView.DataSource = bs;

            resultsForm.DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataTable.Columns.Add(GenColumn("Name", typeof(string)));
            DataTable.Columns.Add(GenColumn("Executed", typeof(DateTime)));
            DataTable.Columns.Add(GenColumn("Duration", typeof(string)));
            DataTable.Columns.Add(GenColumn("LeftCount", typeof(int)));
            DataTable.Columns.Add(GenColumn("RightCount", typeof(int)));
            DataTable.Columns.Add(GenColumn("DiffCount", typeof(int)));
            DataTable.Columns.Add(GenColumn("Added", typeof(int)));
            DataTable.Columns.Add(GenColumn("Missing", typeof(int)));
            DataTable.Columns.Add(GenColumn("Changed", typeof(int)));
            DataTable.Columns.Add(GenColumn("Quality", typeof(string)));
            DataTable.Columns.Add(GenColumn("Memory", typeof(string)));
        }

        private DataColumn GenColumn(string name, Type type)
        {
            DataColumn dc = new DataColumn();
            dc.DataType = type;
            dc.ColumnName = name;
            return dc;
        }

        # endregion execution

    }
}
