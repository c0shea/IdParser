using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        public string FormattedPostalCode => Country == Country.USA && PostalCode.Length > 5
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
        public Dictionary<string, string> AdditionalJurisdictionElements { get; set; }

        internal IdentificationCard(Version version, Country country, string input, List<string> subfileRecords)
        {
            // D.12.3 Header
            IssuerIdentificationNumber = (IssuerIdentificationNumber)Convert.ToInt32(input.Substring(9, 6));
            AamvaVersionNumber = version;

            // The country is needed before we parse the subfile records so that dates can be interpreted correctly
            Country = country == Country.Unknown ? IssuerIdentificationNumber.GetCountry() : country;

            if (version == Version.Aamva2000)
            {
                JurisdictionVersionNumber = 0;
            }
            else
            {
                JurisdictionVersionNumber = Convert.ToByte(input.Substring(17, 2));
            }

            // Default Values
            WeightRange = WeightRange.None;
            AdditionalJurisdictionElements = new Dictionary<string, string>();
            ComplianceType = ComplianceType.None;

            // Data Elements
            foreach (var record in subfileRecords)
            {
                ParseRecord(record);
            }
        }

        private void ParseRecord(string subfileRecord)
        {
            if (subfileRecord.Length < 3)
                return;

            var elementId = subfileRecord.Substring(0, 3);
            var data = subfileRecord.Substring(3).Trim();

            switch (elementId)
            {
                // Required attributes
                case "DAA":
                    var names = data.Split(',', '$');
                    LastName = names.Length > 0 ? names[0].Trim() : null;
                    FirstName = names.Length > 1 ? names[1].Trim() : null;
                    MiddleName = names.Length > 2 ? names[2].Trim() : null;

                    break;

                // AAMVA 2003-2005
                case "DCT":
                    var givenNames = data.Split(',', '$', ' ');
                    FirstName = givenNames[0];
                    MiddleName = givenNames.Length > 1 ? givenNames[1] : null;

                    break;

                case "DBA":
                    ExpirationDate = Country.ParseDate(AamvaVersionNumber, data);

                    break;
                case "DCS":
                    if (NameHasValue(data))
                    {
                        LastName = data;
                    }
                    
                    break;
                case "DAC":
                    if (NameHasValue(data))
                    {
                        FirstName = data;
                    }
                    
                    break;
                case "DAD":
                    if (NameHasValue(data))
                    {
                        MiddleName = data;
                    }
                    
                    break;
                case "DBD":
                    if (DateHasValue(data))
                    {
                        IssueDate = Country.ParseDate(AamvaVersionNumber, data);
                    }

                    break;
                case "DBB":
                    if (DateHasValue(data))
                    {
                        DateOfBirth = Country.ParseDate(AamvaVersionNumber, data);
                    }

                    break;
                case "DBC":
                    if (byte.TryParse(data, out var numericSex))
                    {
                        Sex = (Sex) numericSex;
                    }
                    else if (data.Equals("M", StringComparison.OrdinalIgnoreCase))
                    {
                        Sex = Sex.Male;
                    }
                    else if (data.Equals("F", StringComparison.OrdinalIgnoreCase))
                    {
                        Sex = Sex.Female;
                    }
                    
                    break;
                case "DAY":
                    EyeColor = data == "UNK" ? null : data;
                    break;
                case "DAU":
                    Height = new Height(AamvaVersionNumber, data);
                    break;
                case "DAG":
                    StreetLine1 = data;
                    break;
                case "DAI":
                    City = data;
                    break;
                case "DAJ":
                    JurisdictionCode = data;
                    break;
                case "DAK":
                    PostalCode = data == null
                                 ? null
                                 : new Regex(@"[^\w\d]").Replace(data, "").Replace("00000", "");
                    break;
                case "DAQ":
                    IdNumber = data;
                    break;
                case "DCF":
                    DocumentDiscriminator = data;
                    break;
                case "DDE":
                    if (data == "T")
                    {
                        WasLastNameTruncated = true;
                    }
                    else if (data == "N")
                    {
                        WasLastNameTruncated = false;
                    }
                    else
                    {
                        WasLastNameTruncated = null;
                    }

                    break;
                case "DDF":
                    if (data == "T")
                    {
                        WasFirstNameTruncated = true;
                    }
                    else if (data == "N")
                    {
                        WasFirstNameTruncated = false;
                    }
                    else
                    {
                        WasFirstNameTruncated = null;
                    }

                    break;
                case "DDG":
                    if (data == "T")
                    {
                        WasMiddleNameTruncated = true;
                    }
                    else if (data == "N")
                    {
                        WasMiddleNameTruncated = false;
                    }
                    else
                    {
                        WasMiddleNameTruncated = null;
                    }

                    break;

                // Optional attributes
                case "DAH":
                    StreetLine2 = data == "NONE" ? null : data;
                    break;
                case "DAZ":
                    HairColor = data == "UNK" ? null : data;
                    break;
                case "DCI":
                    PlaceOfBirth = data;
                    break;
                case "DCJ":
                    AuditInformation = data;
                    break;
                case "DCK":
                    InventoryControlNumber = data;
                    break;
                case "DBN":
                    AliasLastName = data;
                    break;
                case "DBG":
                    AliasFirstName = data;
                    break;
                case "DBS":
                    AliasSuffix = data;
                    break;
                case "DCU":
                    NameSuffix = data;
                    break;
                case "DCE":
                    WeightRange = (WeightRange)Convert.ToByte(data);
                    break;
                case "DCL":
                    Ethnicity = data;
                    break;
                case "DDA":
                    if (data == "M")
                    {
                        ComplianceType = ComplianceType.MateriallyCompliant;
                    }
                    else if (data == "F")
                    {
                        ComplianceType = ComplianceType.FullyCompliant;
                    }
                    else if (data == "N")
                    {
                        ComplianceType = ComplianceType.NonCompliant;
                    }

                    break;
                case "DDB":
                    if (DateHasValue(data))
                    {
                        RevisionDate = Country.ParseDate(AamvaVersionNumber, data);
                    }

                    break;
                case "DDD":
                    if (data == "1")
                    {
                        HasTemporaryLawfulStatus = true;
                    }
                    else
                    {
                        HasTemporaryLawfulStatus = false;
                    }

                    break;
                case "DAW":
                    WeightInPounds = Convert.ToInt16(data);
                    break;
                case "DAX":
                    WeightInKilograms = Convert.ToInt16(data);
                    break;
                case "DDH":
                    if (DateHasValue(data) && AamvaVersionNumber >= Version.Aamva2000)
                    {
                        Under18Until = Country.ParseDate(AamvaVersionNumber, data);
                    }

                    break;
                case "DDI":
                    if (DateHasValue(data) && AamvaVersionNumber >= Version.Aamva2000)
                    {
                        Under19Until = Country.ParseDate(AamvaVersionNumber, data);
                    }

                    break;
                case "DDJ":
                    if (DateHasValue(data) && AamvaVersionNumber >= Version.Aamva2000)
                    {
                        Under21Until = Country.ParseDate(AamvaVersionNumber, data);
                    }

                    break;
                case "DBH":
                    if (AamvaVersionNumber == Version.Aamva2000 &&
                        IssuerIdentificationNumber == IssuerIdentificationNumber.Connecticut)
                    {
                        IsOrganDonor = data == "Y";
                    }

                    break;
                case "DDK":
                    IsOrganDonor = data == "1";

                    break;
                case "DDL":
                    IsVeteran = data == "1";

                    break;
                default:
                    if (elementId.Substring(0, 1) == "Z" && !AdditionalJurisdictionElements.ContainsKey(elementId))
                    {
                        AdditionalJurisdictionElements.Add(elementId, data);
                    }

                    break;
            }
        }

        protected bool DateHasValue(string data)
        {
            return data != "" && data != "00000000";
        }

        private bool NameHasValue(string data)
        {
            return data != "NONE" && data != "unavl" && data != "unavail";
        }
    }
}
