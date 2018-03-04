using IdParser.Attributes;

namespace IdParser
{
    public enum Validation
    {
        None,
        Strict
    }

    public enum Version : byte
    {
        PreStandard = 0,
        Aamva2000 = 1,
        Aamva2003 = 2,
        Aamva2005 = 3,
        Aamva2009 = 4,
        Aamva2010 = 5,
        Aamva2011 = 6,
        Aamva2012 = 7,
        Aamva2013 = 8,
        Aamva2016 = 9,
        Future = 99
    }

    // https://www.aamva.org/IIN-and-RID/
    public enum IssuerIdentificationNumber
    {
        [Country(Country.Usa)]
        [Abbreviation("AL")]
        Alabama = 636033,

        [Country(Country.Usa)]
        [Abbreviation("AK")]
        Alaska = 636059,

        [Country(Country.Canada)]
        [Abbreviation("AB")]
        [Description("Alberta")]
        Alberta,

        [Country(Country.Usa)]
        [Abbreviation("AS")]
        [Description("American Samoa")]
        AmericanSamoa = 604427,

        [Country(Country.Usa)]
        [Abbreviation("AZ")]
        Arizona = 636026,

        [Country(Country.Usa)]
        [Abbreviation("AR")]
        Arkansas = 636026,

        [Country(Country.Canada)]
        [Abbreviation("BC")]
        [Description("British Columbia")]
        BritishColumbia = 636028,

        [Country(Country.Usa)]
        [Abbreviation("CA")]
        California = 636014,

        [Country(Country.Mexico)]
        [Abbreviation("COA")]
        Coahuila = 636056,

        [Country(Country.Usa)]
        [Abbreviation("CO")]
        Colorado = 636020,

        [Country(Country.Usa)]
        [Abbreviation("CT")]
        Connecticut = 636006,

        [Country(Country.Usa)]
        [Abbreviation("DE")]
        Delaware = 636011,

        [Country(Country.Usa)]
        [Abbreviation("DC")]
        [Description("District of Columbia")]
        DistrictOfColumbia = 636043,

        [Country(Country.Usa)]
        [Abbreviation("FL")]
        Florida = 636010,

        [Country(Country.Usa)]
        [Abbreviation("GA")]
        Georgia = 636055,

        [Country(Country.Usa)]
        [Abbreviation("GU")]
        Guam = 636019,

        [Country(Country.Usa)]
        [Abbreviation("HI")]
        Hawaii = 636047,

        [Country(Country.Mexico)]
        [Abbreviation("HID")]
        Hidalgo = 636057,

        [Country(Country.Usa)]
        [Abbreviation("ID")]
        Idaho = 636050,

        [Country(Country.Usa)]
        [Abbreviation("IL")]
        Illinois = 636035,

        [Country(Country.Usa)]
        [Abbreviation("IN")]
        Indiana = 636037,

        [Country(Country.Usa)]
        [Abbreviation("IA")]
        Iowa = 636018,

        [Country(Country.Usa)]
        [Abbreviation("KS")]
        Kansas = 636022,

        [Country(Country.Usa)]
        [Abbreviation("KY")]
        Kentucky = 636046,

        [Country(Country.Usa)]
        [Abbreviation("LA")]
        Louisiana = 636007,

        [Country(Country.Usa)]
        [Abbreviation("ME")]
        Maine = 636041,

        [Country(Country.Canada)]
        [Abbreviation("MB")]
        Manitoba = 636048,

        [Country(Country.Usa)]
        [Abbreviation("MD")]
        Maryland = 636003,

        [Country(Country.Usa)]
        [Abbreviation("MA")]
        Massachusetts = 636002,

        [Country(Country.Usa)]
        [Abbreviation("MI")]
        Michigan = 636032,

        [Country(Country.Usa)]
        [Abbreviation("MN")]
        Minnesota = 636038,

        [Country(Country.Usa)]
        [Abbreviation("MS")]
        Mississippi = 636051,

        [Country(Country.Usa)]
        [Abbreviation("MO")]
        Missouri = 636030,

        [Country(Country.Usa)]
        [Abbreviation("MT")]
        Montana = 636008,

        [Country(Country.Usa)]
        [Abbreviation("NE")]
        Nebraska = 636054,

        [Country(Country.Usa)]
        [Abbreviation("NV")]
        Nevada = 636049,

        [Country(Country.Canada)]
        [Abbreviation("NB")]
        [Description("New Brunswick")]
        NewBrunswick = 636017,

        [Country(Country.Usa)]
        [Abbreviation("NH")]
        [Description("New Hampshire")]
        NewHampshire = 636039,

        [Country(Country.Usa)]
        [Abbreviation("NJ")]
        [Description("New Jersey")]
        NewJersey = 636036,

        [Country(Country.Usa)]
        [Abbreviation("NM")]
        [Description("New Mexico")]
        NewMexico = 636009,

        [Country(Country.Usa)]
        [Abbreviation("NY")]
        [Description("New York")]
        NewYork = 636001,

        [Country(Country.Canada)]
        [Abbreviation("NL")]
        Newfoundland = 636016,

