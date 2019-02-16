using System;
using IdParser.Attributes;

// ReSharper disable once CheckNamespace
namespace IdParser
{
    [Flags]
    public enum EndorsementCode
    {
        None = 0,

        [Abbreviation("N")]
        Tank = 1,

        [Abbreviation("P")]
        Passenger = 2,

        [Abbreviation("S")]
        [Description("School Bus")]
        SchoolBus = 4,

        [Abbreviation("T")]
        [Description("Doubles/Triples")]
        DoublesTriples = 8,

        [Abbreviation("H")]
        [Description("Hazardous Material")]
        HazardousMaterial = 16,

        [Abbreviation("X")]
        [Description("Combined Tank/Hazardous Material")]
        CombinedTankHazardousMaterial = Tank | HazardousMaterial,

        [Abbreviation("L")]
        Motorcycles = 32,

        [Abbreviation("O")]
        [Description("Other Jurisdiction Specific Endorsements")]
        Other = 64
    }
}
