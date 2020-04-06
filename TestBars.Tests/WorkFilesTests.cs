using NUnit.Framework;
using System.Collections.Generic;
using Castle.Windsor;
using TestBars.WorkServersPostgreSql;

namespace TestBars.Tests
{
    [TestFixture]
    public class WorkFilesTests
    {
        WindsorContainer container;
        
        WorkFiles workFiles;
        IList<IServerObj> ListStubServerObj;
        IDrives drives;
        [SetUp]
        public void containerCreate()
        {
            container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsorTest());
            

            ListStubServerObj = new List<IServerObj>();
            IServerObj StubServerObj = container.Resolve<IServerObj>();
            IDrives drives = container.Resolve<IDrives>();
            workFiles = new WorkFiles(drives);
            ListStubServerObj.Add(StubServerObj);
        }

        [Test]
        public void SortStringTest_returnSortString()
        {
            
            StubFiles stubFiles = new StubFiles();
            IList<string> listliststring = new List<string>()
            {
                "LocalServer"
                ,"DbTest"
                ,"0,00741"
                ,"02.04.2020"
            };

            string execute = stubFiles.GetResulSortString();

            Assert.AreEqual(execute, workFiles.SortString(listliststring));
        }

        [Test]
        public void CreatestringTest_returnCorrectString()
        {
            StubFiles stubFiles = new StubFiles();
            string execute = stubFiles.GetCreatestring();
            Assert.AreEqual(execute, workFiles.Createstring(ListStubServerObj));
        }

        [TearDown]
        public void containerNull()
        {
            container = null;
            workFiles = null;
            ListStubServerObj = null;
            drives = null;
        }
    }
}