using AuthorizeNetLite.Attributes;

namespace AuthorizeNetLite.Options {
  public enum TransactionDetailType : int {
    [StringValue("getSettledBatchRequestList")]
    SettledBatchList = 0,
    [StringValue("getTransactionListRequest")]
    TransactionListRequest = 1,
    [StringValue("getTransactionDetailsRequest")]
    TransactionDetailRequest = 2,
    [StringValue("getUnsettledTransactionListRequest")]
    UnsettledTransactionListRequest = 3
  }
}
