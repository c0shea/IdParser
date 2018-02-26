using IdParser.Attributes;

namespace IdParser.Parsers.Id
{
    [Parser("DCJ")]
    public class AuditInformationParser : AbstractParser
    {
        public AuditInformationParser(IdParser.IdentificationCard idCard, Version version, Country country) : base(idCard, version, country)
        {
        }

        public override void ParseAndSet(string input)
        {
            IdCard.AuditInformation = input;
        }
    }
}
