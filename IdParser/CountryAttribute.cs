using System;

namespace IdParser {
    [AttributeUsage(AttributeTargets.All)]
    public class CountryAttribute : Attribute {
        public Country Country { get; set; }

        public CountryAttribute(Country country) {
            Country = country;
        }
    }
}
