using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCF")]
    public class DocumentDiscriminatorParser : AbstractParser
    {
        public DocumentDiscriminatorParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            IdCard.DocumentDiscriminator = input;
        }
    }
}
