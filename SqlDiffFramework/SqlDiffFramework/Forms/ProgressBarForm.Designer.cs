namespace SqlDiffFramework.Forms
{
	partial class ProgressBarForm
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
			this.progressBarMessager = new CleanCode.GeneralComponents.Controls.ProgressBarMessager();
			this.SuspendLayout();
			// 
			// progressBarMessager
			// 
			this.progressBarMessager.AutoSize = true;
			this.progressBarMessager.Location = new System.Drawing.Point(3, 12);
			this.progressBarMessager.Maximum = 100;
			this.progressBarMessager.MaxMessages = 10;
			this.progressBarMessager.Minimum = 0;
			this.progressBarMessager.Name = "progressBarMessager";
			this.progressBarMessager.ResetOnDisplay = true;
			this.progressBarMessager.ShowElapsedTimes = true;
			this.progressBarMessager.Size = new System.Drawing.Size(273, 166);
			this.progressBarMessager.Step = 20;
			this.progressBarMessager.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
			this.progressBarMessager.TabIndex = 0;
			this.progressBarMessager.Value = 0;
			// 
			// ProgressBarForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 184);
			this.ControlBox = false;
			this.Controls.Add(this.progressBarMessager);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ProgressBarForm";
			this.ShowInTaskbar = false;
			this.Text = "...";
			this.VisibleChanged += new System.EventHandler(this.ProgressBarForm_VisibleChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CleanCode.GeneralComponents.Controls.ProgressBarMessager progressBarMessager;


	}
}
