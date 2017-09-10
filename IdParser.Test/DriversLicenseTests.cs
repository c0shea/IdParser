using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Test
{
    [TestClass]
    public class DriversLicenseTests
    {
        [TestMethod]
        public void TestMA2009License()
        {
            var file = File.ReadAllText("MA License 2009.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            Assert.AreEqual("ROBERT", idCard.FirstName);
            Assert.AreEqual("LOWNEY", idCard.MiddleName);
            Assert.AreEqual("SMITH", idCard.LastName);

            Assert.AreEqual("123 MAIN STREET", idCard.StreetLine1);
            Assert.AreEqual("BOSTON", idCard.City);
            Assert.AreEqual("MA", idCard.IssuerIdentificationNumber.GetAbbreviation());
            Assert.AreEqual(Country.USA, idCard.Country);

            Assert.AreEqual(new DateTime(1977, 07, 07), idCard.DateOfBirth);
            Assert.AreEqual(Sex.Male, idCard.Sex);
            Assert.IsNull(idCard.EyeColor);
            Assert.AreEqual(6, idCard.Height.Feet);
            Assert.AreEqual(0, idCard.Height.Inches);
            
            Assert.AreEqual("S65807412", idCard.IdNumber);
            Assert.AreEqual(Version.Aamva2009, idCard.AamvaVersionNumber);
            Assert.AreEqual(new DateTime(2016, 06, 29), idCard.IssueDate);
            Assert.AreEqual(new DateTime(2020, 07, 07), idCard.ExpirationDate);
        }

        [TestMethod]
        public void TestMA2016License()
        {
            var file = File.ReadAllText("MA License 2016.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            Assert.AreEqual("MORRIS", idCard.FirstName);
            Assert.AreEqual("T", idCard.MiddleName);
            Assert.AreEqual("SAMPLE", idCard.LastName);
            
            Assert.AreEqual("24 BEACON STREET", idCard.StreetLine1);
            Assert.AreEqual("BOSTON", idCard.City);
            Assert.AreEqual("MA", idCard.IssuerIdentificationNumber.GetAbbreviation());
            Assert.AreEqual("02133-0000", idCard.FormattedPostalCode);
            Assert.AreEqual(Country.USA, idCard.Country);

            Assert.AreEqual(new DateTime(1971, 12, 31), idCard.DateOfBirth);
            Assert.AreEqual(Sex.Male, idCard.Sex);
            Assert.AreEqual(62, idCard.Height.TotalInches);
            Assert.IsFalse(idCard.IsOrganDonor);
            Assert.IsFalse(idCard.IsVeteran);

            Assert.AreEqual("S12345678", idCard.IdNumber);
            Assert.AreEqual(Version.Aamva2013, idCard.AamvaVersionNumber);
            Assert.AreEqual(new DateTime(2016, 08, 09), idCard.IssueDate);
            Assert.AreEqual(new DateTime(2021, 08, 16), idCard.ExpirationDate);

            Assert.AreEqual("08102016 REV 02222016", idCard.DocumentDiscriminator);
            Assert.AreEqual("12345S123456780612", idCard.InventoryControlNumber);

            Assert.AreEqual("MA504", idCard.AdditionalJurisdictionElements.Single(e => e.Key == "ZMZ").Value);
            Assert.AreEqual("08102016", idCard.AdditionalJurisdictionElements.Single(e => e.Key == "ZMB").Value);
            
            Assert.IsInstanceOfType(idCard, typeof(DriversLicense));

            if (idCard is DriversLicense license)
            {
                Assert.AreEqual("D", license.Jurisdiction.VehicleClass);
                Assert.AreEqual("NONE", license.Jurisdiction.RestrictionCodes);
                Assert.AreEqual("NONE", license.Jurisdiction.EndorsementCodes);
            }
        }

        [TestMethod]
        public void TestNYLicense()
        {
            var file = File.ReadAllText("NY License.txt");
            var license = Barcode.Parse(file);

            Assert.AreEqual("M", license.FirstName);
            Assert.AreEqual("Motorist", license.MiddleName);
            Assert.AreEqual("Michael", license.LastName);
            
            Assert.AreEqual("2345 ANYWHERE STREET", license.StreetLine1);
            Assert.AreEqual("YOUR CITY", license.City);
            Assert.AreEqual("New York", license.IssuerIdentificationNumber.GetDescription());
            Assert.AreEqual("NY", license.IssuerIdentificationNumber.GetAbbreviation());

            Assert.AreEqual(new DateTime(2013, 08, 31), license.DateOfBirth);
            Assert.AreEqual(Sex.Male, license.Sex);
            Assert.AreEqual("BRO", license.EyeColor);

            Assert.AreEqual(new DateTime(2013, 08, 31), license.IssueDate);
            Assert.AreEqual(new DateTime(2013, 08, 31), license.ExpirationDate);
            Assert.AreEqual(Country.USA, license.Country);

            Assert.AreEqual("2345 ANYWHERE STREET", license.StreetLine1);
            Assert.AreEqual("YOUR CITY", license.City);
        }

        [TestMethod]
        public void TestVALicense()
        {
            var file = File.ReadAllText("VA License.txt");
            var idCard = Barcode.Parse(file);

            Assert.AreEqual("JUSTIN", idCard.FirstName);
            Assert.AreEqual("WILLIAM", idCard.MiddleName);
            Assert.AreEqual("MAURY", idCard.LastName);
            Assert.AreEqual(new DateTime(1958, 07, 15), idCard.DateOfBirth);

            Assert.AreEqual("VA", idCard.IssuerIdentificationNumber.GetAbbreviation());

            Assert.AreEqual(new DateTime(2009, 08, 14), idCard.IssueDate);
            Assert.AreEqual(new DateTime(2017, 08, 14), idCard.ExpirationDate);
            Assert.AreEqual(Country.USA, idCard.Country);

            Assert.AreEqual("17 FIRST STREET", idCard.StreetLine1);
            Assert.AreEqual("STAUNTON", idCard.City);
            Assert.AreEqual("244010000", idCard.PostalCode);

            Assert.IsInstanceOfType(idCard, typeof(DriversLicense));

            if (idCard is DriversLicense license)
            {
                Assert.AreEqual("158X9", license.Jurisdiction.RestrictionCodes);
            }
        }

        [TestMethod]
        public void TestGALicense()
        {
            var file = File.ReadAllText("GA License.txt");
            var idCard = Barcode.Parse(file);

            Assert.AreEqual("JANICE", idCard.FirstName);
            Assert.IsNull(idCard.MiddleName);
            Assert.AreEqual("SAMPLE", idCard.LastName);
            Assert.AreEqual("PH.D.", idCard.NameSuffix);
            Assert.AreEqual(new DateTime(1957, 07, 01), idCard.DateOfBirth);

            Assert.AreEqual("123 NORTH STATE ST.", idCard.StreetLine1);
            Assert.AreEqual("ANYTOWN", idCard.City);
            Assert.AreEqual("303340000", idCard.PostalCode);

            Assert.AreEqual("Georgia", idCard.IssuerIdentificationNumber.GetDescription());
            Assert.AreEqual("GA", idCard.IssuerIdentificationNumber.GetAbbreviation());

            Assert.AreEqual(new DateTime(2006, 07, 01), idCard.IssueDate);
            Assert.AreEqual(Country.USA, idCard.Country);

            Assert.IsInstanceOfType(idCard, typeof(DriversLicense));

            if (idCard is DriversLicense license)
            {
                Assert.AreEqual("NONE", license.Jurisdiction.RestrictionCodes);
                Assert.AreEqual("C", license.Jurisdiction.VehicleClass);
                Assert.AreEqual("P", license.Jurisdiction.EndorsementCodes);
            }
        }

        [TestMethod]
        public void TestCTLicense()
        {
            var file = File.ReadAllText("CT License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

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

            Assert.AreEqual("CT", idCard.IssuerIdentificationNumber.GetAbbreviation());

            Assert.AreEqual("990000001", idCard.IdNumber);
            Assert.AreEqual(new DateTime(2015, 01, 01), idCard.ExpirationDate);
            Assert.AreEqual(Country.USA, idCard.Country);

            Assert.IsInstanceOfType(idCard, typeof(DriversLicense));

            if (idCard is DriversLicense license)
            {
                Assert.AreEqual("D", license.Jurisdiction.VehicleClass);
                Assert.AreEqual("B", license.Jurisdiction.RestrictionCodes);
            }
        }

        [TestMethod]
        public void TestCTLicenseWebBrowser()
        {
            var file = File.ReadAllText("CT License Web Browser.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            Assert.IsNotNull(idCard);
            Assert.AreEqual("ADULT", idCard.FirstName);
            Assert.AreEqual("60 STATE ST", idCard.StreetLine1);
            Assert.AreEqual("CT", idCard.JurisdictionCode);
            Assert.AreEqual(new DateTime(1961, 01, 01), idCard.DateOfBirth);
        }

        [TestMethod]
        public void TestNonStandardDataElementSeparator()
        {
            var file = File.ReadAllText("MA License Piped.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            Assert.AreEqual("S65807412", idCard.IdNumber);
            Assert.AreEqual("123 MAIN STREET", idCard.StreetLine1);
            Assert.AreEqual(Country.USA, idCard.Country);
            Assert.IsInstanceOfType(idCard, typeof(DriversLicense));
        }

        [TestMethod]
        public void TestMALicenseWithNoMiddleName()
        {
            var file = File.ReadAllText("MA License No Middle Name.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            Assert.IsNotNull(idCard);
            Assert.IsNull(idCard.MiddleName);
            Assert.IsNotNull(idCard.FirstName);
            Assert.AreEqual("TONY", idCard.FirstName);
            Assert.AreEqual("ROBERT", idCard.LastName);
        }

        [TestMethod]
        public void TestCTLicenseNoMiddleName()
        {
            var file = File.ReadAllText("CT License No Middle Name.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            Assert.IsNotNull(idCard);
            Assert.IsNotNull(idCard.FirstName);
            Assert.IsNotNull(idCard.LastName);
            Assert.IsNull(idCard.MiddleName);
            Assert.AreEqual("WANG", idCard.LastName);
            Assert.AreEqual("CHUNG", idCard.FirstName);
        }
    }
}
