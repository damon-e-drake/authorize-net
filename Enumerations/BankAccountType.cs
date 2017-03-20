using System.Runtime.Serialization;

namespace AuthorizeNetLite.Enumerations {
  public enum BankAccountType {
    [EnumMember(Value = "checking")]
    Checking,
    [EnumMember(Value = "savings")]
    Savings,
    [EnumMember(Value = "businessChecking")]
    BusinessChecking
  }
}