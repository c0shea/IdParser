namespace IdParser.Test
{
    public class WeightTests
    {
        [Fact]
        public void EqualityFromRangeTest()
        {
            var left = Weight.FromRange(WeightRange.Lbs131To160);
            var right = Weight.FromRange(WeightRange.Lbs131To160);

            Assert.Equal(left, right);
            Assert.NotSame(left, right);
        }

        [Fact]
        public void EqualityFromPoundsTest()
        {
            var left = Weight.FromImperial(120);
            var right = Weight.FromImperial(120);

            Assert.Equal(left, right);
            Assert.NotSame(left, right);
        }

        [Fact]
        public void ComparableTest()
        {
            var first = Weight.FromImperial(150);
            var second = Weight.FromImperial(125);

            Assert.True(first.CompareTo(second) > 0);
            Assert.True(second.CompareTo(first) < 0);
        }

        [Fact]
        public void ImperialDisplayTest()
        {
            var weight = Weight.FromImperial(115);
            var actual = weight.ToString();

            Assert.Equal("115 lbs", actual);
        }

        [Fact]
        public void RangeDisplayTest()
        {
            var weight = Weight.FromRange(WeightRange.Lbs161To190);
            var actual = weight.ToString();

            Assert.Equal("161-190 lbs (71-86 kg)", actual);
        }

        [Fact]
        public void MetricDisplayTest()
        {
            var weight = Weight.FromMetric(33);
            var actual = weight.ToString();

            Assert.Equal("33 kg", actual);
        }
    }
}
