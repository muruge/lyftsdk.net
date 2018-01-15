using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class Passenger
	{
		[JsonProperty("rating")]
		public string Rating { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }

		[JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
		public object UserID { get; set; }
	}
}