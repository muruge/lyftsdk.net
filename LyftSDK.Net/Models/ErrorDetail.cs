using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class ErrorDetail
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }
    }
}