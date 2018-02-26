using System;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCE")]
    public class WeightRangeParser : AbstractParser
    {
        public WeightRangeParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.WeightRange = (WeightRange) Convert.ToByte(input);
        }
    }
}
