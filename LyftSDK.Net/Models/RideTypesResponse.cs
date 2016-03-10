using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class RideTypesResponse : LyftResponse
    {
        [JsonProperty("ride_types")]
        public IList<RideType> RideTypes { get; set; }
    }
}