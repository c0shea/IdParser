using System;
using System.Text.RegularExpressions;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAK")]
    public class PostalCodeParser : AbstractParser
    {
        private const string NonAlphaNumericPattern = @"[^\w\d]";

        public PostalCodeParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            // Some jurisdictions, like Hawaii, have spaces after the ZIP code followed by a number like 0.
            // Chop off the excess junk otherwise we'd wind up with a 6-digit ZIP code.
            var indexOfSpaces = input.IndexOf("    ", StringComparison.OrdinalIgnoreCase);
            if (indexOfSpaces >= 0)
            {
                input = input.Substring(0, indexOfSpaces);
            }

            IdCard.Address.PostalCode = new Regex(NonAlphaNumericPattern).Replace(input, "")
                                                                         .Replace("0000", "");
        }
    }
}
