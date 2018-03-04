using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Test
{
    [TestClass]
    public class WeightTests
    {
        [TestMethod]
        public void EqualityFromRangeTest()
        {
            var left = Weight.FromRange(WeightRange.Lbs131To160);
            var right = Weight.FromRange(WeightRange.Lbs131To160);

            Assert.AreEqual(left, right);
            Assert.AreNotSame(left, right);
        }

        [TestMethod]
        public void EqualityFromPoundsTest()
        {
            var left = Weight.FromImperial(120);
            var right = Weight.FromImperial(120);

            Assert.AreEqual(left, right);
            Assert.AreNotSame(left, right);
        }

        [TestMethod]
        public void ComparableTest()
        {
            var first = Weight.FromImperial(150);
            var second = Weight.FromImperial(125);

            Assert.IsTrue(first.CompareTo(second) > 0);
            Assert.IsTrue(second.CompareTo(first) < 0);
        }

        [TestMethod]
        public void ImperialDisplayTest()
        {
            var weight = Weight.FromImperial(115);
            var actual = weight.ToString();

            Assert.AreEqual("115 lbs", actual);
        }

        [TestMethod]
        public void RangeDisplayTest()
        {
            var weight = Weight.FromRange(WeightRange.Lbs161To190);
            var actual = weight.ToString();

            Assert.AreEqual("161-190 lbs (71-86 kg)", actual);
        }

        [TestMethod]
        public void MetricDisplayTest()
        {
            var weight = Weight.FromMetric(33);
            var actual = weight.ToString();

            Assert.AreEqual("33 kg", actual);
        }
    }
}
