using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    internal class ClientCredentialRequest : AuthRequestBase
    {
        [JsonProperty("scope")] public string Scope = "public";

        public ClientCredentialRequest()
            : base(AuthTokenGrantType.ClientCredentials)
        {
        }
    }
}