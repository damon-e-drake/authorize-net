using AuthorizeNetLite.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AuthorizeNetLite.Transactions {
  public sealed class TransactionSetting {
    [JsonProperty("settingName", Order = 1), JsonConverter(typeof(StringEnumConverter))]
    public TransactionSettingType Setting { get; set; }
    [JsonProperty("settingValue", Order = 2)]
    public string Value { get; set; }
  }
}