using System;

namespace IdParser {
    [AttributeUsage(AttributeTargets.All)]
    public class AbbreviationAttribute : Attribute {
        public string Abbreviation { get; set; }

        public AbbreviationAttribute(string abbreviation) {
            Abbreviation = abbreviation;
        }
    }
}