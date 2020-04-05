using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    interface IScanerSheets
    {
        void ScanSheets(string ListId, IList<IServerObj> servers, SheetsService sheetService);
    }
}
