using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Tests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void InvalidLengthTest()
        {
            Assert.ThrowsException<ArgumentException>(() => Barcode.Parse("ABC123"));
        }

        [TestMethod]
        public void InvalidComplianceIndicatorTest()
        {
            Assert.ThrowsException<ArgumentException>(() => Barcode.Parse(new string('A', 32)));
        }
    }
}
