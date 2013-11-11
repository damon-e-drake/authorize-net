using AuthorizeNetLite.Transactions;
using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Request {
  [Serializable]
  [XmlRoot("transactionRequest")]
  public sealed class TransactionBody {
    [XmlElement("transactionType")]
    public string Type { get; set; }

    [XmlElement("amount")]
    public decimal Amount { get; set; }

    [XmlArray("payment")]
    [XmlArrayItem("creditCard", typeof(CreditCard))]
    public CreditCard[] CardInformation { get; set; }

    [XmlElement("billTo")]
    public Address BillingAddress { get; set; }
    [XmlElement("shipTo")]
    public Address ShippingAddress { get; set; }
  }
}