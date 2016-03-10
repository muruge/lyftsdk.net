using System.Collections.Generic;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class Error
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }

        [JsonProperty("error_detail")]
        public IList<ErrorDetail> ErrorDetail { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}