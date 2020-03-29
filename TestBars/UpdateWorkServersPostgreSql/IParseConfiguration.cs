using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.UpdateWorkServersPostgreSql
{
    interface IParseConfiguration
    {
        Dictionary<string, string> GetConfigServers_Npgsql();
    }
}
