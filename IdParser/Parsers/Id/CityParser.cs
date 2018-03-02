using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAI")]
    public class CityParser : AbstractParser
    {
        public CityParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.Address.City = input;
        }
    }
}
