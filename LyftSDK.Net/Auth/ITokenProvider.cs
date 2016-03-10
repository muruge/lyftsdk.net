using System.Threading.Tasks;
using LyftSDK.Net.Models;

namespace LyftSDK.Net.Auth
{
    public interface ITokenProvider
    {
        Task<AuthorizationToken> GetToken();
    }
}