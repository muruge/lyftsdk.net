using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class PricingDetails
    {
        [JsonProperty("base_charge")]
        public int BaseCharge { get; set; }

        [JsonProperty("cost_per_mile")]
        public int CostPerMile { get; set; }

        [JsonProperty("cost_per_minute")]
        public int CostPerMinute { get; set; }

        [JsonProperty("cost_minimum")]
        public int CostMinimum { get; set; }

        [JsonProperty("trust_and_service")]
        public int TrustAndService { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("cancel_penalty_amount")]
        public int CancelPenaltyAmount { get; set; }
    }
}