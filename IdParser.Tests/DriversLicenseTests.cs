using System;
using System.IO;
#if !NET20
using System.Linq;
#endif
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Tests {
    [TestClass]
    public class DriversLicenseTests {
        [TestMethod]
        public void TestMA2009License() {
            var file = File.ReadAllText("MA License 2009.txt");
            var idCard = IdParser.Parse(file, Validation.None);

            Assert.AreEqual("ROBERT", idCard.FirstName);
            Assert.AreEqual("LOWNEY", idCard.MiddleName);
            Assert.AreEqual("SMITH", idCard.LastName);
#if NET20
            Assert.AreEqual("MA", IdParser.GetAbbreviation(idCard.IssuerIdentificationNumber));
#else
            Assert.AreEqual("MA", idCard.IssuerIdentificationNumber.GetAbbreviation());
#endif
            Assert.AreEqual(new DateTime(2016, 06, 29), idCard.IssueDate);
            Assert.AreEqual(new DateTime(1977, 07, 07), idCard.DateOfBirth);
            Assert.AreEqual(Country.USA, idCard.Country);
        }

        [TestMethod]
        public void TestMA2016License() {
            var file = File.ReadAllText("MA License 2016.txt");
            var idCard = IdParser.Parse(file, Validation.None);

            Assert.AreEqual("MORRIS", idCard.FirstName);
            Assert.AreEqual("T", idCard.MiddleName);
            Assert.AreEqual("SAMPLE", idCard.LastName);
            Assert.AreEqual(new DateTime(1971, 12, 31), idCard.DateOfBirth);

#if NET20
            Assert.AreEqual("MA", IdParser.GetAbbreviation(idCard.IssuerIdentificationNumber));
#else
            Assert.AreEqual("MA", idCard.IssuerIdentificationNumber.GetAbbreviation());
#endif
            Assert.AreEqual("S12345678", idCard.IdNumber);
            Assert.AreEqual(new DateTime(2016, 08, 09), idCard.IssueDate);
            Assert.AreEqual(Country.USA, idCard.Country);

            Assert.AreEqual("24 BEACON STREET", idCard.StreetLine1);
#if !NET20
            Assert.AreEqual("MA504", idCard.AdditionalJurisdictionElements.Single(e => e.Key == "ZMZ").Value);
#endif
            Assert.AreEqual("02133-0000", idCard.FormattedPostalCode);

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

            Assert.AreEqual("M", license.FirstName);
            Assert.AreEqual("Motorist", license.MiddleName);
            Assert.AreEqual("Michael", license.LastName);
            Assert.AreEqual(new DateTime(2013, 08, 31), license.DateOfBirth);

#if NET20
            Assert.AreEqual("New York", IdParser.GetDescription(license.IssuerIdentificationNumber));
            Assert.AreEqual("NY", IdParser.GetAbbreviation(license.IssuerIdentificationNumber));
#else
            Assert.AreEqual("New York", license.IssuerIdentificationNumber.GetDescription());
            Assert.AreEqual("NY", license.IssuerIdentificationNumber.GetAbbreviation());
#endif
            Assert.AreEqual(new DateTime(2013, 08, 31), license.IssueDate);
            Assert.AreEqual(new DateTime(2013, 08, 31), license.ExpirationDate);
            Assert.AreEqual(Country.USA, license.Country);

            Assert.AreEqual("2345 ANYWHERE STREET", license.StreetLine1);
            Assert.AreEqual("YOUR CITY", license.City);
        }

        [TestMethod]
        public void TestVALicense() {
            var file = File.ReadAllText("VA License.txt");
            var idCard = IdParser.Parse(file);

            Assert.AreEqual("JUSTIN", idCard.FirstName);
            Assert.AreEqual("WILLIAM", idCard.MiddleName);
            Assert.AreEqual("MAURY", idCard.LastName);
            Assert.AreEqual(new DateTime(1958, 07, 15), idCard.DateOfBirth);

#if NET20
            Assert.AreEqual("VA", IdParser.GetAbbreviation(idCard.IssuerIdentificationNumber));
#else
            Assert.AreEqual("VA", idCard.IssuerIdentificationNumber.GetAbbreviation());
#endif
            Assert.AreEqual(new DateTime(2009, 08, 14), idCard.IssueDate);
            Assert.AreEqual(new DateTime(2017, 08, 14), idCard.ExpirationDate);
            Assert.AreEqual(Country.USA, idCard.Country);

            Assert.AreEqual("17 FIRST STREET", idCard.StreetLine1);
            Assert.AreEqual("STAUNTON", idCard.City);
            Assert.AreEqual("244010000", idCard.PostalCode);

            if (idCard is DriversLicense) {
                var license = (DriversLicense)idCard;

                Assert.AreEqual("158X9", license.Jurisdiction.RestrictionCodes);
            }
        }

        [TestMethod]
        public void TestGALicense() {
            var file = File.ReadAllText("GA License.txt");
            var idCard = IdParser.Parse(file);

            Assert.AreEqual("JANICE", idCard.FirstName);
            Assert.IsNull(idCard.MiddleName);
            Assert.AreEqual("SAMPLE", idCard.LastName);
            Assert.AreEqual("PH.D.", idCard.NameSuffix);
            Assert.AreEqual(new DateTime(1957, 07, 01), idCard.DateOfBirth);

            Assert.AreEqual("123 NORTH STATE ST.", idCard.StreetLine1);
            Assert.AreEqual("ANYTOWN", idCard.City);
            Assert.AreEqual("303340000", idCard.PostalCode);

#if NET20
            Assert.AreEqual("Georgia", IdParser.GetDescription(idCard.IssuerIdentificationNumber));
            Assert.AreEqual("GA", IdParser.GetAbbreviation(idCard.IssuerIdentificationNumber));
#else
            Assert.AreEqual("Georgia", idCard.IssuerIdentificationNumber.GetDescription());
            Assert.AreEqual("GA", idCard.IssuerIdentificationNumber.GetAbbreviation());
#endif
            Assert.AreEqual(new DateTime(2006, 07, 01), idCard.IssueDate);
            Assert.AreEqual(Country.USA, idCard.Country);

            if (idCard is DriversLicense) {
                var license = (DriversLicense)idCard;

                Assert.AreEqual("NONE", license.Jurisdiction.RestrictionCodes);
                Assert.AreEqual("C", license.Jurisdiction.VehicleClass);
                Assert.AreEqual("P", license.Jurisdiction.EndorsementCodes);
            }
        }

        [TestMethod]
        public void TestCTLicense() {
            var file = File.ReadAllText("CT License.txt");
            var idCard = IdParser.Parse(file, Validation.None);

            Assert.AreEqual("ADULT", idCard.FirstName);
            Assert.AreEqual("A", idCard.MiddleName);
            Assert.AreEqual("CTLIC", idCard.LastName);
            Assert.AreEqual(new DateTime(1961, 01, 01), idCard.DateOfBirth);

            Assert.AreEqual(new Height(Version.Aamva2013, "066 in"), idCard.Height);
            Assert.AreEqual("BLU", idCard.EyeColor);
            Assert.IsTrue(idCard.IsOrganDonor);

            Assert.AreEqual("60 STATE ST", idCard.StreetLine1);
            Assert.AreEqual("WETHERSFIELD", idCard.City);
            Assert.AreEqual("061091896", idCard.PostalCode);

#if NET20
            Assert.AreEqual("CT", IdParser.GetAbbreviation(idCard.IssuerIdentificationNumber));
#else
            Assert.AreEqual("CT", idCard.IssuerIdentificationNumber.GetAbbreviation());
#endif
            Assert.AreEqual("990000001", idCard.IdNumber);
            Assert.AreEqual(new DateTime(2015, 01, 01), idCard.ExpirationDate);
            Assert.AreEqual(Country.USA, idCard.Country);

            if (idCard is DriversLicense) {
                var license = (DriversLicense)idCard;

                Assert.AreEqual("D", license.Jurisdiction.VehicleClass);
                Assert.AreEqual("B", license.Jurisdiction.RestrictionCodes);
            }
        }

        [TestMethod]
        public void TestCTLicenseWebBrowser() {
            var barcode = @"@
AAMVA6360060101DL00290179DAACTLIC,ADULT,A
DAG60 STATE ST
DAIWETHERSFIELD
DAJCT
DAK061091896  
DAQ990000001
DARD   
DASB         
DAT     
DBA20150101
DBB19610101
DBC2
DBD20090223
DAU506
DAYBLU
DBF00
DBHY";

            var idCard = IdParser.Parse(barcode, Validation.None);

            Assert.IsNotNull(idCard);
            Assert.AreEqual("ADULT", idCard.FirstName);
            Assert.AreEqual("60 STATE ST", idCard.StreetLine1);
            Assert.AreEqual("CT", idCard.JurisdictionCode);
            Assert.AreEqual(new DateTime(1961, 01, 01), idCard.DateOfBirth);
        }

        [TestMethod]
        public void TestNonStandardDataElementSeparator() {
            var file = File.ReadAllText("MA License Piped.txt");
            var idCard = IdParser.Parse(file, Validation.None);

            Assert.AreEqual("S65807412", idCard.IdNumber);
            Assert.AreEqual("123 MAIN STREET", idCard.StreetLine1);
            Assert.AreEqual(Country.USA, idCard.Country);
            Assert.IsInstanceOfType(idCard, typeof(DriversLicense));
        }

        [TestMethod]
        public void TestMALicenseWithNoMiddleName() {
            var file = File.ReadAllText("MA License No Middle Name.txt");
            var idCard = IdParser.Parse(file, Validation.None);

            Assert.IsNotNull(idCard);
            Assert.IsNull(idCard.MiddleName);
            Assert.IsNotNull(idCard.FirstName);
            Assert.AreEqual("TONY", idCard.FirstName);
            Assert.AreEqual("ROBERT", idCard.LastName);
        }
    }
}