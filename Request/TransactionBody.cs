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
    [XmlArrayItem("bankAccount", typeof(ECheck))]
    public Payment[] Payment { get; set; }

    [XmlElement("authCode")]
    public string AuthorizationCode { get; set; }

    [XmlElement("refTransId")]
    public string ReferencedTransactionID { get; set; }

    [XmlElement("order")]
    public Order OrderInformation { get; set; }

    [XmlArray("lineItems")]
    [XmlArrayItem("lineItem", typeof(LineItem))]
    public LineItem[] Items { get; set; }

    [XmlElement("tax")]
    public TransactionCharges Tax { get; set; }
    [XmlElement("duty")]
    public TransactionCharges Duty { get; set; }
    [XmlElement("shipping")]
    public TransactionCharges Shipping { get; set; }

    [XmlElement("customer")]
    public Customer Customer { get; set; }

    [XmlElement("billTo")]
    public Address BillingAddress { get; set; }
    [XmlElement("shipTo")]
    public Address ShippingAddress { get; set; }

    [XmlElement("poNumber")]
    public string PONumber { get; set; }

    [XmlElement("customerIP")]
    public string CustomerIP { get; set; }

    [XmlArray("transactionSettings")]
    [XmlArrayItem("setting", typeof(Setting))]
    public Setting[] Settings { get; set; }

    [XmlArray("userFields")]
    [XmlArrayItem("userField", typeof(UserField))]
    public UserField[] UserFields { get; set; }
  }
}