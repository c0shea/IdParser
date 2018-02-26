using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCF")]
    public class DocumentDiscriminatorParser : AbstractParser
    {
        public DocumentDiscriminatorParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.DocumentDiscriminator = input;
        }
    }
}
