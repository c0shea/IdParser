using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Tests {
    [TestClass]
    public class DriversLicenseTests {
        [TestMethod]
        public void TestMALicense() {
            var file = File.ReadAllText("MA License.txt");
            var license = IdParser.Parse(file, true);

            Assert.AreEqual("SMITH", license.LastName);
        }

        [TestMethod]
        public void TestNYLicense() {
            var file = File.ReadAllText("NY License.txt");
            var license = IdParser.Parse(file);

            Assert.AreEqual("Michael", license.LastName);
            Assert.AreEqual(new DateTime(2013, 08, 31), license.DateOfBirth);
        }

        [TestMethod]
        public void TestVALicense() {
            var file = File.ReadAllText("VA License.txt");
            var idCard = IdParser.Parse(file);

            Assert.AreEqual("STAUNTON", idCard.City);

            if (idCard is DriversLicense) {
                var license = (DriversLicense)idCard;

                Assert.AreEqual("158X9", license.Jurisdiction.RestrictionCodes);
            }
        }
    }
}