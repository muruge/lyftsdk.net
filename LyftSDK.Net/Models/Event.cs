using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class Event
	{
		[JsonProperty("origin")]
		public Location Origin { get; set; }

		[JsonProperty("passenger")]
		public Passenger Passenger { get; set; }

		[JsonProperty("requested_at")]
		public DateTime RequestedAt { get; set; }

		[JsonProperty("route_url")]
		public string RouteUrl { get; set; }

		[JsonProperty("ride_id")]
		public string RideID { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("generated_at")]
		public DateTime GeneratedAt { get; set; }

		[JsonProperty("ride_type")]
		public string RideType { get; set; }

		[JsonProperty("destination", NullValueHandling = NullValueHandling.Ignore)]
		public Location Destination { get; set; }

		[JsonProperty("driver", NullValueHandling = NullValueHandling.Ignore)]
		public Driver Driver { get; set; }

		[JsonProperty("primetime_percentage", NullValueHandling = NullValueHandling.Ignore)]
		public string PrimetimePercentage { get; set; }

		[JsonProperty("can_cancel", NullValueHandling = NullValueHandling.Ignore)]
		public IList<string> CanCancel { get; set; }

		[JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
		public Location Location { get; set; }

		[JsonProperty("vehicle", NullValueHandling = NullValueHandling.Ignore)]
		public Vehicle Vehicle { get; set; }

		[JsonProperty("pickup", NullValueHandling = NullValueHandling.Ignore)]
		public LocationAndTime Pickup { get; set; }

		[JsonProperty("dropoff", NullValueHandling = NullValueHandling.Ignore)]
		public LocationAndTime Dropoff { get; set; }

		[JsonProperty("charges", NullValueHandling = NullValueHandling.Ignore)]
		public IList<Charge> Charges { get; set; }

		[JsonProperty("line_items", NullValueHandling = NullValueHandling.Ignore)]
		public IList<LineItem> LineItems { get; set; }

		[JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
		public Price Price { get; set; }

		[JsonProperty("canceled_by", NullValueHandling = NullValueHandling.Ignore)]
		public string CanceledBy { get; set; }
	}
}