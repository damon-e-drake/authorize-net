using System;
using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Interfaces;
using AuthorizeNetLite.Transactions;
using Newtonsoft.Json;

namespace AuthorizeNetLite.Security {
  [ApiMethod("authenticateTestRequest")]
  public class AuthenticateTestRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication", Order = 1)]
    public Authentication Credentials { get; set; }
  }

  public class AuthenticateTestResponse : IAuthorizeNetResponse {
    [JsonProperty("messages")]
    public ResponseStatus Status { get; set; }
  }
}