using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  public sealed class ResponseError {
    [JsonProperty("errorCode", Order = 1)]
    public string Code { get; set; }
    [JsonProperty("errorText", Order = 2)]
    public string Description { get; set; }
  }
}