using System.Text.Json;
using System.Text.Json.Serialization;

namespace GlowingSystem.Converters
{
    public class DateJsonConverter : JsonConverter<DateTime>
    {
        private const string DateFormatOutput = "dd.MM.yyyy";
        private const string DateFormatInput = "yyyy-mm-dd";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString()!, DateFormatInput, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormatOutput));
        }
    }
}
