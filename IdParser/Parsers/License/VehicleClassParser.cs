using IdParser.Attributes;

namespace IdParser.Parsers.License
{
    [Parser("DCA")]
    public class VehicleClassParser : AbstractParser
    {
        public VehicleClassParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            License.Jurisdiction.VehicleClass = input;
        }
    }

    [Parser("DAR")]
    public class VehicleClassLegacyParser : AbstractParser
    {
        public VehicleClassLegacyParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            License.Jurisdiction.VehicleClass = input;
        }
    }
}
