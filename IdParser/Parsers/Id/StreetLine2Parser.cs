using System.Text.RegularExpressions;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAH")]
    public class StreetLine2Parser : AbstractParser
    {
        public StreetLine2Parser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            // Jurisdictions like Wyoming set the StreetLine2 to the City, State, and Postal Code when it
            if (IdCard.Address.City != null &&
                IdCard.Address.JurisdictionCode != null &&
                IdCard.Address.PostalCode != null &&
                Regex.IsMatch(input, $@"\s*{IdCard.Address.City}(\s|,)*{IdCard.Address.JurisdictionCode}(\s|,)*{IdCard.Address.PostalCode}"))
            {
                return;
            }

            IdCard.Address.StreetLine2 = input.TrimEnd(',');
        }
    }
}
