using Google.Apis.Drive.v3;
using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle.ManagerSpreasheetGoogle
{
    public interface ISearchSpreadsheets
    {
        string Search(IList<IServerObj> servers, DriveService driveService);
    }
}
