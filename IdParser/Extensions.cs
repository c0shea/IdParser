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
            return value.GetAttributeValueOrDefault<DescriptionAttribute>(a => a.Description);
        }

        /// <summary>
        /// Gets the value of the <see cref="AbbreviationAttribute"/> on the <see cref="Enum"/>.
        /// </summary>
        public static string GetAbbreviation(this Enum value)
        {
            return value.GetAttributeValueOrDefault<AbbreviationAttribute>(a => a.Abbreviation);
        }

        private static string GetAttributeValueOrDefault<T>(this Enum value, Func<T, string> property) where T : Attribute
        {
            var field = value.GetType().GetTypeInfo().GetField(value.ToString());
            var attribute = field.GetCustomAttribute<T>();

            return attribute == null ? value.ToString() : property(attribute);
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
