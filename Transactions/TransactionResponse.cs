using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AuthorizeNetLite.Transactions {
  public sealed class TransactionResponse : IAuthorizeNetResponse {
    [JsonProperty("responseCode")]
    public string ResponseCode { get; set; }
    [JsonProperty("rawResponseCode")]
    public string RawResponseCode { get; set; }
    [JsonProperty("authCode")]
    public string AuthorizationCode { get; set; }
    [JsonProperty("avsResultCode")]
    public string AvsResultCode { get; set; }
    [JsonProperty("cvvResultCode")]
    public string CvvResultCode { get; set; }
    [JsonProperty("cavvResultCode")]
    public string CavvResultCode { get; set; }
    [JsonProperty("transId")]
    public string TransactionID { get; set; }
    [JsonProperty("refTransID")]
    public string ReferencedTransactionID { get; set; }
    [JsonProperty("transHash")]
    public string MD5Hash { get; set; }
    [JsonProperty("testRequest")]
    public string TestRequest { get; set; }
    [JsonProperty("accountNumber")]
    public string AccountNumber { get; set; }
    [JsonProperty("entryMode")]
    public string EntryMode { get; set; }
    [JsonProperty("accountType")]
    public string AccountType { get; set; }
    [JsonProperty("splitTenderId")]
    public string SplitTenderID { get; set; }

    // PrePaidCard { requestedAmount, approvedAmount, balanceOnCard }

    [JsonProperty("messages")]
    public ResponseStatus Status { get; set; }
    [JsonProperty("errors")]
    public IEnumerable<ResponseError> Errors { get; set; }

    // [SplitTenderPayment] { transId, responseCode, responseToCustomer, authCode, accountNumber, accountType, requestedAmount, approvedAmount, balanceOncard }

    [JsonProperty("userFields")]
    public IEnumerable<UserField> UserFields { get; set; }
    [JsonProperty("shipTo")]
    public Address ShippingAddress { get; set; }

    // SecureAcceptance { SecureAcceptanceUrl, PayerID, PayerEmail }
    // emvResponse? TODO:research definition

    [JsonProperty("transHashSha2")]
    public string SHA2Hash { get; set; }
  }
}