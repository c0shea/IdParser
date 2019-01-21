using IdParser.Attributes;

namespace IdParser
{
    public enum Ethnicity
    {
        [Abbreviation("AI")]
        [Description("Alaskan or American Indian")]
        AlaskanAmericanIndian,

        [Abbreviation("AP")]
        [Description("Asian or Pacific Islander")]
        AsianPacificIslander,

        [Abbreviation("BK")]
        Black,

        [Abbreviation("H")]
        [Description("Hispanic Origin")]
        HispanicOrigin,

        [Abbreviation("O")]
        [Description("Non-Hispanic")]
        NonHispanic,

        [Abbreviation("W")]
        White
    }
}
