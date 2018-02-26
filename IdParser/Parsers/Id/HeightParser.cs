using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAU")]
    public class HeightParser : AbstractParser
    {
        public HeightParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.Height = new Height(Version, input);
        }
    }
}
