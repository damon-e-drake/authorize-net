using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  public sealed class ResponseMessage {
    [JsonProperty("code", Order = 1)]
    public string Code { get; set; }
    [JsonProperty("description", Order = 2)]
    public string Description { get; set; }
  }
}