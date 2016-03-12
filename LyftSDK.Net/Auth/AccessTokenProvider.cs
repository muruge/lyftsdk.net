using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    public class AccessTokenProvider : TokenProviderBase
    {
        public AccessTokenProvider(string clientId, string clientSecret, bool useProd = false)
            : base(clientId, clientSecret, useProd)
        {
        }

        protected override string RequestContent()
        {
            var content = JsonConvert.SerializeObject(new ClientCredentialRequest());
            return content;
        }
    }
}