using AuthorizeNetLite.Converters;
using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  public sealed class TransactionCharge {
    [JsonProperty("amount", Order = 1), JsonConverter(typeof(StringMoneyConverter))]
    public decimal Amount { get; set; }

    [JsonProperty("name", Order = 2)]
    public string Name { get; set; }

    [JsonProperty("description", Order = 3)]
    public string Description { get; set; }
  }
}