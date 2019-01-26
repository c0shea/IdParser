using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DDH")]
    public class Under18UntilParser : AbstractParser
    {
        public Under18UntilParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (DateHasNoValue(input) || Version < Version.Aamva2000)
            {
                return;
            }

            IdCard.Under18Until = ParseDate(input);
        }
    }
}
