using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [Serializable]
  [XmlRoot("creditCard")]
  public sealed class CreditCard : Payment {
    [XmlElement("cardNumber")]
    public string CardNumber { get; set; }
    [XmlElement("expirationDate")]
    public string ExpirationDate { get; set; }
    [XmlElement("cardCode")]
    public string CardCode { get; set; }
    [XmlElement("track1")]
    public string FirstDataTrack { get; set; }
    [XmlElement("track2")]
    public string SecondDataTrack { get; set; }
  }
}