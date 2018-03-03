using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCL")]
    public class EthnicityParser : AbstractParser
    {
        public EthnicityParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (string.IsNullOrEmpty(input) || input.EqualsIgnoreCase("U"))
            {
                return;
            }

            if (input.EqualsIgnoreCase(Ethnicity.AlaskanAmericanIndian.GetAbbreviation()))
            {
                IdCard.Ethnicity = Ethnicity.AlaskanAmericanIndian;
            }
            else if (input.EqualsIgnoreCase(Ethnicity.AsianPacificIslander.GetAbbreviation()))
            {
                IdCard.Ethnicity = Ethnicity.AsianPacificIslander;
            }
            else if (input.EqualsIgnoreCase(Ethnicity.Black.GetAbbreviation()))
            {
                IdCard.Ethnicity = Ethnicity.Black;
            }
            else if (input.EqualsIgnoreCase(Ethnicity.HispanicOrigin.GetAbbreviation()))
            {
                IdCard.Ethnicity = Ethnicity.HispanicOrigin;
            }
            else if (input.EqualsIgnoreCase(Ethnicity.NonHispanic.GetAbbreviation()))
            {
                IdCard.Ethnicity = Ethnicity.NonHispanic;
            }
            else if (input.EqualsIgnoreCase(Ethnicity.White.GetAbbreviation()))
            {
                IdCard.Ethnicity = Ethnicity.White;
            }
        }
    }
}
