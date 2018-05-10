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
    public partial class Form2 : Form
    {
        public Form2(WinDoor window)
        {
            InitializeComponent();
          
            textBox1.Text = window.Name + "\n Периметр = "+ window.Perimeter()+ "\n Площадь = "+window.Square();
            PriceList priceList = new PriceList();
            priceList.GetPrices();

            DataTable windowCalculating = new DataTable();
            windowCalculating.Columns.Add("Наименование", typeof(string)); //0
            windowCalculating.Columns.Add("Ед.Изм", typeof(string)); //1
            windowCalculating.Columns.Add("Цена", typeof(double));//2
           
            windowCalculating.Columns.Add("S", typeof(double));//3
            windowCalculating.Columns.Add("Стоимость СК", typeof(double));//4


            try
            {

                if (window.Deaf)
                {
                    if (window.Pipe)
                    {
                        windowCalculating.Rows.Add();
                        string tmp = priceList.materials.Rows[0][0].ToString();
                        tmp=null;
                        string tmp2 = window.Material;
                        //Добавляем материал
                        DataRow[] tmpmat = priceList.materials.Select("Name = '" + window.Material + "'");
                        if (tmpmat != null)
                            for (int i = 0; i < 3; i++)
                                windowCalculating.Rows[0][i] = tmpmat[0][i];


                    }
                    else
                    {

                    }
                }
                else
                {

                }
                dataGridView1.DataSource = windowCalculating;
                dataGridView1.Update();
            }
            catch
            {
                dataGridView1.DataSource = priceList.materials;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
