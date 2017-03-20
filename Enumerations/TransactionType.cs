using System.Runtime.Serialization;

namespace AuthorizeNetLite.Transactions {
  public enum TransactionType {
    [EnumMember(Value = "authOnlyTransaction")]
    AuthOnly,
    [EnumMember(Value = "authCaptureTransaction")]
    AuthCapture,
    [EnumMember(Value = "captureOnlyTransaction")]
    CaptureOnly,
    [EnumMember(Value = "refundTransaction")]
    Refund,
    [EnumMember(Value = "priorAuthCaptureTransaction")]
    PriorAuthCapture,
    [EnumMember(Value = "voidTransaction")]
    Void,
    [EnumMember(Value = "getDetailsTransaction")]
    GetDetails,
    [EnumMember(Value = "authOnlyContinueTransaction")]
    AuthOnlyContinue,
    [EnumMember(Value = "authCaptureContinueTransaction")]
    AuthCaptureContinue
  }
}
