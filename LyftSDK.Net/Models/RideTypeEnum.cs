using System.ComponentModel;

namespace LyftSDK.Net.Models
{
    public enum RideTypeEnum
    {
        [Description("lyft")] Lyft,
        [Description("lyft_line")] LyftLine,
        [Description("lyft_plus")] LyftPlus,
        [Description("lyft_suv")] LyftSuv
    }
}