using AuthorizeNetLite.Attributes;

namespace AuthorizeNetLite.Options {
  public enum TransactionType : int {
    [StringValue("authCaptureTransaction")]
    AuthCapture = 0,
    [StringValue("authOnlyTransaction")]
    AuthOnly = 1,
    [StringValue("captureOnlyTransaction")]
    CaptureOnly = 2,
    [StringValue("priorAuthCaptureTransaction")]
    PriorAuthCapture = 3,
    [StringValue("voidTransaction")]
    Void = 4,
    [StringValue("refundTransaction")]
    Refund = 5,
    [StringValue("getSettledBatchRequestList")]
    SettledBatchList = 6,
    [StringValue("getTransactionListRequest")]
    TransactionListRequest = 7,
    [StringValue("getTransactionDetailsRequest")]
    TransactionDetailRequest = 8,
    [StringValue("getUnsettledTransactionListRequest")]
    UnsettledTransactionListRequest = 9
  }
}
