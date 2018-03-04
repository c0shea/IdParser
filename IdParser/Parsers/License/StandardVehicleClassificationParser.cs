using IdParser.Attributes;

namespace IdParser.Parsers.License
{
    [Parser("DCM")]
    public class StandardVehicleClassificationParser : AbstractParser
    {
        public StandardVehicleClassificationParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            License.StandardVehicleClassification = input;
        }
    }
}
