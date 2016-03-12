using LyftSDK.Net.Models.Helpers;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class RideType
    {
        [JsonProperty("pricing_details")]
        public PricingDetails PricingDetails { get; set; }

        [JsonProperty("ride_type")]
        [JsonConverter(typeof (RideTypeEnumConverter))]
        public RideTypeEnum Type { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("seats")]
        public int Seats { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}