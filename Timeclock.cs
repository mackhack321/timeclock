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
        private const string RECORD_FILE = "log.csv";

        private DateTime clockIn;
        private DateTime clockOut;

        public Timeclock()
        {
            InitializeComponent();
        }

        private void logInAs(string ID)
        {
            textBoxEmployeeID.Clear();

            if (string.IsNullOrWhiteSpace(ID))
            {
                MessageBox.Show("Employee ID must have actual characters in it", "Error: Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                labelGreeting.Text = "Hello, " + ID;
                buttonClockIn.Enabled = true;

                buttonLogIn.Enabled = false;
                buttonNewID.Enabled = false;
                textBoxEmployeeID.Enabled = false;
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
                if (!File.Exists(RECORD_FILE))
                {
                    using (StreamWriter file = File.CreateText(RECORD_FILE))
                    {
                        string header = "Employee ID,Time In,Time Out,Duration";
                        file.WriteLine(header);
                        file.Close();
                    }
                }

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

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            employeeID = textBoxEmployeeID.Text;
            logInAs(employeeID);
        }

        private void buttonNewID_Click(object sender, EventArgs e)
        {
            textBoxNewID.Visible = true;
            labelNewID.Visible = true;
            buttonCreateID.Visible = true;
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
            logInAs(textBoxNewID.Text);
        }
    }
}
