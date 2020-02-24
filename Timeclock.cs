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

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            buttonClockIn.Enabled = true;
        }

        private void buttonNewID_Click(object sender, EventArgs e)
        {
            textBoxNewID.Visible = true;
            labelNewID.Visible = true;
            buttonCreateID.Visible = true;
        }
    }
}
