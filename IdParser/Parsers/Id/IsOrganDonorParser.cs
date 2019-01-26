using System;
using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DDK")]
    public class IsOrganDonorParser : AbstractParser
    {
        public IsOrganDonorParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.IsOrganDonor = ParseBool(input) ?? false;
        }
    }

    [Parser("DBH")]
    public class IsOrganDonorLegacyParser : AbstractParser
    {
        public IsOrganDonorLegacyParser(IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            if (Version == Version.Aamva2000)
            {
                IdCard.IsOrganDonor = ParseBool(input) ?? false;

                if (input.Equals("DONOR", StringComparison.OrdinalIgnoreCase))
                {
                    IdCard.IsOrganDonor = true;
                }
            }
        }
    }
}
