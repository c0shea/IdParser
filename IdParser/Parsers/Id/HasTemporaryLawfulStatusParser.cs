using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DDD")]
    public class HasTemporaryLawfulStatusParser : AbstractParser
    {
        public HasTemporaryLawfulStatusParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.HasTemporaryLawfulStatus = ParseBool(input) ?? false;
        }
    }
}
