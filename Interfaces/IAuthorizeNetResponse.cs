using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizeNetLite.Interfaces {

  public sealed class ResponseMessage {
    [JsonProperty("code", Order = 1)]
    public string Code { get; set; }
    [JsonProperty("description", Order = 2)]
    public string Description { get; set; }
  }

  public sealed class ResponseError {
    [JsonProperty("errorCode", Order = 1)]
    public string Code { get; set; }
    [JsonProperty("errorText", Order = 2)]
    public string Description { get; set; }
  }

  public interface IAuthorizeNetResponse {
    List<ResponseMessage> Messages { get; set; }
  }

  public sealed class TransactionResponse : IAuthorizeNetResponse {
    [JsonProperty("responseCode")]
    public string ResponseCode { get; set; }
    [JsonProperty("rawResponseCode")]
    public string RawResponseCode { get; set; }
    [JsonProperty("authCode")]
    public string AuthorizationCode { get; set; }
    [JsonProperty("avsResultCode")]
    public string AvsResultCode { get; set;}
    [JsonProperty("cvvResultCode")]
    public string CvvResultCode { get; set; }
    [JsonProperty("cavvResultCode")]
    public string CavvResultCode { get; set; }


    public List<ResponseMessage> Messages { get; set; }

  }
}
