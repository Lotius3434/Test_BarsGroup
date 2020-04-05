using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    interface ICreatorSpreasheet
    {
        void CreateSpreasheet(IList<IServerObj> servers, SheetsService sheetService);
    }
}
