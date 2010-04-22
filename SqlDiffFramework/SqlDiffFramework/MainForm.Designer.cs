namespace SqlDiffFramework
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripStatusLabel spacer1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.msgDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.spacer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.memoryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.spacer3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.legendLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LegendCurrentDiffLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LegendNonCurrentDiffLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LegendCurrentOmittedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LegendNonCurrentOmittedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftSqlEditor = new CleanCode.SqlEditorControls.SqlEditor();
            this.rightSqlEditor = new CleanCode.SqlEditorControls.SqlEditor();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLeftQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRightQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            this.tabLeavesControlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabInsertsSpacesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextDifferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousDifferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.firstDifferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentDifferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastDifferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCurrentDifferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.showProgressMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.showLeftPaneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRightPaneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBothPanesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeBatchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.metaQueriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editConnectionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMainKeyReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGeneralKeyReferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInputKeyReferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOutputKeyReferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandToolStrip = new System.Windows.Forms.ToolStrip();
            this.nextDiffButton = new System.Windows.Forms.ToolStripButton();
            this.previousDiffButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.firstDiffButton = new System.Windows.Forms.ToolStripButton();
            this.currentDiffButton = new System.Windows.Forms.ToolStripButton();
            this.lastDiffButton = new System.Windows.Forms.ToolStripButton();
            this.setCurrentDiffButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.turboSortButton = new System.Windows.Forms.ToolStripButton();
            this.tandemButton = new System.Windows.Forms.ToolStripButton();
            this.autoDiffButton = new System.Windows.Forms.ToolStripButton();
            this.autoDiffSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.taubererDiffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hertelDiffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.potterDiffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.showProgressButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.filterValueTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.filterFieldTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.reportToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel17 = new System.Windows.Forms.ToolStripLabel();
            this.currentDiffLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel13 = new System.Windows.Forms.ToolStripLabel();
            this.diffCountLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel19 = new System.Windows.Forms.ToolStripLabel();
            this.matchPercentageLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            this.addedLinesButton = new System.Windows.Forms.ToolStripButton();
            this.addedLinesLabel = new System.Windows.Forms.ToolStripLabel();
            this.missingLinesButton = new System.Windows.Forms.ToolStripButton();
            this.missingLinesLabel = new System.Windows.Forms.ToolStripLabel();
            this.changedLinesButton = new System.Windows.Forms.ToolStripButton();
            this.changedLinesLabel = new System.Windows.Forms.ToolStripLabel();
            this.memoryUsageTimer = new System.Windows.Forms.Timer(this.components);
            spacer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.commandToolStrip.SuspendLayout();
            this.reportToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // spacer1
            // 
            spacer1.AutoSize = false;
            spacer1.Name = "spacer1";
            spacer1.Size = new System.Drawing.Size(734, 17);
            spacer1.Spring = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msgDropDown,
            spacer1,
            this.spacer2,
            this.memoryStatusLabel,
            this.spacer3,
            this.legendLabel,
            this.LegendCurrentDiffLabel,
            this.LegendNonCurrentDiffLabel,
            this.LegendCurrentOmittedLabel,
            this.LegendNonCurrentOmittedLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(1028, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // msgDropDown
            // 
            this.msgDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.msgDropDown.Image = ((System.Drawing.Image)(resources.GetObject("msgDropDown.Image")));
            this.msgDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.msgDropDown.Name = "msgDropDown";
            this.msgDropDown.Size = new System.Drawing.Size(28, 20);
            this.msgDropDown.Text = "--";
            this.msgDropDown.ToolTipText = "Status message history";
            // 
            // spacer2
            // 
            this.spacer2.AutoSize = false;
            this.spacer2.Name = "spacer2";
            this.spacer2.Size = new System.Drawing.Size(25, 17);
            // 
            // memoryStatusLabel
            // 
            this.memoryStatusLabel.AutoSize = false;
            this.memoryStatusLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.memoryStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.memoryStatusLabel.Name = "memoryStatusLabel";
            this.memoryStatusLabel.Size = new System.Drawing.Size(45, 17);
            this.memoryStatusLabel.Text = "--";
            this.memoryStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.memoryStatusLabel.Click += new System.EventHandler(this.memoryStatusLabel_Click);
            // 
            // spacer3
            // 
            this.spacer3.AutoSize = false;
            this.spacer3.Name = "spacer3";
            this.spacer3.Size = new System.Drawing.Size(25, 17);
            // 
            // legendLabel
            // 
            this.legendLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.legendLabel.Name = "legendLabel";
            this.legendLabel.Size = new System.Drawing.Size(48, 17);
            this.legendLabel.Text = "Legend";
            this.legendLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LegendCurrentDiffLabel
            // 
            this.LegendCurrentDiffLabel.AutoSize = false;
            this.LegendCurrentDiffLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LegendCurrentDiffLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.LegendCurrentDiffLabel.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.LegendCurrentDiffLabel.Name = "LegendCurrentDiffLabel";
            this.LegendCurrentDiffLabel.Size = new System.Drawing.Size(25, 18);
            this.LegendCurrentDiffLabel.ToolTipText = "Current Diff--extra or different element";
            // 
            // LegendNonCurrentDiffLabel
            // 
            this.LegendNonCurrentDiffLabel.AutoSize = false;
            this.LegendNonCurrentDiffLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LegendNonCurrentDiffLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.LegendNonCurrentDiffLabel.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.LegendNonCurrentDiffLabel.Name = "LegendNonCurrentDiffLabel";
            this.LegendNonCurrentDiffLabel.Size = new System.Drawing.Size(25, 18);
            this.LegendNonCurrentDiffLabel.ToolTipText = "All differences except the current diff";
            // 
            // LegendCurrentOmittedLabel
            // 
            this.LegendCurrentOmittedLabel.AutoSize = false;
            this.LegendCurrentOmittedLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LegendCurrentOmittedLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.LegendCurrentOmittedLabel.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.LegendCurrentOmittedLabel.Name = "LegendCurrentOmittedLabel";
            this.LegendCurrentOmittedLabel.Size = new System.Drawing.Size(25, 18);
            this.LegendCurrentOmittedLabel.ToolTipText = "Current Diff--omitted element";
            // 
            // LegendNonCurrentOmittedLabel
            // 
            this.LegendNonCurrentOmittedLabel.AutoSize = false;
            this.LegendNonCurrentOmittedLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LegendNonCurrentOmittedLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.LegendNonCurrentOmittedLabel.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.LegendNonCurrentOmittedLabel.Name = "LegendNonCurrentOmittedLabel";
            this.LegendNonCurrentOmittedLabel.Size = new System.Drawing.Size(25, 18);
            this.LegendNonCurrentOmittedLabel.ToolTipText = "All omitted elements except the current diff";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.leftSqlEditor);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.rightSqlEditor);
            this.mainSplitContainer.Size = new System.Drawing.Size(1028, 570);
            this.mainSplitContainer.SplitterDistance = 512;
            this.mainSplitContainer.TabIndex = 9;
            this.mainSplitContainer.TabStop = false;
            // 
            // leftSqlEditor
            // 
            this.leftSqlEditor.AutoExecuteMode = false;
            this.leftSqlEditor.AutoHighlightMode = true;
            this.leftSqlEditor.CommandTimeout = 60;
            this.leftSqlEditor.ContainerTest = false;
            this.leftSqlEditor.CsvPath = ".";
            this.leftSqlEditor.DateCellStyleFormat = null;
            this.leftSqlEditor.DbConnectionName = "--";
            this.leftSqlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSqlEditor.LocalMode = false;
            this.leftSqlEditor.Location = new System.Drawing.Point(0, 0);
            this.leftSqlEditor.MaxColumnWidth = 200;
            this.leftSqlEditor.Name = "leftSqlEditor";
            this.leftSqlEditor.Partner = null;
            this.leftSqlEditor.ShowBooleansAsCheckBoxes = false;
            this.leftSqlEditor.Size = new System.Drawing.Size(512, 570);
            this.leftSqlEditor.SqlPath = ".";
            this.leftSqlEditor.StaleQueryColor = System.Drawing.Color.LightSteelBlue;
            this.leftSqlEditor.TabIndex = 0;
            this.leftSqlEditor.TabLeavesControl = false;
            this.leftSqlEditor.TandemMode = false;
            this.leftSqlEditor.TurboSortMode = false;
            this.leftSqlEditor.UniqueNameHint = null;
            this.leftSqlEditor.UserCommandsTitle = "SqlEditor Quick Reference";
            // 
            // rightSqlEditor
            // 
            this.rightSqlEditor.AutoExecuteMode = false;
            this.rightSqlEditor.AutoHighlightMode = true;
            this.rightSqlEditor.CommandTimeout = 60;
            this.rightSqlEditor.ContainerTest = false;
            this.rightSqlEditor.CsvPath = ".";
            this.rightSqlEditor.DateCellStyleFormat = null;
            this.rightSqlEditor.DbConnectionName = "--";
            this.rightSqlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSqlEditor.LocalMode = false;
            this.rightSqlEditor.Location = new System.Drawing.Point(0, 0);
            this.rightSqlEditor.MaxColumnWidth = 200;
            this.rightSqlEditor.Name = "rightSqlEditor";
            this.rightSqlEditor.Partner = null;
            this.rightSqlEditor.ShowBooleansAsCheckBoxes = false;
            this.rightSqlEditor.Size = new System.Drawing.Size(512, 570);
            this.rightSqlEditor.SqlPath = ".";
            this.rightSqlEditor.StaleQueryColor = System.Drawing.Color.LightSteelBlue;
            this.rightSqlEditor.TabIndex = 0;
            this.rightSqlEditor.TabLeavesControl = false;
            this.rightSqlEditor.TandemMode = false;
            this.rightSqlEditor.TurboSortMode = false;
            this.rightSqlEditor.UniqueNameHint = null;
            this.rightSqlEditor.UserCommandsTitle = "SqlEditor Quick Reference";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mainSplitContainer);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1028, 570);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1028, 641);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.commandToolStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.reportToolStrip);
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.queryToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWorkspaceToolStripMenuItem,
            this.toolStripSeparator1,
            this.newQueryMenuItem,
            this.openQueryToolStripMenuItem,
            this.toolStripSeparator16,
            this.saveLeftQueryMenuItem,
            this.saveRightQueryMenuItem,
            this.toolStripSeparator18,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newWorkspaceToolStripMenuItem
            // 
            this.newWorkspaceToolStripMenuItem.Name = "newWorkspaceToolStripMenuItem";
            this.newWorkspaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newWorkspaceToolStripMenuItem.Text = "&New Workspace";
            this.newWorkspaceToolStripMenuItem.ToolTipText = "Open another instance of SqlDiffFramework";
            this.newWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.newWorkspaceMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // newQueryMenuItem
            // 
            this.newQueryMenuItem.Name = "newQueryMenuItem";
            this.newQueryMenuItem.ShortcutKeyDisplayString = "";
            this.newQueryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.newQueryMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newQueryMenuItem.Text = "Ne&w Query";
            this.newQueryMenuItem.Click += new System.EventHandler(this.newQueryMenuItem_Click);
            // 
            // openQueryToolStripMenuItem
            // 
            this.openQueryToolStripMenuItem.Name = "openQueryToolStripMenuItem";
            this.openQueryToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.openQueryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.openQueryToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.openQueryToolStripMenuItem.Text = "&Open Query";
            this.openQueryToolStripMenuItem.Click += new System.EventHandler(this.openQueryToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(217, 6);
            // 
            // saveLeftQueryMenuItem
            // 
            this.saveLeftQueryMenuItem.Name = "saveLeftQueryMenuItem";
            this.saveLeftQueryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F8)));
            this.saveLeftQueryMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveLeftQueryMenuItem.Text = "Save &Left Query";
            this.saveLeftQueryMenuItem.Click += new System.EventHandler(this.saveLeftQueryMenuItem_Click);
            // 
            // saveRightQueryMenuItem
            // 
            this.saveRightQueryMenuItem.Name = "saveRightQueryMenuItem";
            this.saveRightQueryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F9)));
            this.saveRightQueryMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveRightQueryMenuItem.Text = "Save &Right Query";
            this.saveRightQueryMenuItem.Click += new System.EventHandler(this.saveRightQueryMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(217, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator34,
            this.tabLeavesControlMenuItem,
            this.tabInsertsSpacesMenuItem,
            this.toolStripSeparator2,
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.toolStripSeparator3,
            this.restoreSettingsMenuItem,
            this.optionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            this.cutToolStripMenuItem.Visible = false;
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Visible = false;
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator34
            // 
            this.toolStripSeparator34.Name = "toolStripSeparator34";
            this.toolStripSeparator34.Size = new System.Drawing.Size(174, 6);
            this.toolStripSeparator34.Visible = false;
            // 
            // tabLeavesControlMenuItem
            // 
            this.tabLeavesControlMenuItem.CheckOnClick = true;
            this.tabLeavesControlMenuItem.Name = "tabLeavesControlMenuItem";
            this.tabLeavesControlMenuItem.Size = new System.Drawing.Size(177, 22);
            this.tabLeavesControlMenuItem.Text = "&Tab Leaves Pane";
            this.tabLeavesControlMenuItem.ToolTipText = "Toggle behavior of tab/ctrl-tab moving within input/output panes";
            this.tabLeavesControlMenuItem.Visible = false;
            this.tabLeavesControlMenuItem.Click += new System.EventHandler(this.tabLeavesControlMenuItem_Click);
            // 
            // tabInsertsSpacesMenuItem
            // 
            this.tabInsertsSpacesMenuItem.CheckOnClick = true;
            this.tabInsertsSpacesMenuItem.Name = "tabInsertsSpacesMenuItem";
            this.tabInsertsSpacesMenuItem.Size = new System.Drawing.Size(177, 22);
            this.tabInsertsSpacesMenuItem.Text = "Tab &Inserts Spaces";
            this.tabInsertsSpacesMenuItem.ToolTipText = "If disabled, Tab inserts an actual Tab";
            this.tabInsertsSpacesMenuItem.Visible = false;
            this.tabInsertsSpacesMenuItem.Click += new System.EventHandler(this.tabInsertsSpacesMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.findToolStripMenuItem.Text = "&Find...";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.replaceToolStripMenuItem.Text = "&Replace...";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(174, 6);
            // 
            // restoreSettingsMenuItem
            // 
            this.restoreSettingsMenuItem.Name = "restoreSettingsMenuItem";
            this.restoreSettingsMenuItem.Size = new System.Drawing.Size(177, 22);
            this.restoreSettingsMenuItem.Text = "Restore &Settings...";
            this.restoreSettingsMenuItem.ToolTipText = "Restore settings to last saved or to factory defaults";
            this.restoreSettingsMenuItem.Click += new System.EventHandler(this.restoreSettingsMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextDifferenceMenuItem,
            this.previousDifferenceMenuItem,
            this.toolStripSeparator14,
            this.firstDifferenceMenuItem,
            this.currentDifferenceMenuItem,
            this.lastDifferenceMenuItem,
            this.setCurrentDifferenceMenuItem,
            this.toolStripSeparator25,
            this.showProgressMenuItem,
            this.toolStripSeparator19,
            this.showLeftPaneMenuItem,
            this.showRightPaneMenuItem,
            this.showBothPanesMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // nextDifferenceMenuItem
            // 
            this.nextDifferenceMenuItem.Enabled = false;
            this.nextDifferenceMenuItem.Name = "nextDifferenceMenuItem";
            this.nextDifferenceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.nextDifferenceMenuItem.Size = new System.Drawing.Size(229, 22);
            this.nextDifferenceMenuItem.Text = "&Next Difference";
            this.nextDifferenceMenuItem.Click += new System.EventHandler(this.nextDifferenceMenuItem_Click);
            // 
            // previousDifferenceMenuItem
            // 
            this.previousDifferenceMenuItem.Enabled = false;
            this.previousDifferenceMenuItem.Name = "previousDifferenceMenuItem";
            this.previousDifferenceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.previousDifferenceMenuItem.Size = new System.Drawing.Size(229, 22);
            this.previousDifferenceMenuItem.Text = "&Previous Difference";
            this.previousDifferenceMenuItem.Click += new System.EventHandler(this.previousDifferenceMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(226, 6);
            // 
            // firstDifferenceMenuItem
            // 
            this.firstDifferenceMenuItem.Enabled = false;
            this.firstDifferenceMenuItem.Name = "firstDifferenceMenuItem";
            this.firstDifferenceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Home)));
            this.firstDifferenceMenuItem.Size = new System.Drawing.Size(229, 22);
            this.firstDifferenceMenuItem.Text = "&First Difference";
            this.firstDifferenceMenuItem.Click += new System.EventHandler(this.firstDifferenceMenuItem_Click);
            // 
            // currentDifferenceMenuItem
            // 
            this.currentDifferenceMenuItem.Enabled = false;
            this.currentDifferenceMenuItem.Name = "currentDifferenceMenuItem";
            this.currentDifferenceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Return)));
            this.currentDifferenceMenuItem.Size = new System.Drawing.Size(229, 22);
            this.currentDifferenceMenuItem.Text = "&Current Difference";
            this.currentDifferenceMenuItem.Click += new System.EventHandler(this.currentDifferenceMenuItem_Click);
            // 
            // lastDifferenceMenuItem
            // 
            this.lastDifferenceMenuItem.Enabled = false;
            this.lastDifferenceMenuItem.Name = "lastDifferenceMenuItem";
            this.lastDifferenceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.End)));
            this.lastDifferenceMenuItem.Size = new System.Drawing.Size(229, 22);
            this.lastDifferenceMenuItem.Text = "&Last Difference";
            this.lastDifferenceMenuItem.Click += new System.EventHandler(this.lastDifferenceMenuItem_Click);
            // 
            // setCurrentDifferenceMenuItem
            // 
            this.setCurrentDifferenceMenuItem.Enabled = false;
            this.setCurrentDifferenceMenuItem.Name = "setCurrentDifferenceMenuItem";
            this.setCurrentDifferenceMenuItem.ShortcutKeyDisplayString = "Alt+.";
            this.setCurrentDifferenceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.OemPeriod)));
            this.setCurrentDifferenceMenuItem.Size = new System.Drawing.Size(229, 22);
            this.setCurrentDifferenceMenuItem.Text = "&Set Current Difference";
            this.setCurrentDifferenceMenuItem.Click += new System.EventHandler(this.setCurrentDifferenceMenuItem_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(226, 6);
            // 
            // showProgressMenuItem
            // 
            this.showProgressMenuItem.CheckOnClick = true;
            this.showProgressMenuItem.Name = "showProgressMenuItem";
            this.showProgressMenuItem.Size = new System.Drawing.Size(229, 22);
            this.showProgressMenuItem.Text = "Show Progress &Monitor ";
            this.showProgressMenuItem.Click += new System.EventHandler(this.showProgressMenuItem_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(226, 6);
            // 
            // showLeftPaneMenuItem
            // 
            this.showLeftPaneMenuItem.Name = "showLeftPaneMenuItem";
            this.showLeftPaneMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.showLeftPaneMenuItem.Size = new System.Drawing.Size(229, 22);
            this.showLeftPaneMenuItem.Text = "&Expand Left Pane";
            this.showLeftPaneMenuItem.Click += new System.EventHandler(this.showLeftPaneMenuItem_Click);
            // 
            // showRightPaneMenuItem
            // 
            this.showRightPaneMenuItem.Name = "showRightPaneMenuItem";
            this.showRightPaneMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.showRightPaneMenuItem.Size = new System.Drawing.Size(229, 22);
            this.showRightPaneMenuItem.Text = "Expand &Right Pane";
            this.showRightPaneMenuItem.Click += new System.EventHandler(this.showRightPaneMenuItem_Click);
            // 
            // showBothPanesMenuItem
            // 
            this.showBothPanesMenuItem.Name = "showBothPanesMenuItem";
            this.showBothPanesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.showBothPanesMenuItem.Size = new System.Drawing.Size(229, 22);
            this.showBothPanesMenuItem.Text = "Show &Both Panes";
            this.showBothPanesMenuItem.Click += new System.EventHandler(this.showBothPanesMenuItem_Click);
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeQueryMenuItem,
            this.executeBatchMenuItem,
            this.toolStripSeparator7,
            this.metaQueriesMenuItem,
            this.editConnectionsMenuItem,
            this.mirrorQueryMenuItem});
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.queryToolStripMenuItem.Text = "&Query";
            // 
            // executeQueryMenuItem
            // 
            this.executeQueryMenuItem.Name = "executeQueryMenuItem";
            this.executeQueryMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.executeQueryMenuItem.Size = new System.Drawing.Size(221, 22);
            this.executeQueryMenuItem.Text = "E&xecute Query";
            this.executeQueryMenuItem.Click += new System.EventHandler(this.executeQueryMenuItem_Click);
            // 
            // executeBatchMenuItem
            // 
            this.executeBatchMenuItem.Name = "executeBatchMenuItem";
            this.executeBatchMenuItem.Size = new System.Drawing.Size(221, 22);
            this.executeBatchMenuItem.Text = "Execute &Batch...";
            this.executeBatchMenuItem.Click += new System.EventHandler(this.executeBatchMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(218, 6);
            // 
            // metaQueriesMenuItem
            // 
            this.metaQueriesMenuItem.Name = "metaQueriesMenuItem";
            this.metaQueriesMenuItem.ShortcutKeyDisplayString = "Ctrl+F2";
            this.metaQueriesMenuItem.Size = new System.Drawing.Size(221, 22);
            this.metaQueriesMenuItem.Text = "&Meta-Queries...";
            this.metaQueriesMenuItem.ToolTipText = "Find database meta-information\n(Press Shift to reload query library)";
            this.metaQueriesMenuItem.Click += new System.EventHandler(this.metaQueriesMenuItem_Click);
            // 
            // editConnectionsMenuItem
            // 
            this.editConnectionsMenuItem.Name = "editConnectionsMenuItem";
            this.editConnectionsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.editConnectionsMenuItem.Size = new System.Drawing.Size(221, 22);
            this.editConnectionsMenuItem.Text = "Edit &Connections...";
            this.editConnectionsMenuItem.ToolTipText = "Add or change connection details";
            this.editConnectionsMenuItem.Click += new System.EventHandler(this.editConnectionsMenuItem_Click);
            // 
            // mirrorQueryMenuItem
            // 
            this.mirrorQueryMenuItem.Name = "mirrorQueryMenuItem";
            this.mirrorQueryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mirrorQueryMenuItem.Size = new System.Drawing.Size(221, 22);
            this.mirrorQueryMenuItem.Text = "Mirror &Query...";
            this.mirrorQueryMenuItem.ToolTipText = "Copy settings and text from one pane to the other";
            this.mirrorQueryMenuItem.Click += new System.EventHandler(this.mirrorQueryMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMainKeyReferenceToolStripMenuItem,
            this.showGeneralKeyReferenceMenuItem,
            this.showInputKeyReferenceMenuItem,
            this.showOutputKeyReferenceMenuItem,
            this.aboutMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // showMainKeyReferenceToolStripMenuItem
            // 
            this.showMainKeyReferenceToolStripMenuItem.Name = "showMainKeyReferenceToolStripMenuItem";
            this.showMainKeyReferenceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1)));
            this.showMainKeyReferenceToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.showMainKeyReferenceToolStripMenuItem.Text = "Show &Main Key Reference";
            this.showMainKeyReferenceToolStripMenuItem.Click += new System.EventHandler(this.showMainKeyReferenceMenuItem_Click);
            // 
            // showGeneralKeyReferenceMenuItem
            // 
            this.showGeneralKeyReferenceMenuItem.Name = "showGeneralKeyReferenceMenuItem";
            this.showGeneralKeyReferenceMenuItem.ShortcutKeyDisplayString = "Ctrl+F1";
            this.showGeneralKeyReferenceMenuItem.Size = new System.Drawing.Size(287, 22);
            this.showGeneralKeyReferenceMenuItem.Text = "Show &Editor Pane Key Reference";
            this.showGeneralKeyReferenceMenuItem.Click += new System.EventHandler(this.showEditorPaneKeyReferenceMenuItem_Click);
            // 
            // showInputKeyReferenceMenuItem
            // 
            this.showInputKeyReferenceMenuItem.Name = "showInputKeyReferenceMenuItem";
            this.showInputKeyReferenceMenuItem.ShortcutKeyDisplayString = "F1";
            this.showInputKeyReferenceMenuItem.Size = new System.Drawing.Size(287, 22);
            this.showInputKeyReferenceMenuItem.Text = "Show &Input Key Reference";
            this.showInputKeyReferenceMenuItem.Click += new System.EventHandler(this.showInputKeyReferenceMenuItem_Click);
            // 
            // showOutputKeyReferenceMenuItem
            // 
            this.showOutputKeyReferenceMenuItem.Name = "showOutputKeyReferenceMenuItem";
            this.showOutputKeyReferenceMenuItem.ShortcutKeyDisplayString = "F1";
            this.showOutputKeyReferenceMenuItem.Size = new System.Drawing.Size(287, 22);
            this.showOutputKeyReferenceMenuItem.Text = "Show &Output Key Reference";
            this.showOutputKeyReferenceMenuItem.Click += new System.EventHandler(this.showOutputKeyReferenceMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(287, 22);
            this.aboutMenuItem.Text = "&About SqlDiffFramework";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // commandToolStrip
            // 
            this.commandToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.commandToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextDiffButton,
            this.previousDiffButton,
            this.toolStripSeparator5,
            this.firstDiffButton,
            this.currentDiffButton,
            this.lastDiffButton,
            this.setCurrentDiffButton,
            this.toolStripSeparator4,
            this.turboSortButton,
            this.tandemButton,
            this.autoDiffButton,
            this.autoDiffSplitButton,
            this.toolStripSeparator6,
            this.showProgressButton,
            this.toolStripLabel2,
            this.filterValueTextBox,
            this.toolStripLabel7,
            this.filterFieldTextBox});
            this.commandToolStrip.Location = new System.Drawing.Point(3, 24);
            this.commandToolStrip.Name = "commandToolStrip";
            this.commandToolStrip.Size = new System.Drawing.Size(334, 25);
            this.commandToolStrip.TabIndex = 1;
            // 
            // nextDiffButton
            // 
            this.nextDiffButton.AutoToolTip = false;
            this.nextDiffButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextDiffButton.Enabled = false;
            this.nextDiffButton.Image = ((System.Drawing.Image)(resources.GetObject("nextDiffButton.Image")));
            this.nextDiffButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextDiffButton.Name = "nextDiffButton";
            this.nextDiffButton.Size = new System.Drawing.Size(23, 22);
            this.nextDiffButton.Text = "Next";
            this.nextDiffButton.ToolTipText = "Next Difference (Alt+Down)";
            this.nextDiffButton.Click += new System.EventHandler(this.nextDiffButton_Click);
            // 
            // previousDiffButton
            // 
            this.previousDiffButton.AutoToolTip = false;
            this.previousDiffButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previousDiffButton.Enabled = false;
            this.previousDiffButton.Image = ((System.Drawing.Image)(resources.GetObject("previousDiffButton.Image")));
            this.previousDiffButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousDiffButton.Name = "previousDiffButton";
            this.previousDiffButton.Size = new System.Drawing.Size(23, 22);
            this.previousDiffButton.Text = "Previous";
            this.previousDiffButton.ToolTipText = "Previous Difference (Alt+Up)";
            this.previousDiffButton.Click += new System.EventHandler(this.previousDiffButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // firstDiffButton
            // 
            this.firstDiffButton.AutoToolTip = false;
            this.firstDiffButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.firstDiffButton.Enabled = false;
            this.firstDiffButton.Image = ((System.Drawing.Image)(resources.GetObject("firstDiffButton.Image")));
            this.firstDiffButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.firstDiffButton.Name = "firstDiffButton";
            this.firstDiffButton.Size = new System.Drawing.Size(23, 22);
            this.firstDiffButton.ToolTipText = "First Difference (Alt+Home)";
            this.firstDiffButton.Click += new System.EventHandler(this.firstDiffButton_Click);
            // 
            // currentDiffButton
            // 
            this.currentDiffButton.AutoToolTip = false;
            this.currentDiffButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.currentDiffButton.Enabled = false;
            this.currentDiffButton.Image = ((System.Drawing.Image)(resources.GetObject("currentDiffButton.Image")));
            this.currentDiffButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.currentDiffButton.Name = "currentDiffButton";
            this.currentDiffButton.Size = new System.Drawing.Size(23, 22);
            this.currentDiffButton.ToolTipText = "Current Difference (Alt+Enter)";
            this.currentDiffButton.Click += new System.EventHandler(this.currentDiffButton_Click);
            // 
            // lastDiffButton
            // 
            this.lastDiffButton.AutoToolTip = false;
            this.lastDiffButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lastDiffButton.Enabled = false;
            this.lastDiffButton.Image = ((System.Drawing.Image)(resources.GetObject("lastDiffButton.Image")));
            this.lastDiffButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lastDiffButton.Name = "lastDiffButton";
            this.lastDiffButton.Size = new System.Drawing.Size(23, 22);
            this.lastDiffButton.ToolTipText = "Last Difference (Alt+End)";
            this.lastDiffButton.Click += new System.EventHandler(this.lastDiffButton_Click);
            // 
            // setCurrentDiffButton
            // 
            this.setCurrentDiffButton.AutoToolTip = false;
            this.setCurrentDiffButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setCurrentDiffButton.Enabled = false;
            this.setCurrentDiffButton.Image = global::SqlDiffFramework.Properties.Resources.current_diff_set;
            this.setCurrentDiffButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setCurrentDiffButton.Name = "setCurrentDiffButton";
            this.setCurrentDiffButton.Size = new System.Drawing.Size(23, 22);
            this.setCurrentDiffButton.ToolTipText = "Set current difference to selection (Alt+.)";
            this.setCurrentDiffButton.Click += new System.EventHandler(this.setCurrentDiffButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // turboSortButton
            // 
            this.turboSortButton.AutoSize = false;
            this.turboSortButton.AutoToolTip = false;
            this.turboSortButton.Checked = global::SqlDiffFramework.Properties.Settings.Default.TurboSortButton_Checked;
            this.turboSortButton.CheckOnClick = true;
            this.turboSortButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.turboSortButton.Image = global::SqlDiffFramework.Properties.Resources.turboSort;
            this.turboSortButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.turboSortButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.turboSortButton.Name = "turboSortButton";
            this.turboSortButton.Size = new System.Drawing.Size(55, 22);
            this.turboSortButton.ToolTipText = "Re-sort internally to normalize possible sort differences (e.g. between Oracle an" +
                "d SQL Server)";
            this.turboSortButton.Click += new System.EventHandler(this.turboSortButton_Click);
            // 
            // tandemButton
            // 
            this.tandemButton.AutoSize = false;
            this.tandemButton.AutoToolTip = false;
            this.tandemButton.Checked = global::SqlDiffFramework.Properties.Settings.Default.TandemButton_Checked;
            this.tandemButton.CheckOnClick = true;
            this.tandemButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tandemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tandemButton.Image = global::SqlDiffFramework.Properties.Resources.link;
            this.tandemButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tandemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tandemButton.Name = "tandemButton";
            this.tandemButton.Size = new System.Drawing.Size(44, 22);
            this.tandemButton.Text = "Tandem";
            this.tandemButton.ToolTipText = "Load corresponding left or right file automatically when the other is loaded manu" +
                "ally.";
            this.tandemButton.Click += new System.EventHandler(this.tandemButton_Click);
            // 
            // autoDiffButton
            // 
            this.autoDiffButton.Checked = global::SqlDiffFramework.Properties.Settings.Default.AutoDiffButton_Checked;
            this.autoDiffButton.CheckOnClick = true;
            this.autoDiffButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoDiffButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.autoDiffButton.Image = ((System.Drawing.Image)(resources.GetObject("autoDiffButton.Image")));
            this.autoDiffButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoDiffButton.Name = "autoDiffButton";
            this.autoDiffButton.Size = new System.Drawing.Size(28, 22);
            this.autoDiffButton.Text = "Diff";
            this.autoDiffButton.ToolTipText = "Enable auto-diff upon grid load";
            this.autoDiffButton.Click += new System.EventHandler(this.autoDiffButton_Click);
            // 
            // autoDiffSplitButton
            // 
            this.autoDiffSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.autoDiffSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taubererDiffMenuItem,
            this.hertelDiffMenuItem,
            this.potterDiffMenuItem});
            this.autoDiffSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("autoDiffSplitButton.Image")));
            this.autoDiffSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoDiffSplitButton.Name = "autoDiffSplitButton";
            this.autoDiffSplitButton.Size = new System.Drawing.Size(16, 22);
            // 
            // taubererDiffMenuItem
            // 
            this.taubererDiffMenuItem.Name = "taubererDiffMenuItem";
            this.taubererDiffMenuItem.Size = new System.Drawing.Size(129, 22);
            this.taubererDiffMenuItem.Text = "Tauberer";
            this.taubererDiffMenuItem.ToolTipText = "handles larger data set but not always accurate on larger data sets (count marked" +
                " with *)";
            // 
            // hertelDiffMenuItem
            // 
            this.hertelDiffMenuItem.Name = "hertelDiffMenuItem";
            this.hertelDiffMenuItem.Size = new System.Drawing.Size(129, 22);
            this.hertelDiffMenuItem.Text = "Hertel";
            this.hertelDiffMenuItem.ToolTipText = "memory hog but always accurate";
            // 
            // potterDiffMenuItem
            // 
            this.potterDiffMenuItem.Name = "potterDiffMenuItem";
            this.potterDiffMenuItem.Size = new System.Drawing.Size(129, 22);
            this.potterDiffMenuItem.Text = "Potter";
            this.potterDiffMenuItem.ToolTipText = "slower on largest data sets but always accurate";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // showProgressButton
            // 
            this.showProgressButton.CheckOnClick = true;
            this.showProgressButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showProgressButton.Image = ((System.Drawing.Image)(resources.GetObject("showProgressButton.Image")));
            this.showProgressButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showProgressButton.Name = "showProgressButton";
            this.showProgressButton.Size = new System.Drawing.Size(23, 22);
            this.showProgressButton.ToolTipText = "Show Progress Monitor";
            this.showProgressButton.Click += new System.EventHandler(this.showProgressButton_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel2.Text = "Filter";
            this.toolStripLabel2.Visible = false;
            // 
            // filterValueTextBox
            // 
            this.filterValueTextBox.Name = "filterValueTextBox";
            this.filterValueTextBox.Size = new System.Drawing.Size(50, 25);
            this.filterValueTextBox.ToolTipText = "Show only rows with this value";
            this.filterValueTextBox.Visible = false;
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel7.Text = "Field";
            this.toolStripLabel7.Visible = false;
            // 
            // filterFieldTextBox
            // 
            this.filterFieldTextBox.Name = "filterFieldTextBox";
            this.filterFieldTextBox.Size = new System.Drawing.Size(50, 25);
            this.filterFieldTextBox.ToolTipText = "Common field name to filter on";
            this.filterFieldTextBox.Visible = false;
            // 
            // reportToolStrip
            // 
            this.reportToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.reportToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel17,
            this.currentDiffLabel,
            this.toolStripLabel13,
            this.diffCountLabel,
            this.toolStripSeparator32,
            this.toolStripLabel19,
            this.matchPercentageLabel,
            this.toolStripSeparator33,
            this.addedLinesButton,
            this.addedLinesLabel,
            this.missingLinesButton,
            this.missingLinesLabel,
            this.changedLinesButton,
            this.changedLinesLabel});
            this.reportToolStrip.Location = new System.Drawing.Point(353, 24);
            this.reportToolStrip.Name = "reportToolStrip";
            this.reportToolStrip.Size = new System.Drawing.Size(423, 25);
            this.reportToolStrip.TabIndex = 2;
            // 
            // toolStripLabel17
            // 
            this.toolStripLabel17.Name = "toolStripLabel17";
            this.toolStripLabel17.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel17.Text = "Current Diff:";
            // 
            // currentDiffLabel
            // 
            this.currentDiffLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.currentDiffLabel.Name = "currentDiffLabel";
            this.currentDiffLabel.Size = new System.Drawing.Size(17, 22);
            this.currentDiffLabel.Text = "--";
            this.currentDiffLabel.ToolTipText = "Index of Current Diff Chunk";
            // 
            // toolStripLabel13
            // 
            this.toolStripLabel13.Name = "toolStripLabel13";
            this.toolStripLabel13.Size = new System.Drawing.Size(17, 22);
            this.toolStripLabel13.Text = "of";
            // 
            // diffCountLabel
            // 
            this.diffCountLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.diffCountLabel.Name = "diffCountLabel";
            this.diffCountLabel.Size = new System.Drawing.Size(17, 22);
            this.diffCountLabel.Text = "--";
            this.diffCountLabel.ToolTipText = "Total Number of Diff Chunks";
            // 
            // toolStripSeparator32
            // 
            this.toolStripSeparator32.Name = "toolStripSeparator32";
            this.toolStripSeparator32.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel19
            // 
            this.toolStripLabel19.Name = "toolStripLabel19";
            this.toolStripLabel19.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel19.Text = "Match:";
            // 
            // matchPercentageLabel
            // 
            this.matchPercentageLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.matchPercentageLabel.Name = "matchPercentageLabel";
            this.matchPercentageLabel.Size = new System.Drawing.Size(17, 22);
            this.matchPercentageLabel.Text = "--";
            this.matchPercentageLabel.ToolTipText = "Percentage of lines matching vs. total lines";
            // 
            // toolStripSeparator33
            // 
            this.toolStripSeparator33.Name = "toolStripSeparator33";
            this.toolStripSeparator33.Size = new System.Drawing.Size(6, 25);
            // 
            // addedLinesButton
            // 
            this.addedLinesButton.AutoToolTip = false;
            this.addedLinesButton.CheckOnClick = true;
            this.addedLinesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addedLinesButton.Image = ((System.Drawing.Image)(resources.GetObject("addedLinesButton.Image")));
            this.addedLinesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addedLinesButton.Name = "addedLinesButton";
            this.addedLinesButton.Size = new System.Drawing.Size(42, 22);
            this.addedLinesButton.Text = "Added";
            this.addedLinesButton.ToolTipText = "Include added rows in diff navigation";
            // 
            // addedLinesLabel
            // 
            this.addedLinesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.addedLinesLabel.Name = "addedLinesLabel";
            this.addedLinesLabel.Size = new System.Drawing.Size(17, 22);
            this.addedLinesLabel.Text = "--";
            this.addedLinesLabel.ToolTipText = "Lines added to left table";
            // 
            // missingLinesButton
            // 
            this.missingLinesButton.AutoToolTip = false;
            this.missingLinesButton.CheckOnClick = true;
            this.missingLinesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.missingLinesButton.Image = ((System.Drawing.Image)(resources.GetObject("missingLinesButton.Image")));
            this.missingLinesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.missingLinesButton.Name = "missingLinesButton";
            this.missingLinesButton.Size = new System.Drawing.Size(45, 22);
            this.missingLinesButton.Text = "Missing";
            this.missingLinesButton.ToolTipText = "Include missing rows in diff navigation";
            // 
            // missingLinesLabel
            // 
            this.missingLinesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.missingLinesLabel.Name = "missingLinesLabel";
            this.missingLinesLabel.Size = new System.Drawing.Size(17, 22);
            this.missingLinesLabel.Text = "--";
            this.missingLinesLabel.ToolTipText = "Lines missing from left table";
            // 
            // changedLinesButton
            // 
            this.changedLinesButton.AutoToolTip = false;
            this.changedLinesButton.CheckOnClick = true;
            this.changedLinesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.changedLinesButton.Image = ((System.Drawing.Image)(resources.GetObject("changedLinesButton.Image")));
            this.changedLinesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changedLinesButton.Name = "changedLinesButton";
            this.changedLinesButton.Size = new System.Drawing.Size(54, 22);
            this.changedLinesButton.Text = "Changed";
            this.changedLinesButton.ToolTipText = "Include changed rows in diff navigation";
            // 
            // changedLinesLabel
            // 
            this.changedLinesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.changedLinesLabel.Name = "changedLinesLabel";
            this.changedLinesLabel.Size = new System.Drawing.Size(17, 22);
            this.changedLinesLabel.Text = "--";
            this.changedLinesLabel.ToolTipText = "Lines changed between left and right tables";
            // 
            // memoryUsageTimer
            // 
            this.memoryUsageTimer.Interval = 1000;
            this.memoryUsageTimer.Tick += new System.EventHandler(this.memoryUsageTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 641);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "SqlDiffFramework";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.commandToolStrip.ResumeLayout(false);
            this.commandToolStrip.PerformLayout();
            this.reportToolStrip.ResumeLayout(false);
            this.reportToolStrip.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripDropDownButton msgDropDown;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStrip commandToolStrip;
		private System.Windows.Forms.ToolStripButton nextDiffButton;
		private System.Windows.Forms.ToolStripButton previousDiffButton;
		private System.Windows.Forms.ToolStripButton currentDiffButton;
		private System.Windows.Forms.ToolStripButton firstDiffButton;
		private System.Windows.Forms.ToolStripButton lastDiffButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        //private System.Windows.Forms.ToolStripButton useLocalDataButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripStatusLabel LegendCurrentOmittedLabel;
		private System.Windows.Forms.ToolStripStatusLabel LegendCurrentDiffLabel;
		private System.Windows.Forms.ToolStripStatusLabel legendLabel;
        private System.Windows.Forms.ToolStripStatusLabel LegendNonCurrentDiffLabel;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nextDifferenceMenuItem;
		private System.Windows.Forms.ToolStripMenuItem previousDifferenceMenuItem;
		private System.Windows.Forms.ToolStripMenuItem firstDifferenceMenuItem;
		private System.Windows.Forms.ToolStripMenuItem currentDifferenceMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lastDifferenceMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
		private System.Windows.Forms.ToolStripButton turboSortButton;
        //private System.Windows.Forms.ToolStripButton autoHighlightButton;
        private System.Windows.Forms.ToolStripMenuItem openQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tandemButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripStatusLabel spacer2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
		private System.Windows.Forms.ToolStrip reportToolStrip;
		private System.Windows.Forms.ToolStripLabel toolStripLabel13;
        private System.Windows.Forms.ToolStripLabel diffCountLabel;
		private System.Windows.Forms.ToolStripLabel toolStripLabel17;
		private System.Windows.Forms.ToolStripLabel currentDiffLabel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator32;
		private System.Windows.Forms.ToolStripLabel toolStripLabel19;
		private System.Windows.Forms.ToolStripLabel matchPercentageLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator33;
        private System.Windows.Forms.ToolStripLabel addedLinesLabel;
        private System.Windows.Forms.ToolStripLabel missingLinesLabel;
        private System.Windows.Forms.ToolStripLabel changedLinesLabel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
		private System.Windows.Forms.ToolStripMenuItem showLeftPaneMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showRightPaneMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showBothPanesMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        //private System.Windows.Forms.ToolStripButton autoExecuteButton;
        private System.Windows.Forms.ToolStripMenuItem newQueryMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel memoryStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel spacer3;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripTextBox filterValueTextBox;
		private System.Windows.Forms.ToolStripLabel toolStripLabel7;
		private System.Windows.Forms.ToolStripTextBox filterFieldTextBox;
		private System.Windows.Forms.ToolStripStatusLabel LegendNonCurrentOmittedLabel;
        private System.Windows.Forms.ToolStripMenuItem showProgressMenuItem;
		private System.Windows.Forms.ToolStripButton autoDiffButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator34;
        private System.Windows.Forms.ToolStripMenuItem restoreSettingsMenuItem;
        private System.Windows.Forms.Timer memoryUsageTimer;
        private System.Windows.Forms.ToolStripMenuItem saveLeftQueryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRightQueryMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeQueryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metaQueriesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editConnectionsMenuItem;
        private System.Windows.Forms.ToolStripButton setCurrentDiffButton;
        private System.Windows.Forms.ToolStripMenuItem setCurrentDifferenceMenuItem;
        private System.Windows.Forms.ToolStripButton showProgressButton;
        private System.Windows.Forms.ToolStripMenuItem tabLeavesControlMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabInsertsSpacesMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showInputKeyReferenceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOutputKeyReferenceMenuItem;
        private CleanCode.SqlEditorControls.SqlEditor leftSqlEditor;
        private CleanCode.SqlEditorControls.SqlEditor rightSqlEditor;
        private System.Windows.Forms.ToolStripMenuItem showGeneralKeyReferenceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMainKeyReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton autoDiffSplitButton;
        private System.Windows.Forms.ToolStripMenuItem taubererDiffMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hertelDiffMenuItem;
        private System.Windows.Forms.ToolStripMenuItem potterDiffMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorQueryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeBatchMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton addedLinesButton;
        private System.Windows.Forms.ToolStripButton missingLinesButton;
        private System.Windows.Forms.ToolStripButton changedLinesButton;
	}
}
