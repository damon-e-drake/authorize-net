using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;

namespace AuthorizeNetLite.Reporting {
  [ApiMethod("getTransactionListRequest")]
  public class TransactionListRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication", Order = 1)]
    public Authentication Credentials { get; set; }
    [JsonProperty("batchId", Order = 2)]
    public long BatchID { get; set; }
    [JsonProperty("sorting", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public TransactionListSorting Sorting { get; set; }
    [JsonProperty("paging", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public TransactionListPaging Paging { get; set; }
  }
}