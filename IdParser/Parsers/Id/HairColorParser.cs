using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAZ")]
    public class HairColorParser : AbstractParser
    {
        public HairColorParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (string.IsNullOrEmpty(input) || input.EqualsIgnoreCase("UNK"))
            {
                return;
            }

            if (input.EqualsIgnoreCase(HairColor.Bald.GetAbbreviation()))
            {
                IdCard.HairColor = HairColor.Bald;
            }
            else if (input.EqualsIgnoreCase(HairColor.Black.GetAbbreviation()))
            {
                IdCard.HairColor = HairColor.Black;
            }
            else if (input.EqualsIgnoreCase(HairColor.Blond.GetAbbreviation()))
            {
                IdCard.HairColor = HairColor.Blond;
            }
            else if (input.EqualsIgnoreCase(HairColor.Brown.GetAbbreviation()))
            {
                IdCard.HairColor = HairColor.Brown;
            }
            // California doesn't follow the abbreviation scheme for brown
            else if (input.EqualsIgnoreCase("BRN"))
            {
                IdCard.HairColor = HairColor.Brown;
            }
            // Arizona doesn't follow the abbreviation scheme for brown
            else if (input.EqualsIgnoreCase("BR"))
            {
                IdCard.HairColor = HairColor.Brown;
            }
            // West Virginia doesn't follow the abbreviation scheme for brown
            else if (input.EqualsIgnoreCase("BN"))
            {
                IdCard.EyeColor = EyeColor.Brown;
            }
            else if (input.EqualsIgnoreCase(HairColor.Gray.GetAbbreviation()))
            {
                IdCard.HairColor = HairColor.Gray;
            }
            else if (input.EqualsIgnoreCase(HairColor.RedAuburn.GetAbbreviation()))
            {
                IdCard.HairColor = HairColor.RedAuburn;
            }
            else if (input.EqualsIgnoreCase(HairColor.Sandy.GetAbbreviation()))
            {
                IdCard.HairColor = HairColor.Sandy;
            }
            else if (input.EqualsIgnoreCase(HairColor.White.GetAbbreviation()))
            {
                IdCard.HairColor = HairColor.White;
            }

            else if (input.EqualsIgnoreCase(HairColor.Bald.ToString()))
            {
                IdCard.HairColor = HairColor.Bald;
            }
            else if (input.EqualsIgnoreCase(HairColor.Black.ToString()))
            {
                IdCard.HairColor = HairColor.Black;
            }
            else if (input.EqualsIgnoreCase(HairColor.Blond.ToString()))
            {
                IdCard.HairColor = HairColor.Blond;
            }
            else if (input.EqualsIgnoreCase(HairColor.Brown.ToString()))
            {
                IdCard.HairColor = HairColor.Brown;
            }
            else if (input.EqualsIgnoreCase(HairColor.Gray.ToString()))
            {
                IdCard.HairColor = HairColor.Gray;
            }
            else if (input.EqualsIgnoreCase(HairColor.RedAuburn.ToString()))
            {
                IdCard.HairColor = HairColor.RedAuburn;
            }
            else if (input.EqualsIgnoreCase(HairColor.Sandy.ToString()))
            {
                IdCard.HairColor = HairColor.Sandy;
            }
            else if (input.EqualsIgnoreCase(HairColor.White.ToString()))
            {
                IdCard.HairColor = HairColor.White;
            }
        }
    }
}
