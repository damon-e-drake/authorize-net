using System;
using System.Xml.Serialization;
using AuthorizeNetLite.Response;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("getTransactionDetailsResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionDetailResponse {
    [XmlElement("messages")]
    public Status Status { get; set; }

    [XmlElement("transaction")]
    public TransactionDetail Transaction { get; set; }
  }
}