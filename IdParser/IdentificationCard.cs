using System;
using System.Collections.Generic;

namespace IdParser
{
    public class IdentificationCard
    {
        public IssuerIdentificationNumber IssuerIdentificationNumber { get; set; }
        public Version AamvaVersionNumber { get; set; }
        public byte JurisdictionVersionNumber { get; set; }

        public DateTime ExpirationDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public string EyeColor { get; set; }
        public Height Height { get; set; }
        public string StreetLine1 { get; set; }

        public string City { get; set; }
        public string JurisdictionCode { get; set; }
        public string PostalCode { get; set; }

        public string FormattedPostalCode => Country == Country.Usa && PostalCode.Length > 5
                                             ? $"{PostalCode.Substring(0, 5)}-{PostalCode.Substring(5)}"
                                             : PostalCode;
        public string Address => StreetLine2 == null
                                 ? $"{StreetLine1}{Environment.NewLine}{City}, {JurisdictionCode} {FormattedPostalCode}"
                                 : $"{StreetLine1}{Environment.NewLine}{StreetLine2}{Environment.NewLine}{City}, {JurisdictionCode} {FormattedPostalCode}";
        public string IdNumber { get; set; }
        public string DocumentDiscriminator { get; set; }
        public Country Country { get; set; }
        public bool? WasLastNameTruncated { get; set; }
        public bool? WasFirstNameTruncated { get; set; }
        public bool? WasMiddleNameTruncated { get; set; }

        // D.12.5.2 Optional data elements
        public string StreetLine2 { get; set; }
        public string HairColor { get; set; }
        public string PlaceOfBirth { get; set; }
        public string AuditInformation { get; set; }
        public string InventoryControlNumber { get; set; }
        public string AliasLastName { get; set; }
        public string AliasFirstName { get; set; }
        public string AliasSuffix { get; set; }
        public string NameSuffix { get; set; }
        public WeightRange WeightRange { get; set; }
        public string Ethnicity { get; set; }
        public ComplianceType ComplianceType { get; set; }
        public DateTime? RevisionDate { get; set; }
        public bool HasTemporaryLawfulStatus { get; set; }
        public short? WeightInPounds { get; set; }
        public short? WeightInKilograms { get; set; }
        public DateTime? Under18Until { get; set; }
        public DateTime? Under19Until { get; set; }
        public DateTime? Under21Until { get; set; }
        public bool IsOrganDonor { get; set; }
        public bool IsVeteran { get; set; }
        public Dictionary<string, string> AdditionalJurisdictionElements { get; } = new Dictionary<string, string>();
    }
}
