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

                double size = 1.5;
                double sizeMaterial = 1.4;
                windowCalculating.Rows.Add();
                //Добавляем материал
                DataRow[] tmpmat = GetMaterialFromPricelist(window.Material, priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[0][i] = tmpmat[0][i];
                windowCalculating.Rows.Add();
                //Расчет материала
                windowCalculating.Rows[0][3] = window.Square();
                if (window.Width <= size && window.Height <= size)
                    if (window.Width >= window.Height)
                        windowCalculating.Rows[0][3] = Math.Ceiling(window.Width / size * sizeMaterial) * window.Height;
                    else windowCalculating.Rows[0][3] = Math.Ceiling(window.Height / size * sizeMaterial) * window.Width;

                else if (window.Width > size && window.Height <= size)
                    windowCalculating.Rows[0][3] = Math.Ceiling(window.Height / size * sizeMaterial) * window.Width;

                else if (window.Width <= size && window.Height > size)
                    windowCalculating.Rows[0][3] = Math.Ceiling(window.Width / size * sizeMaterial) * window.Height;

                else if (window.Width > size && window.Height > size)
                    if (window.Cutting == false)
                        windowCalculating.Rows[0][3] = Math.Ceiling(window.Width / size * sizeMaterial) * window.Height;
                    else windowCalculating.Rows[0][3] = Math.Ceiling(window.Height / size * sizeMaterial) * window.Width;
                windowCalculating.Rows[0][4] =Convert.ToDouble(windowCalculating.Rows[0][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[0][2].ToString());

                if (window.Deaf)
                {                                        
                       //люверс 6мм
                        tmpmat = GetMaterialFromPricelist("Люверс 6мм", priceList);
                        if (tmpmat != null)
                            for (int i = 0; i < 3; i++)
                                windowCalculating.Rows[1][i] = tmpmat[0][i];
                        windowCalculating.Rows.Add();
                //    windowCalculating.Rows[1];
                        //установка люверсов
                        tmpmat = GetMaterialFromPricelist("Установка люверса 6мм", priceList);
                        if (tmpmat != null)
                            for (int i = 0; i < 3; i++)
                                windowCalculating.Rows[2][i] = tmpmat[0][i];
                        windowCalculating.Rows.Add();
                    
                 }

                else
                {

                }
                foreach (DataRow dr in windowCalculating.Rows)
                {

                    dataGridView1.Rows.Add(dr.ItemArray);

                }
                dataGridView1.Update();
            }
            catch
            {
                dataGridView1.DataSource = priceList.materials;
            }
        }

        DataRow[] GetMaterialFromPricelist (string name, PriceList priceList)
        {

            return priceList.materials.Select("Name = '" + name + "'");
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
