using AuthorizeNetLite.Interfaces;
using AuthorizeNetLite.Transactions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AuthorizeNetLite.Reporting {
  public class BatchListResponse : IAuthorizeNetResponse {
    [JsonProperty("batchList", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<Batch> Batches { get; set; }
    [JsonProperty("messages")]
    public ResponseStatus Status { get; set; }

    public BatchListResponse() {
      Batches = Enumerable.Empty<Batch>();
    }
  }
}