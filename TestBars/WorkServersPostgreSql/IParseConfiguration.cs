using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.WorkServersPostgreSql
{
    interface IParseConfiguration
    {
        Dictionary<string, string> GetConfigServers_Npgsql();
    }
}
