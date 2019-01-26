using System;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAU")]
    public class HeightParser : AbstractParser
    {
        public HeightParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 3)
            {
                return;
            }

            if (Version == Version.Aamva2000)
            {
                var feet = Convert.ToInt32(input.Substring(0, 1));
                var inches = Convert.ToInt32(input.Substring(1, 2));

                IdCard.Height = Height.FromImperial(feet, inches);
                return;
            }

            var height = Convert.ToInt32(input.Substring(0, input.Length - 2));

            if (input.IndexOf("cm", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                IdCard.Height = Height.FromMetric(height);
                return;
            }

            IdCard.Height = Height.FromImperial(height);
        }
    }
}
