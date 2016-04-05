using System;
using System.Configuration;
using LyftSDK.Net.Auth;
using LyftSDK.Net.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LyftSDK.Net.Tests
{
    [TestClass]
    public class LyftClientTests
    {
        private static readonly string _clientId = ConfigurationManager.AppSettings["Lyft.ClientID"];
        private static readonly string _clientSecret = ConfigurationManager.AppSettings["Lyft.ClientSecret"];

        ITokenProvider _lyftTokenProvider;
        private LyftClient _client;

        [TestInitialize]
        public void Init()
        {
            _lyftTokenProvider = new ClientTokenProvider(_clientId, _clientSecret, true);
            _client = new LyftClient(_lyftTokenProvider);
        }

        [TestMethod]
        public void GetRideTypesTest()
        {
            RideTypesResponse result = _client.GetRideTypesAsync(new Location { Lat = 40.721193086128, Lng = -74.0054243803024 }).Result;
            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.RideTypes);
        }

        [TestMethod]
        public void GetRideTypesLyftTest()
        {
            RideTypesResponse result = _client.GetRideTypesAsync(new Location { Lat = 40.721193086128, Lng = -74.0054243803024 }, RideTypeEnum.Lyft).Result;
            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.RideTypes);
        }

        [TestMethod]
        public void GetEtaTest()
        {
            EtaEstimatesResponse result = _client.GetEtaAsync(new Location { Lat = 40.721193086128, Lng = -74.0054243803024 }).Result;
            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.EtaEstimates);
        }

        [TestMethod]
        public void GetCostTest()
        {
            Location start = new Location {Lat = 40.73142657014893, Lng = -73.98931603878736 };
            Location end = new Location { Lat = 40.75615336334427, Lng = -73.98722156882286 };
            
            CostEstimatesResponse result = _client.GetCostEstimatesAsync(start, end).Result;
            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.CostEstimates);
        }
    }
}
