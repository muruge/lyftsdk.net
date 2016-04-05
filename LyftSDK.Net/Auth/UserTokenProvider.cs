using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    public class UserTokenProvider : TokenProviderBase
    {
        private readonly string _token;
        private readonly AuthTokenType _tokenType;

        public UserTokenProvider(string clientId, string clientSecret, AuthTokenType tokenType, string token,
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
            var content = _tokenType == AuthTokenType.AuthorizationCode
                ? GetAuthCodeRequestContent()
                : GetRefreshTokenRequestContent();

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

        public async void RevokeRefreshToken()
        {
            if (_tokenType != AuthTokenType.RefreshToken)
                return;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.ApiUrlBase);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", GetAuthHeader());

                client.DefaultRequestHeaders.Accept.Clear();

                var content = JsonConvert.SerializeObject(new { token = _token });
                HttpContent request = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("oauth/revoke_refresh_token", request);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception("Error revoking refresh token. ERROR: " + error);
                }
            }
        }

        private string GetRefreshTokenRequestContent()
        {
            var refreshTokenReq = new
            {
                grant_type = "refresh_token",
                refresh_token = _token
            };

            string content = JsonConvert.SerializeObject(refreshTokenReq);
            return content;
        }

        private string GetAuthCodeRequestContent()
        {
            var authTokenReq = new
            {
                grant_type = "authorization_code",
                code = _token
            };

            string content = JsonConvert.SerializeObject(authTokenReq);
            return content;
        }
    }
}