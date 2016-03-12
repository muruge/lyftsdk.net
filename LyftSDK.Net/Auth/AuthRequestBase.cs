using LyftSDK.Net.Helpers;
using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    internal abstract class AuthRequestBase
    {
        [JsonProperty("grant_type")] public string GrantType;

        protected AuthRequestBase(AuthTokenGrantType grantType)
        {
            GrantType = grantType.GetDescription();
        }
    }
}