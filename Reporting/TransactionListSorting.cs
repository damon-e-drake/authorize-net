using Newtonsoft.Json;

namespace AuthorizeNetLite.Reporting {
  public class TransactionListSorting {
    [JsonProperty("orderBy", Order = 1)]
    public string OrderBy { get; set; }
    [JsonProperty("orderDescending", Order = 2)]
    public bool Descending { get; set; }
  }
}