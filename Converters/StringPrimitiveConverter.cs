using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AuthorizeNetLite.Converters {
  public class StringPrimitiveConverter<T> : JsonConverter {
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      var jt = JToken.ReadFrom(reader);
      return jt.Value<T>();
    }

    public override bool CanConvert(Type objectType) {
      return typeof(T).Equals(objectType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      serializer.Serialize(writer, value.ToString());
    }
  }
}
