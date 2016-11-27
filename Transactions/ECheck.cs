using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [XmlRoot("bankAccount")]
  public sealed class ECheck : Payment {
    //[XmlElement("accountType")]
    //public string AccountType { get; set; }

    [XmlElement("routingNumber")]
    public string RoutingNumber { get; set; }

    [XmlElement("accountNumber")]
    public string AccountNumber { get; set; }

    [XmlElement("nameOnAccount")]
    public string AccountName { get; set; }

    [XmlElement("echeckType")]
    public string CheckType { get; set; }

    [XmlElement("bankName")]
    public string BankName { get; set; }

    //[XmlElement("checkNumber")]
    //public string CheckNumber { get; set; }
  }
}