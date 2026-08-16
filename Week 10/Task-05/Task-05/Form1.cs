using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (chkOption1.Checked && chkOption2.Checked)
            {
                MessageBox.Show("Both Option 1 and Option 2 are selected");
            }
            else if (chkOption1.Checked)
            {
                MessageBox.Show("Option 1 is selected");
            }
            else if (chkOption2.Checked)
            {
                MessageBox.Show("Option 2 is selected");
            }
            else
            {
                MessageBox.Show("No option is selected");
            }
        }
    }
}
