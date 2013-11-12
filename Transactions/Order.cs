using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [Serializable]
  [XmlRoot("order")]
  public sealed class Order{
    [XmlElement("invoiceNumber")]
    public string InvoiceNumber { get; set; }

    [XmlElement("description")]
    public string Description { get; set; }
  }
}