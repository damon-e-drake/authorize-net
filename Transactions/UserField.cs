using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  public sealed class UserField {
    [JsonProperty("name", Order = 1)]
    public string Name { get; set; }
    [JsonProperty("value", Order = 2)]
    public string Value { get; set; }
  }
}