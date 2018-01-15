using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
	public class RideListResponse : LyftResponse
	{
		[JsonProperty("ride_history")]
		public IList<RideHistory> RideHistory { get; set; }
	}
}