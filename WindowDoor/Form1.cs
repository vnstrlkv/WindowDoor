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
using SQLite;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Diagnostics;

//не забыть забиндить данные в окне
namespace WindowDoor
{
    public partial class Form1 : Form
    {

        PriceList priceList = new PriceList();
        Person person = new Person();
        // public WinDoor window = new WinDoor();
        

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

        public Form1()
        {
            InitializeComponent();

           
            priceList.GetPrices();
            CountText.Text = "1";
            comboBox1.DataSource = new double[] { 1.4, 2.0 };
            MaterialBox1.DataSource = priceList.materials ;
            MaterialBox1.DisplayMember = "Name";
            MaterialBox1.BindingContext = BindingContext;

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
               // person.PhoneNumber = phoneNumber.Text + " размер "+ windows.Height.ToString() + " x " + windows.Width.ToString();
            }
            person.PhoneNumber = phoneNumber.Text + " размер " + windows.Width.ToString() + " x " + windows.Height.ToString();
            windows.Deaf = checkDeaf.Checked;
            windows.OpenWindow = openWindow.Checked;
            windows.Pipe = checkPipe1.Checked;
            windows.PaintPipe = paintPipe.Checked;
            windows.FullOpenWindow = fullOpenWindow.Checked;
            windows.Flash = flash1.Checked;
            int k;
            if (MaterialBox1.SelectedItem != null)
                if(int.TryParse(CountText.Text, out k))
            {
                windows.Count = k;
                DataRowView dv = (DataRowView)MaterialBox1.SelectedItem;
                windows.Material = (string)dv.Row["Name"];

                windows.SizeMaterial =(double)comboBox1.SelectedItem;
                windows.Cutting = cuttingbox.Checked;
                person.Windows.Add(windows);

                Form f = new Form2(person);
                f.Show();
            }
            else
            MessageBox.Show("Выберите материал и введите корректное количество окон", "Ошибка", MessageBoxButtons.OK);
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

        private void saveClient_Click(object sender, EventArgs e)
        {
            WinDoor windows = new WinDoor();
            windows.Height = GetDouble(heightBox.Text, 0);
            windows.Width = GetDouble(widthBox.Text, 0);
            windows.Delivery = GetDouble(delivery.Text, 0);
            windows.InstallWindow = GetDouble(installWindow.Text, 0);
            windows.Metering = GetDouble(metering.Text, 0);
            if (person.FirstName != nameBox1.Text || person.SecondName != nameBox2.Text)
            {
                person = new Person();
                person.FirstName = nameBox1.Text;
                person.SecondName = nameBox2.Text;
                // person.PhoneNumber = phoneNumber.Text + " размер "+ windows.Height.ToString() + " x " + windows.Width.ToString();
            }
            person.PhoneNumber = phoneNumber.Text + " размер " + windows.Width.ToString() + " x " + windows.Height.ToString();
            windows.Deaf = checkDeaf.Checked;
            windows.OpenWindow = openWindow.Checked;
            windows.Pipe = checkPipe1.Checked;
            windows.PaintPipe = paintPipe.Checked;
            windows.FullOpenWindow = fullOpenWindow.Checked;
            windows.Flash = flash1.Checked;
            int k;
            if (MaterialBox1.SelectedItem != null)
                if (int.TryParse(CountText.Text, out k))
                {
                    windows.Count = k;
                    DataRowView dv = (DataRowView)MaterialBox1.SelectedItem;
                    windows.Material = (string)dv.Row["Name"];

                    windows.SizeMaterial = (double)comboBox1.SelectedItem;
                    windows.Cutting = cuttingbox.Checked;
                    person.Windows.Add(windows);
                }
        



            Person client = person;
            string path = DateTime.Today.ToString("dd.MM.yyyy");
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }



