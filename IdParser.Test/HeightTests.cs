namespace IdParser.Test
{
    public class HeightTests
    {
        [Fact]
        public void EqualityTest()
        {
            var left = Height.FromImperial(65);
            var right = Height.FromImperial(65);

            Assert.Equal(left, right);
        }

        [Fact]
        public void ComparableTest()
        {
            var first = Height.FromImperial(6, 2);
            var second = Height.FromImperial(5, 8);

            Assert.True(first.CompareTo(second) > 0);
            Assert.True(second.CompareTo(first) < 0);
        }

        [Fact]
        public void ImperialDisplayTest()
        {
            var height = Height.FromImperial(67);
            var actual = height.ToString();

            Assert.Equal("5'7\"", actual);
        }

        [Fact]
        public void MetricDisplayTest()
        {
            var height = Height.FromMetric(175);
            var actual = height.ToString();

            Assert.Equal("175 cm", actual);
        }

        [Fact]
        public void RoundingTest()
        {
            var height = Height.FromImperial(62);
            var actual = height.ToString();

            Assert.Equal("5'2\"", actual);
        }
    }
}
