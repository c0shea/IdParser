using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DBN")]
    public class AliasLastNameParser : AbstractParser
    {
        public AliasLastNameParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            IdCard.Name.AliasLast = input;
        }
    }
}
