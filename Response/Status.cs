using System.Runtime.Serialization;

namespace AuthorizeNetLite.Response {
  [DataContract(Name = "messages", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class Status {
    [DataMember(Name = "resultCode", Order = 0)]
    public string ResultCode { get; set; }
    [DataMember(Name = "message", Order = 1)]
    public StatusMessage Message { get; set; }
  }
}