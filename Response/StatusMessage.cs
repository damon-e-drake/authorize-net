using System.Runtime.Serialization;

namespace AuthorizeNetLite.Response {
  [DataContract(Name = "message", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class StatusMessage {
    [DataMember(Name = "code", Order = 0)]
    public string Code { get; set; }
    [DataMember(Name = "text", Order = 1)]
    public string Text { get; set; }
  }
}