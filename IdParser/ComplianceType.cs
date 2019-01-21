using IdParser.Attributes;

namespace IdParser
{
    public enum ComplianceType
    {
        [Description("Materially Compliant")]
        MateriallyCompliant,

        [Description("Fully Compliant")]
        FullyCompliant,

        [Description("Non-Compliant")]
        NonCompliant
    }
}