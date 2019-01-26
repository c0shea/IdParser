using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DDG")]
    public class WasMiddleNameTruncatedParser : AbstractParser
    {
        public WasMiddleNameTruncatedParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.Name.WasMiddleTruncated = ParseBool(input);
        }
    }
}
