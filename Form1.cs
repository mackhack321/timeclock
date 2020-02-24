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
    public class Employee
    { 
        private string employeeID { get; set; }
        private string fname { get; set; }
        private string lname { get; set; }
    }
    public partial class Timeclock : Form
    {
        public Timeclock()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            buttonClockIn.Enabled = true;
        }
    }
}
