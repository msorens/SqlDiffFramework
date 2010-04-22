namespace SqlDiffFramework
{
    partial class BatchResultsForm
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
            this.extendedDataGridView_old = new CleanCode.DataGridViewControls.ExtendedDataGridView();
            this.File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Runtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeftRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiffChunks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Added = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Missing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView = new CleanCode.DataGridViewControls.ExtendedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.extendedDataGridView_old)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // extendedDataGridView_old
            // 
            this.extendedDataGridView_old.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.extendedDataGridView_old.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.extendedDataGridView_old.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.File,
            this.Runtime,
            this.Duration,
            this.LeftRows,
            this.RightRows,
            this.DiffChunks,
            this.Added,
            this.Missing,
            this.Changed,
            this.Quality});
            this.extendedDataGridView_old.ContainerTest = false;
            this.extendedDataGridView_old.DateCellStyleFormat = null;
            this.extendedDataGridView_old.Location = new System.Drawing.Point(12, 370);
            this.extendedDataGridView_old.MaxColumnWidth = 200;
            this.extendedDataGridView_old.Name = "extendedDataGridView_old";
            this.extendedDataGridView_old.ShowBooleansAsCheckBoxes = false;
            this.extendedDataGridView_old.ShowCsvExport = CleanCode.DataGridViewControls.ExtendedDataGridView.CsvExportChoice.Never;
            this.extendedDataGridView_old.Size = new System.Drawing.Size(805, 0);
            this.extendedDataGridView_old.TabIndex = 0;
            this.extendedDataGridView_old.UserCommandsTitle = "ExtendedDataGridView Quick Reference";
            this.extendedDataGridView_old.Visible = false;
            // 
            // File
            // 
            this.File.HeaderText = "File";
            this.File.Name = "File";
            this.File.Width = 150;
            // 
            // Runtime
            // 
            this.Runtime.HeaderText = "Runtime";
            this.Runtime.Name = "Runtime";
            this.Runtime.Width = 150;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.Width = 60;
            // 
            // LeftRows
            // 
            this.LeftRows.HeaderText = "Left Rows";
            this.LeftRows.Name = "LeftRows";
            this.LeftRows.Width = 45;
            // 
            // RightRows
            // 
            this.RightRows.HeaderText = "Right Rows";
            this.RightRows.Name = "RightRows";
            this.RightRows.Width = 45;
            // 
            // DiffChunks
            // 
            this.DiffChunks.HeaderText = "Diff Chunks";
            this.DiffChunks.Name = "DiffChunks";
            this.DiffChunks.Width = 45;
            // 
            // Added
            // 
            this.Added.HeaderText = "Added";
            this.Added.Name = "Added";
            this.Added.Width = 60;
            // 
            // Missing
            // 
            this.Missing.HeaderText = "Missing";
            this.Missing.Name = "Missing";
            this.Missing.Width = 60;
            // 
            // Changed
            // 
            this.Changed.HeaderText = "Changed";
            this.Changed.Name = "Changed";
            this.Changed.Width = 60;
            // 
            // Quality
            // 
            this.Quality.HeaderText = "Quality";
            this.Quality.Name = "Quality";
            this.Quality.Width = 60;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContainerTest = false;
            this.dataGridView.DateCellStyleFormat = null;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.MaxColumnWidth = 200;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ShowBooleansAsCheckBoxes = false;
            this.dataGridView.ShowCsvExport = CleanCode.DataGridViewControls.ExtendedDataGridView.CsvExportChoice.Never;
            this.dataGridView.Size = new System.Drawing.Size(805, 269);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.UserCommandsTitle = "ExtendedDataGridView Quick Reference";
            // 
            // BatchResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 304);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.extendedDataGridView_old);
            this.Name = "BatchResultsForm";
            this.Text = "Batch Results";
            ((System.ComponentModel.ISupportInitialize)(this.extendedDataGridView_old)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CleanCode.DataGridViewControls.ExtendedDataGridView extendedDataGridView_old;
        private System.Windows.Forms.DataGridViewTextBoxColumn File;
        private System.Windows.Forms.DataGridViewTextBoxColumn Runtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeftRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn RightRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiffChunks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Added;
        private System.Windows.Forms.DataGridViewTextBoxColumn Missing;
        private System.Windows.Forms.DataGridViewTextBoxColumn Changed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quality;
        private CleanCode.DataGridViewControls.ExtendedDataGridView dataGridView;
    }
}