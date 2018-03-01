using System;

namespace IdParser
{
    /// <summary>
    /// Represents the height of the person identified in the ID card.
    /// Heights are approximated when converting between Metric and Imperial units.
    /// </summary>
    public struct Height : IComparable<Height>, IEquatable<Height>
    {
        private const double CentimetersPerInch = 2.54;
        private const byte InchesPerFoot = 12;

        private readonly double _centimeters;
        private readonly bool _isMetric;

        private Height(double centimeters, bool isMetric)
        {
            _centimeters = centimeters;
            _isMetric = isMetric;
        }

        public static Height FromMetric(double centimeters)
        {
            return new Height(centimeters, true);
        }

        public static Height FromImperial(int feet, int inches)
        {
            return FromImperial(feet * InchesPerFoot + inches);
        }

        public static Height FromImperial(int inches)
        {
            return new Height(inches * CentimetersPerInch, false);
        }

        public override string ToString()
        {
            if (_isMetric)
            {
                return $"{_centimeters} cm";
            }

            var totalInches = _centimeters / CentimetersPerInch;
            var feet = (int) (totalInches / InchesPerFoot);

            return $"{feet}'{totalInches - feet * InchesPerFoot}\"";
        }

        #region IComparable

        public int CompareTo(Height other)
        {
            return _centimeters.CompareTo(other._centimeters);
        }

        #endregion

        #region IEquatable

        public bool Equals(Height other)
        {
            return _centimeters.Equals(other._centimeters) && _isMetric == other._isMetric;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Height height && Equals(height);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_centimeters.GetHashCode() * 397) ^ _isMetric.GetHashCode();
            }
        }

        public static bool operator ==(Height left, Height right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Height left, Height right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
