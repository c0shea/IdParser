using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCS")]
    public class LastNameParser : AbstractParser
    {
        public LastNameParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.Name.Last = input.TrimEnd(',');
        }
    }
}
