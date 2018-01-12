using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LyftSDK.Net.Auth;
using LyftSDK.Net.Helpers;
using LyftSDK.Net.Models;
using Newtonsoft.Json;

namespace LyftSDK.Net
{
    public class LyftClient
    {
        private readonly ITokenProvider _tokenProvider;

        public LyftClient(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public async Task<RideTypesResponse> GetRideTypesAsync(Location location, RideTypeEnum? rideType = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["lat"] = location.Lat.ToString(CultureInfo.InvariantCulture);
            query["lng"] = location.Lng.ToString(CultureInfo.InvariantCulture);

            if (rideType != null)
                query["ride_type"] = rideType.GetDescription();

            var response = await GetFromApiAsync<RideTypesResponse>($"ridetypes?{query}");
            return response;
        }

        public async Task<EtaEstimatesResponse> GetEtaAsync(Location location, RideTypeEnum? rideType = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["lat"] = location.Lat.ToString(CultureInfo.InvariantCulture);
            query["lng"] = location.Lng.ToString(CultureInfo.InvariantCulture);

            if (rideType != null)
                query["ride_type"] = rideType.GetDescription();

            var response = await GetFromApiAsync<EtaEstimatesResponse>($"eta?{query}");
            return response;
        }

	    public async Task<RideListResponse> GetRidesAsync(DateTime startTime, DateTime endTime, int limit = 10)
	    {
		    var query = HttpUtility.ParseQueryString(string.Empty);
		    query["start_time"] = TimeToString(startTime);  // "2016-12-09T00:00:00+00:00"
		    query["end_time"] = TimeToString(endTime);  //"2016-12-12T00:00:00+00:00";
		    query["limit"] = limit.ToString(CultureInfo.InvariantCulture);

		    var response = await GetFromApiAsync<RideListResponse>($"rides?{query}");
		    return response;
	    }

	    private static string TimeToString(DateTime dt)
	    {
		    // The earliest date is '2015-01-01T00:00:00+00:00'
		    return $"{dt:yyyy-MM-ddTHH:mm:sszzz}";
	    }

	    public async Task<RideResponse> GetRideAsync(string rideID)
	    {
		    var response = await GetFromApiAsync<RideResponse>($"rides/{rideID}");
		    return response;
	    }

		public async Task<CostEstimatesResponse> GetCostEstimatesAsync(Location startLocation, Location endLocation,
            RideTypeEnum? rideType = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["start_lat"] = startLocation.Lat.ToString(CultureInfo.InvariantCulture);
            query["start_lng"] = startLocation.Lng.ToString(CultureInfo.InvariantCulture);
            query["end_lat"] = endLocation.Lat.ToString(CultureInfo.InvariantCulture);
            query["end_lng"] = endLocation.Lng.ToString(CultureInfo.InvariantCulture);

            if (rideType != null)
                query["ride_type"] = rideType.GetDescription();

            var response = await GetFromApiAsync<CostEstimatesResponse>($"cost?{query}");
            return response;
        }

		public async Task<RideResponse> PostRideAsync(Location startLocation, Location endLocation, RideTypeEnum rideType, string primetimeConfirmationToken = null)
	    {
		    string url = "rides";
		    var postData = new Ride
		    {
			    StartLocation = startLocation,
			    EndLocation = endLocation,
			    Type = rideType,
			    PrimetimeConfirmationToken = primetimeConfirmationToken
		    };

		    var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
		    return await PostToApiAsync<RideResponse>(url, content);
	    }

        #region private methods

        private async Task<T> GetFromApiAsync<T>(string url)
            where T : LyftResponse, new()
        {
            var client = await CreateHttpClient();

            try
            {
                var apiResponse = await client.GetAsync(url);
                var responseData = await apiResponse.ReadAs<T>();
                return responseData;
            }
            finally
            {
                client?.Dispose();
            }
        }

		private async Task<T> PostToApiAsync<T>(string url, HttpContent content)
		    where T : LyftResponse, new()
	    {
		    var client = await CreateHttpClient();

		    try
		    {
			    var apiResponse = await client.PostAsync(url, content);
			    var responseData = await apiResponse.ReadAs<T>();
			    return responseData;
		    }
		    finally
		    {
			    client?.Dispose();
		    }
	    }

        private async Task<HttpClient> CreateHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri($"{Constants.ApiUrlBase}v1/")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var authToken = await _tokenProvider.GetToken();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authToken.TokenType,
                authToken.AccessToken);
            return client;
        }

        #endregion
    }
}