using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAC")]
    public class FirstNameParser : AbstractParser
    {
        public FirstNameParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (NameHasNoValue(input))
            {
                return;
            }

            IdCard.Name.First = input;
        }
    }
}
