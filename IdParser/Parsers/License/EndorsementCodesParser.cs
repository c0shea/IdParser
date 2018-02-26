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
            License.Jurisdiction.EndorsementCodes = input;
        }
    }
}
