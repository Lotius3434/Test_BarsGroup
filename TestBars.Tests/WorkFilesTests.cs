using NUnit.Framework;
using TestBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;

namespace TestBars.Tests
{
    [TestFixture]
    public class WorkFilesTests
    {
        WindsorContainer container;
        IWorkFiles _IWorkFiles;
        WorkFiles workFiles;
        [SetUp]
        public void containerCreate()
        {
            container = new WindsorContainer();
            container.Install(new ConfigurationCastleWindsorTest());
            _IWorkFiles = container.Resolve<IWorkFiles>();
            workFiles = new WorkFiles();

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

            string execute = stubFiles.GetBuildeResulSortString();

            Assert.AreEqual(execute, workFiles.SortString(listliststring));
        }

        [Test]
        public void CreatestringTest()
        {

        }

        [Test]
        public void WriteFileTxtTest()
        {

        }
    }
}