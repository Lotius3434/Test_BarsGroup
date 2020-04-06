using NUnit.Framework;

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