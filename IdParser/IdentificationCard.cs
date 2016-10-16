using System;
using System.Collections.Generic;
using System.Globalization;

namespace IdParser {
    public class IdentificationCard {
        internal IdentificationCard(Version version, Country country, string input, List<string> subfileRecords) {
            // D.12.3 Header
            IssuerIdentificationNumber = (IssuerIdentificationNumber)Convert.ToInt32(input.Substring(9, 6));
            AamvaVersionNumber = version;

            // The country is needed before we parse the subfile records so that dates can be interpreted correctly
            Country = country == Country.Unknown ? IssuerIdentificationNumber.GetCountry() : country;

            if (version == Version.Aamva2000) {
                JurisdictionVersionNumber = 0;
            }
            else {
                JurisdictionVersionNumber = Convert.ToByte(input.Substring(17, 2));
            }

            // Default Values
            WeightRange = WeightRange.None;
            AdditionalJurisdictionElements = new Dictionary<string, string>();
            ComplianceType = ComplianceType.None;

            // Data Elements
            foreach (var record in subfileRecords) {
                ParseRecord(record);
            }
        }

        private void ParseRecord(string subfileRecord) {
            if (subfileRecord.Length < 3)
                return;

            var elementId = subfileRecord.Substring(0, 3);
            var data = subfileRecord.Substring(3).Trim();

            switch (elementId) {
                // Required attributes
                case "DAA":
                    var names = data.Split(',', '$');
                    LastName = names[0];
                    FirstName = names[1];
                    MiddleName = names[2];

                    break;

                // AAMVA 2003-2005
                case "DCT":
                    var givenNames = data.Split(',', '$', ' ');
                    FirstName = givenNames[0];
                    MiddleName = givenNames.Length > 1 ? givenNames[1] : null;

                    break;

                case "DBA":
                    if (AamvaVersionNumber == Version.Aamva2000 || Country == Country.Canada) {
                        ExpirationDate = DateTime.ParseExact(data, "yyyyMMdd", CultureInfo.CurrentCulture);
                    }
                    else {
                        ExpirationDate = DateTime.ParseExact(data, "MMddyyyy", CultureInfo.CurrentCulture);
                    }

                    break;
                case "DCS":
                    LastName = data;
                    break;
                case "DAC":
                    FirstName = data;
                    break;
                case "DAD":
                    MiddleName = data;
                    break;
                case "DBD":
                    if (data != string.Empty && data != "00000000") {
                        if (AamvaVersionNumber == Version.Aamva2000 || Country == Country.Canada) {
                            IssueDate = DateTime.ParseExact(data, "yyyyMMdd", CultureInfo.CurrentCulture);
                        }
                        else {
                            IssueDate = DateTime.ParseExact(data, "MMddyyyy", CultureInfo.CurrentCulture);
                        }
                    }

                    break;
                case "DBB":
                    if (data != string.Empty && data != "00000000") {
                        if (AamvaVersionNumber == Version.Aamva2000 || Country == Country.Canada) {
                            DateOfBirth = DateTime.ParseExact(data, "yyyyMMdd", CultureInfo.CurrentCulture);
                        }
                        else {
                            DateOfBirth = DateTime.ParseExact(data, "MMddyyyy", CultureInfo.CurrentCulture);
                        }
                    }

                    break;
                case "DBC":
                    Sex = (Sex)Convert.ToInt32(data);
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
                    PostalCode = data;
                    break;
                case "DAQ":
                    IdNumber = data;
                    break;
                case "DCF":
                    DocumentDiscriminator = data;
                    break;
                case "DDE":
                    if (data == "T") {
                        WasLastNameTruncated = true;
                    }
                    else if (data == "N") {
                        WasLastNameTruncated = false;
                    }
                    else {
                        WasLastNameTruncated = null;
                    }

                    break;
                case "DDF":
                    if (data == "T") {
                        WasFirstNameTruncated = true;
                    }
                    else if (data == "N") {
                        WasFirstNameTruncated = false;
                    }
                    else {
                        WasFirstNameTruncated = null;
                    }

                    break;
                case "DDG":
                    if (data == "T") {
                        WasMiddleNameTruncated = true;
                    }
                    else if (data == "N") {
                        WasMiddleNameTruncated = false;
                    }
                    else {
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
                    if (data == "M") {
                        ComplianceType = ComplianceType.MateriallyCompliant;
                    }
                    else if (data == "F") {
                        ComplianceType = ComplianceType.FullyCompliant;
                    }
                    else if (data == "N") {
                        ComplianceType = ComplianceType.NonCompliant;
                    }

                    break;
                case "DDB":
                    if (data != string.Empty && data != "00000000") {
                        if (AamvaVersionNumber == Version.Aamva2000 || Country == Country.Canada) {
                            RevisionDate = DateTime.ParseExact(data, "yyyyMMdd", CultureInfo.CurrentCulture);
                        }
                        else {
                            RevisionDate = DateTime.ParseExact(data, "MMddyyyy", CultureInfo.CurrentCulture);
                        }
                    }

                    break;
                case "DDD":
                    if (data == "1") {
                        HasTemporaryLawfulStatus = true;
                    }
                    else {
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
                    if (data != string.Empty && data != "00000000" && AamvaVersionNumber >= Version.Aamva2000) {
                        if (Country == Country.Canada) {
                            Under18Until = DateTime.ParseExact(data, "yyyyMMdd", CultureInfo.CurrentCulture);
                        }
                        else {
                            Under18Until = DateTime.ParseExact(data, "MMddyyyy", CultureInfo.CurrentCulture);
                        }
                    }

                    break;
                case "DDI":
                    if (data != string.Empty && data != "00000000" && AamvaVersionNumber >= Version.Aamva2000) {
                        if (Country == Country.Canada) {
                            Under19Until = DateTime.ParseExact(data, "yyyyMMdd", CultureInfo.CurrentCulture);
                        }
                        else {
                            Under19Until = DateTime.ParseExact(data, "MMddyyyy", CultureInfo.CurrentCulture);
                        }
                    }

                    break;
                case "DDJ":
                    if (data != string.Empty && data != "00000000" && AamvaVersionNumber >= Version.Aamva2000) {
                        if (Country == Country.Canada) {
                            Under21Until = DateTime.ParseExact(data, "yyyyMMdd", CultureInfo.CurrentCulture);
                        }
                        else {
                            Under21Until = DateTime.ParseExact(data, "MMddyyyy", CultureInfo.CurrentCulture);
                        }
                    }

                    break;
                case "DBH":
                    if (AamvaVersionNumber == Version.Aamva2000 &&
                        IssuerIdentificationNumber == IssuerIdentificationNumber.Connecticut) {
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
                    if (elementId.Substring(0, 1) == "Z" && !AdditionalJurisdictionElements.ContainsKey(elementId)) {
                        AdditionalJurisdictionElements.Add(elementId, data);
                    }

                    break;
            }
        }

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

        public string FormattedPostalCode => Country == Country.USA && PostalCode.Length > 5 ? $"{PostalCode.Substring(0, 5)}-{PostalCode.Substring(5)}" : PostalCode;
        public string Address => StreetLine2 == null ? $"{StreetLine1}\n{City}, {JurisdictionCode} {FormattedPostalCode}" :
                                                       $"{StreetLine1}\n{StreetLine2}\n{City}, {JurisdictionCode} {FormattedPostalCode}";
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
    }
}
