using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DDB")]
    public class RevisionDate : AbstractParser
    {
        public RevisionDate(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (DateHasNoValue(input))
            {
                return;
            }

            IdCard.RevisionDate = ParseDate(input);
        }
    }
}
