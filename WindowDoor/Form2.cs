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

            windowCalculating = Calculate(windowCalculating, window);

            try
            {

                
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

        DataTable Calculate(DataTable windowCalculating, WinDoor window)
        {
            PriceList priceList = new PriceList();
            priceList.GetPrices();

            double size = 1.5;
            double sizeMaterial = 1.4;
            windowCalculating.Rows.Add();
            //Добавляем материал
            DataRow[] tmpmat = GetMaterialFromPricelist(window.Material, priceList);
            if (tmpmat != null)
                for (int i = 0; i < 3; i++)
                    windowCalculating.Rows[windowCalculating.Rows.Count-1][i] = tmpmat[0][i];
            //Расчет материала
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = window.Square();
            if (window.Width <= size && window.Height <= size)
                if (window.Width >= window.Height)
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Width / size * sizeMaterial) * window.Height;
                else windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Height / size * sizeMaterial) * window.Width;

            else if (window.Width > size && window.Height <= size)
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Height / size * sizeMaterial) * window.Width;

            else if (window.Width <= size && window.Height > size)
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Width / size * sizeMaterial) * window.Height;

            else if (window.Width > size && window.Height > size)
                if (window.Cutting == false)
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Width / size * sizeMaterial) * window.Height;
                else windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Height / size * sizeMaterial) * window.Width;
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

            windowCalculating.Rows.Add();

            if (window.Deaf)
            {
                //люверс 6мм
                tmpmat = GetMaterialFromPricelist("Люверс 6мм", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Perimeter() / 0.3);
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                //    Работа;
                //установка люверсов
                tmpmat = GetMaterialFromPricelist("Установка люверса 6мм", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Люверс 6мм'")[0][3];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();
            }

            else
            {

                tmpmat = GetMaterialFromPricelist("Люверс 6мм", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
               
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Width / 0.3);
              
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                tmpmat = GetMaterialFromPricelist("Люверсы 42*22", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
             
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling((window.Height - 0.4) / 0.4*2);
               
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();


                tmpmat = GetMaterialFromPricelist("Скоба поворотная", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling((window.Height - 0.4) / 0.4 * 2);

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();


                if (window.Pipe)
                {
                    double pipeSize = Math.Ceiling(window.Width);
                    tmpmat = GetMaterialFromPricelist("Труба профильная железо 15 х 15 х 1,5; Длина 6 м", priceList);
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];

                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(pipeSize);

                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                    windowCalculating.Rows.Add();
                }

                //    Работа;
                //установка люверсов
                tmpmat = GetMaterialFromPricelist("Установка люверса 6мм", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Люверс 6мм'")[0][3];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                tmpmat = GetMaterialFromPricelist("Установка люверсов 42*22", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Люверсы 42*22'")[0][3];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                if (window.PaintPipe && window.Pipe)
                {
                    tmpmat = GetMaterialFromPricelist("Грунт трубы", priceList);
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Труба профильная железо 15 х 15 х 1,5; Длина 6 м'")[0][3];
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());
                }

            }



            return windowCalculating;
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
