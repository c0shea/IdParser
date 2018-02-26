using IdParser.Attributes;

namespace IdParser.Parsers.License
{
    [Parser("DCN")]
    public class StandardEndorsementCodeParser : AbstractParser
    {
        public StandardEndorsementCodeParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            License.StandardEndorsementCode = input;
        }
    }
}
