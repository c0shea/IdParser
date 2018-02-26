using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCL")]
    public class EthnicityParser : AbstractParser
    {
        public EthnicityParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.Ethnicity = input;
        }
    }
}
