using IdParser.Attributes;

// ReSharper disable once CheckNamespace
namespace IdParser
{
    public enum HairColor
    {
        [Abbreviation("BAL")]
        Bald,

        [Abbreviation("BLK")]
        Black,

        [Abbreviation("BLN")]
        Blond,

        [Abbreviation("BRO")]
        Brown,

        [Abbreviation("GRY")]
        Gray,

        [Abbreviation("RED")]
        [Description("Red/Auburn")]
        RedAuburn,

        [Abbreviation("SDY")]
        Sandy,

        [Abbreviation("WHI")]
        White
    }
}