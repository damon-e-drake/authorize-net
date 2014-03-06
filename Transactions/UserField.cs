using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "userField", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class UserField {
    [DataMember(Name = "name", Order = 0)]
    public string Name { get; set; }
    [DataMember(Name = "value", Order = 1)]
    public string Value { get; set; }
  }
}