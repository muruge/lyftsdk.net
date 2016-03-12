using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    internal class AuthCodeRequest : AuthRequestBase
    {
        public AuthCodeRequest(string authCode)
            : base(AuthTokenGrantType.AuthorizationCode)
        {
            Code = authCode;
        }


        [JsonProperty("code")]
        public string Code { get; set; }
    }
}