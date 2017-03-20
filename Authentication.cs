using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizeNetLite {
  public class Authentication {
    [JsonProperty("name", Order = 1)]
    public string Code { get; set; }
    [JsonProperty("transactionKey", Order = 2)]
    public string Key { get; set; }
  }
}
