using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.WorkServersPostgreSql;

namespace TestBars.UpdateWorkSheetsGoogle
{
    interface IWriterSheets
    {
        void WriteSheet(string spreadsheet, IList<IServerObj> servers, SheetsService service);
    }
}
