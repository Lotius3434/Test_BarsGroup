using NUnit.Framework;
using NUnit;
using TestBars.WorkServersPostgreSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestBars.WorkServersPostgreSql.Tests
{
    [TestFixture]
    public class ParseConfigurationTests
    {
       
        [Test]
        public void GetConfigServers_NpgsqlTest_ReturnIsNotNull()
        {
            ParseConfiguration parseConfiguration = new ParseConfiguration();
            Assert.IsNotNull(parseConfiguration.GetConfigServers_Npgsql());
        }
        
    }
}