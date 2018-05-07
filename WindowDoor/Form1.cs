using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDoors;
using Prices;

namespace WindowDoor
{
    public partial class Form1 : Form
    {
        public WinDoor window = new WinDoor();
        public Form1()
        {
            InitializeComponent();
         
        }

        private void widthBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void heightBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            window.Height = Convert.ToDouble(heightBox.Text);
            window.Width = Convert.ToDouble(widthBox.Text);
            window.Name = nameBox1.Text;
            window.Square();
            window.Perimeter();
            Form f = new Form2(window);
            f.Show();
        }

        private void nameBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
