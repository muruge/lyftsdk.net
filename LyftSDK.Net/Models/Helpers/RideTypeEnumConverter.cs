using System;
using System.Linq;
using LyftSDK.Net.Helpers;
using Newtonsoft.Json;

namespace LyftSDK.Net.Models.Helpers
{
    internal class RideTypeEnumConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var rideType = (RideTypeEnum)value;
            writer.WriteValue(rideType.GetDescription());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            return Enum.GetValues(typeof (RideTypeEnum))
                .Cast<RideTypeEnum>()
                .FirstOrDefault(rideType => rideType.GetDescription() == value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}