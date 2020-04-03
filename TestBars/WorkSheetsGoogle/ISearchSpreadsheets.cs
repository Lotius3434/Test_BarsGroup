using Google.Apis.Drive.v3;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle
{
    public interface ISearchSpreadsheets
    {
        DriveService SetDriveService { set; }
        string Search(IList<IServerObj> servers);
    }
}
