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
  [XmlRoot("getSettledBatchListRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class SettledBatchListRequest : RequestBase<SettledBatchListRequest, SettledBatchListResponse> {
    public static async Task<IReadOnlyList<Batch>> GetAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default(CancellationToken)) {
      return (await new SettledBatchListRequest { StartDate = startDate, EndDate = endDate }.GetResponseAsync(cancellationToken: cancellationToken)).Batches;
    }

    [XmlElement("includeStatistics")]
    public bool IncludeStatistics { get; set; }
    [XmlElement("firstSettlementDate")]
    public DateTime StartDate { get; set; }
    [XmlElement("lastSettlementDate")]
    public DateTime EndDate { get; set; }
  }
}