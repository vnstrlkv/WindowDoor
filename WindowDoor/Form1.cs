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
using System.Globalization;
namespace WindowDoor
{
    public partial class Form1 : Form
    {
        public static double GetDouble(string value, double defaultValue)
        {
            double result;

            //Try parsing in the current culture
            if (!double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                //Then in neutral language
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
            }

            return result;
        }

        public WinDoor window = new WinDoor();
        public Form1()
        {
            InitializeComponent();
            PriceList priceList = new PriceList();
            priceList.GetPrices();
            dataGridView1.DataSource = priceList.materials;
        }

        private void widthBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void heightBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            window.Height = GetDouble(heightBox.Text,-1);
            window.Width = GetDouble(widthBox.Text, -1);
            window.Name = nameBox1.Text;
            window.Deaf = checkDeaf.Checked;
            window.Pipe = checkPipe1.Checked;
            if (MaterialBox1.SelectedItem != null)
            {
                window.Material = MaterialBox1.SelectedItem.ToString();

                window.Cutting = cuttingbox.Checked;
                string tmp = window.Material;
                Form f = new Form2(window);
                f.Show();
            }
            else
            MessageBox.Show("Ошибка", "Выберите материал", MessageBoxButtons.OK);
        }
        
        private void nameBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkDeaf_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MaterialBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cuttingbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
