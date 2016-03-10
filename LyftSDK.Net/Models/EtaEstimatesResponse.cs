using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class EtaEstimatesResponse : LyftResponse
    {
        [JsonProperty("eta_estimates")]
        public IList<EtaEstimate> EtaEstimates { get; set; }
    }
}