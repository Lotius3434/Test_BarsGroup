using System.Collections.Generic;

namespace TestBars.WorkServersPostgreSql
{
    public interface IParseConfiguration
    {
        Dictionary<string, string> GetConfigServers_Npgsql();
    }
}
