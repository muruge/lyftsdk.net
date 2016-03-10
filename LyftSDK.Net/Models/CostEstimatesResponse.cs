using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class CostEstimatesResponse : LyftResponse
    {
        [JsonProperty("cost_estimates")]
        public IList<CostEstimate> CostEstimates { get; set; }
    }
}