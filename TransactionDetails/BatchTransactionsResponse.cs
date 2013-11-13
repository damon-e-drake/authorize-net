using System;
using System.Xml.Serialization;
using AuthorizeNetLite.Response;

namespace AuthorizeNetLite.TransactionDetails {
  [Serializable]
  [XmlRoot("getTransactionListResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class BatchTransactionsResponse {
    [XmlElement("messages")]
    public Status Status { get; set; }

    [XmlArray("transactions")]
    [XmlArrayItem("transaction", typeof(TransactionDetailSummary))]
    public TransactionDetailSummary[] Transactions { get; set; }
  }
}