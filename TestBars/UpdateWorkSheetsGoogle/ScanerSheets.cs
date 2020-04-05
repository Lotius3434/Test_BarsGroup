using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.WorkServersPostgreSql;

namespace TestBars.UpdateWorkSheetsGoogle
{
    class ScanerSheets : IScanerSheets
    {
        ICreatorSheets creatorSheets;
        public ScanerSheets(ICreatorSheets creatorSheets)
        {
            this.creatorSheets = creatorSheets;
        }
        public void ScanSheets(string IdSreadssheet, IList<IServerObj> servers, SheetsService service)// Метод который парсит листы в таблице.
        {
            Console.WriteLine("Сканирование листов в таблице");




            List<string> sheets = new List<string>();
            List<string> result = new List<string>();

            Spreadsheet gsSpreadsheet;
            gsSpreadsheet = service.Spreadsheets.Get(IdSreadssheet).Execute();
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
                creatorSheets.CreateSheets(IdSreadssheet, result, servers, service);
            }

        }
    }
}
