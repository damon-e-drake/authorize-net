using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.Request;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("getTransactionListRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class BatchTransactionsRequest : RequestBase<BatchTransactionsRequest, BatchTransactionsResponse> {
    [XmlElement("batchId")]
    public long BatchID { get; set; }
  }
}