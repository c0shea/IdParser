using IdParser.Attributes;

// ReSharper disable once CheckNamespace
namespace IdParser
{
    public enum Country
    {
        [Description("United States of America")]
        [Abbreviation("US")]
        Usa,

        [Abbreviation("CA")]
        Canada,

        [Abbreviation("MX")]
        Mexico
    }
}