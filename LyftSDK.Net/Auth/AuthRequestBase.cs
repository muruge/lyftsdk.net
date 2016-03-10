using LyftSDK.Net.Helpers;
using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    internal abstract class AuthRequestBase
    {
        protected AuthRequestBase(AuthTokenGrantType grantType)
        {
            GrantType = grantType.GetDescription();
        }

        [JsonProperty("grant_type")]
        public string GrantType;
    }
}