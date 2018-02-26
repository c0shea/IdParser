using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAD")]
    public class MiddleNameParser : AbstractParser
    {
        public MiddleNameParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (NameHasNoValue(input))
            {
                return;
            }

            IdCard.MiddleName = input;
        }
    }
}
