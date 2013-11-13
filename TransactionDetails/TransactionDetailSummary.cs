using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.TransactionDetails {
  [Serializable]
  [XmlRoot("transaction")]
  public sealed class TransactionDetailSummary {
    [XmlElement("transId")]
    public long TransactionID { get; set; }
    [XmlElement("submitTimeUTC")]
    public DateTime SubmittedUTC { get; set; }
    [XmlElement("submitTimeLocal")]
    public DateTime SubmittedLocal { get; set; }
    [XmlElement("invoiceNumber")]
    public string InvoiceNumber { get; set; }
    [XmlElement("firstName")]
    public string FirstName { get; set; }
    [XmlElement("lastName")]
    public string LastName { get; set; }
    [XmlElement("accountType")]
    public string AccountType { get; set; }
    [XmlElement("accountNumber")]
    public string AccountNumber { get; set; }
    [XmlElement("settleAmount")]
    public decimal SettlementAmount { get; set; }
  }
}