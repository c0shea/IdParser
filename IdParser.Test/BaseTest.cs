using System.IO;

namespace IdParser.Test
{
    public class BaseTest
    {
        protected string Id(string jurisdiction) => File.ReadAllText(Path.Combine("Ids", $"{jurisdiction}.txt"));

        protected string License(string jurisdiction) => File.ReadAllText(Path.Combine("Licenses", $"{jurisdiction}.txt"));

        protected void AssertIdCard(IdentificationCard expected, IdentificationCard actual)
        {
            Assert.NotNull(expected);
            Assert.NotNull(actual);

            Assert.Equal(expected.Name.First, actual.Name.First);
            Assert.Equal(expected.Name.Middle, actual.Name.Middle);
            Assert.Equal(expected.Name.Last, actual.Name.Last);
            Assert.Equal(expected.Name.Suffix, actual.Name.Suffix);

            Assert.Equal(expected.Name.WasFirstTruncated, actual.Name.WasFirstTruncated);
            Assert.Equal(expected.Name.WasMiddleTruncated, actual.Name.WasMiddleTruncated);
            Assert.Equal(expected.Name.WasLastTruncated, actual.Name.WasLastTruncated);

            Assert.Equal(expected.Address.City, actual.Address.City);
            Assert.Equal(expected.Address.StreetLine1, actual.Address.StreetLine1);
            Assert.Equal(expected.Address.StreetLine2, actual.Address.StreetLine2);
            Assert.Equal(expected.Address.JurisdictionCode, actual.Address.JurisdictionCode);
            Assert.Equal(expected.Address.JurisdictionCode, actual.IssuerIdentificationNumber.GetAbbreviation());
            Assert.Equal(expected.Address.PostalCode, actual.Address.PostalCode);
            Assert.Equal(expected.Address.Country, actual.Address.Country);

            Assert.Equal(expected.DateOfBirth, actual.DateOfBirth);
            Assert.Equal(expected.PlaceOfBirth, actual.PlaceOfBirth);
            Assert.Equal(expected.Sex, actual.Sex);
            Assert.Equal(expected.Height, actual.Height);
            Assert.Equal(expected.Weight, actual.Weight);

            Assert.Equal(expected.EyeColor, actual.EyeColor);
            Assert.Equal(expected.HairColor, actual.HairColor);
            Assert.Equal(expected.Ethnicity, actual.Ethnicity);

            Assert.Equal(expected.IdNumber, actual.IdNumber);
            Assert.Equal(expected.AamvaVersionNumber, actual.AamvaVersionNumber);

            Assert.Equal(expected.IssueDate, actual.IssueDate);
            Assert.Equal(expected.ExpirationDate, actual.ExpirationDate);
            Assert.Equal(expected.RevisionDate, actual.RevisionDate);

            Assert.Equal(expected.Under18Until, actual.Under18Until);
            Assert.Equal(expected.Under19Until, actual.Under19Until);
            Assert.Equal(expected.Under21Until, actual.Under21Until);

            Assert.Equal(expected.ComplianceType, actual.ComplianceType);
            Assert.Equal(expected.HasTemporaryLawfulStatus, actual.HasTemporaryLawfulStatus);
            Assert.Equal(expected.IsOrganDonor, actual.IsOrganDonor);
            Assert.Equal(expected.IsVeteran, actual.IsVeteran);
        }

        protected void AssertLicense(DriversLicense expected, IdentificationCard actualId)
        {
            Assert.NotNull(expected);
            Assert.NotNull(actualId);
            Assert.IsType<DriversLicense>(actualId);

            var actual = (DriversLicense)actualId;
            Assert.NotNull(actual.Jurisdiction);

            Assert.Equal(expected.Jurisdiction.VehicleClass, actual.Jurisdiction.VehicleClass);
            Assert.Equal(expected.Jurisdiction.RestrictionCodes, actual.Jurisdiction.RestrictionCodes);
            Assert.Equal(expected.Jurisdiction.EndorsementCodes, actual.Jurisdiction.EndorsementCodes);
            Assert.Equal(expected.Jurisdiction.VehicleClassificationDescription, actual.Jurisdiction.VehicleClassificationDescription);
            Assert.Equal(expected.Jurisdiction.EndorsementCodeDescription, actual.Jurisdiction.EndorsementCodeDescription);
            Assert.Equal(expected.Jurisdiction.RestrictionCodeDescription, actual.Jurisdiction.RestrictionCodeDescription);

            Assert.Equal(expected.StandardVehicleClassification, actual.StandardVehicleClassification);
            Assert.Equal(expected.StandardEndorsementCode, actual.StandardEndorsementCode);
            Assert.Equal(expected.StandardRestrictionCode, actual.StandardRestrictionCode);
            Assert.Equal(expected.HazmatEndorsementExpirationDate, actual.HazmatEndorsementExpirationDate);
        }
    }
}
