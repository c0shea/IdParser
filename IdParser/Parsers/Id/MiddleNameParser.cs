using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAD")]
    public class MiddleNameParser : AbstractParser
    {
        public MiddleNameParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            IdCard.Name.Middle = input;
        }
    }
}
