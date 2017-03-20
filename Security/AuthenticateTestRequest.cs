using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;

namespace AuthorizeNetLite.Security {
  [ApiName("authenticateTestRequest")]
  public class AuthenticateTestRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication", Order = 1)]
    public Authentication Credentials { get; set; }
  }
}