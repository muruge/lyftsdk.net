using LyftSDK.Net.Models.Helpers;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class CostEstimate
    {
        [JsonProperty("ride_type")]
        [JsonConverter(typeof (RideTypeEnumConverter))]
        public RideTypeEnum RideType { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("primetime_percentage")]
        public string PrimetimePercentage { get; set; }

        [JsonProperty("estimated_cost_cents_max")]
        public int EstimatedCostCentsMax { get; set; }

        [JsonProperty("estimated_cost_cents_min")]
        public int EstimatedCostCentsMin { get; set; }

        [JsonProperty("estimated_distance_miles")]
        public double EstimatedDistanceMiles { get; set; }

        [JsonProperty("estimated_duration_seconds")]
        public int EstimatedDurationSeconds { get; set; }

        [JsonProperty("primetime_confirmation_token")]
        public string PrimetimeConfirmationToken { get; set; }
    }
}