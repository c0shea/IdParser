using IdParser.Attributes;

// ReSharper disable once CheckNamespace
namespace IdParser
{
    public enum WeightRange
    {
        [Description("Up to 70 lbs (31 kg)")]
        LbsUpTo70 = 0,

        [Description("71-100 lbs (32-45 kg)")]
        Lbs71To100 = 1,

        [Description("101-130 lbs (46-59 kg)")]
        Lbs101To130 = 2,

        [Description("131-160 lbs (60-70 kg)")]
        Lbs131To160 = 3,

        [Description("161-190 lbs (71-86 kg)")]
        Lbs161To190 = 4,

        [Description("191-220 lbs (87-100 kg)")]
        Lbs191To220 = 5,

        [Description("221-250 lbs (101-113 kg)")]
        Lbs221To250 = 6,

        [Description("251-280 lbs (114-127 kg)")]
        Lbs251To280 = 7,

        [Description("281-320 lbs (128-145 kg)")]
        Lbs281To320 = 8,

        [Description("More than 320 lbs (145 kg)")]
        LbsGreaterThan320 = 9
    }
}