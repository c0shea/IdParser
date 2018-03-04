namespace IdParser
{
    /// <summary>
    /// Represents the name of the person identified in the ID card.
    /// This can include aliases this person is known by.
    /// </summary>
    public class Name
    {
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public string Suffix { get; set; }

        public bool? WasFirstTruncated { get; set; }
        public bool? WasMiddleTruncated { get; set; }
        public bool? WasLastTruncated { get; set; }

        public string AliasFirst { get; set; }
        public string AliasLast { get; set; }
        public string AliasSuffix { get; set; }

        public override string ToString() => Middle == null
            ? $"{First} {Last}"
            : $"{First} {Middle} {Last}";
    }
}
