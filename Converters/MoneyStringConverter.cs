﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AuthorizeNetLite.Converters {
  public class MoneyStringConverter : JsonConverter {
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      var jt = JToken.ReadFrom(reader);
      return jt.Value<decimal>();
    }

    public override bool CanConvert(Type objectType) {
      return typeof(decimal).Equals(objectType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      serializer.Serialize(writer, value.ToString());
    }
  }
}