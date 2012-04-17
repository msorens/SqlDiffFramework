using System.Drawing;
using System.Windows.Forms;
using CleanCode.DataGridViewControls;
using System.Collections.Generic;

/*
 * ==============================================================
 * @ID       $Id: BatchResultsForm.cs 971 2010-09-30 16:09:30Z ww $
 * @created  2009-09-01
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
    public partial class BatchResultsForm : Form
    {
        List<string> columnsToGreyOut = new List<string> { "Quality", "DiffCount", "Added", "Missing", "Changed"  };

        public ExtendedDataGridView DataGridView
        {
            get { return dataGridView; }
        }

        public bool FlagNonZero {
            get { return flagNonZero; }
            set { flagNonZero = value; Refresh(); }
        }
        private bool flagNonZero;

        public BatchResultsForm()
        {
            InitializeComponent();
            dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
            dataGridView.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView_RowsAdded);
            dataGridView.DataError += new DataGridViewDataErrorEventHandler(dataGridView_DataError);
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string msg = "Invalid text entered for '" + dataGridView.Rows[e.RowIndex].Cells[0].Value + "' row, "
                + "'" + dataGridView.Columns[e.ColumnIndex].Name + "' column";
            MessageBox.Show(msg, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // auto-scroll to end
            if (dataGridView.FirstDisplayedScrollingRowIndex 
                + dataGridView.DisplayedRowCount(false) < dataGridView.Rows.Count)
            {
                dataGridView.FirstDisplayedScrollingRowIndex =
                    dataGridView.Rows.Count - dataGridView.DisplayedRowCount(false);
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name.Equals("Quality"))
            {

                int percent = int.Parse(e.Value.ToString()
                    .Replace("%", "") // all have a trailing percent
                    .Replace("+","") // some are '99+'
                    .Replace("--","-1")); // some may indicate 'no data'
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.BackColor = 
                    e.Value.ToString().Length == 0 ? Color.White :
                    percent == 100 ? Color.Green :
                    percent > 95 ? Color.Yellow :
                    Color.Red;
            }

            /* no ELSE here! */

            if (columnsToGreyOut.Contains(dataGridView.Columns[e.ColumnIndex].Name))
            {
                int leftCount = int.Parse(dataGridView.Rows[e.RowIndex].Cells["LeftCount"].Value.ToString());
                int rightCount = int.Parse(dataGridView.Rows[e.RowIndex].Cells["RightCount"].Value.ToString());
                if (leftCount == -1 || rightCount == -1)
                {   // make it invisible
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.LightGray;
                }
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name.Equals("LeftCount")
                    || dataGridView.Columns[e.ColumnIndex].Name.Equals("RightCount"))
            {
                int count = int.Parse(e.Value.ToString());
                if (count == -1)
                {   // make it invisible
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.LightGray;
                }
                else if (FlagNonZero)
                {
                    e.CellStyle.BackColor = (count > 0) ? Color.Orange : Color.White;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            { Hide(); e.Cancel = true; }
            else { Close(); }
            base.OnFormClosing(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Let escape close the form
            Keys keyCode = (keyData & Keys.KeyCode);
            if (keyCode == Keys.Escape) { Hide(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
