using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class Driver
    {
        [JsonProperty("locations")]
        public IList<Location> Locations { get; set; }
    }
}