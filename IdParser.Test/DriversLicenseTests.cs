using System;
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
                RevisionDate = new DateTime(2009, 07, 15),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = File.ReadAllText("MA License 2009.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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
                RevisionDate = new DateTime(2016, 02, 22),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = File.ReadAllText("MA License 2016.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("02133", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Massachusetts", idCard.IssuerIdentificationNumber.GetDescription());

            Assert.AreEqual("08102016 REV 02222016", idCard.DocumentDiscriminator);
            Assert.AreEqual("12345S123456780612", idCard.InventoryControlNumber);

            Assert.AreEqual("MA504", idCard.AdditionalJurisdictionElements.Single(e => e.Key == "ZMZ").Value);
            Assert.AreEqual("08102016", idCard.AdditionalJurisdictionElements.Single(e => e.Key == "ZMB").Value);
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
                RevisionDate = new DateTime(2009, 07, 15),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = File.ReadAllText("MA License No Middle Name.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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
            var idCard = Barcode.Parse(file);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("New York", idCard.IssuerIdentificationNumber.GetDescription());
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
                ComplianceType = ComplianceType.NonCompliant,

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    RestrictionCodes = "158X9",
                    EndorsementCodes = "S"
                }
            };

            var file = File.ReadAllText("VA License.txt");
            var idCard = Barcode.Parse(file);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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
                ExpirationDate = new DateTime(2013, 02, 01),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C",
                    EndorsementCodes = "P"
                }
            };

            var file = File.ReadAllText("GA License.txt");
            var idCard = Barcode.Parse(file);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("Georgia", idCard.IssuerIdentificationNumber.GetDescription());
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

                IsOrganDonor = true,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "B"
                }
            };

            var file = File.ReadAllText("CT License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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

                IsOrganDonor = true,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "B"
                }
            };

            var file = File.ReadAllText("CT License Web Browser.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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

                IsOrganDonor = false,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = File.ReadAllText("CT License No Middle Name.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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
                ExpirationDate = new DateTime(2018, 02, 04),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "F"
                }
            };

            var file = File.ReadAllText("MO License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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
                ExpirationDate = new DateTime(2022, 03, 09),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "E",
                    RestrictionCodes = "A"
                }
            };

            var file = File.ReadAllText("FL License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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

                ComplianceType = ComplianceType.NonCompliant,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "C",
                    EndorsementCodes = "MC"
                }
            };

            var file = File.ReadAllText("NH License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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
                ExpirationDate = new DateTime(2019, 10, 24),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C"
                }
            };

            var file = File.ReadAllText("TX License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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

                IsOrganDonor = true,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C",
                    RestrictionCodes = "*/1",
                    EndorsementCodes = "----"
                }
            };

            var file = File.ReadAllText("PA License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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
                RevisionDate = new DateTime(2016, 06, 07),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C",
                    RestrictionCodes = "1"
                }
            };

            var file = File.ReadAllText("PA License 2016.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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
                RevisionDate = new DateTime(2016, 01, 26),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "10",
                    RestrictionCodes = "A"
                }
            };

            var file = File.ReadAllText("RH License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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

                HasTemporaryLawfulStatus = false,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = File.ReadAllText("NJ License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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

                ComplianceType = ComplianceType.NonCompliant,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C"
                }
            };

            var file = File.ReadAllText("NC License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

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

                IsOrganDonor = false,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "J"
                }
            };

            var file = File.ReadAllText("SC License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("29575-4321", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("South Carolina", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestMELicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "HARRY",
                    Last = "DRIVER",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "48 MAIN ST",
                    City = "BANGOR",
                    JurisdictionCode = "ME",
                    PostalCode = "04401",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1947, 10, 02),
                Sex = Sex.Male,
                Height = Height.FromImperial(69),
                Weight = Weight.FromImperial(175),

                IdNumber = "2407225",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2017, 09, 17),
                ExpirationDate = new DateTime(2021, 10, 02),
                
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C",
                    RestrictionCodes = "B"
                }
            };

            var file = File.ReadAllText("ME License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("04401", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Maine", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestOHLicense()
        {
            var weight = Weight.FromImperial(140);
            weight.WeightRange = WeightRange.Lbs131To160;

            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "DEBBIE",
                    Middle = "T",
                    Last = "MOTORIST",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "102 PARK AVE",
                    City = "NORTHWOOD",
                    JurisdictionCode = "OH",
                    PostalCode = "436191234",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1956, 02, 23),
                PlaceOfBirth = "US,OHIO",
                Sex = Sex.Female,
                EyeColor = EyeColor.Brown,
                HairColor = HairColor.Brown,
                Height = Height.FromImperial(60),
                Weight = weight,

                IdNumber = "PJ842270",
                AamvaVersionNumber = Version.Aamva2013,

                IssueDate = new DateTime(2016, 12, 02),
                ExpirationDate = new DateTime(2020, 02, 23),
                RevisionDate = new DateTime(2013, 12, 04),

                ComplianceType = ComplianceType.MateriallyCompliant,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "B"
                }
            };

            var file = File.ReadAllText("OH License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("43619-1234", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Ohio", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestMILicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "ROBERT",
                    Last = "SMITH"
                },

                Address = new Address
                {
                    StreetLine1 = "1348 E MAPLE CT",
                    City = "ROCHESTER HILLS",
                    JurisdictionCode = "MI",
                    PostalCode = "483064321",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1968, 03, 23),
                Sex = Sex.Male,

                IdNumber = "L 341 567 071 342",
                AamvaVersionNumber = Version.Aamva2005,

                IssueDate = new DateTime(2016, 03, 25),
                ExpirationDate = new DateTime(2020, 03, 25)
            };

            var file = File.ReadAllText("MI License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("48306-4321", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Michigan", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestONLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARY",
                    Middle = "ANN",
                    Last = "TESTER"
                },

                Address = new Address
                {
                    StreetLine1 = "123 ST GEORGE ST E",
                    City = "FERGUS",
                    JurisdictionCode = "ON",
                    PostalCode = "N1M3J6",
                    Country = Country.Canada
                },

                DateOfBirth = new DateTime(1996, 06, 03),
                Sex = Sex.Female,
                Height = Height.FromMetric(170),

                IdNumber = "S9244-43879-65702",
                AamvaVersionNumber = Version.Aamva2005,

                IssueDate = new DateTime(2017, 06, 07),
                ExpirationDate = new DateTime(2020, 06, 03),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "G"
                }
            };

            var file = File.ReadAllText("ON License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("N1M 3J6", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Ontario", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestVTLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "BOBBY",
                    Middle = "L",
                    Last = "TABLES",

                    WasFirstTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "304 PARK ST APT 5",
                    City = "BENNINGTON",
                    JurisdictionCode = "VT",
                    PostalCode = "05201",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1978, 08, 09),
                Sex = Sex.Male,
                EyeColor = EyeColor.Brown,
                Height = Height.FromImperial(67),
                Weight = Weight.FromImperial(195),

                IdNumber = "92265728",
                AamvaVersionNumber = Version.Aamva2012,

                IssueDate = new DateTime(2016, 08, 14),
                ExpirationDate = new DateTime(2018, 08, 09),
                RevisionDate = new DateTime(2013, 02, 20),

                IsOrganDonor = true,
                ComplianceType = ComplianceType.FullyCompliant,

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "B"
                }
            };

            var file = File.ReadAllText("VT License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("05201", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Vermont", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestPRLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "LAURENCIA",
                    Last = "ORTIZ ORTIZ",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "CAM CUBA LIBRE 800 KM",
                    City = "COROZAL",
                    JurisdictionCode = "PR",
                    PostalCode = "00783",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1972, 03, 06),
                Sex = Sex.Female,
                EyeColor = EyeColor.Brown,
                Height = Height.FromImperial(62),

                IdNumber = "4696735",
                AamvaVersionNumber = Version.Aamva2010,

                IssueDate = new DateTime(2017, 03, 03),
                ExpirationDate = new DateTime(2023, 03, 06),

                ComplianceType = ComplianceType.NonCompliant,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "3",
                    RestrictionCodes = "7"
                }
            };

            var file = File.ReadAllText("PR License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("00783", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Puerto Rico", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestMDLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "DIANA",
                    Middle = "ROSE",
                    Last = "SMITH",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "12 DOGWOOD CT APT B",
                    City = "BALTIMORE",
                    JurisdictionCode = "MD",
                    PostalCode = "21201",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1992, 10, 10),
                Sex = Sex.Female,
                Height = Height.FromImperial(66),
                Weight = Weight.FromImperial(170),

                IdNumber = "S-512-887-236-780",
                AamvaVersionNumber = Version.Aamva2013,

                IssueDate = new DateTime(2017, 06, 10),
                ExpirationDate = new DateTime(2025, 10, 10),
                RevisionDate = new DateTime(2016, 06, 20),

                ComplianceType = ComplianceType.FullyCompliant,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C",
                    RestrictionCodes = "B"
                }
            };

            var file = File.ReadAllText("MD License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("21201", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Maryland", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestCALicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "ELIJAH",
                    Middle = "MASON",
                    Last = "HARPER"
                },

                Address = new Address
                {
                    StreetLine1 = "671 BLUEBERRY HILL DR",
                    City = "MILPITAS",
                    JurisdictionCode = "CA",
                    PostalCode = "95035",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1973, 07, 05),
                Sex = Sex.Male,
                EyeColor = EyeColor.Blue,
                HairColor = HairColor.Brown,
                Height = Height.FromImperial(68),
                Weight = Weight.FromImperial(165),

                IdNumber = "F1485768",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2016, 02, 02),
                ExpirationDate = new DateTime(2019, 07, 05),
                RevisionDate = new DateTime(2010, 04, 16),

                HasTemporaryLawfulStatus = false,

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C"
                }
            };

            var file = File.ReadAllText("CA License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("95035", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("California", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestNMLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "LUIS",
                    Last = "SINCLAIR-ESCUEVA"
                },

                Address = new Address
                {
                    StreetLine1 = "1675 W 54TH ST",
                    City = "LOS ALAMOS",
                    JurisdictionCode = "NM",
                    PostalCode = "87544",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1981, 10, 27),
                Sex = Sex.Male,
                EyeColor = EyeColor.Brown,
                Height = Height.FromImperial(72),

                IdNumber = "513577879",
                AamvaVersionNumber = Version.Aamva2005,

                IssueDate = new DateTime(2013, 08, 22),
                ExpirationDate = new DateTime(2021, 11, 27),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "B"
                }
            };

            var file = File.ReadAllText("NM License.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("87544", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("New Mexico", idCard.IssuerIdentificationNumber.GetDescription());
        }

        private void AssertIdCard(IdentificationCard expected, IdentificationCard actual)
        {
            Assert.IsNotNull(expected);
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
            Assert.AreEqual(expected.PlaceOfBirth, actual.PlaceOfBirth, nameof(actual.PlaceOfBirth));
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

        private void AssertLicense(DriversLicense expected, IdentificationCard actualId)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actualId);
            Assert.IsInstanceOfType(actualId, typeof(DriversLicense));

            var actual = (DriversLicense)actualId;
            Assert.IsNotNull(actual.Jurisdiction);

            Assert.AreEqual(expected.Jurisdiction.VehicleClass, actual.Jurisdiction.VehicleClass, nameof(actual.Jurisdiction.VehicleClass));
            Assert.AreEqual(expected.Jurisdiction.RestrictionCodes, actual.Jurisdiction.RestrictionCodes, nameof(actual.Jurisdiction.RestrictionCodes));
            Assert.AreEqual(expected.Jurisdiction.EndorsementCodes, actual.Jurisdiction.EndorsementCodes, nameof(actual.Jurisdiction.EndorsementCodes));
            Assert.AreEqual(expected.Jurisdiction.VehicleClassificationDescription, actual.Jurisdiction.VehicleClassificationDescription, nameof(actual.Jurisdiction.VehicleClassificationDescription));
            Assert.AreEqual(expected.Jurisdiction.EndorsementCodeDescription, actual.Jurisdiction.EndorsementCodeDescription, nameof(actual.Jurisdiction.EndorsementCodeDescription));
            Assert.AreEqual(expected.Jurisdiction.RestrictionCodeDescription, actual.Jurisdiction.RestrictionCodeDescription, nameof(actual.Jurisdiction.RestrictionCodeDescription));

            Assert.AreEqual(expected.StandardVehicleClassification, actual.StandardVehicleClassification, nameof(actual.StandardVehicleClassification));
            Assert.AreEqual(expected.StandardEndorsementCode, actual.StandardEndorsementCode, nameof(actual.StandardEndorsementCode));
            Assert.AreEqual(expected.StandardRestrictionCode, actual.StandardRestrictionCode, nameof(actual.StandardRestrictionCode));
            Assert.AreEqual(expected.HazmatEndorsementExpirationDate, actual.HazmatEndorsementExpirationDate, nameof(actual.HazmatEndorsementExpirationDate));
        }
    }
}
