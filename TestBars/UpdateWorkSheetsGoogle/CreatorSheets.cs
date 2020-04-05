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
    class CreatorSheets : ICreatorSheets
    {
        IWriterSheets writerSheets;
        public CreatorSheets(IWriterSheets writerSheets)
        {
            this.writerSheets = writerSheets;
        }
        public void CreateSheets(string SpreadsheetId, List<string> ListServer, IList<IServerObj> servers, SheetsService service) //Метод для создания листов.
        {
            Console.WriteLine("Количество не найденых листов: {0}\nНачинается добавление недостающих листов...", ListServer.Count);

            foreach (var sheetName in ListServer)
            {
                var addSheetRequest = new AddSheetRequest();
                addSheetRequest.Properties = new SheetProperties();
                addSheetRequest.Properties.Title = sheetName;
                BatchUpdateSpreadsheetRequest batchUpdateSpreadsheetRequest = new BatchUpdateSpreadsheetRequest();
                batchUpdateSpreadsheetRequest.Requests = new List<Request>();
                batchUpdateSpreadsheetRequest.Requests.Add(new Request { AddSheet = addSheetRequest });

                var batchUpdateRequest = service.Spreadsheets.BatchUpdate(batchUpdateSpreadsheetRequest, SpreadsheetId);
                batchUpdateRequest.Execute();
            }

            IList<IServerObj> newServers = new List<IServerObj>();

            for (int a = 0; a < ListServer.Count; a++)
            {
                foreach (var _servers in servers)
                {
                    if (ListServer[a].ToString() == _servers.NameServer)
                    {
                        newServers.Add(_servers);
                    }
                }
            }


            writerSheets.WriteSheet(SpreadsheetId, newServers, service);

        }
    }
}
