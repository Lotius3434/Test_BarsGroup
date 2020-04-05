using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle
{
    interface IManagerSpreasheet
    {
        void StartWorkSpreasheet(IList<IServerObj> servers);
    }
}
