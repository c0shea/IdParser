﻿using System;
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

        [TestMethod]
        public void PoundsToKilogramsTest()
        {
            var weight = Weight.FromImperial(175);
            var expectedKg = 79.4;

            Assert.IsTrue(weight.Kilograms.Value.Equals1DigitPrecision(expectedKg));
        }

        [TestMethod]
        public void PoundsTest()
        {
            // This is internally converted to kg. Ensure it is round-tripped back to the expected value.
            var weight = Weight.FromImperial(175);
            var expected = "175 lbs";

            Assert.AreEqual(expected, weight.ToString()); ;
        }
    }

    internal static class DoubleExtensions
    {
        private const double _1Digit = 0.1;

        internal static bool Equals1DigitPrecision(this double value, double comparison)
        {
            var difference = Math.Abs(value - comparison);
            return difference < _1Digit;
        }
    }
}
