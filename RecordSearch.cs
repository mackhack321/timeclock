using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Timeclock
{
    public partial class RecordSearch : Form
    {
        public RecordSearch()
        {
            InitializeComponent();
        }

        private void populateTable()
        {
            dataGridViewRecords.Rows.Clear();
            dataGridViewRecords.Columns.Clear();
            dataGridViewRecords.Refresh();

            string line;
            List<string[]> lines = new List<string[]>();
            try
            {
                using (StreamReader file = new StreamReader(Timeclock.RECORD_FILE))
                {
                    string[] header = file.ReadLine().Split(',');
                    dataGridViewRecords.Columns.Add("id", header[0]);
                    dataGridViewRecords.Columns.Add("timein", header[1]);
                    dataGridViewRecords.Columns.Add("timeout", header[2]);
                    dataGridViewRecords.Columns.Add("duration", header[3]);

                    while ((line = file.ReadLine()) != null)
                    {
                        lines.Add(line.Split(','));
                    }

                    file.Close();
                }

                for (int i = 0; i < lines.Count; i++)
                {
                    dataGridViewRecords.Rows.Add(lines[i][0], lines[i][1], lines[i][2], lines[i][3]);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Could not open record file.  Please make sure the file is not opened in another program.", "ERROR: Could Not Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecordSearch_Load(object sender, EventArgs e)
        {
            populateTable();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string id = textBoxEnterID.Text;
            List<DataGridViewRow> results = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridViewRecords.Rows)
            {
                if ((string)row.Cells[0].Value == id) { results.Add(row); }
            }

            if (results.Count == 0)
            {
                MessageBox.Show("Found no results.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                foreach (DataGridViewRow row in results)
                {
                    if (!results.Contains(row))
                    {
                        dataGridViewRecords.Rows.Remove(row);
                    } 
                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            populateTable();
        }
    }
}
