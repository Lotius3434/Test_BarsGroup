using System.Collections.Generic;
using TestBars.WorkServersPostgreSql;

namespace TestBars.Tests
{
    class StubParseConfiguration : IParseConfiguration
    {
        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        public Dictionary<string, string> GetConfigServers_Npgsql()
        {
            keyValuePairs.Add("LocalServer","FakeConfig");
            return keyValuePairs;
        }
    }
}
