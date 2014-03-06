using System.Runtime.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "customer", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class Customer {
    [DataMember(Name = "id", EmitDefaultValue = false, Order = 0)]
    public string ID { get; set; }
    [DataMember(Name = "email", EmitDefaultValue = false, Order = 1)]
    public string EMail { get; set; }
  }
}