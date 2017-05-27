namespace SqlDiffFramework.Forms
{
    partial class BatchSetupForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rightSnapshotLabel = new System.Windows.Forms.TextBox();
            this.rightSourceLabel = new System.Windows.Forms.TextBox();
            this.rightSystemLabel = new System.Windows.Forms.TextBox();
            this.systemRowLabel = new System.Windows.Forms.Label();
            this.sourceRowLabel = new System.Windows.Forms.Label();
            this.snapshotRowLabel = new System.Windows.Forms.Label();
            this.leftSystemLabel = new System.Windows.Forms.TextBox();
            this.leftSourceLabel = new System.Windows.Forms.TextBox();
            this.leftSnapshotLabel = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.fileMask = new CleanCode.GeneralComponents.Controls.FileMask();
            this.executeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.showResultsButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveSnapshotsCheckBox = new System.Windows.Forms.CheckBox();
            this.nonZeroCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.includeOrphansCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rightSnapshotLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rightSourceLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.rightSystemLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.systemRowLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sourceRowLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.snapshotRowLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.leftSystemLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.leftSourceLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.leftSnapshotLabel, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(685, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rightSnapshotLabel
            // 
            this.rightSnapshotLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightSnapshotLabel.Enabled = false;
            this.rightSnapshotLabel.Location = new System.Drawing.Point(389, 59);
            this.rightSnapshotLabel.Name = "rightSnapshotLabel";
            this.rightSnapshotLabel.Size = new System.Drawing.Size(293, 20);
            this.rightSnapshotLabel.TabIndex = 4;
            // 
            // rightSourceLabel
            // 
            this.rightSourceLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightSourceLabel.Enabled = false;
            this.rightSourceLabel.Location = new System.Drawing.Point(389, 31);
            this.rightSourceLabel.Name = "rightSourceLabel";
            this.rightSourceLabel.Size = new System.Drawing.Size(293, 20);
            this.rightSourceLabel.TabIndex = 3;
            // 
            // rightSystemLabel
            // 
            this.rightSystemLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightSystemLabel.Enabled = false;
            this.rightSystemLabel.Location = new System.Drawing.Point(389, 3);
            this.rightSystemLabel.Name = "rightSystemLabel";
            this.rightSystemLabel.Size = new System.Drawing.Size(293, 20);
            this.rightSystemLabel.TabIndex = 2;
            // 
            // systemRowLabel
            // 
            this.systemRowLabel.AutoSize = true;
            this.systemRowLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemRowLabel.Location = new System.Drawing.Point(3, 0);
            this.systemRowLabel.Name = "systemRowLabel";
            this.systemRowLabel.Size = new System.Drawing.Size(82, 28);
            this.systemRowLabel.TabIndex = 0;
            this.systemRowLabel.Text = "System";
            this.systemRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sourceRowLabel
            // 
            this.sourceRowLabel.AutoSize = true;
            this.sourceRowLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceRowLabel.Location = new System.Drawing.Point(3, 28);
            this.sourceRowLabel.Name = "sourceRowLabel";
            this.sourceRowLabel.Size = new System.Drawing.Size(82, 28);
            this.sourceRowLabel.TabIndex = 0;
            this.sourceRowLabel.Text = "Source";
            this.sourceRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // snapshotRowLabel
            // 
            this.snapshotRowLabel.AutoSize = true;
            this.snapshotRowLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.snapshotRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snapshotRowLabel.Location = new System.Drawing.Point(3, 56);
            this.snapshotRowLabel.Name = "snapshotRowLabel";
            this.snapshotRowLabel.Size = new System.Drawing.Size(82, 28);
            this.snapshotRowLabel.TabIndex = 0;
            this.snapshotRowLabel.Text = "Snapshot";
            this.snapshotRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leftSystemLabel
            // 
            this.leftSystemLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftSystemLabel.Enabled = false;
            this.leftSystemLabel.Location = new System.Drawing.Point(91, 3);
            this.leftSystemLabel.Name = "leftSystemLabel";
            this.leftSystemLabel.Size = new System.Drawing.Size(292, 20);
            this.leftSystemLabel.TabIndex = 1;
            // 
            // leftSourceLabel
            // 
            this.leftSourceLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftSourceLabel.Enabled = false;
            this.leftSourceLabel.Location = new System.Drawing.Point(91, 31);
            this.leftSourceLabel.Name = "leftSourceLabel";
            this.leftSourceLabel.Size = new System.Drawing.Size(292, 20);
            this.leftSourceLabel.TabIndex = 1;
            // 
            // leftSnapshotLabel
            // 
            this.leftSnapshotLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftSnapshotLabel.Enabled = false;
            this.leftSnapshotLabel.Location = new System.Drawing.Point(91, 59);
            this.leftSnapshotLabel.Name = "leftSnapshotLabel";
            this.leftSnapshotLabel.Size = new System.Drawing.Size(292, 20);
            this.leftSnapshotLabel.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.outputTextBox, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.fileMask, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 144);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.20833F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.79167F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(684, 114);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(389, 3);
            this.outputTextBox.Name = "outputTextBox";
            this.tableLayoutPanel2.SetRowSpan(this.outputTextBox, 2);
            this.outputTextBox.Size = new System.Drawing.Size(292, 108);
            this.outputTextBox.TabIndex = 5;
            this.outputTextBox.Text = "";
            this.toolTip.SetToolTip(this.outputTextBox, "Results displayed here when you press Execute");
            // 
            // fileMask
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.fileMask, 2);
            this.fileMask.DisplayLabels = true;
            this.fileMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileMask.Location = new System.Drawing.Point(3, 3);
            this.fileMask.Mask = "";
            this.fileMask.Name = "fileMask";
            this.fileMask.RestrictionLambda = null;
            this.tableLayoutPanel2.SetRowSpan(this.fileMask, 2);
            this.fileMask.Size = new System.Drawing.Size(380, 108);
            this.fileMask.SourceDirectory = null;
            this.fileMask.TabIndex = 6;
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(0, 0);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(60, 23);
            this.executeButton.TabIndex = 3;
            this.executeButton.Text = "&Execute";
            this.toolTip.SetToolTip(this.executeButton, "Begin processing the list of matched pairs of files that satisfy the file mask(s)" +
                    ".");
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(131, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.toolTip.SetToolTip(this.closeButton, "Add SHIFT to also close results form at the same time.");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.executeButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(363, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 24);
            this.panel1.TabIndex = 6;
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(65, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(60, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.toolTip.SetToolTip(this.cancelButton, "Stop batch execution after the current step completes.");
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.showResultsButton, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 271);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(684, 30);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // showResultsButton
            // 
            this.showResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showResultsButton.Location = new System.Drawing.Point(589, 3);
            this.showResultsButton.Name = "showResultsButton";
            this.showResultsButton.Size = new System.Drawing.Size(92, 23);
            this.showResultsButton.TabIndex = 3;
            this.showResultsButton.Text = "Show &Results";
            this.showResultsButton.UseVisualStyleBackColor = true;
            this.showResultsButton.Click += new System.EventHandler(this.showResultsButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.saveSnapshotsCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.nonZeroCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.includeOrphansCheckBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(354, 24);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // saveSnapshotsCheckBox
            // 
            this.saveSnapshotsCheckBox.AutoSize = true;
            this.saveSnapshotsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.saveSnapshotsCheckBox.Name = "saveSnapshotsCheckBox";
            this.saveSnapshotsCheckBox.Size = new System.Drawing.Size(104, 17);
            this.saveSnapshotsCheckBox.TabIndex = 7;
            this.saveSnapshotsCheckBox.Text = "Save &Snapshots";
            this.toolTip.SetToolTip(this.saveSnapshotsCheckBox, "All query results will be saved in the designated snapshot directories\nwith the s" +
                    "ame base name as each query.");
            this.saveSnapshotsCheckBox.UseVisualStyleBackColor = true;
            this.saveSnapshotsCheckBox.CheckedChanged += new System.EventHandler(this.saveSnapshotsCheckBox_CheckedChanged);
            // 
            // nonZeroCheckBox
            // 
            this.nonZeroCheckBox.AutoSize = true;
            this.nonZeroCheckBox.Location = new System.Drawing.Point(123, 3);
            this.nonZeroCheckBox.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.nonZeroCheckBox.Name = "nonZeroCheckBox";
            this.nonZeroCheckBox.Size = new System.Drawing.Size(92, 17);
            this.nonZeroCheckBox.TabIndex = 7;
            this.nonZeroCheckBox.Text = "Flag Non-&zero";
            this.toolTip.SetToolTip(this.nonZeroCheckBox, "Check this box if your query set looks for violations\nwhere ANY returned rows ind" +
                    "icate a problem.");
            this.nonZeroCheckBox.UseVisualStyleBackColor = true;
            this.nonZeroCheckBox.CheckedChanged += new System.EventHandler(this.nonZeroCheckBox_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // includeOrphansCheckBox
            // 
            this.includeOrphansCheckBox.AutoSize = true;
            this.includeOrphansCheckBox.Location = new System.Drawing.Point(231, 3);
            this.includeOrphansCheckBox.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.includeOrphansCheckBox.Name = "includeOrphansCheckBox";
            this.includeOrphansCheckBox.Size = new System.Drawing.Size(104, 17);
            this.includeOrphansCheckBox.TabIndex = 7;
            this.includeOrphansCheckBox.Text = "Include &Orphans";
            this.toolTip.SetToolTip(this.includeOrphansCheckBox, "Overrides standard requiring file to exist on both sides.\nNote that the file list" +
                    " above will NOT reflect these included orphans.");
            this.includeOrphansCheckBox.UseVisualStyleBackColor = true;
            this.includeOrphansCheckBox.CheckedChanged += new System.EventHandler(this.nonZeroCheckBox_CheckedChanged);
            // 
            // BatchSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(709, 308);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BatchSetupForm";
            this.Text = "Batch Execution Palette";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label systemRowLabel;
        private System.Windows.Forms.Label sourceRowLabel;
        private System.Windows.Forms.Label snapshotRowLabel;
        private System.Windows.Forms.TextBox leftSystemLabel;
        private System.Windows.Forms.TextBox rightSnapshotLabel;
        private System.Windows.Forms.TextBox rightSourceLabel;
        private System.Windows.Forms.TextBox rightSystemLabel;
        private System.Windows.Forms.TextBox leftSourceLabel;
        private System.Windows.Forms.TextBox leftSnapshotLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button showResultsButton;
        private System.Windows.Forms.CheckBox saveSnapshotsCheckBox;
        private CleanCode.GeneralComponents.Controls.FileMask fileMask;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox nonZeroCheckBox;
        private System.Windows.Forms.CheckBox includeOrphansCheckBox;
    }
}