using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DBS")]
    public class AliasSuffixParser : AbstractParser
    {
        public AliasSuffixParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.AliasSuffix = input;
        }
    }
}
