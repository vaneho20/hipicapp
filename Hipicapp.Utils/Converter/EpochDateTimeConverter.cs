using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Hipicapp.Utils.Converter
{
    public class EpochDateTimeConverter : DateTimeConverterBase
    {
        internal static readonly long InitialJavaScriptDateTicks = 621355968000000000;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long ticks;

            if (value is DateTime)
            {
                ticks = (((DateTime)value).ToUniversalTime().Ticks - InitialJavaScriptDateTicks) / 10000;
            }
            else
            {
                throw new JsonSerializationException("Expected date object value.");
            }

            writer.WriteValue(ticks);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read();

            long ticks = (long)reader.Value;

            DateTime d = new DateTime((ticks * 10000) + InitialJavaScriptDateTicks, DateTimeKind.Utc);

            return d;
        }
    }
}