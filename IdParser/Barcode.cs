using System;
using System.Collections.Generic;
using System.Linq;
using IdParser.Attributes;
using IdParser.Parsers;

namespace IdParser
{
    public static class Barcode
    {
        internal const char ExpectedComplianceIndicator = (char)64;
        internal const char ExpectedDataElementSeparator = (char)10;
        internal const char ExpectedRecordSeparator = (char)30;
        internal const char ExpectedSegmentTerminator = (char)13;
        internal const string ExpectedFileType = "ANSI ";
        internal static string ExpectedHeader => $"@{ExpectedSegmentTerminator}{ExpectedDataElementSeparator}{ExpectedRecordSeparator}{ExpectedSegmentTerminator}{ExpectedDataElementSeparator}{ExpectedFileType}";

        private static readonly Lazy<Dictionary<string, Type>> Parsers = new Lazy<Dictionary<string, Type>>(() =>
            typeof(ParserAttribute).Assembly.GetTypes()
                                            .Where(t => t.IsDefined(typeof(ParserAttribute), false))
                                            .ToDictionary(t => t.GetCustomAttributes(typeof(ParserAttribute), false)
                                                                .Cast<ParserAttribute>()
                                                                .Single().ElementId,
                                                          t => t));

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
            var idCard = GetIdCardInstance(version, rawPdf417Input);

            PopulateIdCard(idCard, version, country, subfileRecords);

            return idCard;
        }

        private static IdentificationCard GetIdCardInstance(Version version, string rawPdf417Input)
        {
            var idCard = ParseSubfileType(version, rawPdf417Input) == "DL"
                ? new DriversLicense()
                : new IdentificationCard();

            idCard.IssuerIdentificationNumber = (IssuerIdentificationNumber)Convert.ToInt32(rawPdf417Input.Substring(9, 6));
            idCard.AamvaVersionNumber = version;
            idCard.JurisdictionVersionNumber = version == Version.Aamva2000
                ? (byte)0
                : Convert.ToByte(rawPdf417Input.Substring(17, 2));
            
            return idCard;
        }

        /// <summary>
        /// Gets the AAMVA version of the input.
        /// </summary>
        /// <param name="input">The raw PDF417 barcode data</param>
        private static Version ParseAamvaVersion(string input)
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

        private static char ParseComplianceIndicator(string input) => input.Substring(0, 1)[0];
        private static string ParseFileType(string input) => input.Substring(4, 5);
        private static byte ParseAamvaVersionNumber(string input) => Convert.ToByte(input.Substring(15, 2));
        private static char ParseDataElementSeparator(string input) => input.Substring(1, 1)[0];
        private static char ParseRecordSeparator(string input) => input.Substring(2, 1)[0];
        private static char ParseSegmentTerminator(string input) => input.Substring(3, 1)[0];

        /// <summary>
        /// Determines whether the barcode is an <see cref="IdentificationCard"/> or a <see cref="DriversLicense"/>.
        /// </summary>
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
        private static Country? ParseCountry(Version version, List<string> subfileRecords)
        {
            // Country is not a subfile record in the AAMVA 2000 standard
            if (version == Version.Aamva2000)
            {
                return null;
            }

            foreach (var subfileRecord in subfileRecords)
            {
                var elementId = subfileRecord.Substring(0, 3);
                var data = subfileRecord.Substring(3).Trim();

                if (elementId == "DCG")
                {
                    if (data == "USA")
                    {
                        return Country.Usa;
                    }
                    if (data == "CAN" || data == "CDN")
                    {
                        return Country.Canada;
                    }
                }
            }

            return null;
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

        private static void PopulateIdCard(IdentificationCard idCard, Version version, Country? country, List<string> subfileRecords)
        {
            foreach (var subfileRecord in subfileRecords)
            {
                if (subfileRecord.Length < 3)
                {
                    continue;
                }

                var elementId = subfileRecord.Substring(0, 3);
                var data = subfileRecord.Substring(3).Trim();

                if (elementId.StartsWith("Z") && !idCard.AdditionalJurisdictionElements.ContainsKey(elementId))
                {
                    idCard.AdditionalJurisdictionElements.Add(elementId, data);
                    continue;
                }

                var parser = CreateParserInstance(elementId, version, country, idCard);
                parser?.ParseAndSet(data);
            }
        }

        private static AbstractParser CreateParserInstance(string elementId, Version version, Country? country, IdentificationCard idCard)
        {
            if (!Parsers.Value.TryGetValue(elementId, out var type))
            {
                return null;
            }

            var instance = Activator.CreateInstance(type, idCard, version, country) as AbstractParser;

            return instance;
        }
    }
}
