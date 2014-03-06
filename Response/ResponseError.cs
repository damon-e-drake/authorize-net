using System.Runtime.Serialization;

namespace AuthorizeNetLite.Response {
  [DataContract(Name = "error", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class ResponseError {
    [DataMember(Name = "errorCode")]
    public string Code { get; set; }
    [DataMember(Name = "errorText")]
    public string Text { get; set; }
  }
}