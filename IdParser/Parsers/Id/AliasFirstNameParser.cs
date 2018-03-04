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
            // DBG was designated for Medical Indicator/Codes only in AAMVA 2000 but we don't support this deprecated property
            if (Version == Version.Aamva2000)
            {
                return;
            }

            IdCard.Name.AliasFirst = input;
        }
    }
}
