using NUnit.Framework;
using System.Collections.Generic;
using Castle.Windsor;

namespace TestBars.WorkServersPostgreSql.Tests
{
    [TestFixture]
    public class ManagerConnectionDbTests
    {
        WindsorContainer container;

        
        IList<IServerObj> ListStubServerObj;
        IManagerConnectionDb managerConnectionDb;
        [SetUp]
        public void containerCreate()
        {
            container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsorTest());

            managerConnectionDb = container.Resolve<IManagerConnectionDb>();
            ListStubServerObj = new List<IServerObj>();
            IServerObj StubServerObj = container.Resolve<IServerObj>();
            
            ListStubServerObj.Add(StubServerObj);
        }


        [Test]
        public void GetServersTest_ReturnCorrectListServerObj()
        {
            IList<IServerObj> resul = managerConnectionDb.GetServers();

            Assert.AreEqual(ListStubServerObj[0].NameServer, resul[0].NameServer);
            Assert.AreEqual(ListStubServerObj[0].DataBases[0].name, resul[0].DataBases[0].name);
            Assert.AreEqual(ListStubServerObj[0].DataBases[0].size, resul[0].DataBases[0].size);
            Assert.AreEqual(ListStubServerObj[0].DataBases[0].updateDate, resul[0].DataBases[0].updateDate);

        }
        [TearDown]
        public void containerNull()
        {
            ListStubServerObj = null;
            managerConnectionDb = null;
        }
    }
}