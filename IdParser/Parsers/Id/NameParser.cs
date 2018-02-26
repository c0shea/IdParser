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
            var names = input.Split(',', '$');
            IdCard.LastName = names.Length > 0 ? names[0].Trim().ReplaceEmptyWithNull() : null;
            IdCard.FirstName = names.Length > 1 ? names[1].Trim().ReplaceEmptyWithNull() : null;
            IdCard.MiddleName = names.Length > 2 ? names[2].Trim().ReplaceEmptyWithNull() : null;
        }
    }
}
