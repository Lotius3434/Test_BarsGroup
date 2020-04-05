using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    interface IWriterSheets
    {
        void WriteSheet(string spreadsheet, IList<IServerObj> servers, SheetsService sheetService);
    }
}
