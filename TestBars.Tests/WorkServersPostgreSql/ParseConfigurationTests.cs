using NUnit.Framework;

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