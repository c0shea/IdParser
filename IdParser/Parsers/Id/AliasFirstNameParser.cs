using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DBG")]
    public class AliasFirstNameParser : AbstractParser
    {
        public AliasFirstNameParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.AliasFirstName = input;
        }
    }
}
