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
  [XmlRoot("getUnsettledTransactionListRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class UnsettledRequest : RequestBase<UnsettledRequest, UnsettledResponse> {
    public static async Task<IReadOnlyList<TransactionDetailSummary>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) {
      return (await new UnsettledRequest().GetResponseAsync(cancellationToken: cancellationToken)).Transactions;
    }
  }
}