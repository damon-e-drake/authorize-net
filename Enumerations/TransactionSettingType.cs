using System.Runtime.Serialization;

namespace AuthorizeNetLite.Enumerations {
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
}