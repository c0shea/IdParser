using System;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAX")]
    public class WeightInKilogramsParser : AbstractParser
    {
        public WeightInKilogramsParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            var weight = Convert.ToInt16(input);

            if (IdCard.Weight == null)
            {
                IdCard.Weight = Weight.FromMetric(weight);
                return;
            }

            IdCard.Weight.SetMetric(weight);
        }
    }
}
