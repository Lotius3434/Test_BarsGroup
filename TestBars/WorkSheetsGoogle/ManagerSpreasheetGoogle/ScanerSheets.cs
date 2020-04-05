using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    class ScanerSheets : IScanerSheets
    {
        ICreatorSheets creatorSheets;
        IWriterSheets writerSheets;
        public ScanerSheets(ICreatorSheets creatorSheets, IWriterSheets writerSheets)
        {
            this.creatorSheets = creatorSheets;
            this.writerSheets = writerSheets;
        }
        public void ScanSheets(string IdSreadssheet, IList<IServerObj> servers, SheetsService sheetService)// Метод который парсит листы в таблице.
        {
            Console.WriteLine("Сканирование листов в таблице");




            List<string> sheets = new List<string>();
            List<string> result = new List<string>();

            Spreadsheet gsSpreadsheet;
            gsSpreadsheet = sheetService.Spreadsheets.Get(IdSreadssheet).Execute();
            foreach (Sheet gsSheet in gsSpreadsheet.Sheets)
            {
                sheets.Add(gsSheet.Properties.Title);
            }

            foreach (var nameServ in servers)
            {
                string Servsname = sheets.Find((x) => x == nameServ.NameServer);
                if (Servsname == null)
                {
                    result.Add(nameServ.NameServer);
                }
            }


            if (result.Count > 0) // Если соответствующих листов не найдено, происходит их добавление.
            {
                creatorSheets.CreateSheets(IdSreadssheet, result, servers, sheetService);
            }

            writerSheets.WriteSheet(IdSreadssheet, servers, sheetService);
        }
    }
}
