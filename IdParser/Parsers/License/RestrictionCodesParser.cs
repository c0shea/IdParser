using IdParser.Attributes;

namespace IdParser.Parsers.License
{
    [Parser("DCB")]
    public class RestrictionCodesParser : AbstractParser
    {
        public RestrictionCodesParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            License.Jurisdiction.RestrictionCodes = input;
        }
    }

    [Parser("DAS")]
    public class RestrictionCodesLegacyParser : AbstractParser
    {
        public RestrictionCodesLegacyParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            License.Jurisdiction.RestrictionCodes = input;
        }
    }
}
