using System.Runtime.Serialization;
using AuthorizeNetLite.Response;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite {
  [DataContract(Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class BaseRequest {
    [DataMember(Name = "merchantAuthentication", Order = 0)]
    public Authentication Credentials { get; set; }
  }

  [DataContract(Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class BaseResponse {
    [DataMember(Name = "refId", EmitDefaultValue = false, Order = 0)]
    public long ReferenceID { get; set; }

    [DataMember(Name = "messages", Order = 1)]
    public Status Status { get; set; }
  }
}
