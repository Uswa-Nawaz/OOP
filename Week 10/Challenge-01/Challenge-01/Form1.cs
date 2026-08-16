using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge_01
{
    public partial class Form1 : Form
    {
        // Color cycle: RED -> GREEN -> BLUE -> RED ...
        private Color[] colors = { Color.Red, Color.Green, Color.Blue };
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            // Set the initial background color of the textbox
            txtDisplay.BackColor = colors[currentIndex];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            txtDisplay.BackColor = colors[currentIndex];
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex - 1 + colors.Length) % colors.Length;
            txtDisplay.BackColor = colors[currentIndex];
        }
    }
}
