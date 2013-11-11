using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Response {
  [Serializable]
  [XmlRoot("createTransactionResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class TransactionResponse {
    [XmlElement("messages")]
    public Status Status { get; set; }
    [XmlElement("transactionResponse")]
    public TransactionSummary Transaction { get; set; }
  }
}