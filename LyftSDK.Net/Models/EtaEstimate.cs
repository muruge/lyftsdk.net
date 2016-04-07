using LyftSDK.Net.Models.Helpers;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class EtaEstimate
    {
        [JsonProperty("ride_type")]
        [JsonConverter(typeof (RideTypeEnumConverter))]
        public RideTypeEnum RideType { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("eta_seconds")]
        public int? EtaSeconds { get; set; }
    }
}