            FileInfo newFile = new FileInfo(DateTime.Today.ToString("dd.MM.yyyy") + "\\" + client.Name() + ".xlsx");
            using (ExcelPackage pck = new ExcelPackage(newFile))
            {
                var format = new ExcelTextFormat();
                format.Delimiter = '/';

                int l = pck.Workbook.Worksheets.Count + 1;
                if (pck.Workbook.Worksheets[1].Cells["A3"].ToString() != "ВСЕГО")
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(l.ToString());
                    ws.Cells["A1"].LoadFromText(client.Name());
                    ws.Cells["A2"].LoadFromText(client.PhoneNumber, format);
                    ws.Cells["A3"].LoadFromText("ВСЕГО");
                    DataTable windowCalculating = new DataTable();
                    windowCalculating.Columns.Add("Наименование", typeof(string)); //0
                    windowCalculating.Columns.Add("Ед.Изм", typeof(string)); //1
                    windowCalculating.Columns.Add("Цена", typeof(double));//2

                    windowCalculating.Columns.Add("S", typeof(double));//3
                    windowCalculating.Columns.Add("Стоимость за единицу", typeof(double));//4
                    windowCalculating.Columns.Add("Количество", typeof(double));//5
                    windowCalculating.Columns.Add("Всего", typeof(double));//6
                    windowCalculating.Rows.Add();
                    DataRow[] tmpmat = GetMaterialFromPricelist(client.Windows[0].Material, priceList, "Name");
                    if (tmpmat != null)
                        for (int n = 0; n < 3; n++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][n] = tmpmat[0][n];
                    windowCalculating.Rows.Add();
  

                    tmpmat = GetMaterialFromPricelist("Люверс 6мм", priceList, "Name");
                    if (tmpmat != null)
                        for (int n = 0; n < 3; n++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][n] = tmpmat[0][n];
                    windowCalculating.Rows.Add();
    
                    tmpmat = GetMaterialFromPricelist("Люверсы 42*22", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows.Add();
                    tmpmat = GetMaterialFromPricelist("Скоба поворотная", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows.Add();
                    tmpmat = GetMaterialFromPricelist("Труба профильная железо 15 х 15 х 1,5; Длина 6 м", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows.Add();
                    tmpmat = GetMaterialFromPricelist("Молния трактор", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows.Add();
                    tmpmat = GetMaterialFromPricelist("Установка люверса 6мм", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows.Add();
                    tmpmat = GetMaterialFromPricelist("Установка люверсов 42*22", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows.Add();
                    tmpmat = GetMaterialFromPricelist("Грунт трубы", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows.Add();
                    tmpmat = GetMaterialFromPricelist("Пошив молнии", priceList, "Name");
                    if (tmpmat != null)
                        for (int i = 0; i < 3; i++)
                            windowCalculating.Rows[windowCalculating.Rows.Count - 1][i] = tmpmat[0][i];
                    windowCalculating.Rows.Add();
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][0] = "Замер";
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = -client.Windows[0].Metering;
                    windowCalculating.Rows.Add();
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][0] = "Доставка";
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = client.Windows[0].Delivery;
                    windowCalculating.Rows.Add();
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][0] = "Монтаж";
                    windowCalculating.Rows[windowCalculating.Rows.Count - 1][4] = client.Windows[0].InstallWindow;
                    windowCalculating.Rows.Add();







                    ws.Cells["A4"].LoadFromDataTable(windowCalculating, true);



                    for (int cel = 5; cel < 17; cel++)
                    { string tmp="=";
                        for (int book = 1; book < pck.Workbook.Worksheets.Count; book++)
                        {
                            var sheet = pck.Workbook.Worksheets[book];
                            for (int cel2 = 5; cel2 < 17; cel2++)
                                if (sheet.Cells["A" + cel2].Value != null && ws.Cells["A" + cel].Value!=null) 
                                    
                                if (ws.Cells["A" + cel].Value.ToString() == sheet.Cells["A" + cel2].Value.ToString())
                                {
                                    tmp += "'"+sheet.Name + "'!"+sheet.Cells["D" + cel2].ToString() + "*" + "'" + sheet.Name + "'!" + sheet.Cells["F" + cel2].ToString() + "+";
                                    break;
                                }//D*F
                            
                        }
                        if (tmp != "=") 
                        ws.Cells["D" + cel].Formula = tmp.TrimEnd('+');
                        ws.Cells["E" + cel].Formula = "C" + cel+"*"+"D"+cel;
                    }


                
                    int j = 5;
                    while (ws.Cells["A" + j.ToString()].Text != "Замер")
                    {
                        ws.Cells["E" + l.ToString()].FormulaR1C1 = "=RC[-1]*RC[-2]";
                        j++;
                    }
                    j = j + 3;
                    ws.Cells["E" + j.ToString()].FormulaR1C1 = "=SUM(R[-" + (j - 5).ToString() + "]C:R[-1]C)";

                

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
            }
          //  this.Close();




    
        }

        DataRow[] GetMaterialFromPricelist(string name, PriceList priceList, string type)
        {
            DataRow[] dt = priceList.materials.Select(type + " = '" + name + "'");
            DataRow[] dr = dt;
            return dt;
        }

        private void BDbutton_Click(object sender, EventArgs e)
        {

            Form f = new Form3();
            f.Show();
        }

        private void flash1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PriceButton_Click(object sender, EventArgs e)
        {
            // Form f = new PriceForm();
            // f.Show();
            /*
            PriceList pG = new PriceList();
            pG.GetPricesGoogle();

            FileInfo newFile = new FileInfo("price.xlsx");
            //  newFile.Delete();
            using (ExcelPackage pck = new ExcelPackage(newFile))
            {

                ExcelWorksheet ws = pck.Workbook.Worksheets[1];
                ws.Cells["A1"].LoadFromDataTable(pG.materials, true);


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
            priceList.GetPrices();
            MaterialBox1.DataSource = null;
            MaterialBox1.Items.Clear();
            MaterialBox1.DataSource = priceList.materials;
            MaterialBox1.DisplayMember = "Name";
            MaterialBox1.BindingContext = BindingContext;
            MaterialBox1.Update();
            */
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MaterialBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string s = Application.StartupPath + "\\" + DateTime.Today.ToString("dd.MM.yyyy");
                Process.Start(s);
            }
            catch { Process.Start(Application.StartupPath); }

        }
    }
    
}
