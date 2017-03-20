using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  public sealed class Order {
    [JsonProperty("invoiceNumber", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
    public string InvoiceNumber { get; set; }
    [JsonProperty("description", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }
  }
}