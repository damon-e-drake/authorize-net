using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.Interfaces {
  public interface IAuthorizeNetResponse {
    ResponseStatus Status { get; set; }
  }
}