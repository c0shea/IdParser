using System;

namespace IdParser
{
    /// <summary>
    /// Specifies a country display value for the target.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class CountryAttribute : Attribute
    {
        public Country Country { get; set; }

        public CountryAttribute(Country country)
        {
            Country = country;
        }
    }
}
