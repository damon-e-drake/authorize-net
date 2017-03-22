using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;
using System;

namespace AuthorizeNetLite.Reporting {
  [ApiMethod("getSettledBatchListRequest")]
  public class BatchListRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication")]
    public Authentication Credentials { get; set; }
    [JsonProperty("includeStatistics")]
    public bool IncludeStatistics { get; set; }
    [JsonProperty("firstSettlementDate")]
    public DateTime StartDate { get; set; }
    [JsonProperty("lastSettlementDate")]
    public DateTime EndDate { get; set; }
  }
}
