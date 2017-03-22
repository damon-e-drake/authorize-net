using AuthorizeNetLite.Converters;
using Newtonsoft.Json;

namespace AuthorizeNetLite.Reporting {
  public class TransactionListPaging {
    [JsonProperty("limit", Order = 1), JsonConverter(typeof(StringIntConverter))]
    public int Limit { get; set; }
    [JsonProperty("offset", Order = 2), JsonConverter(typeof(StringIntConverter))]
    public int Offset { get; set; }
  }
}