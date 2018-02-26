using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DDI")]
    public class Under19UntilParser : AbstractParser
    {
        public Under19UntilParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (DateHasNoValue(input) || Version < Version.Aamva2000)
            {
                return;
            }

            IdCard.Under19Until = ParseDate(input);
        }
    }
}
