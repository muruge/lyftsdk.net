using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class DriversResponse
    {
        [JsonProperty("nearby_drivers")]
        public IList<NearbyDriver> NearbyDrivers { get; set; }

    }
}