using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class Driver
    {
        [JsonProperty("locations")]
		[Obsolete("Use class DriverLocation")]
        public IList<Location> Locations { get; set; }

		[JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }

		[JsonProperty("rating")]
		public object Rating { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
    }
}