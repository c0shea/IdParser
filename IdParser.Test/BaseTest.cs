using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Test
{
    public class BaseTest
    {
        protected string Id(string jurisdiction) => File.ReadAllText(Path.Combine("Ids", $"{jurisdiction}.txt"));

        protected string License(string jurisdiction) => File.ReadAllText(Path.Combine("Licenses", $"{jurisdiction}.txt"));

        protected void AssertIdCard(IdentificationCard expected, IdentificationCard actual)
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

        protected void AssertLicense(DriversLicense expected, IdentificationCard actualId)
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
