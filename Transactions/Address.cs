using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [Serializable]
  public sealed class Address {
    [XmlElement("firstName")]
    public string FirstName { get; set; }
    [XmlElement("lastName")]
    public string LastName { get; set; }
    [XmlElement("company")]
    public string Company { get; set; }
    [XmlElement("address")]
    public string Street { get; set; }
    [XmlElement("city")]
    public string City { get; set; }
    [XmlElement("state")]
    public string State { get; set; }
    [XmlElement("zip")]
    public string ZipCode { get; set; }
    [XmlElement("country")]
    public string Country { get; set; }
  }
}