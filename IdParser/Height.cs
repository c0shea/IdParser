using System;

namespace IdParser
{
    /// <summary>
    /// Represents the height of the person identified in the ID card.
    /// Heights are approximated when converting between Metric and Imperial units.
    /// </summary>
    public class Height : IComparable<Height>, IEquatable<Height>
    {
        private const double CentimetersPerInch = 2.54;
        private const byte InchesPerFoot = 12;

        // In order for JSON serialization and deserialization to work in both Json.NET
        // and ServiceStack.Text, an immutable type has to:
        // - Be a class and not a struct (immutable structs do not deserialize in ServiceStack)
        // - Have public properties with a private setter for ServiceStack
        // - Have a public constructor that initializes the public properties for Json.NET
        public double Centimeters { get; private set; }
        public bool IsMetric { get; private set; }

        public Height(double centimeters, bool isMetric)
        {
            Centimeters = centimeters;
            IsMetric = isMetric;
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
            if (IsMetric)
            {
                return $"{Centimeters} cm";
            }

            var totalInches = Centimeters / CentimetersPerInch;
            var feet = (int) (totalInches / InchesPerFoot);

            return $"{feet}'{Math.Round(totalInches - feet * InchesPerFoot, 0)}\"";
        }

        #region IComparable

        public int CompareTo(Height other)
        {
            return Centimeters.CompareTo(other.Centimeters);
        }

        #endregion

        #region IEquatable

        public bool Equals(Height other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Centimeters.Equals(other.Centimeters) && IsMetric == other.IsMetric;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Height) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable NonReadonlyMemberInGetHashCode
                return (Centimeters.GetHashCode() * 397) ^ IsMetric.GetHashCode();
                // ReSharper restore NonReadonlyMemberInGetHashCode
            }
        }

        public static bool operator ==(Height left, Height right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Height left, Height right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
