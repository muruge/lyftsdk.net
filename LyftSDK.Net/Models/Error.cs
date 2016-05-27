using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class Error
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }

        [JsonProperty("error_detail")]
        public dynamic ErrorDetail { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        public override string ToString()
        {
            var error = new StringBuilder();

            if(!string.IsNullOrWhiteSpace(ErrorMessage))
                error.AppendFormat("Error: {0}", ErrorMessage).AppendLine();

            if (!string.IsNullOrWhiteSpace(ErrorDescription))
                error.AppendFormat("ErrorDescription: {0}", ErrorDescription).AppendLine();

            if(ErrorDetail != null)
                error.AppendFormat("ErrorDetail: {0}", ErrorDetail.ToString()).AppendLine();

            return error.ToString();
        }
    }
}