using System;

namespace IdParser
{
    public class Address
    {
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string JurisdictionCode { get; set; }
        public string PostalCode { get; set; }
        public Country Country { get; set; }

        public string PostalCodeDisplay => Country == Country.Usa && PostalCode.Length > 5
            ? $"{PostalCode.Substring(0, 5)}-{PostalCode.Substring(5)}"
            : PostalCode;

        public override string ToString() => StreetLine2 == null
            ? $"{StreetLine1}{Environment.NewLine}{City}, {JurisdictionCode} {PostalCodeDisplay}"
            : $"{StreetLine1}{Environment.NewLine}{StreetLine2}{Environment.NewLine}{City}, {JurisdictionCode} {PostalCodeDisplay}";
    }
}
