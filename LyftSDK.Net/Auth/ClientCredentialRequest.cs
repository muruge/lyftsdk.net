using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    internal class ClientCredentialRequest : AuthRequestBase
    {
        public ClientCredentialRequest()
           : base(AuthTokenGrantType.ClientCredentials)
        {
        }

        [JsonProperty("scope")]
        public string Scope = "public";
    }
}