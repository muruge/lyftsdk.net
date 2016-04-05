using Newtonsoft.Json;

namespace LyftSDK.Net.Auth
{
    public class ClientTokenProvider : TokenProviderBase
    {
        public ClientTokenProvider(string clientId, string clientSecret, bool useProd = false)
            : base(clientId, clientSecret, useProd)
        {
        }

        protected override string RequestContent()
        {
            var clientTokenReq = new
            {
                grant_type = "client_credentials",
                scope = "public"
            };

            string content = JsonConvert.SerializeObject(clientTokenReq);
            return content;
        }
    }
}