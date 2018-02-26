using System;
using System.Globalization;

namespace IdParser.Parsers
{
    public abstract class AbstractParser
    {
        protected IdentificationCard IdCard { get; }
        protected DriversLicense License => IdCard as DriversLicense ?? throw new InvalidOperationException("IdCard is of type IdentificationCard and not the expected DriversLicense type.");
        protected Version Version { get; }
        protected Country Country { get; }

        protected AbstractParser(IdentificationCard idCard, Version version, Country country)
        {
            IdCard = idCard;
            Version = version;
            Country = country;
        }

        public abstract void ParseAndSet(string input);

        protected static bool DateHasNoValue(string input)
        {
            return string.IsNullOrEmpty(input) || input == "00000000";
        }

        protected static bool NameHasNoValue(string input)
        {
            return string.IsNullOrEmpty(input) || input == "NONE" || input == "unavl" || input == "unavail";
        }

        protected DateTime ParseDate(string input)
        {
            const string usaFormat = "MMddyyyy";
            const string canadaFormat = "yyyyMMdd";
            bool tryCanadaFormatFirst = Country == Country.Canada || Version == Version.Aamva2000;

            // Some jurisdictions, like New Hampshire (version 2013), don't follow the standard and have trailing
            // characters (like 'M') after the date in the same record. In an attempt to parse the date successfully,
            // only try parsing the positions we know should contain a date.
            if (input != null && input.Length > usaFormat.Length)
            {
                input = input.Substring(0, usaFormat.Length);
            }

            // Some jurisdictions, like Wyoming (version 2009), don't follow the standard and use the wrong date format.
            // In an attempt to parse the ID successfully, attempt to parse using both formats if the first attempt fails.
            // Hopefully between the two one will work.
            if (DateTime.TryParseExact(input, tryCanadaFormatFirst ? canadaFormat : usaFormat, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out var firstAttemptResult))
            {
                return firstAttemptResult;
            }

            if (DateTime.TryParseExact(input, !tryCanadaFormatFirst ? canadaFormat : usaFormat, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out var secondAttemptResult))
            {
                return secondAttemptResult;
            }

            throw new ArgumentException($"Failed to parse the date '{input}' for country '{Country}' using version '{Version}'.", nameof(input));
        }

        protected static bool? ParseBool(string input)
        {
            switch (input.ToUpper())
            {
                case "T":
                    return true;
                case "Y":
                    return true;
                case "N":
                    return false;
                case "F":
                    return false;
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    return null;
            }
        }
    }
}
