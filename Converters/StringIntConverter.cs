using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AuthorizeNetLite.Converters {
  public class StringIntConverter : JsonConverter {
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      var jt = JToken.ReadFrom(reader);
      return jt.Value<int>();
    }

    public override bool CanConvert(Type objectType) {
      return typeof(int).Equals(objectType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      serializer.Serialize(writer, value.ToString());
    }
  }
}