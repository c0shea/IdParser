namespace IdParser.Test
{
    public class NameTests
    {
        [Fact]
        public void NoMiddleNameTest()
        {
            var name = new Name
            {
                First = "John",
                Last = "Doe"
            };

            Assert.Equal("John Doe", name.ToString());
        }

        [Fact]
        public void FullNameTest()
        {
            var name = new Name
            {
                First = "John",
                Middle = "Martin",
                Last = "Doe"
            };

            Assert.Equal("John Martin Doe", name.ToString());
        }

        [Fact]
        public void SuffixTest()
        {
            var name = new Name
            {
                First = "John",
                Last = "Doe",
                Suffix = "Jr"
            };

            Assert.Equal("John Doe, Jr", name.ToString());
        }
    }
}
