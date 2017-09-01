using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdParser
{
    public static class Barcode
    {
        internal const char ExpectedComplianceIndicator = (char) 64;
        internal const char ExpectedDataElementSeparator = (char) 10;
        internal const char ExpectedRecordSeparator = (char) 30;
        internal const char ExpectedSegmentTerminator = (char) 13;
        internal const string ExpectedFileType = "ANSI ";
        internal static string ExpectedHeader => $"@{ExpectedSegmentTerminator}{ExpectedDataElementSeparator}{ExpectedRecordSeparator}{ExpectedSegmentTerminator}{ExpectedDataElementSeparator}{ExpectedFileType}";

        /// <summary>
        /// Parses the raw input from the PDF417 barcode into an IdentificationCard or DriversLicense object.
        /// </summary>
        /// <param name="rawPdf417Input">The string to parse the information out of</param>
        /// <param name="validationLevel">
        /// Specifies the level of <see cref="Validation"/> that will be performed.
        /// Strict validation will ensure the input fully conforms to the AAMVA standard.
        /// No validation will be performed if none is specified and exceptions will not be thrown
        /// for elements that do not match or do not adversely affect parsing.
        /// </param>
        public static IdentificationCard Parse(string rawPdf417Input, Validation validationLevel = Validation.Strict)
        {
            if (rawPdf417Input.Length < 31)
            {
                throw new ArgumentException($"The input is missing required header elements and is not a valid AAMVA format. Expected at least 31 characters. Received {rawPdf417Input.Length}.", nameof(rawPdf417Input));
            }

            if (validationLevel == Validation.Strict)
            {
                ValidateFormat(rawPdf417Input);
            }
            else
            {
                rawPdf417Input = rawPdf417Input.RemoveInvalidCharactersFromHeader()
                                               .FixIncorrectHeader()
                                               .RemoveIncorrectCarriageReturns();
            }

            var version = ParseAamvaVersion(rawPdf417Input);
            var subfileRecords = GetSubfileRecords(version, rawPdf417Input);
            var country = ParseCountry(version, subfileRecords);
            
            if (ParseSubfileType(version, rawPdf417Input) == "DL")
            {
                return new DriversLicense(version, country, rawPdf417Input, subfileRecords);
            }

            return new IdentificationCard(version, country, rawPdf417Input, subfileRecords);
        }

        /// <summary>
        /// Gets the AAMVA version of the input.
        /// </summary>
        /// <param name="input">The raw PDF417 barcode data</param>
        public static Version ParseAamvaVersion(string input)
        {
            if (input == null || input.Length < 17)
            {
                throw new ArgumentException("Input must not be null or less than 17 characters in order to parse the version.", nameof(input));
            }

            var version = ParseAamvaVersionNumber(input);

            if (Enum.IsDefined(typeof(Version), version))
            {
                return (Version)version;
            }

            return Version.Future;
        }

        private static void ValidateFormat(string input)
        {
            var complianceIndicator = ParseComplianceIndicator(input);
            if (complianceIndicator != ExpectedComplianceIndicator)
            {
                throw new ArgumentException($"The compliance indicator is invalid. Expected '{ExpectedComplianceIndicator.ConvertToHex()}'. Received '{complianceIndicator.ConvertToHex()}'.", nameof(input));
            }

            var dataElementSeparator = ParseDataElementSeparator(input);
            if (dataElementSeparator != ExpectedDataElementSeparator)
            {
                throw new ArgumentException($"The data element separator is invalid. Expected '{ExpectedDataElementSeparator.ConvertToHex()}'. Received '{dataElementSeparator.ConvertToHex()}'.", nameof(input));
            }

            var recordSeparator = ParseRecordSeparator(input);
            if (recordSeparator != ExpectedRecordSeparator)
            {
                throw new ArgumentException($"The record separator is invalid. Expected '{ExpectedRecordSeparator.ConvertToHex()}'. Received '{recordSeparator.ConvertToHex()}'.", nameof(input));
            }

            var segmentTerminator = ParseSegmentTerminator(input);
            if (segmentTerminator != ExpectedSegmentTerminator)
            {
                throw new ArgumentException($"The segment terminator is invalid. Expected '{ExpectedSegmentTerminator.ConvertToHex()}'. Received '{segmentTerminator.ConvertToHex()}'.", nameof(input));
            }

            var fileType = ParseFileType(input);
            if (fileType != ExpectedFileType)
            {
                throw new ArgumentException($"The file type is invalid. Expected '{ExpectedFileType}'. Received '{fileType.ConvertToHex()}'.", nameof(input));
            }
        }

        private static char ParseComplianceIndicator(string input)
        {
            return input.Substring(0, 1)[0];
        }

        private static string ParseFileType(string input)
        {
            return input.Substring(4, 5);
        }

        private static byte ParseAamvaVersionNumber(string input)
        {
            return Convert.ToByte(input.Substring(15, 2));
        }

        private static char ParseDataElementSeparator(string input)
        {
            return input.Substring(1, 1)[0];
        }

        private static char ParseRecordSeparator(string input)
        {
            return input.Substring(2, 1)[0];
        }

        private static char ParseSegmentTerminator(string input)
        {
            return input.Substring(3, 1)[0];
        }

        private static string ParseSubfileType(Version version, string input)
        {
            if (version == Version.Aamva2000)
            {
                return input.Substring(19, 2);
            }

            return input.Substring(21, 2);
        }

        /// <summary>
        /// Parses the country based on the DCG subfile record. The <see cref="IdentificationCard"/>
        /// constructor attempts to determine the correct country based on the IIN if the country is unknown.
        /// </summary>
        private static Country ParseCountry(Version version, List<string> subfileRecords)
        {
            // Country is not a subfile record in the AAMVA 2000 standard
            if (version == Version.Aamva2000)
            {
                return Country.Unknown;
            }

            foreach (var subfileRecord in subfileRecords)
            {
                var elementId = subfileRecord.Substring(0, 3);
                var data = subfileRecord.Substring(3).Trim();

                if (elementId == "DCG")
                {
                    if (data == "USA")
                    {
                        return Country.USA;
                    }
                    if (data == "CAN" || data == "CDN")
                    {
                        return Country.Canada;
                    }
                }
            }

            return Country.Unknown;
        }

        private static List<string> GetSubfileRecords(Version version, string input)
        {
            int offset = 0;

            if (version == Version.Aamva2000)
            {
                offset = Convert.ToInt32(input.Substring(21, 4));
            }
            else if (version >= Version.Aamva2003)
            {
                offset = Convert.ToInt32(input.Substring(23, 4));
            }

            var records = input.Substring(offset).Split(new[] { ParseDataElementSeparator(input), ParseSegmentTerminator(input) }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var firstRecord = records[0].Substring(0, 2);

            if (firstRecord == "DL" || firstRecord == "ID")
            {
                records[0] = records[0].Substring(2);
            }

            return records;
        }
        
        private static string ConvertToHex(this string value)
        {
            var hex = BitConverter.ToString(Encoding.UTF8.GetBytes(value));

            hex = "0x" + hex.Replace("-", "");

            return hex;
        }

        private static string ConvertToHex(this char value)
        {
            return "0x" + BitConverter.ToString(Encoding.UTF8.GetBytes(new[] { value }));
        }
    }
}
