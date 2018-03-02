using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DAA")]
    public class NameParser : AbstractParser
    {
        // AAMVA 2000
        public NameParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            var standardSplitCharacters = new[] { ',', '$', '@' };

            // Jurisdictions that follow the AAMVA 2000 standard
            if (input.IndexOfAny(standardSplitCharacters) >= 0)
            {
                var names = input.Split(standardSplitCharacters);
                IdCard.LastName = names.Length > 0 ? names[0].Trim().ReplaceEmptyWithNull() : null;
                IdCard.FirstName = names.Length > 1 ? names[1].Trim().ReplaceEmptyWithNull() : null;
                IdCard.MiddleName = names.Length > 2 ? names[2].Trim().ReplaceEmptyWithNull() : null;
            }
            // Jurisdictions like Pennsylvania that don't follow the standard
            else if (input.IndexOf(' ') >= 0)
            {
                var names = input.Split(' ');
                IdCard.FirstName = names.Length > 0 ? names[0].Trim().ReplaceEmptyWithNull() : null;

                if (names.Length == 2)
                {
                    IdCard.LastName = names[1].Trim().ReplaceEmptyWithNull();
                }
                else if (names.Length > 2)
                {
                    IdCard.MiddleName = names[1].Trim().ReplaceEmptyWithNull();
                    IdCard.LastName = names[2].Trim().ReplaceEmptyWithNull();
                }
            }
        }
    }
}
