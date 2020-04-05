using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.WorkServersPostgreSql;

namespace TestBars.UpdateWorkSheetsGoogle
{
    interface ICreatorSheets
    {
        void CreateSheets(string SpreadsheetId, List<string> ListServer, IList<IServerObj> servers, SheetsService service);
    }
}
