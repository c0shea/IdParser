using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAG")]
    public class StreetLine1Parser : AbstractParser
    {
        public StreetLine1Parser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.Address.StreetLine1 = input;
        }
    }
}
