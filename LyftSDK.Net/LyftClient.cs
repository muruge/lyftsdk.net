﻿using System;
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