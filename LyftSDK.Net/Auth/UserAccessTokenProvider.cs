using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    public class UserAccessTokenProvider : TokenProviderBase
    {
        private readonly string _token;
        private readonly AuthTokenGrantType _tokenType;

        public UserAccessTokenProvider(string clientId, string clientSecret, AuthTokenGrantType tokenType, string token,
            bool useProd = false)
            : base(clientId, clientSecret, useProd)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token));

            _tokenType = tokenType;
            _token = token;
        }

        protected override string RequestContent()
        {
            var content = _tokenType == AuthTokenGrantType.AuthorizationCode
                ? JsonConvert.SerializeObject(new AuthCodeRequest(_token))
                : JsonConvert.SerializeObject(new RefreshTokenRequest(_token));

            return content;
        }

        public string CreateOAuthUrl(IEnumerable<string> scopes, string state = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["client_id"] = ClientId;
            query["response_type"] = "code";
            query["scope"] = string.Join(" ", scopes);

            if (!string.IsNullOrWhiteSpace(state))
                query["state"] = state;

            string oauthUrl = $"{Constants.ApiUrlBase}oauth/authorize?{query}";
            return oauthUrl;
        }
    }
}