using System;
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
            return value.GetAttributeValueOrDefault<DescriptionAttribute, string>(a => a.Description);
        }

        /// <summary>
        /// Gets the value of the <see cref="AbbreviationAttribute"/> on the <see cref="Enum"/>.
        /// </summary>
        public static string GetAbbreviation(this Enum value)
        {
            return value.GetAttributeValueOrDefault<AbbreviationAttribute, string>(a => a.Abbreviation);
        }

        /// <summary>
        /// Gets the value of the <see cref="CountryAttribute"/> on the <see cref="Enum"/>.
        /// </summary>
        public static Country GetCountry(this Enum value)
        {
            return value.GetAttributeValueOrDefault<CountryAttribute, Country>(a => a.Country);
        }

        private static TVal GetAttributeValueOrDefault<T, TVal>(this Enum value, Func<T, TVal> property) where T : Attribute
        {
            var field = value.GetType().GetTypeInfo().GetField(value.ToString());
            var attribute = field.GetCustomAttribute<T>();

            if (typeof(TVal) == typeof(string))
            {
                return attribute == null ? (TVal)(object)value.ToString() : property(attribute);
            }
            
            return property(attribute);
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

        internal static bool EqualsIgnoreCase(this string source, string value)
        {
            return source.Equals(value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
