using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAQ")]
    public class IdNumberParser : AbstractParser
    {
        public IdNumberParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.IdNumber = input;
        }
    }
}
