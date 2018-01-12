using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class RideHistory
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("passenger")]
		public Passenger Passenger { get; set; }

		[JsonProperty("ride_type")]
		public string RideType { get; set; }

		[JsonProperty("ride_id")]
		public string RideID { get; set; }

		[JsonProperty("requested_at")]
		public DateTime RequestedAt { get; set; }

		[JsonProperty("destination")]
		public Location EndLocation { get; set; }

		[JsonProperty("primetime_percentage")]
		public string PrimetimePercentage { get; set; }

		[JsonProperty("route_url")]
		public string RouteUrl { get; set; }

		[JsonProperty("location")]
		public Location Location { get; set; }

		[JsonProperty("generated_at")]
		public DateTime GeneratedAt { get; set; }

		[JsonProperty("ride_profile")]
		public string RideProfile { get; set; }

		[JsonProperty("origin")]
		public Location StartLocation { get; set; }

		[JsonProperty("driver")]
		public Driver Driver { get; set; }

		[JsonProperty("can_cancel")]
		public IList<string> CanCancel { get; set; }

		[JsonProperty("vehicle")]
		public Vehicle Vehicle { get; set; }

		[JsonProperty("pickup")]
		public LocationAndTime Pickup { get; set; }

		[JsonProperty("line_items")]
		public IList<LineItem> LineItems { get; set; }

		[JsonProperty("dropoff")]
		public LocationAndTime Dropoff { get; set; }

		[JsonProperty("price")]
		public Price Price { get; set; }

		[JsonProperty("canceled_by")]
		public string CanceledBy { get; set; }
	}
}