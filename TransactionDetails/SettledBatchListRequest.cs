using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.Request;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("getSettledBatchListRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class SettledBatchListRequest : RequestBase<SettledBatchListRequest, SettledBatchListResponse> {
    [XmlElement("includeStatistics")]
    public bool IncludeStatistics { get; set; }
    [XmlElement("firstSettlementDate")]
    public DateTime StartDate { get; set; }
    [XmlElement("lastSettlementDate")]
    public DateTime EndDate { get; set; }
  }
}