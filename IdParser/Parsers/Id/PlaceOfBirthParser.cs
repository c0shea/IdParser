using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCI")]
    public class PlaceOfBirthParser : AbstractParser
    {
        public PlaceOfBirthParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.PlaceOfBirth = input;
        }
    }
}
