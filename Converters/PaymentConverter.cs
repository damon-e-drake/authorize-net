using AuthorizeNetLite.Transactions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AuthorizeNetLite.Converters {
  public class PaymentConverter : JsonConverter {
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      var json = JToken.Load(reader).ToString(Formatting.None);

      if (json.StartsWith("{\"creditCard\":")) {
        json = json.Remove(json.Length - 1, 1).Replace("{\"creditCard\":", "");
        return JsonConvert.DeserializeObject<CreditCard>(json);
      }

      return new CreditCard();
    }

    public override bool CanConvert(Type objectType) {
      return typeof(decimal).Equals(objectType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      if (value.GetType() == typeof(CreditCard)) {
        writer.WriteRawValue("{\"creditCard\":" + JsonConvert.SerializeObject(value) + "}");
      }
      //serializer.Serialize(writer, value);
    }
  }
}