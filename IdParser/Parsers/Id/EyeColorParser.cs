using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAY")]
    public class EyeColorParser : AbstractParser
    {
        public EyeColorParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (string.IsNullOrEmpty(input) || input.EqualsIgnoreCase("UNK"))
            {
                return;
            }

            if (input.EqualsIgnoreCase(EyeColor.Black.GetAbbreviation()))
            {
                IdCard.EyeColor = EyeColor.Black;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Blue.GetAbbreviation()))
            {
                IdCard.EyeColor = EyeColor.Blue;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Brown.GetAbbreviation()))
            {
                IdCard.EyeColor = EyeColor.Brown;
            }
            // California doesn't follow the abbreviation scheme for brown
            else if (input.EqualsIgnoreCase("BRN"))
            {
                IdCard.EyeColor = EyeColor.Brown;
            }
            // Arizona doesn't follow the abbreviation scheme for brown
            else if (input.EqualsIgnoreCase("BR"))
            {
                IdCard.EyeColor = EyeColor.Brown;
            }
            // West Verginia doesn't follow the abbreviation scheme for brown
            else if (input.EqualsIgnoreCase("BN"))
            {
                IdCard.EyeColor = EyeColor.Brown;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Dichromatic.GetAbbreviation()))
            {
                IdCard.EyeColor = EyeColor.Dichromatic;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Gray.GetAbbreviation()))
            {
                IdCard.EyeColor = EyeColor.Gray;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Green.GetAbbreviation()))
            {
                IdCard.EyeColor = EyeColor.Green;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Hazel.GetAbbreviation()))
            {
                IdCard.EyeColor = EyeColor.Hazel;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Maroon.GetAbbreviation()))
            {
                IdCard.EyeColor = EyeColor.Maroon;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Pink.GetAbbreviation()))
            {
                IdCard.EyeColor = EyeColor.Pink;
            }

            else if (input.EqualsIgnoreCase(EyeColor.Black.ToString()))
            {
                IdCard.EyeColor = EyeColor.Black;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Blue.ToString()))
            {
                IdCard.EyeColor = EyeColor.Blue;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Brown.ToString()))
            {
                IdCard.EyeColor = EyeColor.Brown;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Dichromatic.ToString()))
            {
                IdCard.EyeColor = EyeColor.Dichromatic;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Gray.ToString()))
            {
                IdCard.EyeColor = EyeColor.Gray;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Green.ToString()))
            {
                IdCard.EyeColor = EyeColor.Green;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Hazel.ToString()))
            {
                IdCard.EyeColor = EyeColor.Hazel;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Maroon.ToString()))
            {
                IdCard.EyeColor = EyeColor.Maroon;
            }
            else if (input.EqualsIgnoreCase(EyeColor.Pink.ToString()))
            {
                IdCard.EyeColor = EyeColor.Pink;
            }
        }
    }
}
