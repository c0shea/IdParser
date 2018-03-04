using IdParser.Attributes;

namespace IdParser.Parsers.License
{
    [Parser("DCB")]
    public class RestrictionCodesParser : AbstractParser
    {
        public RestrictionCodesParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            // Leave the word "NONE" since null would indicate that we don't have the information available.
            License.Jurisdiction.RestrictionCodes = input;
        }
    }

    [Parser("DAS")]
    public class RestrictionCodesLegacyParser : AbstractParser
    {
        public RestrictionCodesLegacyParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            License.Jurisdiction.RestrictionCodes = input;
        }
    }
}
