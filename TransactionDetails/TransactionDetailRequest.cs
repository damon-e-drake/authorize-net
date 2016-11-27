using System;
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
  [XmlRoot("getTransactionDetailsRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionDetailRequest : RequestBase<TransactionDetailRequest, TransactionDetailResponse> {
    public static async Task<TransactionDetail> GetAsync(long transactionId, CancellationToken cancellationToken = default(CancellationToken)) {
      return (await new TransactionDetailRequest { TransactionID = transactionId }.GetResponseAsync(cancellationToken: cancellationToken)).Transaction;
    }
    [XmlElement("transId")]
    public long TransactionID { get; set; }
  }
}
