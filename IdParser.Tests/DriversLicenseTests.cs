using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Tests {
    [TestClass]
    public class DriversLicenseTests {
        [TestMethod]
        public void TestMA2009License() {
            var file = File.ReadAllText("MA License 2009.txt");
            var idCard = IdParser.Parse(file, true);

            Assert.AreEqual("SMITH", idCard.LastName);
            Assert.AreEqual("MA", idCard.IssuerIdentificationNumber.GetAbbreviation());
        }

        [TestMethod]
        public void TestMA2016License() {
            var file = File.ReadAllText("MA License 2016.txt");
            var idCard = IdParser.Parse(file, true);

            Assert.AreEqual("SAMPLE", idCard.LastName);
            Assert.AreEqual("S12345678", idCard.IdNumber);
            Assert.AreEqual("24 BEACON STREET", idCard.StreetLine1);
            Assert.AreEqual("MA504", idCard.AdditionalJurisdictionElements.Single(e => e.Key == "ZMZ").Value);
            Assert.AreEqual("02133-0000", idCard.FormattedPostalCode);
            Assert.AreEqual("MA", idCard.IssuerIdentificationNumber.GetAbbreviation());

            if (idCard is DriversLicense) {
                var license = (DriversLicense)idCard;

                Assert.AreEqual("D", license.Jurisdiction.VehicleClass);
                Assert.AreEqual("NONE", license.Jurisdiction.RestrictionCodes);
            }
        }

        [TestMethod]
        public void TestNYLicense() {
            var file = File.ReadAllText("NY License.txt");
            var license = IdParser.Parse(file);

            Assert.AreEqual("Michael", license.LastName);
            Assert.AreEqual(new DateTime(2013, 08, 31), license.DateOfBirth);
            Assert.AreEqual("New York", license.IssuerIdentificationNumber.GetDescription());
            Assert.AreEqual("NY", license.IssuerIdentificationNumber.GetAbbreviation());
        }

        [TestMethod]
        public void TestVALicense() {
            var file = File.ReadAllText("VA License.txt");
            var idCard = IdParser.Parse(file);

            Assert.AreEqual("STAUNTON", idCard.City);
            Assert.AreEqual("VA", idCard.IssuerIdentificationNumber.GetAbbreviation());

            if (idCard is DriversLicense) {
                var license = (DriversLicense)idCard;

                Assert.AreEqual("158X9", license.Jurisdiction.RestrictionCodes);
            }
        }

        [TestMethod]
        public void TestGALicense()
        {
            var file = File.ReadAllText("GA License.txt");
            var idCard = IdParser.Parse(file);

            Assert.AreEqual("123 NORTH STATE ST.", idCard.StreetLine1);
            Assert.AreEqual("Georgia", idCard.IssuerIdentificationNumber.GetDescription());
            Assert.AreEqual("GA", idCard.IssuerIdentificationNumber.GetAbbreviation());

            if (idCard is DriversLicense) {
                var license = (DriversLicense)idCard;

                Assert.AreEqual("C", license.Jurisdiction.VehicleClass);
            }
        }

        [TestMethod]
        public void TestCTLicense()
        {
            var file = File.ReadAllText("CT License.txt");
            var idCard = IdParser.Parse(file, true);

            Assert.IsTrue(idCard.IsOrganDonor);
            Assert.AreEqual("CTLIC", idCard.LastName);
            Assert.AreEqual("990000001", idCard.IdNumber);
            Assert.AreEqual("CT", idCard.IssuerIdentificationNumber.GetAbbreviation());
        }

        [TestMethod]
        public void TestNonStandardDataElementSeparator()
        {
            var file = File.ReadAllText("MA License Piped.txt");
            var idCard = IdParser.Parse(file, true);

            Assert.AreEqual("S65807412", idCard.IdNumber);
            Assert.AreEqual("123 MAIN STREET", idCard.StreetLine1);
            Assert.IsInstanceOfType(idCard, typeof(DriversLicense));
        }
    }
}