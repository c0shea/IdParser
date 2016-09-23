using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Tests {
    [TestClass]
    public class DriversLicenseTests {
        [TestMethod]
        public void TestMALicense()
        {
            var file = File.ReadAllText("MA License.txt");
            var license = IdParser.Parse(file, true);

            Assert.AreEqual("SMITH", license.LastName);
        }
    }
}