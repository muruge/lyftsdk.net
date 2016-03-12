using System.Net.Http;
using System.Threading.Tasks;
using LyftSDK.Net.Models;
using Newtonsoft.Json;

namespace LyftSDK.Net.Helpers
{
    internal static class HttpExtensions
    {
        internal static async Task<T> ReadAs<T>(this HttpResponseMessage httpResponse) where T : LyftResponse, new()
        {
            var value = new T();
            var content = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                value = JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                value.Error = JsonConvert.DeserializeObject<Error>(content);
            }

            return value;
        }
    }
}