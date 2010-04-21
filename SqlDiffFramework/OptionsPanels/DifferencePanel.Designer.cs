namespace SqlDiffFramework.OptionsPanels
{
    partial class DifferencePanel
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.footerBarLabel = new System.Windows.Forms.Label();
            this.maxRowsResolvedTotalUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxRowsResolvedPerChunkUpDown = new System.Windows.Forms.NumericUpDown();
            this.timeoutUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.maxRowsResolvedTotalUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRowsResolvedPerChunkUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(47, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "* Set to 0 to disable";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(272, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 26);
            this.label7.TabIndex = 10;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(272, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "*";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Row limit for refining differences to individual columns in the entire grid.";
            this.label4.Location = new System.Drawing.Point(47, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Max. rows per result set showing column highlights";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Row limit for refining differences to individual columns for one difference regio" +
                "n; the higher the number the longer it may take.";
            this.label3.Location = new System.Drawing.Point(47, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max. rows per chunk showing column highlights";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Select command timeout; increase if you see time-out messages.";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "SQL Timeout (seconds)";
            // 
            // footerBarLabel
            // 
            this.footerBarLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.footerBarLabel.Location = new System.Drawing.Point(50, 180);
            this.footerBarLabel.Name = "footerBarLabel";
            this.footerBarLabel.Size = new System.Drawing.Size(240, 1);
            this.footerBarLabel.TabIndex = 12;
            this.footerBarLabel.Text = "label9";
            // 
            // maxRowsResolvedTotalUpDown
            // 
            this.maxRowsResolvedTotalUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::SqlDiffFramework.Properties.Settings.Default, "MaxHighlightedRowsTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maxRowsResolvedTotalUpDown.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.maxRowsResolvedTotalUpDown.Location = new System.Drawing.Point(208, 103);
            this.maxRowsResolvedTotalUpDown.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.maxRowsResolvedTotalUpDown.Name = "maxRowsResolvedTotalUpDown";
            this.maxRowsResolvedTotalUpDown.Size = new System.Drawing.Size(64, 20);
            this.maxRowsResolvedTotalUpDown.TabIndex = 8;
            this.maxRowsResolvedTotalUpDown.Value = global::SqlDiffFramework.Properties.Settings.Default.MaxHighlightedRowsTotal;
            // 
            // maxRowsResolvedPerChunkUpDown
            // 
            this.maxRowsResolvedPerChunkUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::SqlDiffFramework.Properties.Settings.Default, "MaxHighlightedRowsPerChunk", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maxRowsResolvedPerChunkUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxRowsResolvedPerChunkUpDown.Location = new System.Drawing.Point(208, 63);
            this.maxRowsResolvedPerChunkUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxRowsResolvedPerChunkUpDown.Name = "maxRowsResolvedPerChunkUpDown";
            this.maxRowsResolvedPerChunkUpDown.Size = new System.Drawing.Size(64, 20);
            this.maxRowsResolvedPerChunkUpDown.TabIndex = 7;
            this.maxRowsResolvedPerChunkUpDown.Value = global::SqlDiffFramework.Properties.Settings.Default.MaxHighlightedRowsPerChunk;
            // 
            // timeoutUpDown
            // 
            this.timeoutUpDown.AccessibleDescription = "Timeout in seconds.";
            this.timeoutUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::SqlDiffFramework.Properties.Settings.Default, "CommandTimeout", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.timeoutUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.timeoutUpDown.Location = new System.Drawing.Point(208, 23);
            this.timeoutUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.timeoutUpDown.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.timeoutUpDown.Name = "timeoutUpDown";
            this.timeoutUpDown.Size = new System.Drawing.Size(64, 20);
            this.timeoutUpDown.TabIndex = 6;
            this.timeoutUpDown.Value = global::SqlDiffFramework.Properties.Settings.Default.CommandTimeout;
            // 
            // DifferencePanel
            // 
            this.AccessibleDescription = "Differencing settings";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CategoryPath = "Options\\DifferencePanel";
            this.Controls.Add(this.footerBarLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maxRowsResolvedTotalUpDown);
            this.Controls.Add(this.maxRowsResolvedPerChunkUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeoutUpDown);
            this.Controls.Add(this.label1);
            this.DisplayName = "Differencing";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "DifferencePanel";
            ((System.ComponentModel.ISupportInitialize)(this.maxRowsResolvedTotalUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRowsResolvedPerChunkUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown maxRowsResolvedTotalUpDown;
        private System.Windows.Forms.NumericUpDown maxRowsResolvedPerChunkUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown timeoutUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label footerBarLabel;
    }
}
