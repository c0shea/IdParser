using System;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DBC")]
    public class SexParser : AbstractParser
    {
        public SexParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (byte.TryParse(input, out var numericSex))
            {
                IdCard.Sex = (Sex)numericSex;
            }
            else if (input.Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                IdCard.Sex = Sex.Male;
            }
            else if (input.Equals("F", StringComparison.OrdinalIgnoreCase))
            {
                IdCard.Sex = Sex.Female;
            }
        }
    }
}
