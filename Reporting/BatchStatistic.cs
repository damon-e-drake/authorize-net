using Newtonsoft.Json;

namespace AuthorizeNetLite.Reporting {
  public class BatchStatistic {
    [JsonProperty("accountType")]
    public string AccountType { get; set; }
    [JsonProperty("chargeAmount")]
    public decimal ChargeAmount { get; set; }
    [JsonProperty("refundAmount")]
    public decimal RefundAmount { get; set; }
    [JsonProperty("chargeCount")]
    public int Charges { get; set; }
    [JsonProperty("refundCount")]
    public int Refunds { get; set; }
    [JsonProperty("voidCount")]
    public int Voids { get; set; }
    [JsonProperty("declineCount")]
    public int Declines { get; set; }
    [JsonProperty("errorCount")]
    public int Errors { get; set; }
  }
}