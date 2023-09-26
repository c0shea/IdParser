using System;

namespace IdParser.Test
{
    public class ValidationTests
    {
        [Fact]
        public void InvalidLengthTest()
        {
            Assert.Throws<ArgumentException>(() => Barcode.Parse("ABC123"));
        }

        [Fact]
        public void InvalidComplianceIndicatorTest()
        {
            Assert.Throws<ArgumentException>(() => Barcode.Parse(new string('A', 32)));
        }
    }
}
