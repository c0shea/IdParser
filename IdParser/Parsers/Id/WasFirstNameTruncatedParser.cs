using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DDF")]
    public class WasFirstNameTruncatedParser : AbstractParser
    {
        public WasFirstNameTruncatedParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.Name.WasFirstTruncated = ParseBool(input);
        }
    }
}
