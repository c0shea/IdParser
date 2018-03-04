using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAH")]
    public class StreetLine2Parser : AbstractParser
    {
        public StreetLine2Parser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            IdCard.Address.StreetLine2 = input.TrimEnd(',');
        }
    }
}
