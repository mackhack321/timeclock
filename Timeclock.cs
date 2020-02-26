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
    public partial class Timeclock : Form
    {
        private string employeeID;
        public const string RECORD_FILE = "log.csv";
        public const string CREDS_FILE = "creds.csv";

        private DateTime clockIn;
        private DateTime clockOut;

        public Timeclock()
        {
            InitializeComponent();
        }

        private bool verifyCreds(string ID, string password)
        {
            string line;
            List<string[]> lines = new List<string[]>();
            try
            {
                using (StreamReader file = new StreamReader(CREDS_FILE))
                {
                    file.ReadLine(); // skip header

                    while ((line = file.ReadLine()) != null)
                    {
                        lines.Add(line.Split(','));
                    }

                    file.Close();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Could not open credentials file.  Please make sure the file is not opened in another program.", "ERROR: Could Not Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i][0] == ID && lines[i][1] == password) { return true;  }
            }

            return false;
        }

        private void showEmployeeCreation()
        {
            textBoxNewID.Visible = true;
            textBoxNewPassword.Visible = true;

            buttonCreateID.Visible = true;

            labelNewID.Visible = true;
            labelNewPassword.Visible = true;
        }

        private void hideEmployeeCreation()
        {
            textBoxNewID.Visible = false;
            textBoxNewPassword.Visible = false;

            buttonCreateID.Visible = false;

            labelNewID.Visible = false;
            labelNewPassword.Visible = false;
        }

        private void logInAs(string ID, string password)
        {
            textBoxEmployeeID.Clear();
            textBoxPassword.Clear();

            employeeID = ID;

            if (string.IsNullOrWhiteSpace(ID))
            {
                MessageBox.Show("Employee ID must have actual characters in it", "Error: Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (verifyCreds(ID, password))
                {
                    labelGreeting.Text = "Hello, " + ID;
                    buttonClockIn.Enabled = true;

                    buttonLogIn.Enabled = false;
                    buttonNewID.Enabled = false;
                    textBoxEmployeeID.Enabled = false;
                    textBoxPassword.Enabled = false;

                    if (ID.EndsWith("_mgr"))
                    {
                        buttonOpenRecordExt.Visible = true;
                        buttonOpenLogView.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Employee ID or Password incorrect", "ERROR: Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string timeBetweenStamps(DateTime a, DateTime b)
        {
            TimeSpan timeSpan = b - a;
            return $"{timeSpan.Hours} hr(s) {timeSpan.Minutes} min(s) {timeSpan.Seconds} sec(s)";
        }

        private void logInAndOut(DateTime timeIn, DateTime timeOut)
        {
            string data = $"{employeeID},{timeIn},{timeOut},{timeBetweenStamps(timeIn, timeOut)}";

            try
            {
                using (StreamWriter file = File.AppendText(RECORD_FILE))
                {
                    file.WriteLine(data);
                    file.Close();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Could not open record file.  Please make sure the file is not opened in another program.", "ERROR: Could Not Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void makeNewEmployee(string ID, string password)
        {
            try
            {
                using (StreamWriter file = File.AppendText(CREDS_FILE))
                {
                    file.WriteLine($"{ID},{password}");
                    file.Close();

                    MessageBox.Show($"Created Employee ID {ID} with password {password}", "Employee Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    logInAs(ID, password);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Could not open credentials file.  Please make sure the file is not opened in another program.", "ERROR: Could Not Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            logInAs(textBoxEmployeeID.Text, textBoxPassword.Text);
        }

        private void buttonNewID_Click(object sender, EventArgs e)
        {
            showEmployeeCreation();
        }

        private void buttonClockIn_Click(object sender, EventArgs e)
        {            
            buttonClockIn.Enabled = false;
            buttonClockOut.Enabled = true;

            clockIn = DateTime.Now;
        }

        private void buttonClockOut_Click(object sender, EventArgs e)
        {
            buttonClockOut.Enabled = false;
            buttonClockIn.Enabled = true;

            clockOut = DateTime.Now;

            logInAndOut(clockIn, clockOut);
        }

        private void buttonCreateID_Click(object sender, EventArgs e)
        {
            makeNewEmployee(textBoxNewID.Text, textBoxNewPassword.Text);
            hideEmployeeCreation();
        }

        private void buttonOpenRecordExt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(RECORD_FILE);
        }

        private void buttonOpenLogView_Click(object sender, EventArgs e)
        {
            RecordSearch recordSearch = new RecordSearch();
            recordSearch.Show();
        }

        private void Timeclock_Load(object sender, EventArgs e)
        {
            if (!File.Exists(CREDS_FILE))
            {
                using (StreamWriter file = File.CreateText(CREDS_FILE))
                {
                    string header = "Employee ID,Password";
                    file.WriteLine(header);
                    file.Close();
                }
            }

            if (!File.Exists(RECORD_FILE))
            {
                using (StreamWriter file = File.CreateText(RECORD_FILE))
                {
                    string header = "Employee ID,Time In,Time Out,Duration";
                    file.WriteLine(header);
                    file.Close();
                }
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) { buttonLogIn.PerformClick(); }
        }

        private void textBoxNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) { buttonCreateID.PerformClick(); }
        }
    }
}
