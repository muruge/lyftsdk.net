using System;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class LocationAndTime
	{
		[JsonProperty("lat")]
		public float Lat { get; set; }

		[JsonProperty("lng")]
		public float Lng { get; set; }

		[JsonProperty("time")]
		public DateTime Time { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }
	}
}