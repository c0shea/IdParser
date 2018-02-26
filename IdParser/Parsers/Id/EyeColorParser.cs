using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAY")]
    public class EyeColorParser : AbstractParser
    {
        public EyeColorParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (input == "UNK")
            {
                return;
            }

            IdCard.EyeColor = input;
        }
    }
}
