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
using Personal;
using OfficeOpenXml;
using System.IO;
using System.Data;
using OfficeOpenXml.Style;
using System.Drawing;

namespace WindowDoor
{
    public partial class Form2 : Form
    {
        public static DataTable windowCalculating;
        public static Person client;

        public Form2(Person person)
        {
            InitializeComponent();
            client = person;
            textBox1.Text = person.SecondName+" "+person.FirstName;
            WinDoor window = person.Windows[person.Windows.Count-1];
            PriceList priceList = new PriceList();
            priceList.GetPrices();

            windowCalculating = new DataTable();
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
            double BK = 1.13;
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
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Width / size) * sizeMaterial * window.Height;
                else windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Height / size) * sizeMaterial * window.Width;

            else if (window.Width > size && window.Height <= size)
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Height / size) * sizeMaterial * window.Width;

            else if (window.Width <= size && window.Height > size)
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Width / size) * sizeMaterial * window.Height;

            else if (window.Width > size && window.Height > size)
                if (window.Cutting == false)
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Width / size) * sizeMaterial * window.Height;
                else windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Height / size) * sizeMaterial * window.Width;
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
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][2] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString()) * BK;
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();
            }

            else if (window.OpenWindow)
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
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][2] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString()) * BK;
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                tmpmat = GetMaterialFromPricelist("Установка люверсов 42*22", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Люверсы 42*22'")[0][3];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][2] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString()) * BK;
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                if (window.PaintPipe && window.Pipe)
                {
                    tmpmat = GetMaterialFromPricelist("Грунт трубы", priceList);
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Труба профильная железо 15 х 15 х 1,5; Длина 6 м'")[0][3];
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][2] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString()) * BK;
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());
                }

               

            }

            else if (window.FullOpenWindow)
            {
                tmpmat = GetMaterialFromPricelist("Люверсы 42*22", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling((window.Perimeter()) / 0.4 * 2);

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                tmpmat = GetMaterialFromPricelist("Скоба поворотная", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling((window.Height) / 0.4 * 2);

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                tmpmat = GetMaterialFromPricelist("Установка люверсов 42*22", priceList);
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Люверсы 42*22'")[0][3];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][2] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString()) * BK;
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();
            }


            //ДОСТАВКА И МОНТАЖ
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][0] = "Замер";
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = -window.Metering;
            windowCalculating.Rows.Add();
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][0] = "Доставка";
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = window.Delivery;
            windowCalculating.Rows.Add();
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][0] = "Монтаж";
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = window.InstallWindow;
            windowCalculating.Rows.Add();

            //ИТОГО
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][0] = "ИТОГО";
            double summ=0;
            foreach (DataRow dr in windowCalculating.Rows)
            {
                double k;
                if (Double.TryParse(dr[4].ToString(), out k))
                summ +=Convert.ToDouble(dr[4]);
            }
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Math.Ceiling(summ);

            return windowCalculating;
        }

        DataRow[] GetMaterialFromPricelist (string name, PriceList priceList)
        {

            return priceList.materials.Select("Name = '" + name + "'");
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string path =  DateTime.Today.ToString("dd.MM.yyyy");
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

          

            FileInfo newFile = new FileInfo(DateTime.Today.ToString("dd.MM.yyyy")+"\\"+client.Name()+".xlsx");
            using (ExcelPackage pck = new ExcelPackage(newFile))
            {

                int k =pck.Workbook.Worksheets.Count;
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(k.ToString());
                ws.Cells["A1"].LoadFromText(client.Name());
                ws.Cells["A2"].LoadFromText(client.PhoneNumber);
                ws.Cells["A3"].LoadFromDataTable(windowCalculating, true);


                ws.Cells.Style.Font.Size = 12; // Размер шрифта по умолчанию для всего листа
                ws.Cells.Style.Font.Name = "Times New Roman"; // Default Имя шрифта для всего листа

                using (var cells = ws.Cells[ws.Dimension.Address])
                {
                    cells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    cells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    cells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    cells.AutoFitColumns();
                }
               
                pck.Save();
            }
            this.Close();
            
        }
    }
}
