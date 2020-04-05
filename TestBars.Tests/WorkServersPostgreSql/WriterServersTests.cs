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
    public class WriterServersTests
    {
        IWriterServers writerServers;
        WindsorContainer container;
        IServerObj StubtServerObjs;
        
        
        [SetUp]
        public void containerCreate()
        {
            container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsorTest());
            writerServers = container.Resolve<IWriterServers>();
            StubtServerObjs = container.Resolve<IServerObj>(); 

        }
        [Test]
        public void WriteServerObjsTest_ReturnGoodDb()
        {
            string nameServer = "LocalServer";
            string nameDb = "DbTest";
            string sizeDb = "0,00741";
            string updateDateDb = "02.04.2020";

            writerServers.CreateServerObj(nameServer);
            writerServers.WriteServerObjs(nameDb, sizeDb, updateDateDb);

            Assert.AreEqual(StubtServerObjs.NameServer, writerServers.GetServerObj().NameServer);
            Assert.AreEqual(StubtServerObjs.DataBases[0].name, writerServers.GetServerObj().DataBases[0].name);
            Assert.AreEqual(StubtServerObjs.DataBases[0].size, writerServers.GetServerObj().DataBases[0].size);
            Assert.AreEqual(StubtServerObjs.DataBases[0].updateDate, writerServers.GetServerObj().DataBases[0].updateDate);

        }
        [TearDown]
        public void containerNull()
        {
            writerServers = null;
            container = null;
            StubtServerObjs = null;

        }

    }
}