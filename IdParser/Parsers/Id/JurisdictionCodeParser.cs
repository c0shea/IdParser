using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAJ")]
    public class JurisdictionCodeParser : AbstractParser
    {
        public JurisdictionCodeParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.Address.JurisdictionCode = input;
        }
    }
}
