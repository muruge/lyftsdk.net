using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class Charge
	{
		[JsonProperty("payment_method")]
		public string PaymentMethod { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("amount")]
		public int Amount { get; set; }
	}
}