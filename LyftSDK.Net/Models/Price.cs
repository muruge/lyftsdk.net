using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class Price
	{
		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
	}
}