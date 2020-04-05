using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.WorkServersPostgreSql;

namespace TestBars.UpdateWorkSheetsGoogle
{
    class CreatorSpreasheet : ICreatorSpreasheet
    {
        IWriterSheets writerSheets;
        public CreatorSpreasheet(IWriterSheets writerSheets)
        {
            this.writerSheets = writerSheets;
        }
        public void CreateSpreasheet(IList<IServerObj> servers, SheetsService service) // Метод создания таблицы.
        {
            string spreadsheetName = ConfigurationManager.AppSettings["NameSpreadSheet"];

            var myNewSheet = new Spreadsheet();
            myNewSheet.Properties = new SpreadsheetProperties();
            myNewSheet.Properties.Title = spreadsheetName;

            myNewSheet.Sheets = new List<Sheet>();
            for (int a = 0; a < servers.Count; a++)
            {
                var sheet = new Sheet();
                sheet.Properties = new SheetProperties();
                sheet.Properties.Title = servers[a].NameServer;
                myNewSheet.Sheets.Add(sheet);
            }
            Spreadsheet newSheet = service.Spreadsheets.Create(myNewSheet).Execute();

            Console.WriteLine("--Таблица создана\nСсылка на таблицу: {0}", newSheet.SpreadsheetUrl);
            
            writerSheets.WriteSheet(newSheet.SpreadsheetId.ToString(), servers, service);
        }
    }
}
