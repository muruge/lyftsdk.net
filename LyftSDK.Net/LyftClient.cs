using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using LyftSDK.Net.Auth;
using LyftSDK.Net.Helpers;
using LyftSDK.Net.Models;

namespace LyftSDK.Net
{
    public class LyftClient
    {
        private readonly ITokenProvider _tokenProvider;
        private AuthorizationToken _authToken;

        public LyftClient(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public async Task<RideTypesResponse> GetRideTypesAsync(Location location, RideTypeEnum? rideType = null)
        {
            using (var client = CreateHttpClient())
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                query["lat"] = location.Lat.ToString(CultureInfo.InvariantCulture);
                query["lng"] = location.Lng.ToString(CultureInfo.InvariantCulture);

                if (rideType != null)
                    query["ride_type"] = rideType.GetDescription();

                HttpResponseMessage apiResponse = await client.GetAsync($"ridetypes?{query}");

                RideTypesResponse response = await apiResponse.ReadAs<RideTypesResponse>();
                return response;
            }
        }

        public async Task<EtaEstimatesResponse> GetEtaAsync(Location location, RideTypeEnum? rideType = null)
        {
            using (var client = CreateHttpClient())
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                query["lat"] = location.Lat.ToString(CultureInfo.InvariantCulture);
                query["lng"] = location.Lng.ToString(CultureInfo.InvariantCulture);

                if (rideType != null)
                    query["ride_type"] = rideType.GetDescription();

                HttpResponseMessage apiResponse = await client.GetAsync($"eta?{query}");

                EtaEstimatesResponse response = await apiResponse.ReadAs<EtaEstimatesResponse>();
                return response;
            }
        }

        public async Task<CostEstimatesResponse> GetCostEstimatesAsync(Location startLocation, Location endLocation, RideTypeEnum? rideType = null)
        {
            using (var client = CreateHttpClient())
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                query["start_lat"] = startLocation.Lat.ToString(CultureInfo.InvariantCulture);
                query["start_lng"] = startLocation.Lng.ToString(CultureInfo.InvariantCulture);
                query["end_lat"] = endLocation.Lat.ToString(CultureInfo.InvariantCulture);
                query["end_lng"] = endLocation.Lng.ToString(CultureInfo.InvariantCulture);

                if (rideType != null)
                    query["ride_type"] = rideType.GetDescription();

                HttpResponseMessage apiResponse = await client.GetAsync($"cost?{query}");

                CostEstimatesResponse response = await apiResponse.ReadAs<CostEstimatesResponse>();
                return response;
            }
        }

        #region private methods

        private HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri($"{Constants.ApiUrlBase}v1/")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (_authToken == null || _authToken.IsExpired)
            {
                _authToken = _tokenProvider.GetToken().Result;
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_authToken.TokenType, _authToken.AccessToken);
            return client;
        }

        #endregion
    }
}
