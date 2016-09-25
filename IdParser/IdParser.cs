using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace IdParser {
    public static class IdParser {
        private const char ExpectedLineFeed = (char)10;
        private const char ExpectedRecordSeparator = (char)30;
        private const char ExpectedCarriageReturn = (char)13;

        /// <summary>
        /// Validates and parses the raw input from the PDF417 barcode into an IdentificationCard or DriversLicense object.
        /// </summary>
        /// <param name="rawPdf417Input">The string to parse the information out of</param>
        /// <param name="suppressValidation">
        /// If set to true, exceptions will not be thrown for elements that do not match
        /// the AAMVA standardbut do not adversly affect parsing. When set to false
        /// (the default if not specified), exceptions will be thrown for all validation errors.
        /// </param>
        public static IdentificationCard Parse(string rawPdf417Input, bool suppressValidation = false) {
            if (!suppressValidation) {
                ValidateFormat(rawPdf417Input);
            }

            var version = ParseAamvaVersion(rawPdf417Input);

            if (ParseSubfileType(version, rawPdf417Input) == "DL") {
                return new DriversLicense(version, rawPdf417Input, GetSubfileRecords(version, rawPdf417Input));
            }

            return new IdentificationCard(version, rawPdf417Input, GetSubfileRecords(version, rawPdf417Input));
        }

        private static void ValidateFormat(string input) {
            if (input.Length < 31) {
                throw new ArgumentException("The input is missing required header elements and is not a valid AAMVA format.");
            }

            if (input.Substring(0, 1) != "@") {
                throw new ArgumentException("The compliance indicator is invalid. Expected 0x40.");
            }

            if (ParseDataElementSeparator(input) != ExpectedLineFeed) {
                throw new ArgumentException("The data element separator is invalid. Expected 0x0A.");
            }

            if (ParseRecordSeparator(input) != ExpectedRecordSeparator) {
                throw new ArgumentException("The record separator is wrong. Expected 0x1E.");
            }

            if (ParseSegmentTerminator(input) != ExpectedCarriageReturn) {
                throw new ArgumentException("The segment terminator is wrong. Expected 0x0D.");
            }

            if (input.Substring(4, 5) != "ANSI ") {
                throw new ArgumentException("The file type is invalid. Expected \"ANSI \"");
            }
        }

        private static byte ParseAamvaVersionNumber(string input) {
            return Convert.ToByte(input.Substring(15, 2));
        }

        /// <summary>
        /// Gets the AAMVA version of the input.
        /// </summary>
        /// <param name="input">The raw PDF417 barcode data</param>
        public static Version ParseAamvaVersion(string input) {
            var version = ParseAamvaVersionNumber(input);

            if (Enum.IsDefined(typeof(Version), version)) {
                return (Version)version;
            }

            return Version.Future;
        }

        internal static char ParseDataElementSeparator(string input) {
            return input.Substring(1, 1)[0];
        }

        internal static char ParseRecordSeparator(string input) {
            return input.Substring(2, 1)[0];
        }

        internal static char ParseSegmentTerminator(string input) {
            return input.Substring(3, 1)[0];
        }

        private static string ParseSubfileType(Version version, string input) {
            if (version == Version.Aamva2000) {
                return input.Substring(19, 2);
            }

            return input.Substring(21, 2);
        }

        private static List<string> GetSubfileRecords(Version version, string input) {
            int offset = 0;

            if (version == Version.Aamva2000) {
                offset = Convert.ToInt32(input.Substring(21, 4));
            }
            else if (version >= Version.Aamva2003) {
                offset = Convert.ToInt32(input.Substring(23, 4));
            }

            var records = input.Substring(offset).Split(new[] { ParseDataElementSeparator(input), ParseSegmentTerminator(input) }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var firstRecord = records[0].Substring(0, 2);
            if (firstRecord == "DL" || firstRecord == "ID") {
                records[0] = records[0].Substring(2);
            }

            return records;
        }

        public static string GetDescription(this Enum value) {
            var field = value.GetType().GetField(value.ToString());

            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string GetAbbreviation(this Enum value) {
            var field = value.GetType().GetField(value.ToString());

            var attribute = Attribute.GetCustomAttribute(field, typeof(AbbreviationAttribute)) as AbbreviationAttribute;

            return attribute == null ? value.ToString() : attribute.Abbreviation;
        }
    }

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