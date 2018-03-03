using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCU")]
    public class NameSuffixParser : AbstractParser
    {
        public NameSuffixParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            IdCard.NameSuffix = input;
        }
    }
}
