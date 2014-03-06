using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "getTransactionListResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class BatchTransactionsResponse : BaseResponse {
    [DataMember(Name = "transactions", Order = 1)]
    public List<TransactionDetailSummary> Transactions { get; set; }
  }
}