using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class Vehicle
	{
		[JsonProperty("color")]
		public string Color { get; set; }

		[JsonProperty("make")]
		public string Make { get; set; }

		[JsonProperty("license_plate")]
		public string LicensePlate { get; set; }

		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }

		[JsonProperty("year")]
		public int Year { get; set; }

		[JsonProperty("license_plate_state")]
		public string LicensePlateState { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }
	}
}