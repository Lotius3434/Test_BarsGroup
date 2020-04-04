using NUnit.Framework;
using NUnit;
using TestBars.WorkServersPostgreSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TestBars.WorkServersPostgreSql.Tests
{
    public class FakeParseConfiguration : ParseConfiguration
    {

    }
    [TestFixture]
    public class ParseConfigurationTests
    {
        [Test]
        public void GetConfigServers_NpgsqlTest_ReturnDictionary()
        {
            FakeParseConfiguration fakeParseConfiguration = new FakeParseConfiguration();

            Dictionary<string, string> expected = new Dictionary<string, string>();
            expected.Add(
                ConfigurationManager.ConnectionStrings[1].Name
                ,ConfigurationManager.ConnectionStrings[1].ConnectionString);

            Assert.AreEqual(expected, fakeParseConfiguration.GetConfigServers_Npgsql());
        }

        [Test]
        public void GetConfigServers_NpgsqlTest_ReturnIsNotNull()
        {
            ParseConfiguration parseConfiguration = new ParseConfiguration();
            Assert.IsNotNull(parseConfiguration.GetConfigServers_Npgsql());
        }
        
    }
}