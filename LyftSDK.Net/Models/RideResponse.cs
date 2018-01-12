using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class RideResponse : LyftResponse
	{
		[JsonProperty("ride_id")]
		public string RideID { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("origin")]
		public Location StartLocation { get; set; }

		[JsonProperty("destination")]
		public Location EndLocation { get; set; }

		[JsonProperty("passenger")]
		public Passenger Passenger { get; set; }

		[JsonProperty("ride_type", NullValueHandling = NullValueHandling.Ignore)]
		public string RideType { get; set; }

		[JsonProperty("requested_at", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime RequestedAt { get; set; }

		[JsonProperty("primetime_percentage", NullValueHandling = NullValueHandling.Ignore)]
		public string PrimetimePercentage { get; set; }

		[JsonProperty("route_url", NullValueHandling = NullValueHandling.Ignore)]
		public string RouteUrl { get; set; }

		[JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
		public Location Location { get; set; }

		[JsonProperty("generated_at", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime GeneratedAt { get; set; }

		[JsonProperty("ride_profile", NullValueHandling = NullValueHandling.Ignore)]
		public string RideProfile { get; set; }

		[JsonProperty("driver", NullValueHandling = NullValueHandling.Ignore)]
		public Driver Driver { get; set; }

		[JsonProperty("can_cancel", NullValueHandling = NullValueHandling.Ignore)]
		public IList<string> CanCancel { get; set; }

		[JsonProperty("vehicle", NullValueHandling = NullValueHandling.Ignore)]
		public Vehicle Vehicle { get; set; }

		[JsonProperty("pickup", NullValueHandling = NullValueHandling.Ignore)]
		public LocationAndTime Pickup { get; set; }

		[JsonProperty("line_items", NullValueHandling = NullValueHandling.Ignore)]
		public IList<LineItem> LineItems { get; set; }

		[JsonProperty("dropoff", NullValueHandling = NullValueHandling.Ignore)]
		public LocationAndTime Dropoff { get; set; }

		[JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
		public Price Price { get; set; }

		[JsonProperty("canceled_by", NullValueHandling = NullValueHandling.Ignore)]
		public string CanceledBy { get; set; }
	}
}