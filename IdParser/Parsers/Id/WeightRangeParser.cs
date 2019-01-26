using System;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCE")]
    public class WeightRangeParser : AbstractParser
    {
        public WeightRangeParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            var weightRange = (WeightRange)Convert.ToByte(input);

            if (IdCard.Weight == null)
            {
                IdCard.Weight = Weight.FromRange(weightRange);
                return;
            }

            IdCard.Weight.WeightRange = weightRange;
        }
    }
}
