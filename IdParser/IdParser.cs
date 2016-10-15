using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
}