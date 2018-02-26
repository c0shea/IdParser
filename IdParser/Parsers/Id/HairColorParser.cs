using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAZ")]
    public class HairColorParser : AbstractParser
    {
        public HairColorParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (string.IsNullOrEmpty(input) || input == "UNK")
            {
                return;
            }

            IdCard.HairColor = input;
        }
    }
}
