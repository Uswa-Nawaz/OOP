using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_04
{
    public partial class lblName2 : Form
    {
        public lblName2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblName1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name1 = txtName1.Text;
            string name2 = txtName2.Text;

            if (name1 == name2)
            {
                MessageBox.Show("The names are the Same");
            }
            else
            {
                MessageBox.Show("The names are Different");
            }
        }
    }
}
