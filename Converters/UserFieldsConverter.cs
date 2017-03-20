﻿using Newtonsoft.Json;
using System;

namespace AuthorizeNetLite.Converters {
  public class UserFieldsConverter : JsonConverter {
    public override bool CanConvert(Type objectType) {
      throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      writer.WriteRawValue("{\"userField\":" + JsonConvert.SerializeObject(value) + "}");
    }
  }
}