using System;

namespace IdParser
{
    /// <summary>
    /// Represents the weight of the person identified in the ID card.
    /// The level of detail provided varies by jurisdiction, as some provide
    /// no information on weight, others give a range, and some give an exact measurement.
    /// </summary>
    public class Weight : IComparable<Weight>, IEquatable<Weight>
    {
        private const double PoundsPerKilogram = 2.20462262;

        // In order for JSON serialization and deserialization to work in both Json.NET
        // and ServiceStack.Text, an immutable type has to:
        // - Be a class and not a struct (immutable structs do not deserialize in ServiceStack)
        // - Have public properties with a private setter for ServiceStack
        // - Have a public constructor that initializes the public properties for Json.NET
        public WeightRange? WeightRange { get; internal set; }
        public double? Kilograms { get; private set; }
        public bool IsMetric { get; private set; }

        public Weight(WeightRange? weightRange, double? kilograms, bool isMetric)
        {
            WeightRange = weightRange;
            Kilograms = kilograms;
            IsMetric = isMetric;
        }

        public static Weight FromMetric(double kilograms)
        {
            return new Weight(null, kilograms, true);
        }

        public static Weight FromImperial(int pounds)
        {
            return new Weight(null, pounds * PoundsPerKilogram, false);
        }

        public static Weight FromRange(WeightRange weightRange)
        {
            return new Weight(weightRange, null, false);
        }

        internal void SetImperial(int pounds)
        {
            Kilograms = pounds * PoundsPerKilogram;
            IsMetric = false;
        }

        internal void SetMetric(double kilograms)
        {
            Kilograms = kilograms;
            IsMetric = true;
        }

        public override string ToString()
        {
            if (!Kilograms.HasValue)
            {
                if (WeightRange.HasValue)
                {
                    return WeightRange.Value.GetDescription();
                }

                throw new InvalidOperationException($"{nameof(Kilograms)} cannot be null.");
            }

            if (IsMetric)
            {
                return $"{Kilograms} kg";
            }

            return $"{(int)(Kilograms.Value / PoundsPerKilogram)} lbs";
        }

        #region IComparable

        public int CompareTo(Weight other)
        {
            if (Kilograms.HasValue)
            {
                return Kilograms.Value.CompareTo(other.Kilograms);
            }

            if (WeightRange.HasValue)
            {
                return WeightRange.Value.CompareTo(other.WeightRange);
            }

            return IsMetric.CompareTo(other.IsMetric);
        }

        #endregion

        #region IEquatable

        public bool Equals(Weight other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return WeightRange == other.WeightRange && Kilograms.Equals(other.Kilograms) && IsMetric == other.IsMetric;
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

            return Equals((Weight) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable NonReadonlyMemberInGetHashCode
                var hashCode = WeightRange.GetHashCode();
                hashCode = (hashCode * 397) ^ Kilograms.GetHashCode();
                hashCode = (hashCode * 397) ^ IsMetric.GetHashCode();
                // ReSharper restore NonReadonlyMemberInGetHashCode

                return hashCode;
            }
        }

        public static bool operator ==(Weight left, Weight right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Weight left, Weight right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
