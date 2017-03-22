using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AuthorizeNetLite.Enumerations {
  public enum ApiEndpoint { Sandbox, Production }

  public enum BankAccountType {
    [EnumMember(Value = "checking")]
    Checking,
    [EnumMember(Value = "savings")]
    Savings,
    [EnumMember(Value = "businessChecking")]
    BusinessChecking
  }

  public enum TransactionSettingType {
    [EnumMember(Value = "emailCustomer")]
    EmailCustomer,
    [EnumMember(Value = "merchantEmail")]
    MerchantEmail,
    [EnumMember(Value = "allowPartialAuth")]
    AllowPartialAuthorization,
    [EnumMember(Value = "headerEmailReceipt")]
    ReceiptHeader,
    [EnumMember(Value = "footerEmailReceipt")]
    ReceiptFooter,
    [EnumMember(Value = "recurringBilling")]
    RecurringBilling,
    [EnumMember(Value = "duplicateWindow")]
    DuplicateWindow,
    [EnumMember(Value = "testRequest")]
    TestRequest
  }

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

  //TODO: Add enumeration converters and json properties. Add Dictionary Definition.
  public enum TransactionStatus {
    AuthorizedPendingCapture,
    CapturedPendingSettlement,
    CommunicationError,
    RefundSettledSuccessfully,
    RefundPendingSettlement,
    ApprovedReview,
    Declined,
    CouldNotVoid,
    Expired,
    GeneralError,
    PendingFinalSettlement,
    PendingSettlement,
    FailedReview,
    SettleSuccessfully,
    SettlementError,
    UnderReview,
    UpdatingSettlement,
    Voided,
    FDSPendingReview,
    FDSAuthorizedPendingReview,
    ReturnedItem,
    Chargeback,
    ChargebackReversal,
    AuthorizedPendingRelease
  }
}
