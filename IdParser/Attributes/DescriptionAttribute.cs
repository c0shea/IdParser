using System;

namespace IdParser.Attributes
{
    /// <summary>
    /// Specifies a description for the target.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        
        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
