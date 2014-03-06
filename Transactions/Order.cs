using System.Runtime.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "order", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class Order{
    [DataMember(Name = "invoiceNumber", EmitDefaultValue = false, Order = 0)]
    public string InvoiceNumber { get; set; }

    [DataMember(Name = "description", EmitDefaultValue = false, Order = 1)]
    public string Description { get; set; }
  }
}