using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DDA")]
    public class ComplianceTypeParser : AbstractParser
    {
        public ComplianceTypeParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            switch (input)
            {
                case "M":
                    IdCard.ComplianceType = ComplianceType.MateriallyCompliant;
                    break;
                case "F":
                    IdCard.ComplianceType = ComplianceType.FullyCompliant;
                    break;
                case "N":
                    IdCard.ComplianceType = ComplianceType.NonCompliant;
                    break;
            }
        }
    }
}
