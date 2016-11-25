using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.Request;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("getTransactionListRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class BatchTransactionsRequest : RequestBase<BatchTransactionsRequest, BatchTransactionsResponse> {
    public static async Task<IReadOnlyList<TransactionDetailSummary>> GetAsync(long batchId, CancellationToken cancellationToken = default(CancellationToken)) {
      return (await new BatchTransactionsRequest { BatchID = batchId }.GetResponseAsync(cancellationToken: cancellationToken)).Transactions;
    }
    [XmlElement("batchId")]
    public long BatchID { get; set; }
  }
}