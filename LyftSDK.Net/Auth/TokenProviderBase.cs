using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LyftSDK.Net.Helpers;
using LyftSDK.Net.Models;
using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    public abstract class TokenProviderBase : ITokenProvider
    {
        protected readonly string ClientId;
        private readonly string _clientSecret;
        private readonly bool _useSandboxEnvironment;

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
        protected abstract string RequestContent();

        public async Task<AuthorizationToken> GetToken()
        {
            string clientSecret = _useSandboxEnvironment ? $"SANDBOX-{_clientSecret}" : _clientSecret;
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ClientId}:{clientSecret}"));

            string content = JsonConvert.SerializeObject(RequestContent());

            HttpContent request = new StringContent(content, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.ApiUrlBase);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                HttpResponseMessage response = await client.PostAsync("oauth/token", request);

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Cannot obtain authorization token for the given ClientID and ClientSecret.");

                AuthorizationToken authToken = await response.ReadAs<AuthorizationToken>();
                return authToken;
            }
        }
    }
}