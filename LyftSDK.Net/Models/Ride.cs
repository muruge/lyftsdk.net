using LyftSDK.Net.Models.Helpers;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class Ride
	{
		[JsonProperty("origin")]
		public Location StartLocation { get; set; }

		[JsonProperty("destination")]
		public Location EndLocation { get; set; }

		[JsonProperty("ride_type")]
		[JsonConverter(typeof(RideTypeEnumConverter))]
		public RideTypeEnum Type { get; set; }

		[JsonProperty("primetime_confirmation_token", NullValueHandling = NullValueHandling.Ignore)]
		public string PrimetimeConfirmationToken { get; set; }
	}
}