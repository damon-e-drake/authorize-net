using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Response {
  [Serializable]
  [XmlRoot("createTransactionResponse")]
  public class TransactionResponse {
    [XmlElement("messages")]
    public Status Status { get; set; }
    [XmlElement("transactionResponse")]
    public TransactionSummary Transaction { get; set; }
  }
}