using AuthorizeNetLite.Converters;
using Newtonsoft.Json;

namespace AuthorizeNetLite.Reporting {
  public class TransactionListPaging {
    [JsonProperty("limit", Order = 1), JsonConverter(typeof(StringPrimitiveConverter<int>))]
    public int Limit { get; set; }
    [JsonProperty("offset", Order = 2), JsonConverter(typeof(StringPrimitiveConverter<int>))]
    public int Offset { get; set; }
  }
}