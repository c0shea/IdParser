using IdParser.Attributes;

namespace IdParser.Parsers.License
{
    [Parser("DCO")]
    public class StandardRestrictionCodeParser : AbstractParser
    {
        public StandardRestrictionCodeParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            License.StandardRestrictionCode = input;
        }
    }
}
