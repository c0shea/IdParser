using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DBB")]
    public class DateOfBirthParser : AbstractParser
    {
        public DateOfBirthParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (DateHasNoValue(input))
            {
                return;
            }

            IdCard.DateOfBirth = ParseDate(input);
        }
    }
}
