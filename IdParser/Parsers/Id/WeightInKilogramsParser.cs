using System;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAX")]
    public class WeightInKilogramsParser : AbstractParser
    {
        public WeightInKilogramsParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.WeightInKilograms = Convert.ToInt16(input);
        }
    }
}
