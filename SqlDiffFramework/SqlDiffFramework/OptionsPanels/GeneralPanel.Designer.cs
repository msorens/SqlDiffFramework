namespace SqlDiffFramework.OptionsPanels
{
    partial class GeneralPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.footerBarLabel = new System.Windows.Forms.Label();
            this.maxColumnWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.updateIntervalUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.showElapsedTimesCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.maxColumnWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Number of days between reminders for new updates.";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Update Check Interval (days)";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Column width is limited to this value (in pixels) when you \'fit to data\'.";
            this.label3.Location = new System.Drawing.Point(47, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Maximum column width";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(272, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(47, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "* Set to 0 to disable";
            // 
            // footerBarLabel
            // 
            this.footerBarLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.footerBarLabel.Location = new System.Drawing.Point(50, 180);
            this.footerBarLabel.Name = "footerBarLabel";
            this.footerBarLabel.Size = new System.Drawing.Size(240, 1);
            this.footerBarLabel.TabIndex = 3;
            this.footerBarLabel.Text = "label9";
            // 
            // maxColumnWidthUpDown
            // 
            this.maxColumnWidthUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::SqlDiffFramework.Properties.Settings.Default, "MaxColumnWidth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maxColumnWidthUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.maxColumnWidthUpDown.Location = new System.Drawing.Point(208, 65);
            this.maxColumnWidthUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.maxColumnWidthUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.maxColumnWidthUpDown.Name = "maxColumnWidthUpDown";
            this.maxColumnWidthUpDown.Size = new System.Drawing.Size(64, 20);
            this.maxColumnWidthUpDown.TabIndex = 1;
            this.maxColumnWidthUpDown.Value = global::SqlDiffFramework.Properties.Settings.Default.MaxColumnWidth;
            // 
            // updateIntervalUpDown
            // 
            this.updateIntervalUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::SqlDiffFramework.Properties.Settings.Default, "UpdateCheckInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateIntervalUpDown.Location = new System.Drawing.Point(208, 23);
            this.updateIntervalUpDown.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.updateIntervalUpDown.Name = "updateIntervalUpDown";
            this.updateIntervalUpDown.Size = new System.Drawing.Size(64, 20);
            this.updateIntervalUpDown.TabIndex = 1;
            this.updateIntervalUpDown.Value = global::SqlDiffFramework.Properties.Settings.Default.UpdateCheckInterval;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "When running a difference, the progress monitor reports the steps with or without" +
                " the time for each step.";
            this.label1.Location = new System.Drawing.Point(47, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Show elapsed times on progress monitor";
            // 
            // showElapsedTimesCheckBox
            // 
            this.showElapsedTimesCheckBox.AutoSize = true;
            this.showElapsedTimesCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showElapsedTimesCheckBox.Checked = global::SqlDiffFramework.Properties.Settings.Default.ShowElapsedTimes;
            this.showElapsedTimesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SqlDiffFramework.Properties.Settings.Default, "ShowElapsedTimes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.showElapsedTimesCheckBox.Location = new System.Drawing.Point(208, 109);
            this.showElapsedTimesCheckBox.Name = "showElapsedTimesCheckBox";
            this.showElapsedTimesCheckBox.Size = new System.Drawing.Size(15, 14);
            this.showElapsedTimesCheckBox.TabIndex = 5;
            this.showElapsedTimesCheckBox.UseVisualStyleBackColor = true;
            // 
            // GeneralPanel
            // 
            this.AccessibleDescription = "Miscellaneous configuration options";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CategoryPath = "Options\\GeneralPanel";
            this.Controls.Add(this.showElapsedTimesCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.footerBarLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxColumnWidthUpDown);
            this.Controls.Add(this.updateIntervalUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.DisplayName = "General";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "GeneralPanel";
            ((System.ComponentModel.ISupportInitialize)(this.maxColumnWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown updateIntervalUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown maxColumnWidthUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label footerBarLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showElapsedTimesCheckBox;
    }
}
