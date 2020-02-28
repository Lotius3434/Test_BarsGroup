using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    interface IParseConfiguration
    { 
        Dictionary<string, string> GetConfigServers_Npgsql();
    }
}
