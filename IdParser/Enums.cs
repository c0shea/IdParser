using System.ComponentModel;

namespace IdParser {
    public enum Version : byte {
        PreStandard = 0,
        Aamva2000 = 1,
        Aamva2003 = 2,
        Aamva2005 = 3,
        Aamva2009 = 4,
        Aamva2010 = 5,
        Aamva2011 = 6,
        Aamva2012 = 7,
        Aamva2013 = 8,
        Future = 99
    }

    public enum IssuerIdentificationNumber {
        [Abbreviation("AL")]
        Alabama = 636033,
        [Abbreviation("AK")]
        Alaska = 636059,
        [Abbreviation("AS")]
        [Description("American Samoa")]
        AmericanSamoa = 604427,
        [Abbreviation("AZ")]
        Arizona = 636026,
        [Abbreviation("AR")]
        Arkansas = 636026,
        [Abbreviation("BC")]
        [Description("British Columbia")]
        BritishColumbia = 636028,
        [Abbreviation("CA")]
        California = 636014,
        [Abbreviation("COA")]
        Coahuila = 636056,
        [Abbreviation("CO")]
        Colorado = 636020,
        [Abbreviation("CT")]
        Connecticut = 636006,
        [Abbreviation("DC")]
        [Description("District of Columbia")]
        DistrictOfColumbia = 636043,
        [Abbreviation("DE")]
        Delaware = 636011,
        [Abbreviation("FL")]
        Florida = 636010,
        [Abbreviation("GA")]
        Georgia = 636055,
        [Abbreviation("GU")]
        Guam = 636019,
        [Abbreviation("HI")]
        Hawaii = 636047,
        [Abbreviation("HID")]
        Hidalgo = 636057,
        [Abbreviation("ID")]
        Idaho = 636050,
        [Abbreviation("IL")]
        Illinois = 636035,
        [Abbreviation("IN")]
        Indiana = 636037,
        [Abbreviation("IA")]
        Iowa = 636018,
        [Abbreviation("KS")]
        Kansas = 636022,
        [Abbreviation("KY")]
        Kentucky = 636046,
        [Abbreviation("LA")]
        Louisiana = 636007,
        [Abbreviation("ME")]
        Maine = 636041,
        [Abbreviation("MB")]
        Manitoba = 636048,
        [Abbreviation("MD")]
        Maryland = 636003,
        [Abbreviation("MA")]
        Massachusetts = 636002,
        [Abbreviation("MI")]
        Michigan = 636032,
        [Abbreviation("MN")]
        Minnesota = 636038,
        [Abbreviation("MS")]
        Mississippi = 636051,
        [Abbreviation("MO")]
        Missouri = 636030,
        [Abbreviation("MT")]
        Montana = 636008,
        [Abbreviation("NE")]
        Nebraska = 636054,
        [Abbreviation("NV")]
        Nevada = 636049,
        [Abbreviation("NB")]
        [Description("New Brunswick")]
        NewBrunswick = 636017,
        [Abbreviation("ND")]
        [Description("New Hampshire")]
        NewHampshire = 636039,
        [Abbreviation("NJ")]
        [Description("New Jersey")]
        NewJersey = 636036,
        [Abbreviation("NM")]
        [Description("New Mexico")]
        NewMexico = 636009,
        [Abbreviation("NY")]
        [Description("New York")]
        NewYork = 636001,
        [Abbreviation("NL")]
        Newfoundland = 636016,
        [Abbreviation("NC")]
        [Description("North Carolina")]
        NorthCarolina = 636004,
        [Abbreviation("ND")]
        [Description("North Dakota")]
        NorthDakota = 636034,
        [Abbreviation("NS")]
        [Description("Nova Scotia")]
        NovaScotia = 636013,
        [Abbreviation("OH")]
        Ohio = 636023,
        [Abbreviation("OK")]
        Oklahoma = 636058,
        [Abbreviation("ON")]
        Ontario = 636012,
        [Abbreviation("OR")]
        Oregon = 636029,
        [Abbreviation("PA")]
        Pennsylvania = 636025,
        [Abbreviation("PE")]
        [Description("Price Edward Island")]
        PrinceEdwardIsland = 604426,
        [Abbreviation("QC")]
        Quebec = 604428,
        [Abbreviation("RI")]
        [Description("Rhode Island")]
        RhodeIsland = 636052,
        [Abbreviation("SK")]
        Saskatchewan = 636044,
        [Abbreviation("SC")]
        [Description("South Carolina")]
        SouthCarolina = 636005,
        [Abbreviation("SD")]
        [Description("South Dakota")]
        SouthDakota = 636042,
        [Abbreviation("TN")]
        Tennessee = 636053,
        [Description("US State Department")]
        UsStateDepartment = 636027,
        [Abbreviation("TX")]
        Texas = 636015,
        [Abbreviation("VI")]
        [Description("US Virgin Islands")]
        UsVirginIslands = 636062,
        [Abbreviation("UT")]
        Utah = 636040,
        [Abbreviation("VT")]
        Vermont = 636024,
        [Abbreviation("VA")]
        Virginia = 636000,
        [Abbreviation("WA")]
        Washington = 636045,
        [Abbreviation("WV")]
        [Description("West Virginia")]
        WestVirginia = 636061,
        [Abbreviation("WI")]
        Wisconsin = 636031,
        [Abbreviation("WY")]
        Wyoming = 636060,
        [Abbreviation("YT")]
        Yukon = 604429
    }

    public enum Sex : byte {
        Male = 1,
        Female = 2
    }

    public enum Country {
        USA,
        Canada
    }

    public enum WeightRange {
        [Description("None")]
        None = -1,
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

    public enum ComplianceType {
        [Description("None")]
        None,
        [Description("Materially Compliant")]
        MateriallyCompliant,
        [Description("Fully Compliant")]
        FullyCompliant,
        [Description("Non-Compliant")]
        NonCompliant
    }
}