        [Country(Country.Usa)]
        [Abbreviation("NC")]
        [Description("North Carolina")]
        NorthCarolina = 636004,

        [Country(Country.Usa)]
        [Abbreviation("ND")]
        [Description("North Dakota")]
        NorthDakota = 636034,

        [Country(Country.Usa)]
        [Abbreviation("MP")]
        [Description("Northern Marianna Islands")]
        NorthernMariannaIslands = 604430,

        [Country(Country.Canada)]
        [Abbreviation("NS")]
        [Description("Nova Scotia")]
        NovaScotia = 636013,

        [Country(Country.Canada)]
        [Abbreviation("NU")]
        Nunavut = 604433,

        [Country(Country.Usa)]
        [Abbreviation("OH")]
        Ohio = 636023,

        [Country(Country.Usa)]
        [Abbreviation("OK")]
        Oklahoma = 636058,

        [Country(Country.Canada)]
        [Abbreviation("ON")]
        Ontario = 636012,

        [Country(Country.Usa)]
        [Abbreviation("OR")]
        Oregon = 636029,

        [Country(Country.Usa)]
        [Abbreviation("PA")]
        Pennsylvania = 636025,

        [Country(Country.Canada)]
        [Abbreviation("PE")]
        [Description("Price Edward Island")]
        PrinceEdwardIsland = 604426,

        [Country(Country.Usa)]
        [Abbreviation("PR")]
        [Description("Puerto Rico")]
        PuertoRico = 604431,

        [Country(Country.Canada)]
        [Abbreviation("QC")]
        Quebec = 604428,

        [Country(Country.Usa)]
        [Abbreviation("RI")]
        [Description("Rhode Island")]
        RhodeIsland = 636052,

        [Country(Country.Canada)]
        [Abbreviation("SK")]
        Saskatchewan = 636044,

        [Country(Country.Usa)]
        [Abbreviation("SC")]
        [Description("South Carolina")]
        SouthCarolina = 636005,

        [Country(Country.Usa)]
        [Abbreviation("SD")]
        [Description("South Dakota")]
        SouthDakota = 636042,

        [Country(Country.Usa)]
        [Abbreviation("TN")]
        Tennessee = 636053,

        [Country(Country.Usa)]
        [Description("US State Department")]
        UsStateDepartment = 636027,

        [Country(Country.Usa)]
        [Abbreviation("TX")]
        Texas = 636015,

        [Country(Country.Usa)]
        [Abbreviation("VI")]
        [Description("US Virgin Islands")]
        UsVirginIslands = 636062,

        [Country(Country.Usa)]
        [Abbreviation("UT")]
        Utah = 636040,

        [Country(Country.Usa)]
        [Abbreviation("VT")]
        Vermont = 636024,

        [Country(Country.Usa)]
        [Abbreviation("VA")]
        Virginia = 636000,

        [Country(Country.Usa)]
        [Abbreviation("WA")]
        Washington = 636045,

        [Country(Country.Usa)]
        [Abbreviation("WV")]
        [Description("West Virginia")]
        WestVirginia = 636061,

        [Country(Country.Usa)]
        [Abbreviation("WI")]
        Wisconsin = 636031,

        [Country(Country.Usa)]
        [Abbreviation("WY")]
        Wyoming = 636060,

        [Country(Country.Canada)]
        [Abbreviation("YT")]
        Yukon = 604429
    }

    public enum Sex : byte
    {
        Male = 1,
        Female = 2,
        NotSpecified = 9
    }

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

    public enum WeightRange
    {
        [Description("Up to 70 lbs (31 kg)")]
        LbsUpTo70 = 0,

        [Description("71-100 lbs (32-45 kg)")]
        Lbs71To100 = 1,

        [Description("101-130 lbs (46-59 kg)")]
        Lbs101To130 = 2,

        [Description("131-160 lbs (60-70 kg)")]
        Lbs131To160 = 3,

        [Description("161-190 lbs (71-86 kg)")]
        Lbs161To190 = 4,

        [Description("191-220 lbs (87-100 kg)")]
        Lbs191To220 = 5,

        [Description("221-250 lbs (101-113 kg)")]
        Lbs221To250 = 6,

        [Description("251-280 lbs (114-127 kg)")]
        Lbs251To280 = 7,

        [Description("281-320 lbs (128-145 kg)")]
        Lbs281To320 = 8,

        [Description("More than 320 lbs (145 kg)")]
        LbsGreaterThan320 = 9
    }

    public enum ComplianceType
    {
        [Description("Materially Compliant")]
        MateriallyCompliant,

        [Description("Fully Compliant")]
        FullyCompliant,

        [Description("Non-Compliant")]
        NonCompliant
    }

    public enum EyeColor
    {
        [Abbreviation("BLK")]
        Black,

        [Abbreviation("BLU")]
        Blue,

        [Abbreviation("BRO")]
        Brown,

        [Abbreviation("DIC")]
        Dichromatic,

        [Abbreviation("GRY")]
        Gray,

        [Abbreviation("GRN")]
        Green,

        [Abbreviation("HAZ")]
        Hazel,

        [Abbreviation("MAR")]
        Maroon,

        [Abbreviation("PNK")]
        Pink
    }

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
