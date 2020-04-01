using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.UpdateWorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle
{
    interface ISpreasheet
    {
        SheetsService sheetsService { set; }
        string CreateSpreasheet(IList<IServerObj> servers);
        void WriteSheet(string spreadsheet, IList<IServerObj> servers);
        void CreateSheets(string SpreadsheetId, List<string> ListServer, IList<IServerObj> servers);
        void ScanSheets(string ListId, IList<IServerObj> servers);
    }
}
