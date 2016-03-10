using System.ComponentModel;

namespace LyftSDK.Net.Auth
{
    public enum AuthTokenGrantType
    {
        [Description("client_credentials")] ClientCredentials,
        [Description("authorization_code")] AuthorizationCode,
        [Description("refresh_token")] RefreshToken
    }
}