using IdParser.Attributes;

// ReSharper disable once CheckNamespace
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