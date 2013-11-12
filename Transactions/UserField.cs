using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [Serializable]
  [XmlRoot("userField")]
  public sealed class UserField {
    [XmlElement("name")]
    public string Name { get; set; }
    [XmlElement("value")]
    public string Value { get; set; }
  }
}