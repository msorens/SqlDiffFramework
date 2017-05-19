using System.Drawing;
using System.Windows.Forms;
using CleanCode.DataGridViewControls;
using System.Collections.Generic;

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
