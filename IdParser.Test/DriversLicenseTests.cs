using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace IdParser.Test
{
    [TestClass]
    public class DriversLicenseTests : BaseTest
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

            var file = License("MA 2009");
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

            var file = License("MA 2016");
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

            var file = License("MA No Middle Name");
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

            var file = License("NY");
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

            var file = License("VA");
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

            var file = License("GA");
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

            var file = License("CT");
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

            var file = License("CT Web Browser");
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

            var file = License("CT No Middle Name");
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

            var file = License("MO");
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

            var file = License("FL");
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

            var file = License("NH");
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

            var file = License("TX");
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

            var file = License("PA");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("19130", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Pennsylvania", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestPALicenseTwoMiddleNames()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "JOHN",
                    Middle = "ROBERT LEE",
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

            var file = License("PA Two Middle Names");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("19130", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Pennsylvania", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestPALicenseThreeMiddleNames()
        {
            var expected = new Name
            {
                First = "JOHN",
                Middle = "ROBERT LEE JOHNSON",
                Last = "SMITH"
            };

            var file = License("PA Three Middle Names");
            var idCard = Barcode.Parse(file, Validation.None);

            Assert.AreEqual(expected.First, idCard.Name.First);
            Assert.AreEqual(expected.Middle, idCard.Name.Middle);
            Assert.AreEqual(expected.Last, idCard.Name.Last);
            Assert.AreEqual(expected.Suffix, idCard.Name.Suffix);
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

            var file = License("PA 2016");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("18503", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Pennsylvania", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestRILicense()
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

            var file = License("RI");
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

            var file = License("NJ");
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

            var file = License("NC");
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

            var file = License("SC");
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
                EyeColor = EyeColor.Brown,
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

            var file = License("ME");
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

            var file = License("OH");
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

            var file = License("MI");
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

            var file = License("ON");
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

            var file = License("VT");
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

            var file = License("PR");
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

            var file = License("MD");
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

            var file = License("CA");
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

            var file = License("NM");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("87544", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("New Mexico", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestUTLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARIE",
                    Middle = "RAYE",
                    Last = "CALENDAR"
                },

                Address = new Address
                {
                    StreetLine1 = "200 E 1900 N",
                    City = "LEHI",
                    JurisdictionCode = "UT",
                    PostalCode = "84043",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1981, 08, 14),
                Sex = Sex.Female,
                EyeColor = EyeColor.Green,
                HairColor = HairColor.Brown,
                Height = Height.FromImperial(64),
                Weight = Weight.FromImperial(205),

                IdNumber = "0163375279",
                AamvaVersionNumber = Version.Aamva2012,

                IssueDate = new DateTime(2013, 08, 14),
                ExpirationDate = new DateTime(2018, 08, 14),
                RevisionDate = new DateTime(2013, 01, 01),

                Under18Until = new DateTime(1999, 08, 14),
                Under19Until = new DateTime(2000, 08, 14),
                Under21Until = new DateTime(2002, 08, 14),

                IsOrganDonor = true,
                ComplianceType = ComplianceType.FullyCompliant,

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "A"
                }
            };

            var file = License("UT");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("84043", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Utah", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestIALicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARK",
                    Middle = "MOTORIST",
                    Last = "SMITH",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "123 ANY MAIN ST",
                    City = "RED OAK",
                    JurisdictionCode = "IA",
                    PostalCode = "51566",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1991, 07, 11),
                Sex = Sex.Male,
                EyeColor = EyeColor.Green,
                Height = Height.FromImperial(72),

                IdNumber = "109BB2608",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2013, 10, 16),
                ExpirationDate = new DateTime(2020, 07, 11),
                RevisionDate = new DateTime(2011, 07, 25),
                
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C",
                    EndorsementCodes = "L"
                }
            };

            var file = License("IA");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("51566", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Iowa", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestORLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARY",
                    Middle = "JONES",
                    Last = "SMITH"
                },

                Address = new Address
                {
                    StreetLine1 = "4455 SE 25TH ST",
                    City = "CORVALLIS",
                    JurisdictionCode = "OR",
                    PostalCode = "97330",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1950, 06, 26),
                Sex = Sex.Female,
                Height = Height.FromImperial(5, 2),
                Weight = Weight.FromImperial(185),

                IdNumber = "4066452",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2016, 06, 24),
                ExpirationDate = new DateTime(2024, 06, 26),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C",
                    RestrictionCodes = "BD"
                }
            };

            var file = License("OR");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("97330", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Oregon", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestLALicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARCIA",
                    Middle = "MOTORIST",
                    Last = "JONES"
                },

                Address = new Address
                {
                    StreetLine1 = "1234 HWY 57",
                    City = "EROS",
                    JurisdictionCode = "LA",
                    PostalCode = "71238",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1974, 07, 07),
                Sex = Sex.Female,
                Height = Height.FromImperial(5, 2),
                Weight = Weight.FromImperial(220),

                IdNumber = "005799564",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2014, 05, 20),
                ExpirationDate = new DateTime(2018, 07, 07),

                IsOrganDonor = true,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "E"
                }
            };

            var file = License("LA");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("71238", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Louisiana", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestKYLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARY",
                    Middle = "ANN",
                    Last = "SMITH",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "123 WISTERIA LN 23",
                    City = "LOUISVILLE",
                    JurisdictionCode = "KY",
                    PostalCode = "40218",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1954, 11, 12),
                Sex = Sex.Female,
                EyeColor = EyeColor.Hazel,
                Height = Height.FromImperial(65),

                IdNumber = "K12340057",
                AamvaVersionNumber = Version.Aamva2010,

                IssueDate = new DateTime(2017, 11, 22),
                ExpirationDate = new DateTime(2021, 12, 13),
                RevisionDate = new DateTime(2012, 03, 16),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "1"
                }
            };

            var file = License("KY");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("40218", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Kentucky", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestWILicense()
        {
            // Wisconsin defines a subfile in the header but we don't follow it
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "JOEY",
                    Middle = "M",
                    Last = "TESTER",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "N1234 PINEWOOD RD",
                    City = "CHEESY",
                    JurisdictionCode = "WI",
                    PostalCode = "54767",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1983, 08, 15),
                Sex = Sex.Male,
                EyeColor = EyeColor.Brown,
                Height = Height.FromImperial(72),

                IdNumber = "M2861738629325",
                AamvaVersionNumber = Version.Aamva2010,

                IssueDate = new DateTime(2013, 04, 11),
                ExpirationDate = new DateTime(2018, 08, 15),
                RevisionDate = new DateTime(2012, 03, 16),

                ComplianceType = ComplianceType.NonCompliant,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "ABCD",
                    RestrictionCodes = "B",
                    EndorsementCodes = "N"
                }
            };

            var file = License("WI");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("54767", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Wisconsin", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestDELicense()
        {
            // Wisconsin defines a subfile in the header but we don't follow it
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MOTORIST",
                    Last = "TESTER",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "7895 CHERRYBLOSSOM HL",
                    StreetLine2 = "APT @ CRAWFORD INN",
                    City = "NEWARK",
                    JurisdictionCode = "DE",
                    PostalCode = "197521234",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1989, 09, 09),
                Sex = Sex.Male,
                EyeColor = EyeColor.Brown,
                Height = Height.FromImperial(71),
                Weight = Weight.FromImperial(130),

                IdNumber = "1824873",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2017, 10, 27),
                ExpirationDate = new DateTime(2019, 01, 09),
                RevisionDate = new DateTime(2010, 02, 13),

                ComplianceType = ComplianceType.MateriallyCompliant,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "B"
                }
            };

            var file = License("DE");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("19752-1234", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Delaware", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestCOLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MICHAEL",
                    Middle = "CODY",
                    Last = "MOTORIST"
                },

                Address = new Address
                {
                    StreetLine1 = "909 COUNTRY ROAD 206",
                    City = "BOULDER",
                    JurisdictionCode = "CO",
                    PostalCode = "81635",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1992, 07, 13),
                Sex = Sex.Male,
                EyeColor = EyeColor.Green,
                Height = Height.FromImperial(73),

                IdNumber = "102367033",
                AamvaVersionNumber = Version.Aamva2012,

                IssueDate = new DateTime(2013, 08, 08),
                ExpirationDate = new DateTime(2018, 07, 13),
                RevisionDate = new DateTime(2013, 06, 01),

                ComplianceType = ComplianceType.MateriallyCompliant,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "R"
                }
            };

            var file = License("CO");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("81635", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Colorado", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestALLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MICHAEL",
                    Middle = "MOTORIST",
                    Last = "SMITH"
                },

                Address = new Address
                {
                    StreetLine1 = "123 COUNTY DR",
                    City = "BLUE RIDGE",
                    JurisdictionCode = "AL",
                    PostalCode = "360931234",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1967, 03, 27),
                Sex = Sex.Male,
                EyeColor = EyeColor.Blue,
                HairColor = HairColor.Brown,
                Height = Height.FromImperial(70),
                Weight = Weight.FromRange(WeightRange.Lbs191To220),

                IdNumber = "5677922",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2014, 11, 26),
                ExpirationDate = new DateTime(2018, 11, 18),
                RevisionDate = new DateTime(2009, 11, 06),

                ComplianceType = ComplianceType.NonCompliant,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "DMV"
                }
            };

            var file = License("AL");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("36093-1234", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Alabama", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestAZLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "SUSAN",
                    Middle = "T",
                    Last = "WILLIAMS"
                },

                Address = new Address
                {
                    StreetLine1 = "5123 WACO DR",
                    City = "TUSCON",
                    JurisdictionCode = "AZ",
                    PostalCode = "856414321",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1989, 01, 24),
                Sex = Sex.Female,
                EyeColor = EyeColor.Blue,
                HairColor = HairColor.Brown,
                Height = Height.FromImperial(5, 5),
                Weight = Weight.FromImperial(160),

                IdNumber = "D04852767",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2013, 06, 04),
                ExpirationDate = new DateTime(2054, 01, 24),

                IsOrganDonor = false,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "B"
                }
            };

            var file = License("AZ");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("85641-4321", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Arizona", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestARLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MICHAEL",
                    Middle = "RALPH",
                    Last = "MOTORIST"
                },

                Address = new Address
                {
                    StreetLine1 = "321 MAIN ST",
                    City = "HOT SPRINGS",
                    JurisdictionCode = "AR",
                    PostalCode = "719014455",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1946, 11, 22),
                Sex = Sex.Male,
                EyeColor = EyeColor.Brown,
                Ethnicity = Ethnicity.White,
                Height = Height.FromImperial(70),

                IdNumber = "9298847972",
                AamvaVersionNumber = Version.Aamva2010,

                IssueDate = new DateTime(2016, 09, 13),
                ExpirationDate = new DateTime(2024, 11, 22),
                RevisionDate = new DateTime(2012, 09, 15),

                ComplianceType = ComplianceType.NonCompliant,
                HasTemporaryLawfulStatus = false,

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = License("AR");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("71901-4455", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Arkansas", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestWALicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARY",
                    Middle = "S",
                    Last = "TESTER"
                },

                Address = new Address
                {
                    StreetLine1 = "16255 PEWDER CT SE",
                    City = "REDMOND",
                    JurisdictionCode = "WA",
                    PostalCode = "980081234",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1950, 05, 23),
                Sex = Sex.Female,
                EyeColor = EyeColor.Brown,
                Height = Height.FromImperial(61),
                Weight = Weight.FromRange(WeightRange.Lbs131To160),

                IdNumber = "TESTEDM504K9",
                AamvaVersionNumber = Version.Aamva2005,

                IssueDate = new DateTime(2015, 04, 16),
                ExpirationDate = new DateTime(2021, 05, 23)
            };

            var file = License("WA");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("98008-1234", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Washington", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestMTLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARY",
                    Middle = "ROSE",
                    Last = "TESTER"
                },

                Address = new Address
                {
                    StreetLine1 = "1254 MAGNOLIA AVE",
                    City = "HELENA",
                    JurisdictionCode = "MT",
                    PostalCode = "59601",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1994, 05, 14),
                Sex = Sex.Female,
                EyeColor = EyeColor.Hazel,
                Height = Height.FromImperial(67),
                Weight = Weight.FromRange(WeightRange.Lbs131To160),

                IdNumber = "0504928899117",
                AamvaVersionNumber = Version.Aamva2005,

                IssueDate = new DateTime(2015, 07, 02),
                ExpirationDate = new DateTime(2023, 05, 14),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = License("MT");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("59601", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Montana", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestKSLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "JOEY",
                    Middle = "SMITH",
                    Last = "MOTORIST",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "12345 S 110TH TER",
                    City = "OVERLAND PARK",
                    JurisdictionCode = "KS",
                    PostalCode = "66210",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1980, 01, 26),
                Sex = Sex.Male,
                EyeColor = EyeColor.Green,
                Height = Height.FromImperial(71),

                IdNumber = "K04-76-5990",
                AamvaVersionNumber = Version.Aamva2016,

                IssueDate = new DateTime(2017, 11, 29),
                ExpirationDate = new DateTime(2023, 01, 26),
                RevisionDate = new DateTime(2017, 02, 26),

                ComplianceType = ComplianceType.FullyCompliant,
                IsOrganDonor = true,

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "C"
                }
            };

            var file = License("KS");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("66210", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Kansas", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestINLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "RYAN",
                    Middle = "MICHAEL",
                    Last = "MOTORIST"
                },

                Address = new Address
                {
                    StreetLine1 = "12345 W HENCHMEN CIR",
                    City = "ANYCITY",
                    JurisdictionCode = "IN",
                    PostalCode = "47458",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1993, 02, 25),
                Sex = Sex.Male,
                EyeColor = EyeColor.Hazel,
                HairColor = HairColor.Blond,
                Height = Height.FromImperial(69),
                Weight = Weight.FromImperial(245),

                IdNumber = "3249-09-7547",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2016, 08, 03),
                ExpirationDate = new DateTime(2023, 02, 25),
                RevisionDate = new DateTime(2009, 09, 21),

                ComplianceType = ComplianceType.FullyCompliant
            };

            var file = License("IN");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("47458", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Indiana", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestILLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "SUSAN",
                    Middle = "T",
                    Last = "MOTORIST",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "123 LAKE SHORE DR APT",
                    StreetLine2 = "6431",
                    City = "CHICAGO",
                    JurisdictionCode = "IL",
                    PostalCode = "60611",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1969, 06, 27),
                Sex = Sex.Female,
                EyeColor = EyeColor.Green,
                Height = Height.FromImperial(68),
                Weight = Weight.FromImperial(200),

                IdNumber = "W63177069784",
                AamvaVersionNumber = Version.Aamva2013,

                IssueDate = new DateTime(2017, 04, 13),
                ExpirationDate = new DateTime(2021, 06, 27),
                RevisionDate = new DateTime(2015, 09, 17),

                IsOrganDonor = true,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = License("IL");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("60611", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Illinois", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestHILicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MICHAEL",
                    Middle = "JAY",
                    Last = "MOTORIST"
                },

                Address = new Address
                {
                    StreetLine1 = "456 MOANA ST 2",
                    StreetLine2 = "O",
                    City = "HONOLULU",
                    JurisdictionCode = "HI",
                    PostalCode = "96826",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1988, 03, 12),
                Sex = Sex.Male,
                EyeColor = EyeColor.Blue,
                HairColor = HairColor.Blond,
                Height = Height.FromImperial(72),

                IdNumber = "H01387330",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2016, 05, 13),
                ExpirationDate = new DateTime(2024, 03, 12),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "3",
                    RestrictionCodes = "B"
                }
            };

            var file = License("HI");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("96826", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Hawaii", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestWVLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "JOE",
                    Middle = "BOB",
                    Last = "SMITH"
                },

                Address = new Address
                {
                    StreetLine1 = "518   S RANDOM STREET",
                    City = "ANYTOWN",
                    JurisdictionCode = "WV",
                    PostalCode = "12345",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1972, 11, 03),
                Sex = Sex.Male,
                EyeColor = EyeColor.Brown,
                Height = Height.FromImperial(71),
                Weight = Weight.FromImperial(190),

                IdNumber = "F123456",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2017, 10, 01),
                ExpirationDate = new DateTime(2022, 11, 03),
                ComplianceType = ComplianceType.NonCompliant,

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "E"
                }
            };

            var file = License("WV");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("12345", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("West Virginia", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestAKLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MARY",
                    Middle = "JOE",
                    Last = "SMITH"
                },

                Address = new Address
                {
                    StreetLine1 = "12345 E MAIN HY",
                    City = "ANCHORAGE",
                    JurisdictionCode = "AK",
                    PostalCode = "99645",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1955, 04, 02),
                Sex = Sex.Female,
                EyeColor = EyeColor.Blue,
                HairColor = HairColor.Gray,
                Height = Height.FromImperial(64),
                Weight = Weight.FromImperial(160),

                IdNumber = "7559886",
                AamvaVersionNumber = Version.Aamva2013,

                IssueDate = new DateTime(2016, 03, 22),
                ExpirationDate = new DateTime(2021, 04, 02),
                Under21Until = new DateTime(1976, 04, 02),
                
                IsOrganDonor = true,
                IsVeteran = false,
                DocumentDiscriminator = "2881111",

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D",
                    RestrictionCodes = "1"
                }
            };

            var file = License("AK");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("99645", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Alaska", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestDCLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "DIANA",
                    Middle = "ROBIN",
                    Last = "AL-MAAR"
                },

                Address = new Address
                {
                    StreetLine1 = "1234 14TH ST SW 1A",
                    City = "WASHINGTON",
                    JurisdictionCode = "DC",
                    PostalCode = "200091234",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1985, 07, 29),
                Sex = Sex.Female,
                Height = Height.FromImperial(5, 6),
                Weight = Weight.FromImperial(140),

                IdNumber = "3234567",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2013, 07, 30),
                ExpirationDate = new DateTime(2021, 07, 29),

                IsOrganDonor = true,
                DocumentDiscriminator = "2881111",

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = License("DC");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("20009-1234", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("District of Columbia", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestLeadingWhitespaceLicense()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MOTORIST",
                    Middle = "R",
                    Last = "SHEEHAN",
                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "2 ROBERTS DRIVE",
                    City = "PLYMOUTH",
                    JurisdictionCode = "MA",
                    PostalCode = "023601234",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1939, 12, 07),
                Sex = Sex.Male,
                Height = Height.FromImperial(71),

                IdNumber = "S58239477",
                AamvaVersionNumber = Version.Aamva2009,

                IssueDate = new DateTime(2014, 11, 14),
                ExpirationDate = new DateTime(2018, 12, 07),
                RevisionDate = new DateTime(2009, 07, 15),

                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "DM",
                    RestrictionCodes = "B"
                }
            };

            var file = File.ReadAllText("Leading Whitespace.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("02360-1234", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Massachusetts", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestInvalidHeader()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "MICHAEL",
                    Middle = "G",
                    Last = "MOTORIST"
                },

                Address = new Address
                {
                    StreetLine1 = "12 MAIN AVE",
                    City = "WEST HAVEN",
                    JurisdictionCode = "CT",
                    PostalCode = "06516",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1961, 02, 04),
                Sex = Sex.Male,
                EyeColor = EyeColor.Brown,
                Height = Height.FromImperial(5, 4),

                IdNumber = "025995434",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2016, 11, 14),
                ExpirationDate = new DateTime(2023, 02, 04),

                IsOrganDonor = true,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = File.ReadAllText("Invalid Header.txt");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("06516", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Connecticut", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestCTLicenseSuffix()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "PABLO",
                    Last = "CORTEZ",
                    Suffix = "JR"
                },

                Address = new Address
                {
                    StreetLine1 = "715 MAIN LN",
                    City = "STRATFORD",
                    JurisdictionCode = "CT",
                    PostalCode = "066140123",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1976, 10, 07),
                Sex = Sex.Male,
                EyeColor = EyeColor.Green,
                Height = Height.FromImperial(6, 0),

                IdNumber = "227881513",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2016, 08, 23),
                ExpirationDate = new DateTime(2022, 10, 07),

                IsOrganDonor = true,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = License("CT Suffix");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("06614-0123", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Connecticut", idCard.IssuerIdentificationNumber.GetDescription());
        }

        [TestMethod]
        public void TestCTLicenseMultipleMiddleNames()
        {
            var expected = new DriversLicense
            {
                Name = new Name
                {
                    First = "PABLO",
                    Middle = "LUIS RODRIGUEZ",
                    Last = "CORTEZ",
                    Suffix = "JR"
                },

                Address = new Address
                {
                    StreetLine1 = "715 MAIN LN",
                    City = "STRATFORD",
                    JurisdictionCode = "CT",
                    PostalCode = "066140123",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1976, 10, 07),
                Sex = Sex.Male,
                EyeColor = EyeColor.Green,
                Height = Height.FromImperial(6, 0),

                IdNumber = "227881513",
                AamvaVersionNumber = Version.Aamva2000,

                IssueDate = new DateTime(2016, 08, 23),
                ExpirationDate = new DateTime(2022, 10, 07),

                IsOrganDonor = true,
                Jurisdiction = new DriversLicenseJurisdiction
                {
                    VehicleClass = "D"
                }
            };

            var file = License("CT Multiple Middle Names");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);
            AssertLicense(expected, idCard);

            Assert.AreEqual("06614-0123", idCard.Address.PostalCodeDisplay);
            Assert.AreEqual("Connecticut", idCard.IssuerIdentificationNumber.GetDescription());
        }
    }
}
