using System;
using System.Xml.Serialization;
using AuthorizeNetLite.Request;
using AuthorizeNetLite.Response;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("getUnsettledTransactionListResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class UnsettledResponse : ResponseBase {
    [XmlArray("transactions")]
    [XmlArrayItem("transaction", typeof(TransactionDetailSummary))]
    public TransactionDetailSummary[] Transactions { get; set; }
  }
}