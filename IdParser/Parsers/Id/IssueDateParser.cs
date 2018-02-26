using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DBD")]
    public class IssueDateParser : AbstractParser
    {
        public IssueDateParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (DateHasNoValue(input))
            {
                return;
            }

            IdCard.IssueDate = ParseDate(input);
        }
    }
}
