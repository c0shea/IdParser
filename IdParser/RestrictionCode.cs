using System;
using System.Collections.Generic;
using System.Text;
using IdParser.Attributes;

namespace IdParser
{
    [Flags]
    public enum RestrictionCode
    {
        None = 0,

        [Abbreviation("B")]
        [Description("Corrective lenses must be worn")]
        CorrectiveLensesMustBeWorn = 1,

        [Abbreviation("C")]
        [Description("Mechanical Aid (special brakes, hand controls, or other adaptive devices)")]
        MechanicalAid = 2,

        [Abbreviation("D")]
        [Description("Prosthetic Aid")]
        ProstheticAid = 4,

        [Abbreviation("E")]
        [Description("No Manual Transmission Equipped CMV")]
        NoManualTransmissionEquippedCmv = 8,

        [Abbreviation("F")]
        [Description("Outside Mirror")]
        OutsideMirror = 16,

        [Abbreviation("G")]
        [Description("Limit to Daylight Only")]
        LimitToDaylightOnly = 32,

        [Abbreviation("H")]
        [Description("Limited to Employment")]
        LimitedToEmployment = 64,

        [Abbreviation("K")]
        [Description("Intrastate Only")]
        IntrastateOnly = 128,

        [Abbreviation("L")]
        [Description("No Air Brakes Equipped CMV")]
        NoAirBrakesEquippedCmv = 256,

        [Abbreviation("M")]
        [Description("No Class A Passenger Vehicle")]
        NoClassAPassengerVehicle = 512,

        [Abbreviation("N")]
        [Description("No Class A and Class B Passenger Vehicle")]
        NoClassAAndClassBPassengerVehicle = 1_024,

        [Abbreviation("O")]
        [Description("No Tractor-Trailer CMV")]
        NoTractorTrailerCmv = 2_048,

        [Abbreviation("T")]
        [Description("Breath Alcohol Ignition Interlock Device")]
        BreathAlcoholIgnitionInterlockDevice = 4_096,

        [Abbreviation("V")]
        [Description("Medical Variance")]
        MedicalVariance = 8_192,

        [Abbreviation("I")]
        [Description("Limited - Other")]
        LimitedOther = 16_384,

        [Abbreviation("W")]
        [Description("Farm Waiver")]
        FarmWaiver = 32_768,

        [Abbreviation("Z")]
        [Description("No Full Air Brake Equipped CMV")]
        NoFullAirBrakeEquippedCmv = 65_536,

        [Abbreviation("J")]
        Other = 131_072
    }
}
