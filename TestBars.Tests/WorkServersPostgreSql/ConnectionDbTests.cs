using NUnit.Framework;
using TestBars.WorkServersPostgreSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;


namespace TestBars.WorkServersPostgreSql.Tests
{
    [TestFixture]
    public class ConnectionDbTests
    {

        IConnectionDb ConnectionDb;
        WindsorContainer container;
        IList<IServerObj> ListserverObjs;


        [SetUp]
        public void containerCreate()
        {
            container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsor());
            ConnectionDb = container.Resolve<IConnectionDb>();
            ListserverObjs = new List<IServerObj>();

        }
        [Test]
        public void GetServersTest_ReturnIsNotNull()
        {
            IList<IServerObj> ListserverObjs = ConnectionDb.GetServers();
            Assert.IsNotNull(ListserverObjs);
            
        }
    }
}