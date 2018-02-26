using System;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAW")]
    public class WeightInPoundsParser : AbstractParser
    {
        public WeightInPoundsParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.WeightInPounds = Convert.ToInt16(input);
        }
    }
}
