using System;
using System.Globalization;
using System.Reflection;
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
            var format = "MMddyyyy";

            if (country == Country.Canada || version == Version.Aamva2000)
            {
                format = "yyyyMMdd";
            }

            return DateTime.ParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }
    }
}
