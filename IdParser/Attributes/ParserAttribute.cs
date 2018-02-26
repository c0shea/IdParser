using System;

namespace IdParser.Attributes
{
    /// <summary>
    /// Indicates the element this parser is capable of handling.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ParserAttribute : Attribute
    {
        public string ElementId { get; }

        public ParserAttribute(string elementId)
        {
            ElementId = elementId;
        }
    }
}
