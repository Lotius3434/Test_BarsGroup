using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBars.UpdateWorkServersPostgreSql;

namespace TestBars.WorkSheetsGoogle
{
    interface ISearchSpreadsheets
    {
        DriveService SetDriveService { set; }
        string Search(IList<IServerObj> servers);
    }
}
