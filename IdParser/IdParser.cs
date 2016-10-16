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
        /// OBSOLETE - Validates and parses the raw input from the PDF417 barcode into an IdentificationCard or DriversLicense object.
        /// </summary>
        /// <param name="rawPdf417Input">The string to parse the information out of</param>
        /// <param name="suppressValidation">
        /// If set to true, exceptions will not be thrown for elements that do not match
        /// the AAMVA standard but do not adversely affect parsing. When set to false
        /// (the default if not specified), exceptions will be thrown for all validation errors.
        /// </param>
        [Obsolete("Calling Parse with a bool to suppress validation is deprecated. Use the Parse method and specify the validation level via the Validation enum.")]
        public static IdentificationCard Parse(string rawPdf417Input, bool suppressValidation = false) {
            if (suppressValidation) {
                return Parse(rawPdf417Input, Validation.None);
            }

            return Parse(rawPdf417Input, Validation.Strict);
        }

        /// <summary>
        /// Fully validates and parses the raw input from the PDF417 barcode into an IdentificationCard or DriversLicense object.
        /// </summary>
        /// <param name="rawPdf417Input">The string to parse the information out of</param>
        public static IdentificationCard Parse(string rawPdf417Input) {
            return Parse(rawPdf417Input, Validation.Strict);
        }

        /// <summary>
        /// Validates based on the validation level specified and parses the raw input from the PDF417 barcode into an IdentificationCard or DriversLicense object.
        /// </summary>
        /// <param name="rawPdf417Input">The string to parse the information out of</param>
        /// <param name="validationLevel">
        /// Specifies the level of <see cref="Validation"/> that will be performed.
        /// Strict validation will ensure the input fully conforms to the AAMVA standard.
        /// No validation will be performed if none is specified and exceptions will not be thrown
        /// for elements that do not match or do not adversely affect parsing.
        /// </param>
        public static IdentificationCard Parse(string rawPdf417Input, Validation validationLevel) {
            if (validationLevel == Validation.Strict) {
                ValidateFormat(rawPdf417Input);
            }
            else {
                rawPdf417Input = RemoveIncorrectCarriageReturns(rawPdf417Input);
            }

            var version = ParseAamvaVersion(rawPdf417Input);
            var subfileRecords = GetSubfileRecords(version, rawPdf417Input);
            var country = ParseCountry(version, subfileRecords);


            if (ParseSubfileType(version, rawPdf417Input) == "DL") {
                return new DriversLicense(version, country, rawPdf417Input, subfileRecords);
            }

            return new IdentificationCard(version, country, rawPdf417Input, subfileRecords);
        }

        private static void ValidateFormat(string input) {
            if (input.Length < 31) {
                throw new ArgumentException("The input is missing required header elements and is not a valid AAMVA format.", nameof(input));
            }

            if (input.Substring(0, 1) != "@") {
                throw new ArgumentException("The compliance indicator is invalid. Expected 0x40.", nameof(input));
            }

            if (ParseDataElementSeparator(input) != ExpectedLineFeed) {
                throw new ArgumentException("The data element separator is invalid. Expected 0x0A.", nameof(input));
            }

            if (ParseRecordSeparator(input) != ExpectedRecordSeparator) {
                throw new ArgumentException("The record separator is wrong. Expected 0x1E.", nameof(input));
            }

            if (ParseSegmentTerminator(input) != ExpectedCarriageReturn) {
                throw new ArgumentException("The segment terminator is wrong. Expected 0x0D.", nameof(input));
            }

            if (input.Substring(4, 5) != "ANSI ") {
                throw new ArgumentException("The file type is invalid. Expected \"ANSI \"", nameof(input));
            }
        }

        // HID keyboard emulation (and some other methods) tend to replace the \r with \r\n
        // which is invalid and doesn't conform to the AAMVA standard. This fixes it before attempting to parse the fields.
        private static string RemoveIncorrectCarriageReturns(string input) {
            if (input.Length < 5) {
                return input;
            }
            
            var replacedString = input.Replace(ExpectedCarriageReturn.ToString(), string.Empty);

            return replacedString.Substring(0, 3) + ExpectedCarriageReturn + replacedString.Substring(4);
        }

        /// <summary>
        /// Gets the AAMVA version of the input.
        /// </summary>
        /// <param name="input">The raw PDF417 barcode data</param>
        public static Version ParseAamvaVersion(string input) {
            if (input == null || input.Length < 17) {
                throw new ArgumentException("Input must not be null or less than 17 characters in order to parse the version.", nameof(input));
            }

            var version = ParseAamvaVersionNumber(input);

            if (Enum.IsDefined(typeof(Version), version)) {
                return (Version)version;
            }

            return Version.Future;
        }

        private static byte ParseAamvaVersionNumber(string input) {
            return Convert.ToByte(input.Substring(15, 2));
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

        /// <summary>
        /// Parses the country based on the DCG subfile record. The <see cref="IdentificationCard"/>
        /// construcutor attempts to determine the correct country based on the IIN if the country is unknown.
        /// </summary>
        private static Country ParseCountry(Version version, List<string> subfileRecords) {
            // Country is not a subfile record in the AAMVA 2000 standard
            if (version == Version.Aamva2000) {
                return Country.Unknown;
            }

            foreach (var subfileRecord in subfileRecords) {
                var elementId = subfileRecord.Substring(0, 3);
                var data = subfileRecord.Substring(3).Trim();

                if (elementId == "DCG") {
                    if (data == "USA") {
                        return Country.USA;
                    }
                    if (data == "CAN" || data == "CDN") {
                        return Country.Canada;
                    }
                }
            }

            return Country.Unknown;
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

        public static Country GetCountry(this Enum value) {
            var field = value.GetType().GetField(value.ToString());

            var attribute = Attribute.GetCustomAttribute(field, typeof(CountryAttribute)) as CountryAttribute;

            return attribute == null ? Country.Unknown : attribute.Country;
        }
    }
}