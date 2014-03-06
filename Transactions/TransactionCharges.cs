using System.Runtime.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionCharges {
    [DataMember(Name = "amount", Order = 0)]
    public decimal Amount { get; set; }

    [DataMember(Name = "name", Order = 1)]
    public string Name { get; set; }

    [DataMember(Name = "description", Order = 2)]
    public string Description { get; set; }
  }
}