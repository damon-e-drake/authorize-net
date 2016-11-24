using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [XmlRoot("customer")]
  public sealed class Customer {
    [XmlElement("id")]
    public string ID { get; set; }

    [XmlElement("email")]
    public string EMail { get; set; }
  }
}