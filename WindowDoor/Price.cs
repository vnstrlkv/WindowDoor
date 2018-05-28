using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Data;
namespace Prices
{
    class Material
    {
        public string Name { get; set; }
        public string Metr { get; set; }
        public double Price { get; set; }
    }

    class PriceList
    {
        public DataTable materials;
        public void GetPrices()
        {
            FileInfo newFile = new FileInfo("price.xlsx");
            ExcelPackage package = new ExcelPackage(newFile);
            ExcelWorksheet osheet = package.Workbook.Worksheets[1];
            materials = WorksheetToDataTable(osheet);
        }

        private DataTable WorksheetToDataTable(ExcelWorksheet oSheet)
        {
            int totalRows = oSheet.Dimension.End.Row;
            int totalCols = oSheet.Dimension.End.Column;
            DataTable dt = new DataTable(oSheet.Name);
            DataRow dr = null;
            for (int i = 1; i <= totalRows; i++)
            {
                if (i > 1) dr = dt.Rows.Add();
                for (int j = 1; j <= totalCols; j++)
                {
                    if (i == 1)
                        dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());
                    else
                        if (oSheet.Cells[i, j].Value!=null)
                        dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
                }
            }
            return dt;
        }
    }
}
