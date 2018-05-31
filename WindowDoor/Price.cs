using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
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
        public DataTable materials { get; set;}

        public void GetPricesGoogle()
        {
             string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
            string ApplicationName = "WindowsDoors";           
                UserCredential credential;

                using (var stream =
                    new FileStream("client_id.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Google Sheets API service.
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // Define request parameters.
                String spreadsheetId = "1St3ncTv58_rLWLWtT8LnOQyu1ddAPTW9BoghcuwgDBM";
                String range = "1!A1:C38";
                SpreadsheetsResource.ValuesResource.GetRequest request =
                        service.Spreadsheets.Values.Get(spreadsheetId, range);

                // Prints the names and majors of students in a sample spreadsheet:
                // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
                ValueRange response = request.Execute();
                var values = response.Values;

            DataTable dt = new DataTable();
            DataRow dr = null;

            if (values != null && values.Count > 0)
            {
                // Console.WriteLine("Name, Major");
                int i=0;
                foreach (var row in values)
                {

                    if (i > 0) dr = dt.Rows.Add();
                    for (int j=0; j<row.Count;j++)
                        if (i == 0)
                            dt.Columns.Add(row[j].ToString());
                        else
                        if (values[j] != null)
                            dr[j ] = row[j].ToString();
                    i++;
                    
                }
            }

          
            materials = dt;

        }
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
