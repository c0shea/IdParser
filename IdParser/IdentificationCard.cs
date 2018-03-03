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
        public EyeColor EyeColor { get; set; }
        public Height Height { get; set; }

        public Address Address { get; set; } = new Address();

        public string IdNumber { get; set; }
        public string DocumentDiscriminator { get; set; }
        
        public bool? WasLastNameTruncated { get; set; }
        public bool? WasFirstNameTruncated { get; set; }
        public bool? WasMiddleNameTruncated { get; set; }

        public HairColor? HairColor { get; set; }
        public string PlaceOfBirth { get; set; }
        public string AuditInformation { get; set; }
        public string InventoryControlNumber { get; set; }
        public string AliasLastName { get; set; }
        public string AliasFirstName { get; set; }
        public string AliasSuffix { get; set; }
        public string NameSuffix { get; set; }
        public WeightRange? WeightRange { get; set; }
        public Ethnicity? Ethnicity { get; set; }
        public ComplianceType? ComplianceType { get; set; }
        public DateTime? RevisionDate { get; set; }
        public bool? HasTemporaryLawfulStatus { get; set; }
        public short? WeightInPounds { get; set; }
        public short? WeightInKilograms { get; set; }
        public DateTime? Under18Until { get; set; }
        public DateTime? Under19Until { get; set; }
        public DateTime? Under21Until { get; set; }
        public bool? IsOrganDonor { get; set; }
        public bool? IsVeteran { get; set; }
        public Dictionary<string, string> AdditionalJurisdictionElements { get; } = new Dictionary<string, string>();
    }
}
