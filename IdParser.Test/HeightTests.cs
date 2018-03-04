using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdParser.Test
{
    [TestClass]
    public class HeightTests
    {
        [TestMethod]
        public void EqualityTest()
        {
            var left = Height.FromImperial(65);
            var right = Height.FromImperial(65);

            Assert.AreEqual(left, right);
        }

        [TestMethod]
        public void ComparableTest()
        {
            var first = Height.FromImperial(6, 2);
            var second = Height.FromImperial(5, 8);

            Assert.IsTrue(first.CompareTo(second) > 0);
            Assert.IsTrue(second.CompareTo(first) < 0);
        }

        [TestMethod]
        public void ImperialDisplayTest()
        {
            var height = Height.FromImperial(67);
            var actual = height.ToString();

            Assert.AreEqual("5'7\"", actual);
        }

        [TestMethod]
        public void MetricDisplayTest()
        {
            var height = Height.FromMetric(175);
            var actual = height.ToString();

            Assert.AreEqual("175 cm", actual);
        }
    }
}
