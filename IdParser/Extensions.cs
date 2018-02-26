using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using IdParser.Attributes;

namespace IdParser
{
    public static class Extensions
    {
        /// <summary>
        /// Gets the value of the <see cref="DescriptionAttribute"/> on the <see cref="Enum"/>.
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetTypeInfo().GetField(value.ToString());
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Gets the value of the <see cref="AbbreviationAttribute"/> on the <see cref="Enum"/>.
        /// </summary>
        public static string GetAbbreviation(this Enum value)
        {
            var field = value.GetType().GetTypeInfo().GetField(value.ToString());
            var attribute = field.GetCustomAttribute<AbbreviationAttribute>();

            return attribute == null ? value.ToString() : attribute.Abbreviation;
        }

        /// <summary>
        /// Gets the value of the <see cref="CountryAttribute"/> on the <see cref="Enum"/>.
        /// </summary>
        public static Country GetCountry(this Enum value)
        {
            var field = value.GetType().GetTypeInfo().GetField(value.ToString());
            var attribute = field.GetCustomAttribute<CountryAttribute>();

            return attribute?.Country ?? Country.Unknown;
        }

        internal static DateTime ParseDate(this Country country, Version version, string value)
        {
            const string usaFormat = "MMddyyyy";
            const string canadaFormat = "yyyyMMdd";
            bool tryCanadaFormatFirst = country == Country.Canada || version == Version.Aamva2000;

            if (value != null && value.Length > usaFormat.Length)
            {
                value = value.Substring(0, usaFormat.Length);
            }

            // Some jurisdictions, like Wyoming (version 2009), don't follow the standard and use the wrong date format.
            // In an attempt to parse the ID successfully, attempt to parse using both formats if the first attempt fails.
            // Hopefully between the two one will work.
            if (DateTime.TryParseExact(value, tryCanadaFormatFirst ? canadaFormat : usaFormat, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out var firstAttemptResult))
            {
                return firstAttemptResult;
            }

            if (DateTime.TryParseExact(value, !tryCanadaFormatFirst ? canadaFormat : usaFormat, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out var secondAttemptResult))
            {
                return secondAttemptResult;
            }

            throw new ArgumentException($"Failed to parse the date '{value}' for country '{country}' using version '{version}'.", nameof(value));
        }

        internal static string ReplaceEmptyWithNull(this string data)
        {
            return string.IsNullOrEmpty(data) ? null : data;
        }

        internal static string ConvertToHex(this string value)
        {
            var hex = BitConverter.ToString(Encoding.UTF8.GetBytes(value));

            hex = "0x" + hex.Replace("-", "");

            return hex;
        }

        internal static string ConvertToHex(this char value)
        {
            return "0x" + BitConverter.ToString(Encoding.UTF8.GetBytes(new[] { value }));
        }
    }
}
