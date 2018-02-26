using IdParser.Attributes;

namespace IdParser.Parsers.License
{
    [Parser("DCQ")]
    public class EndorsementCodeDescriptionParser : AbstractParser
    {
        public EndorsementCodeDescriptionParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            License.Jurisdiction.EndorsementCodeDescription = input;
        }
    }
}
