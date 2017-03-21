using Newtonsoft.Json;
using System.Collections.Generic;

namespace AuthorizeNetLite.Transactions {
  public sealed class ResponseStatus {
    [JsonProperty("resultCode")]
    public string Code { get; set; }
    [JsonProperty("message")]
    public IEnumerable<ResponseMessage> Messages { get; set; }
  }
}