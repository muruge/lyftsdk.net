using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class Location
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

		[JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
		public string Address { get; set; }

		[JsonProperty("Bearing", NullValueHandling = NullValueHandling.Ignore)]
		public object Bearing { get; set; }
	
		[JsonProperty("eta_seconds", NullValueHandling = NullValueHandling.Ignore)]
		public int? EtaSeconds { get; set; }
    }
}