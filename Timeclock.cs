using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timeclock
{
    public partial class Timeclock : Form
    {
        private string employeeID;
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
        }

        private void buttonClockOut_Click(object sender, EventArgs e)
        {
            buttonClockOut.Enabled = false;
            buttonClockIn.Enabled = true;
        }

        private void buttonCreateID_Click(object sender, EventArgs e)
        {
            logInAs(textBoxNewID.Text);
        }
    }
}
