using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkSheetsGoogle
{
    interface ISpreasheet
    {
        string CreateSpreasheet(List<string> ServersName);
        void WriteSheet(string spreadsheet, List<IList<IList<Object>>> ListInfo);
        void CreateSheets(string SpreadsheetId, List<string> ListServer, List<IList<IList<Object>>> ListInfo);
        void ScanSheets(string ListId, List<string> ListServer, List<IList<IList<Object>>> ListInfo);
    }
}
