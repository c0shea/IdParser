using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IdParser
{
    public static class Extensions
    {
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
