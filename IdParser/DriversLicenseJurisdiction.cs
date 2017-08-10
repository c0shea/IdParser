namespace IdParser
{
    public class DriversLicenseJurisdiction
    {
        public string VehicleClass { get; set; }
        public string RestrictionCodes { get; set; }
        public string EndorsementCodes { get; set; }

        // Optional elements
        public string VehicleClassificationDescription { get; set; }
        public string EndorsementCodeDescription { get; set; }
        public string RestrictionCodeDescription { get; set; }
    }
}
