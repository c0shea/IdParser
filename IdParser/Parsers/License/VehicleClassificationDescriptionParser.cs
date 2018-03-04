using IdParser.Attributes;

namespace IdParser.Parsers.License
{
    [Parser("DCP")]
    public class VehicleClassificationDescriptionParser : AbstractParser
    {
        public VehicleClassificationDescriptionParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (StringHasNoValue(input))
            {
                return;
            }

            License.Jurisdiction.VehicleClassificationDescription = input;
        }
    }
}
