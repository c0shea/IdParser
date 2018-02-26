using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DBA")]
    public class ExpirationDateParser : AbstractParser
    {
        public ExpirationDateParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (DateHasNoValue(input))
            {
                return;
            }

            IdCard.ExpirationDate = ParseDate(input);
        }
    }
}
