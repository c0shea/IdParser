using System;
// ReSharper disable InconsistentNaming

namespace IdParser.Test
{
    public class IdentificationCardTests : BaseTest
    {
        [Fact]
        public void TestTNIdCard()
        {
            var expected = new IdentificationCard
            {
                Name = new Name
                {
                    First = "ELIZABETH",
                    Middle = "MOTORIST",
                    Last = "SMITH",

                    WasFirstTruncated = false,
                    WasMiddleTruncated = false,
                    WasLastTruncated = false
                },

                Address = new Address
                {
                    StreetLine1 = "21078 MAGNOLIA RD",
                    City = "NASHVILLE",
                    JurisdictionCode = "TN",
                    PostalCode = "370115509",
                    Country = Country.Usa
                },

                DateOfBirth = new DateTime(1961, 12, 13),
                Sex = Sex.Female,
                EyeColor = EyeColor.Green,
                Height = Height.FromImperial(63),

                IdNumber = "115775955",
                AamvaVersionNumber = Version.Aamva2011,

                IssueDate = new DateTime(2018, 02, 06),
                ExpirationDate = new DateTime(2026, 02, 06),
                RevisionDate = new DateTime(2011, 12, 02),

                IsOrganDonor = true
            };

            var file = Id("TN");
            var idCard = Barcode.Parse(file, Validation.None);

            AssertIdCard(expected, idCard);

            Assert.Equal("37011-5509", idCard.Address.PostalCodeDisplay);
            Assert.Equal("Tennessee", idCard.IssuerIdentificationNumber.GetDescription());
        }
    }
}
