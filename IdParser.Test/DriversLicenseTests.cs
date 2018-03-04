using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace IdParser.Test
{
    [TestClass]
    public class DriversLicenseTests
    {
        [TestMethod]
        public void TestMA2009License()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "ROBERT",
                    Middle = "LOWNEY",
                    Last = "SMITH",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },
                
                Address = new Address
                {
                    StreetLine1 = "123 MAIN STREET",
                    City = "BOSTON",
                    JurisdictionCode = "MA",
                    PostalCode = "021080",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1977, 07, 07),
                Sex = Sex.Male,
                Height = Height.FromImperial(72),

                IdNumber = "S65807412",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2016, 06, 29),
                ExpirationDate = new DateTime(2020, 07, 07),
                RevisionDate = new DateTime(2009, 07, 15)
            };

            var file = File.ReadAllText("MA License 2009.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("Massachusetts", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestMA2016License()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MORRIS",
                    Middle = "T",
                    Last = "SAMPLE",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },
                
                Address = new Address
                {
                    StreetLine1 = "24 BEACON STREET",
                    City = "BOSTON",
                    JurisdictionCode = "MA",
                    PostalCode = "02133",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1971, 12, 31),
                Sex = Sex.Male,
                Height = Height.FromImperial(62),

                IdNumber = "S12345678",
                AamvaVersionNumber = Version.Aamva2013,

                IssueDate = new DateTime(2016, 08, 09),
                ExpirationDate = new DateTime(2021, 08, 16),
                RevisionDate = new DateTime(2016, 02, 22)
            };

            var file = File.ReadAllText("MA License 2016.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("02133", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Massachusetts", idCard.IssuerIdentificationNumber.GetDescription());

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
        public void TestMALicenseWithNoMiddleName()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "TONY",
                    Last = "ROBERT",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "123 MAIN STREET",
                    City = "BOSTON",
                    JurisdictionCode = "MA",
                    PostalCode = "021080",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1977, 07, 07),
                Sex = Sex.Male,
                Height = Height.FromImperial(72),

                IdNumber = "S65807412",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2016, 06, 29),
                ExpirationDate = new DateTime(2020, 07, 07),
                RevisionDate = new DateTime(2009, 07, 15)
            };

            var file = File.ReadAllText("MA License No Middle Name.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("Massachusetts", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestNYLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "M",
                    Middle = "Motorist",
                    Last = "Michael",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "2345 ANYWHERE STREET",
                    City = "YOUR CITY",
                    JurisdictionCode = "NY",
                    PostalCode = "12345",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(2013, 08, 31),
                Sex = Sex.Male,
                Height = Height.FromImperial(64),
                EyeColor = EyeColor.Brown,

                IdNumber = "NONE",
                AamvaVersionNumber = Version.Aamva2012,

                IssueDate = new DateTime(2013, 08, 31),
                ExpirationDate = new DateTime(2013, 08, 31)
            };

            var file = File.ReadAllText("NY License.txt");
            var license = Barcode.Parse(file);

            AssertIdCard(expected, license);

            Assert.AreEqual("New York", license.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestVALicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "JUSTIN",
                    Middle = "WILLIAM",
                    Last = "MAURY"
                },
                
                Address = new Address
                {
                    StreetLine1 = "17 FIRST STREET",
                    City = "STAUNTON",
                    JurisdictionCode = "VA",
                    PostalCode = "24401",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1958, 07, 15),
                Sex = Sex.Male,
                Height = Height.FromImperial(75),
                EyeColor = EyeColor.Brown,

                IdNumber = "T16700185",
                AamvaVersionNumber = Version.Aamva2005,

                IssueDate = new DateTime(2009, 08, 14),
                ExpirationDate = new DateTime(2017, 08, 14),
                RevisionDate = new DateTime(2008, 12, 10),

                HasTemporaryLawfulStatus = false,
                ComplianceType = ComplianceType.NonCompliant
            };

            var file = File.ReadAllText("VA License.txt");
            var idCard = Barcode.Parse(file);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("Virginia", idCard.IssuerIdentificationNumber.GetDescription());

            Assert.IsInstanceOfType(idCard, typeof(DriversLicense));

            if (idCard is DriversLicense license)
            {
                Assert.AreEqual("158X9", license.Jurisdiction.RestrictionCodes);
            }
        }

        [TestMethod]
        public void TestGALicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "JANICE",
                    Last = "SAMPLE",
                    Suffix = "PH.D."
                },

                Address = new Address
                {
                    StreetLine1 = "123 NORTH STATE ST.",
                    City = "ANYTOWN",
                    JurisdictionCode = "GA",
                    PostalCode = "30334",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1957, 07, 01),
                Sex = Sex.Female,
                Height = Height.FromImperial(64),
                Weight = Weight.FromRange(WeightRange.Lbs101To130),
                EyeColor = EyeColor.Blue,

                IdNumber = "100000001",
                AamvaVersionNumber = Version.Aamva2005,

                IssueDate = new DateTime(2006, 07, 01),
                ExpirationDate = new DateTime(2013, 02, 01)
            };

            var file = File.ReadAllText("GA License.txt");
            var idCard = Barcode.Parse(file);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("Georgia", idCard.IssuerIdentificationNumber.GetDescription());

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
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "ADULT",
                    Middle = "A",
                    Last = "CTLIC"
                },

                Address = new Address
                {
                    StreetLine1 = "60 STATE ST",
                    City = "WETHERSFIELD",
                    JurisdictionCode = "CT",
                    PostalCode = "061091896",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1961, 01, 01),
                Sex = Sex.Female,
                Height = Height.FromImperial(5, 6),
                EyeColor = EyeColor.Blue,

                IdNumber = "990000001",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2009, 02, 23),
                ExpirationDate = new DateTime(2015, 01, 01),

                IsOrganDonor = true
            };

            var file = File.ReadAllText("CT License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("Connecticut", idCard.IssuerIdentificationNumber.GetDescription());

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
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "ADULT",
                    Middle = "A",
                    Last = "CTLIC"
                },

                Address = new Address
                {
                    StreetLine1 = "60 STATE ST",
                    City = "WETHERSFIELD",
                    JurisdictionCode = "CT",
                    PostalCode = "061091896",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1961, 01, 01),
                Sex = Sex.Female,
                Height = Height.FromImperial(5, 6),
                EyeColor = EyeColor.Blue,

                IdNumber = "990000001",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2009, 02, 23),
                ExpirationDate = new DateTime(2015, 01, 01),

                IsOrganDonor = true
            };

            var file = File.ReadAllText("CT License Web Browser.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("Connecticut", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestCTLicenseNoMiddleName()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "CHUNG",
                    Last = "WANG"
                },

                Address = new Address
                {
                    StreetLine1 = "123 SIDE ST",
                    City = "WATERBURY",
                    JurisdictionCode = "CT",
                    PostalCode = "067081897",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1949, 03, 03),
                Sex = Sex.Male,
                Height = Height.FromImperial(5, 8),
                EyeColor = EyeColor.Brown,

                IdNumber = "035032278",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2017, 01, 19),
                ExpirationDate = new DateTime(2023, 03, 03),

                IsOrganDonor = false
            };

            var file = File.ReadAllText("CT License No Middle Name.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("Connecticut", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestMOLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "FirstNameTest",
                    Last = "LastNameTest"
                },

                Address = new Address
                {
                    StreetLine1 = "123 ABC TEST ADDRESS 2ND FL",
                    City = "ST LOUIS",
                    JurisdictionCode = "MO",
                    PostalCode = "633011",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(2017, 08, 09),
                Sex = Sex.Male,
                Height = Height.FromImperial(5, 8),
                Weight = Weight.FromImperial(155),
                EyeColor = EyeColor.Brown,

                IdNumber = "X100097001",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2011, 06, 30),
                ExpirationDate = new DateTime(2018, 02, 04)
            };

            var file = File.ReadAllText("MO License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("Missouri", idCard.IssuerIdentificationNumber.GetDescription());

            Assert.AreEqual("MAST LOUIS CITY", idCard.AdditionalJurisdictionElements.Single(e => e.Key == "ZMZ").Value);
            Assert.AreEqual("112001810097", idCard.AdditionalJurisdictionElements.Single(e => e.Key == "ZMB").Value);

            Assert.IsInstanceOfType(idCard, typeof(DriversLicense));

            if (idCard is DriversLicense license)
            {
                Assert.AreEqual("F", license.Jurisdiction.VehicleClass);
            }
        }

        [TestMethod]
        public void TestFLLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "JOEY",
                    Middle = "MIDLAND",
                    Last = "TESTER"
                },

                Address = new Address
                {
                    StreetLine1 = "1234 PARK ST LOT 504",
                    City = "KEY WEST",
                    JurisdictionCode = "FL",
                    PostalCode = "330400504",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1941, 05, 09),
                Sex = Sex.Male,
                Height = Height.FromImperial(6, 1),

                IdNumber = "H574712510891",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2014, 05, 01),
                ExpirationDate = new DateTime(2022, 03, 09)
            };

            var file = File.ReadAllText("FL License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("33040-0504", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Florida", idCard.IssuerIdentificationNumber.GetDescription());

            Assert.AreEqual(5, idCard.AdditionalJurisdictionElements.Count);
            Assert.AreEqual("FA", idCard.AdditionalJurisdictionElements.Single(e => e.Key == "ZFZ").Value);

            if (idCard is DriversLicense license)
            {
                Assert.AreEqual("A", license.Jurisdiction.RestrictionCodes);
                Assert.AreEqual("E", license.Jurisdiction.VehicleClass);
            }
        }

        [TestMethod]
        public void TestNHLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "DONNIE",
                    Middle = "G",
                    Last = "TESTER",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    City = "SOMETOWN",
                    StreetLine1 = "802 WILLIAMS ST",
                    JurisdictionCode = "NH",
                    PostalCode = "01234",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1977, 11, 06),
                Sex = Sex.Male,
                Height = Height.FromImperial(69),
                EyeColor = EyeColor.Green,

                IdNumber = "NHI17128755",
                AamvaVersionNumber = Version.Aamva2013,

                IssueDate = new DateTime(2017, 12, 19),
                ExpirationDate = new DateTime(2022, 11, 06),
                RevisionDate = new DateTime(2016, 06, 09),

                ComplianceType = ComplianceType.NonCompliant
            };

            var file = File.ReadAllText("NH License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("01234", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("New Hampshire", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestTXLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "ROBERTO",
                    Last = "GONSALVES"
                },

                Address = new Address
                {
                    StreetLine1 = "1254 FIRST",
                    City = "EL PASO",
                    JurisdictionCode = "TX",
                    PostalCode = "79936",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1993, 10, 24),
                Sex = Sex.Male,
                Height = Height.FromImperial(65),
                EyeColor = EyeColor.Brown,
                HairColor = HairColor.Brown,

                IdNumber = "37110073",
                AamvaVersionNumber = Version.Aamva2005,

                IssueDate = new DateTime(2014, 10, 25),
                ExpirationDate = new DateTime(2019, 10, 24)
            };

            var file = File.ReadAllText("TX License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("79936", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Texas", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestPALicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "JOHN",
                    Middle = "P",
                    Last = "SMITH"
                },

                Address = new Address
                {
                    StreetLine1 = "140 MAIN ST",
                    City = "PHILADELPHIA",
                    JurisdictionCode = "PA",
                    PostalCode = "19130",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1986, 02, 02),
                Sex = Sex.Male,
                Height = Height.FromImperial(6, 0),
                EyeColor = EyeColor.Hazel,

                IdNumber = "26798765",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2016, 01, 04),
                ExpirationDate = new DateTime(2020, 02, 03),

                IsOrganDonor = true
            };

            var file = File.ReadAllText("PA License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("19130", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Pennsylvania", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestPA2016License()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "CAPTAIN",
                    Middle = "JACK",
                    Last = "MORGAN",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "1725 SLOUGH AVE",
                    StreetLine2 = "APT 4",
                    City = "SCRANTON",
                    JurisdictionCode = "PA",
                    PostalCode = "18503",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1960, 05, 22),
                Sex = Sex.Male,
                Height = Height.FromImperial(71),
                EyeColor = EyeColor.Brown,

                IdNumber = "25881776",
                AamvaVersionNumber = Version.Aamva2016,

                IssueDate = new DateTime(2017, 11, 28),
                ExpirationDate = new DateTime(2021, 05, 23),
                RevisionDate = new DateTime(2016, 06, 07)
            };

            var file = File.ReadAllText("PA License 2016.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("18503", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Pennsylvania", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestRHLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "LOIS",
                    Middle = "PATRICE",
                    Last = "GRIFFIN",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "31 SPOONER ST",
                    StreetLine2 = "APT T2",
                    City = "QUAHOG",
                    JurisdictionCode = "RI",
                    PostalCode = "000931760",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1988, 04, 21),
                Sex = Sex.Female,
                Height = Height.FromImperial(66),
                Weight = Weight.FromImperial(170),
                EyeColor = EyeColor.Brown,
                HairColor = HairColor.Black,
                
                IdNumber = "30005037",
                AamvaVersionNumber = Version.Aamva2013,

                IssueDate = new DateTime(2017, 10, 17),
                ExpirationDate = new DateTime(2019, 04, 21),
                RevisionDate = new DateTime(2016, 01, 26)
            };

            var file = File.ReadAllText("RH License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("00093-1760", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Rhode Island", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestNJLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MELISSA",
                    Middle = "R",
                    Last = "FOX",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "1435 AUBURN AVE",
                    City = "VERNON",
                    JurisdictionCode = "NJ",
                    PostalCode = "074182554",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1983, 02, 04),
                Sex = Sex.Female,
                Height = Height.FromImperial(62),
                EyeColor = EyeColor.Green,

                IdNumber = "P62472647457903",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2015, 02, 28),
                ExpirationDate = new DateTime(2019, 02, 28),
                RevisionDate = new DateTime(2010, 07, 23),

                HasTemporaryLawfulStatus = false
            };

            var file = File.ReadAllText("NJ License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("07418-2554", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("New Jersey", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestNCLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "RICK",
                    Middle = "SANTIAGO",
                    Last = "MORALES MARTIZ",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "1440 BROWN TER",
                    City = "FAYETTEVILLE",
                    JurisdictionCode = "NC",
                    PostalCode = "283041234",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1986, 06, 12),
                Sex = Sex.Male,
                Height = Height.FromImperial(69),
                EyeColor = EyeColor.Brown,
                HairColor = HairColor.Black,

                IdNumber = "00004985690",
                AamvaVersionNumber = Version.Aamva2013,

                IssueDate = new DateTime(2017, 11, 16),
                ExpirationDate = new DateTime(2025, 06, 12),
                RevisionDate = new DateTime(2014, 10, 24),

                ComplianceType = ComplianceType.NonCompliant
            };

            var file = File.ReadAllText("NC License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("28304-1234", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("North Carolina", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestSCLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARY",
                    Middle = "ROBINS",
                    Last = "SMITH"
                },
                
                Address = new Address
                {
                    StreetLine1 = "209 CEDAR HILL DR UNIT 12",
                    City = "SURFSIDE BEACH",
                    JurisdictionCode = "SC",
                    PostalCode = "295754321",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1972, 02, 12),
                Sex = Sex.Female,
                Height = Height.FromImperial(5, 10),
                Weight = Weight.FromImperial(128),

                IdNumber = "102639206",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2009, 06, 19),
                ExpirationDate = new DateTime(2019, 02, 12),

                IsOrganDonor = false
            };

            var file = File.ReadAllText("SC License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.AreEqual("29575-4321", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("South Carolina", idCard.IssuerIdentificationNumber.GetDescription());
        }

        private void AssertIdCard(IdentificationCard expected, IdentificationCard actual)
        {
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Name.First, actual.Name.First, nameof(actual.Name.First));
            Assert.AreEqual(expected.Name.Middle, actual.Name.Middle, nameof(actual.Name.Middle));
            Assert.AreEqual(expected.Name.Last, actual.Name.Last, nameof(actual.Name.Last));
            Assert.AreEqual(expected.Name.Suffix, actual.Name.Suffix, nameof(actual.Name.Suffix));

            Assert.AreEqual(expected.Name.WasFirstTruncated, actual.Name.WasFirstTruncated, nameof(actual.Name.WasFirstTruncated));
            Assert.AreEqual(expected.Name.WasMiddleTruncated, actual.Name.WasMiddleTruncated, nameof(actual.Name.WasMiddleTruncated));
            Assert.AreEqual(expected.Name.WasLastTruncated, actual.Name.WasLastTruncated, nameof(actual.Name.WasLastTruncated));

            Assert.AreEqual(expected.Address.City, actual.Address.City, nameof(actual.Address.City));
            Assert.AreEqual(expected.Address.StreetLine1, actual.Address.StreetLine1, nameof(actual.Address.StreetLine1));
            Assert.AreEqual(expected.Address.StreetLine2, actual.Address.StreetLine2, nameof(actual.Address.StreetLine2));
            Assert.AreEqual(expected.Address.JurisdictionCode, actual.Address.JurisdictionCode, nameof(actual.Address.JurisdictionCode));
            Assert.AreEqual(expected.Address.JurisdictionCode, actual.IssuerIdentificationNumber.GetAbbreviation(), nameof(actual.IssuerIdentificationNumber));
            Assert.AreEqual(expected.Address.PostalCode, actual.Address.PostalCode, nameof(actual.Address.PostalCode));
            Assert.AreEqual(expected.Address.Country, actual.Address.Country, nameof(actual.Address.Country));

            Assert.AreEqual(expected.DateOfBirth, actual.DateOfBirth, nameof(actual.DateOfBirth));
            Assert.AreEqual(expected.Sex, actual.Sex, nameof(actual.Sex));
            Assert.AreEqual(expected.Height, actual.Height, nameof(actual.Height));
            Assert.AreEqual(expected.Weight, actual.Weight, nameof(actual.Weight));

            Assert.AreEqual(expected.EyeColor, actual.EyeColor, nameof(actual.EyeColor));
            Assert.AreEqual(expected.HairColor, actual.HairColor, nameof(actual.HairColor));
            Assert.AreEqual(expected.Ethnicity, actual.Ethnicity, nameof(actual.Ethnicity));

            Assert.AreEqual(expected.IdNumber, actual.IdNumber, nameof(actual.IdNumber));
            Assert.AreEqual(expected.AamvaVersionNumber, actual.AamvaVersionNumber, nameof(actual.AamvaVersionNumber));

            Assert.AreEqual(expected.IssueDate, actual.IssueDate, nameof(actual.IssueDate));
            Assert.AreEqual(expected.ExpirationDate, actual.ExpirationDate, nameof(actual.ExpirationDate));
            Assert.AreEqual(expected.RevisionDate, actual.RevisionDate, nameof(actual.RevisionDate));

            Assert.AreEqual(expected.Under18Until, actual.Under18Until, nameof(actual.Under18Until));
            Assert.AreEqual(expected.Under19Until, actual.Under19Until, nameof(actual.Under19Until));
            Assert.AreEqual(expected.Under21Until, actual.Under21Until, nameof(actual.Under21Until));

            Assert.AreEqual(expected.ComplianceType, actual.ComplianceType, nameof(actual.ComplianceType));
            Assert.AreEqual(expected.HasTemporaryLawfulStatus, actual.HasTemporaryLawfulStatus, nameof(actual.HasTemporaryLawfulStatus));
            Assert.AreEqual(expected.IsOrganDonor, actual.IsOrganDonor, nameof(actual.IsOrganDonor));
            Assert.AreEqual(expected.IsVeteran, actual.IsVeteran, nameof(actual.IsVeteran));
        }
    }
}
