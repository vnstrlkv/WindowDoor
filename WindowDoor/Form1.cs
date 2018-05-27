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
using Personal;
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

        Person person = new Person();
       // public WinDoor window = new WinDoor();
        public Form1()
        {
            InitializeComponent();
            PriceList priceList = new PriceList();
            priceList.GetPrices();
        }

        private void widthBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void heightBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            WinDoor windows = new WinDoor();
            windows.Height = GetDouble(heightBox.Text,0);
            windows.Width = GetDouble(widthBox.Text, 0);
            windows.Delivery = GetDouble(delivery.Text, 0);
            windows.InstallWindow = GetDouble(installWindow.Text, 0);
            windows.Metering = GetDouble(metering.Text, 0);
            if (person.FirstName != nameBox1.Text || person.SecondName != nameBox2.Text)
            {
                person = new Person();
                person.FirstName = nameBox1.Text;
                person.SecondName = nameBox2.Text;
                person.PhoneNumber = phoneNumber.Text;
            }
            windows.Deaf = checkDeaf.Checked;
            windows.OpenWindow = openWindow.Checked;
            windows.Pipe = checkPipe1.Checked;
            windows.PaintPipe = paintPipe.Checked;
            windows.FullOpenWindow = fullOpenWindow.Checked;

            if (MaterialBox1.SelectedItem != null)
            {
                windows.Material = MaterialBox1.SelectedItem.ToString();

                windows.Cutting = cuttingbox.Checked;
                person.Windows.Add(windows);

                Form f = new Form2(person);
                f.Show();
            }
            else
            MessageBox.Show("Выберите материал", "Ошибка", MessageBoxButtons.OK);
        }
        
        private void nameBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkDeaf_CheckedChanged(object sender, EventArgs e)
        {
           
            //checkDeaf.Checked = true;
            openWindow.Checked = false;
            paintPipe.Checked = false;
            checkPipe1.Checked = false;
            fullOpenWindow.Checked = false;
        }

        private void MaterialBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cuttingbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void paintPipe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkPipe1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openWindow_CheckedChanged(object sender, EventArgs e)
        {
            checkDeaf.Checked = false;
        //   openWindow.Checked = true;
          //  paintPipe.Checked = false;
          //  checkPipe1.Checked = false;
            fullOpenWindow.Checked = false;
        }

        private void fullOpenWindow_CheckedChanged(object sender, EventArgs e)
        {
            checkDeaf.Checked = false;
            openWindow.Checked = false;
            paintPipe.Checked = false;
            checkPipe1.Checked = false;
        //    fullOpenWindow.Checked = true;

        }
    }
}
