using System.Runtime.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "bankAccount", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class ECheck  {
    [DataMember(Name = "accountType", EmitDefaultValue = false, Order = 0)]
    public string AccountType { get; set; }
    [DataMember(Name = "routingNumber", EmitDefaultValue = false, Order = 1)]
    public string RoutingNumber { get; set; }
    [DataMember(Name = "accountNumber", EmitDefaultValue = false, Order = 2)]
    public string AccountNumber { get; set; }
    [DataMember(Name = "nameOnAccount", EmitDefaultValue = false, Order = 3)]
    public string AccountName { get; set; }
    [DataMember(Name = "bankName", EmitDefaultValue = false, Order = 4)]
    public string BankName { get; set; }
    //[DataMember(Name = "echeckType", EmitDefaultValue = false, Order = 4)]
    //public string CheckType { get; set; }
  }
}