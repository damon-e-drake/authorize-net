using AuthorizeNetLite.Attributes;

namespace AuthorizeNetLite.Options {
  public enum GatewayUrl : int {
    [StringValue("https://api.authorize.net/xml/v1/request.api")]
    Production = 0,
    [StringValue("https://apitest.authorize.net/xml/v1/request.api")]
    Development = 1
  }
}
