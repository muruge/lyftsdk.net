using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class NearbyDriver
    {
        [JsonProperty("ride_type")]
        public string RideType { get; set; }

        [JsonProperty("drivers")]
        public IList<Driver> Drivers { get; set; }
    }
}