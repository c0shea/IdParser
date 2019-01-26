using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAC")]
    public class FirstNameParser : AbstractParser
    {
        public FirstNameParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            IdCard.Name.First = input;
        }
    }
}
