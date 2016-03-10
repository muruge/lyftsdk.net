using System;
using LyftSDK.Net.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LyftSDK.Net.Tests
{
    [TestClass]
    public class LyftClientTests
    {
        private static string _clientId = "zLos9W3ZPFj4";
        private static string _clientSecret = "9kv6Pt02qPILkaQnaJimAzR1H-8tTm-l";

        [TestMethod]
        public void GetRideTypesTest()
        {
            LyftClient client = new LyftClient(_clientId, _clientSecret);
            RideTypesResponse result = client.GetRideTypesAsync(new Location { Lat = 40.721193086128, Lng = -74.0054243803024 }).Result;
            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.RideTypes);
        }

        [TestMethod]
        public void GetRideTypesLyftTest()
        {
            LyftClient client = new LyftClient(_clientId, _clientSecret);
            RideTypesResponse result = client.GetRideTypesAsync(new Location { Lat = 40.721193086128, Lng = -74.0054243803024 }, RideTypeEnum.Lyft).Result;
            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.RideTypes);
        }

        [TestMethod]
        public void GetEtaTest()
        {
            LyftClient client = new LyftClient(_clientId, _clientSecret);
            EtaEstimatesResponse result = client.GetEtaAsync(new Location { Lat = 40.721193086128, Lng = -74.0054243803024 }).Result;
            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.EtaEstimates);
        }

        [TestMethod]
        public void GetCostTest()
        {
            Location start = new Location {Lat = 40.73142657014893, Lng = -73.98931603878736 };
            Location end = new Location { Lat = 40.75615336334427, Lng = -73.98722156882286 };

            LyftClient client = new LyftClient(_clientId, _clientSecret);
            CostEstimatesResponse result = client.GetCostEstimatesAsync(start, end).Result;
            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.CostEstimates);
        }
    }
}
