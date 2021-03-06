﻿using System;
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
        PriceList priceList = new PriceList();
        public Form2(Person person)
        {
            InitializeComponent();
            client = person;
            textBox1.Text = person.SecondName+" "+person.FirstName + " " +person.PhoneNumber;
            WinDoor window = person.Windows[person.Windows.Count-1];

            priceList.GetPrices();

            windowCalculating = new DataTable();
            windowCalculating.Columns.Add("Наименование", typeof(string)); //0
            windowCalculating.Columns.Add("Ед.Изм", typeof(string)); //1
            windowCalculating.Columns.Add("Цена", typeof(double));//2
           
            windowCalculating.Columns.Add("S", typeof(double));//3
            windowCalculating.Columns.Add("Стоимость за единицу", typeof(double));//4
            windowCalculating.Columns.Add("Количество", typeof(double));//5
            windowCalculating.Columns.Add("Всего", typeof(double));//6


            windowCalculating = Calculate(windowCalculating, window);
            person.Windows[person.Windows.Count - 1].Summ = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][4].ToString());

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
            double size = window.Size;
            double sizeMaterial = window.SizeMaterial;
            windowCalculating.Rows.Add();
            //Добавляем материал
            DataRow[] tmpmat = GetMaterialFromPricelist(window.Material, priceList, "Name");
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
                tmpmat = GetMaterialFromPricelist("Люверс 6мм", priceList, "Name");
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Perimeter() / 0.3);
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                //    Работа;
                //установка люверсов
                tmpmat = GetMaterialFromPricelist("Установка люверса 6мм", priceList, "Name");
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

                tmpmat = GetMaterialFromPricelist("Люверс 6мм", priceList, "Name");
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
               
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(window.Width / 0.3);
              
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                tmpmat = GetMaterialFromPricelist("Люверсы 42*22", priceList, "Name");
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
             
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling((window.Height - 0.4) / 0.4*2);
               
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();


                tmpmat = GetMaterialFromPricelist("Скоба поворотная", priceList, "Name");
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling((window.Height - 0.4) / 0.4 * 2);

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();


                if (window.Pipe)
                {
                    double pipeSize = Math.Ceiling(window.Width);
                    tmpmat = GetMaterialFromPricelist("Труба профильная железо 15 х 15 х 1,5; Длина 6 м", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];

                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(pipeSize);

                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                    windowCalculating.Rows.Add();
                }

                if (window.Flash)
                {
                    double flashSize = Math.Ceiling(window.Height);
                    tmpmat = GetMaterialFromPricelist("Молния трактор", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];

                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling(flashSize);

                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                    windowCalculating.Rows.Add();
                }

                //    Работа;
                //установка люверсов
                tmpmat = GetMaterialFromPricelist("Установка люверса 6мм", priceList, "Name");
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Люверс 6мм'")[0][3];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][2] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString()) * BK;
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                tmpmat = GetMaterialFromPricelist("Установка люверсов 42*22", priceList, "Name");
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Люверсы 42*22'")[0][3];
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][2] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString()) * BK;
                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                if (window.PaintPipe && window.Pipe)
                {
                    tmpmat = GetMaterialFromPricelist("Грунт трубы", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Труба профильная железо 15 х 15 х 1,5; Длина 6 м'")[0][3];
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][2] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString()) * BK;
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());
                    windowCalculating.Rows.Add();
                }
                if (window.Flash)
                {
                    tmpmat = GetMaterialFromPricelist("Пошив молнии", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = windowCalculating.Select("Наименование = 'Молния трактор'")[0][3];
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][2] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString()) * BK;
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());
                    windowCalculating.Rows.Add();
                }



            }

            else if (window.FullOpenWindow)
            {
                tmpmat = GetMaterialFromPricelist("Люверсы 42*22", priceList, "Name");
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling((window.Perimeter()) / 0.4);

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                tmpmat = GetMaterialFromPricelist("Скоба поворотная", priceList, "Name");
                if (tmpmat != null)
                    for (int i = 0; i < 3; i++)
                        windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][3] = Math.Ceiling((window.Perimeter()) / 0.4);

                windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][3].ToString()) * Convert.ToDouble(windowCalculating.Rows[windowCalculating.Rows.Count - 1][2].ToString());

                windowCalculating.Rows.Add();

                tmpmat = GetMaterialFromPricelist("Установка люверсов 42*22", priceList, "Name");
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
            double summ2 = 0;
            foreach (DataRow dr in windowCalculating.Rows)
            {
                double k;
                if (Double.TryParse(dr[4].ToString(), out k))
                {
                    summ += Convert.ToDouble(dr[4]);
                    dr[5] = window.Count;
                    dr[6] = double.Parse(dr[5].ToString()) * double.Parse(dr[4].ToString());
                    summ2 += Convert.ToDouble(dr[6]); 
                }
            }
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = Math.Ceiling(summ);
            windowCalculating.Rows[windowCalculating.Rows.Count - 1][6] = Math.Ceiling(summ2);
            return windowCalculating;
        }
        
        DataRow[] GetMaterialFromPricelist (string name, PriceList priceList, string type)
        {
            DataRow [] dt = priceList.materials.Select(type+" = '" + name + "'");
            DataRow[] dr = dt;
            return dt;
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
                var format = new ExcelTextFormat();
                format.Delimiter = '/';
                int k =pck.Workbook.Worksheets.Count;
                ExcelWorksheet ws = null;
                if (k==0)
                {
                    k++;
                    ws = pck.Workbook.Worksheets.Add(k.ToString());
                }
                else
                {
                    ws = pck.Workbook.Worksheets[1];
                }
              
                
                ws.Cells["A1"].LoadFromText(client.Name());
                ws.Cells["A2"].LoadFromText(client.PhoneNumber, format);

                string freecell = null;
                int i = 5;
                for (int n =5 ; i < 1000; n++)
                {
                   
                    if (ws.Cells["A" + n].Text.ToString()== "")
                    {
                       i=n;
                        freecell = "A" + i;
                        break;
                    }

                }

                ws.Cells[freecell].LoadFromDataTable(windowCalculating, true);
                //int u = 5;
                while (ws.Cells["A" + i.ToString()].Text != "Замер")
                {
                    ws.Cells["E" + i.ToString()].FormulaR1C1 = "=RC[-1]*RC[-2]";
                    i++;
                }
                i = i + 3;
                ws.Cells["E" + i.ToString()].FormulaR1C1 = "=SUM(R[-" + (i-5).ToString()+"]C:R[-1]C)";
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
