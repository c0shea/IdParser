using System.Text.RegularExpressions;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAK")]
    public class PostalCodeParser : AbstractParser
    {
        private const string NonAlphaNumericPattern = @"[^\w\d]";

        public PostalCodeParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (input == null)
            {
                return;
            }

            IdCard.PostalCode = new Regex(NonAlphaNumericPattern).Replace(input, "")
                                                                 .Replace("0000", "");
        }
    }
}
