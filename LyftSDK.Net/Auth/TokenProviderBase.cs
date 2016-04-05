using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LyftSDK.Net.Helpers;
using LyftSDK.Net.Models;

namespace LyftSDK.Net.Auth
{
    public abstract class TokenProviderBase : ITokenProvider
    {
        private readonly string _clientSecret;
        private readonly bool _useSandboxEnvironment;
        protected readonly string ClientId;

        private AuthorizationToken _authToken;

        protected TokenProviderBase(string clientId, string clientSecret, bool useProd = false)
        {
            if (string.IsNullOrWhiteSpace(clientId))
                throw new ArgumentNullException(nameof(clientId));

            if (string.IsNullOrWhiteSpace(clientSecret))
                throw new ArgumentNullException(nameof(clientSecret));

            ClientId = clientId;
            _clientSecret = clientSecret;
            _useSandboxEnvironment = !useProd;
        }

        protected string GetAuthHeader()
        {
            var clientSecret = _useSandboxEnvironment ? $"SANDBOX-{_clientSecret}" : _clientSecret;
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ClientId}:{clientSecret}"));
            return credentials;
        }

        public async Task<AuthorizationToken> GetToken()
        {
            if (_authToken != null && !_authToken.IsExpired)
                return _authToken;

            var credentials = GetAuthHeader();
            var content = RequestContent();

            HttpContent request = new StringContent(content, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.ApiUrlBase);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsync("oauth/token", request);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception(
                        "Cannot obtain authorization token for the given ClientID and ClientSecret. ERROR: " + error);
                }


                _authToken = await response.ReadAs<AuthorizationToken>();
                return _authToken;
            }
        }

        protected abstract string RequestContent();
    }
}