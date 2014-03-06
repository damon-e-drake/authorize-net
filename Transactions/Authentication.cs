using System.Runtime.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "merchantAuthentication", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class Authentication {
    [DataMember(Name = "name", IsRequired = true, Order = 0)]
    public string ApiLogin { get; set; }
    [DataMember(Name = "transactionKey", Order = 1)]
    public string TransactionKey { get; set; }
  }
}