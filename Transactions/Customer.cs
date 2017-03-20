using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  public sealed class Customer {
    [JsonProperty("id", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
    public string ID { get; set; }

    [JsonProperty("email", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string EMail { get; set; }
  }
}