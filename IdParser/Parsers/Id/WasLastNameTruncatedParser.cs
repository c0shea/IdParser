using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DDE")]
    public class WasLastNameTruncatedParser : AbstractParser
    {
        public WasLastNameTruncatedParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.WasLastNameTruncated = ParseBool(input);
        }
    }
}
