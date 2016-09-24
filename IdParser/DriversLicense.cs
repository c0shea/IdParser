using System;
using System.Collections.Generic;
using System.Globalization;

namespace IdParser {
    public class DriversLicense : IdentificationCard {
        internal DriversLicense(string input, List<string> subfileRecords) : base(input, subfileRecords) {
            Jurisdiction = new DriversLicenseJurisdiction();

            foreach (var record in subfileRecords) {
                ParseRecord(record);
            }
        }

        private void ParseRecord(string subfileRecord) {
            if (subfileRecord.Length < 3)
                return;

            var elementId = subfileRecord.Substring(0, 3);
            var data = subfileRecord.Substring(3).Trim();

            switch (elementId) {
                // Required attributes
                case "DCA":
                    Jurisdiction.VehicleClass = data;
                    break;
                case "DCB":
                    Jurisdiction.RestrictionCodes = data;
                    break;
                case "DCD":
                    Jurisdiction.EndorsementCodes = data;
                    break;

                // Optional attributes
                case "DCM":
                    StandardVehicleClassification = data;
                    break;
                case "DCN":
                    StandardEndorsementCode = data;
                    break;
                case "DCO":
                    StandardRestrictionCode = data;
                    break;
                case "DCP":
                    Jurisdiction.VehicleClassificationDescription = data;
                    break;
                case "DCQ":
                    Jurisdiction.EndorsementCodeDescription = data;
                    break;
                case "DCR":
                    Jurisdiction.RestrictionCodeDescription = data;
                    break;
                case "DDC":
                    if (data != string.Empty && data != "00000000") {
                        HazmatEndorsementExpirationDate = DateTime.ParseExact(data, "MMddyyyy", CultureInfo.CurrentCulture);
                    }

                    break;
            }
        }

        public DriversLicenseJurisdiction Jurisdiction { get; set; }

        // Optional elements
        public string StandardVehicleClassification { get; set; }
        public string StandardEndorsementCode { get; set; }
        public string StandardRestrictionCode { get; set; }
        public DateTime? HazmatEndorsementExpirationDate { get; set; }
    }
}
