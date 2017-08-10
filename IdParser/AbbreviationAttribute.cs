using System;

namespace IdParser
{
    /// <summary>
    /// Specifies an abbreviated display value for the target.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class AbbreviationAttribute : Attribute
    {
        public string Abbreviation { get; set; }

        public AbbreviationAttribute(string abbreviation)
        {
            Abbreviation = abbreviation;
        }
    }
}
