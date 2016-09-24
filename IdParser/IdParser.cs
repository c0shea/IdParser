using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace IdParser {
    public static class IdParser {
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

            if (ParseSubfileType(rawPdf417Input) == "DL") {
                return new DriversLicense(rawPdf417Input, GetSubfileRecords(rawPdf417Input));
            }

            return new IdentificationCard(rawPdf417Input, GetSubfileRecords(rawPdf417Input));
        }

        private static void ValidateFormat(string input) {
            if (input.Length < 31) {
                throw new ArgumentException("The input is missing required header elements and is not a valid AAMVA format.");
            }

            if (input.Substring(0, 1) != "@") {
                throw new ArgumentException("The compliance indicator is invalid. Expected 0x40.");
            }

            if (input.Substring(1, 1) != ((char)10).ToString()) {
                throw new ArgumentException("The data element separator is invalid. Expected 0x0A.");
            }

            if (input.Substring(2, 1) != ((char)30).ToString()) {
                throw new ArgumentException("The record separator is wrong. Expected 0x1E.");
            }

            if (input.Substring(3, 1) != ((char)13).ToString()) {
                throw new ArgumentException("The segment terminator is wrong. Expected 0x0D.");
            }

            if (input.Substring(4, 5) != "ANSI ") {
                throw new ArgumentException("The file type is invalid. Expected \"ANSI \"");
            }
        }

        private static string ParseSubfileType(string input) {
            return input.Substring(21, 2);
        }

        private static List<string> GetSubfileRecords(string input) {
            var offset = Convert.ToInt32(input.Substring(23, 4));

            var records = input.Substring(offset).Split(new[] { (char)10, (char)13 }, StringSplitOptions.RemoveEmptyEntries).ToList();
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
    }
    
    public enum IssuerIdentificationNumber {
        Alabama = 636033,
        Alaska = 636059,
        [Description("American Samoa")]
        AmericanSamoa = 604427,
        Arizona = 636026,
        Arkansas = 636026,
        [Description("British Columbia")]
        BritishColumbia = 636028,
        California = 636014,
        Coahuila = 636056,
        Colorado = 636020,
        Connecticut = 636006,
        [Description("District of Columbia")]
        DistrictOfColumbia = 636043,
        Delaware = 636011,
        Florida = 636010,
        Georgia = 636055,
        Guam = 636019,
        Hawaii = 636047,
        Hidalgo = 636057,
        Idaho = 636050,
        Illinois = 636035,
        Indiana = 636037,
        Iowa = 636018,
        Kansas = 636022,
        Kentucky = 636046,
        Louisiana = 636007,
        Maine = 636041,
        Manitoba = 636048,
        Maryland = 636003,
        Massachusetts = 636002,
        Michigan = 636032,
        Minnesota = 636038,
        Mississippi = 636051,
        Missouri = 636030,
        Montana = 636008,
        Nebraska = 636054,
        Nevada = 636049,
        [Description("New Brunswick")]
        NewBrunswick = 636017,
        [Description("New Hampshire")]
        NewHampshire = 636039,
        [Description("New Jersey")]
        NewJersey = 636036,
        [Description("New Mexico")]
        NewMexico = 636009,
        [Description("New York")]
        NewYork = 636001,
        Newfoundland = 636016,
        [Description("North Carolina")]
        NorthCarolina = 636004,
        [Description("North Dakota")]
        NorthDakota = 636034,
        [Description("Nova Scotia")]
        NovaScotia = 636013,
        Ohio = 636023,
        Oklahoma = 636058,
        Ontario = 636012,
        Oregon = 636029,
        Pennsylvania = 636025,
        [Description("Price Edward Island")]
        PrinceEdwardIsland = 604426,
        Quebec = 604428,
        [Description("Rhode Island")]
        RhodeIsland = 636052,
        Saskatchewan = 636044,
        [Description("South Carolina")]
        SouthCarolina = 636005,
        [Description("South Dakota")]
        SouthDakota = 636042,
        Tennessee = 636053,
        [Description("US State Department")]
        UsStateDepartment = 636027,
        Texas = 636015,
        [Description("US Virgin Islands")]
        UsVirginIslands = 636062,
        Utah = 636040,
        Vermont = 636024,
        Virginia = 636000,
        Washington = 636045,
        [Description("West Virginia")]
        WestVirginia = 636061,
        Wisconsin = 636031,
        Wyoming = 636060,
        Yukon = 604429
    }

    public enum Sex {
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