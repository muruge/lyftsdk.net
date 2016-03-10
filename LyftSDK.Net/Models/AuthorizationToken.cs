using System;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models
{
    public class AuthorizationToken : LyftResponse
    {
        private int _expiresIn;

        public AuthorizationToken()
        {
        }

        public AuthorizationToken(string accessToken, string tokenType, DateTime tokenExpiration, string refreshToken)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            Expiration = tokenExpiration;
            RefreshToken = refreshToken;
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn
        {
            get { return _expiresIn; }
            set
            {
                _expiresIn = value;
                Expiration = DateTime.Now.AddSeconds(_expiresIn);
            }
        }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        public DateTime Expiration { get; private set; }

        public bool IsExpired => Expiration < DateTime.Now;

        public bool IsRefreshable()
        {
            return !string.IsNullOrWhiteSpace(RefreshToken);
        }
    }
}