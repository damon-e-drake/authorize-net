using System.Runtime.Serialization;

namespace AuthorizeNetLite.Response {
  [DataContract(Name = "ErrorResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class ErrorResponse : BaseResponse {

  }
}