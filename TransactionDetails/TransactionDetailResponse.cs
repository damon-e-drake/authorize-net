using System;
using System.Xml.Serialization;
using AuthorizeNetLite.Request;
using AuthorizeNetLite.Response;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("getTransactionDetailsResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionDetailResponse : ResponseBase {
    [XmlElement("transaction")]
    public TransactionDetail Transaction { get; set; }
  }
}