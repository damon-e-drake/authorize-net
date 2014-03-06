using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "setting", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class Setting {
    [DataMember(Name = "settingName", Order = 0)]
    public string Name { get; set; }
    [DataMember(Name = "settingValue", Order = 1)]
    public string Value { get; set; }
  }
}