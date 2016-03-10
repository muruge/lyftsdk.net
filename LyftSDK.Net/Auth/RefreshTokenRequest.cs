using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    internal class RefreshTokenRequest : AuthRequestBase 
    {
        public RefreshTokenRequest(string refreshToken)
           : base(AuthTokenGrantType.RefreshToken)
        {
            Token = refreshToken;
        }


        [JsonProperty("refresh_token")]
        public string Token { get; set; }
    }
}