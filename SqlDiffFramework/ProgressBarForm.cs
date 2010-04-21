using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/*
 * ==============================================================
 * @ID       $Id: ProgressBarForm.cs 894 2010-03-03 14:20:42Z ww $
 * @created  2008-06-01
 * ==============================================================
 *
 * The official license for this file is shown next.
 * Unofficially, consider this e-postcardware as well:
 * if you find this module useful, let us know via e-mail, along with
 * where in the world you are and (if applicable) your website address.
 */

/* ***** BEGIN LICENSE BLOCK *****
 * Version: MIT License
 *
 * Copyright (c) 2010 Michael Sorens
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * ***** END LICENSE BLOCK *****
 */

namespace SqlDiffFramework
{
	public partial class ProgressBarForm : Form
	{

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		private const string RUN_TITLE = "Processing... please wait";
		private const string IDLE_TITLE = "Diff Progress Monitor";

		private Form parent;
		private bool movedByUser = false;

		public ProgressBarForm(Form parent)
		{
			InitializeComponent();
			this.parent = parent;
			// Our UI allows users to redisplay form at will so must turn this off.
			progressBarMessager.ResetOnDisplay = false;
			progressBarMessager.Reset();
			Text = IDLE_TITLE;
		}

		# region properties

		private bool autoDisplay = true;

		public bool AutoDisplay
		{
			get { return autoDisplay; }
			set {
				autoDisplay = value;
				if (autoDisplay && Visible) { Hide(); }
				else if (!autoDisplay && !Visible) { Show(); }
			}
		}


		public bool ShowElapsedTimes
		{
			get { return progressBarMessager.ShowElapsedTimes; }
			set { progressBarMessager.ShowElapsedTimes = value; }
		}

		# endregion properties

		# region event handlers

		private void ProgressBarForm_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible && !movedByUser)
			{
				Move -= new EventHandler(ProgressBarForm_Move);
				Location = new Point(
					Math.Max(0, (parent.Location.X + (parent.Width - Width) / 2)),
					Math.Max(0, (parent.Location.Y + (parent.Height - Height) / 2)));
				Move += new EventHandler(ProgressBarForm_Move);
				Refresh();
			}
		}

		private void ProgressBarForm_Move(object sender, EventArgs e)
		{
			movedByUser = true;
		}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // let Escape close this mini-form
            if (keyData == Keys.Escape) { Hide(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }

		# endregion event handlers

		# region public methods

		public void ReportInitialMessage(string message)
		{
			progressBarMessager.Reset();
			Text = RUN_TITLE;
			if (!Visible) { Show(); }
			// Also need to bring it to the foreground if buried!
			SetForegroundWindow(Handle);
			progressBarMessager.ReportInitialMessage(message);
			Refresh();
		}

		public void UpdateProgress(string message)
		{
			Application.DoEvents();
			if (progressBarMessager.Cancelled)
			{
				if (autoDisplay) { Hide(); }
				Text = IDLE_TITLE;
				throw new CancelledException();
			}
			progressBarMessager.PerformStep(message);
			Refresh();
		}

		public void FinishLastMessage()
		{
			Application.DoEvents();
			progressBarMessager.PerformStep(null);
			Refresh();
			if (autoDisplay) { Hide(); }
			Text = IDLE_TITLE;
		}

		# endregion public methods

	}

	public class CancelledException : ApplicationException
	{
		// Use the default ApplicationException constructors
		public CancelledException() : base() { }
		public CancelledException(string s) : base(s) { }
		public CancelledException(string s, Exception ex) : base(s, ex) { }
	}
}
