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
            Assert.ThrowsException<ArgumentException>(() => IdParser.Parse("ABC123"));
        }

        [TestMethod]
        public void InvalidComplianceIndicatorTest()
        {
            Assert.ThrowsException<ArgumentException>(() => IdParser.Parse(new string('A', 32)));
        }
    }
}
