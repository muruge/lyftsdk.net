using System;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class WebHook
	{
		[JsonProperty("event_id")]
		public string EventID { get; set; }

		[JsonProperty("href")]
		public string Href { get; set; }

		[JsonProperty("occurred_at")]
		public DateTime OccurredAt { get; set; }

		[JsonProperty("event_type")]
		public string EventType { get; set; }

		[JsonProperty("event")]
		public Event Event { get; set; }
	}
}