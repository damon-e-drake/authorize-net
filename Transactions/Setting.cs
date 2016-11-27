using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [XmlRoot("setting")]
  public sealed class Setting {
    [XmlElement("settingName")]
    public string Name { get; set; }
    [XmlElement("settingValue")]
    public string Value { get; set; }
  }
}