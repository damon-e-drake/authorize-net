using System.Runtime.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "lineItem", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class LineItem {
    [DataMember(Name = "itemId", Order = 0)]
    public string ItemID { get; set; }
    [DataMember(Name = "name", Order = 1)]
    public string Name { get; set; }
    [DataMember(Name = "description", Order = 2)]
    public string Description { get; set; }
    [DataMember(Name = "quantity", Order = 3)]
    public decimal Quantity { get; set; }
    [DataMember(Name = "unitPrice", Order = 4)]
    public decimal Price { get; set; }
  }
}