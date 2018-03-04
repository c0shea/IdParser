using IdParser.Attributes;

namespace IdParser.Parsers.License
{
    [Parser("DCD")]
    public class EndorsementCodesParser : AbstractParser
    {
        public EndorsementCodesParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            // Leave the word "NONE" since null would indicate that we don't have the information available.
            License.Jurisdiction.EndorsementCodes = input;
        }
    }

    [Parser("DAT")]
    public class EndorsementCodesLegacyParser : AbstractParser
    {
        public EndorsementCodesLegacyParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            License.Jurisdiction.EndorsementCodes = input;
        }
    }
}
