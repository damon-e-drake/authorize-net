using System;
using System.Xml.Serialization;
using AuthorizeNetLite.Request;

namespace AuthorizeNetLite.Response {
  [XmlRoot("createTransactionResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class TransactionResponse : ResponseBase {
    [XmlElement("transactionResponse")]
    public TransactionSummary Transaction { get; set; }
  }
}