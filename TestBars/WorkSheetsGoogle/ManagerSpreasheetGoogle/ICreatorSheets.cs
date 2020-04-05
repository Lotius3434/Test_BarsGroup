using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    interface ICreatorSheets
    {
        void CreateSheets(string SpreadsheetId, List<string> ListServer, IList<IServerObj> servers, SheetsService sheetService);
    }
}
