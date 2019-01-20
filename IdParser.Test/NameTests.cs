using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Test
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void NoMiddleNameTest()
        {
            var name = new Name
            {
                First = "John",
                Last = "Doe"
            };

            Assert.AreEqual("John Doe", name.ToString());
        }

        [TestMethod]
        public void FullNameTest()
        {
            var name = new Name
            {
                First = "John",
                Middle = "Martin",
                Last = "Doe"
            };

            Assert.AreEqual("John Martin Doe", name.ToString());
        }

        [TestMethod]
        public void SuffixTest()
        {
            var name = new Name
            {
                First = "John",
                Last = "Doe",
                Suffix = "Jr"
            };

            Assert.AreEqual("John Doe, Jr", name.ToString());
        }
    }
}
