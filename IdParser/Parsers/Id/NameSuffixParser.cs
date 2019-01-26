using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCU")]
    public class NameSuffixParser : AbstractParser
    {
        public NameSuffixParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            IdCard.Name.Suffix = input;
        }
    }
}
