using NUnit.Framework;
using TestBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBars.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        [Test]
        public void CalculateBytetoGBTest_double7500000kb_returnStringConvertGb()
        {
            double kb = 7500000;

            string execute = "0,00698";

            Assert.AreEqual(execute, Converter.CalculateBytetoGB(kb));
        }
    }
}