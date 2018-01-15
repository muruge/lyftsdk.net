using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class LineItem
	{
		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("amount")]
		public int Amount { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}