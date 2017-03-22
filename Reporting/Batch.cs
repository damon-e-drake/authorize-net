using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthorizeNetLite.Reporting {
  public class Batch {
    [JsonProperty("batchId")]
    public string ID { get; set; }
    [JsonProperty("settlementTimeUTC")]
    public DateTime UtcTime { get; set; }
    [JsonProperty("settlementTimeLocal")]
    public DateTime LocalTime { get; set; }
    [JsonProperty("settlementState")]
    public string State { get; set; }
    [JsonProperty("paymentMethod")]
    public string Payment { get; set; }
    [JsonProperty("marketType")]
    public string Market { get; set; }
    [JsonProperty("product")]
    public string Product { get; set; }
    [JsonProperty("statistics")]
    public IEnumerable<BatchStatistic> Statistics { get; set; }

    public Batch() {
      Statistics = Enumerable.Empty<BatchStatistic>();
    }
  }
}