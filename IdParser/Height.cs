using System;

namespace IdParser {
    public class Height {
        private const double CentimetersPerInch = 2.54;
        private const byte InchesPerFoot = 12;
        private readonly bool _isMetricInstantiated;

        public byte Feet => (byte)(TotalInches / InchesPerFoot);
        public byte Inches => (byte)(TotalInches - Feet * InchesPerFoot);
        public byte TotalInches { get; }
        public short Centimeters { get; }

        public Height(Version version, string input) {
            if (input.ToLower().Contains("cm")) {
                _isMetricInstantiated = true;
            }

            if (version == Version.Aamva2000) {
                var feet = Convert.ToByte(input.Substring(0, 1));
                var inches = Convert.ToByte(input.Substring(1, 2));
                TotalInches = (byte)(InchesPerFoot * feet + inches);
            }
            else {
                if (input.Length > 3) {
                    var height = Convert.ToInt16(input.Substring(0, input.Length - 2));

                    if (_isMetricInstantiated) {
                        Centimeters = height;
                        TotalInches = (byte)Math.Round(Centimeters / CentimetersPerInch, 0);
                    }
                    else {
                        TotalInches = (byte)height;
                        Centimeters = (short)Math.Round(TotalInches * CentimetersPerInch, 0);
                    }
                }
            }
        }

        public override string ToString() {
            if (_isMetricInstantiated) {
                return $"{Centimeters} cm";
            }

            return $"{Feet}'{Inches}\"";
        }
    }
}