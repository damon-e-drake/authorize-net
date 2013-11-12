using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [Serializable]
  public sealed class TransactionCharges {
    [XmlElement("amount")]
    public decimal Amount { get; set; }

    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("description")]
    public string Description { get; set; }
  }
}