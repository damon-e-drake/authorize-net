using System;
using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Converters;
using AuthorizeNetLite.Interfaces;
using AuthorizeNetLite.Transactions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AuthorizeNetLite.Reporting {
  [ApiMethod("getTransactionListRequest")]
  public class TransactionListRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication", Order = 1)]
    public Authentication Credentials { get; set; }
    [JsonProperty("batchId", Order = 2)]
    public long BatchID { get; set; }
    [JsonProperty("sorting", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public Sorting Sorting { get; set; }
    [JsonProperty("paging", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
    public Paging Paging { get; set; }
  }

  [ApiMethod("getUnsettledTransactionListRequest")]
  public class UnsettledTransactionListRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication", Order = 1)]
    public Authentication Credentials { get; set; }
    [JsonProperty("sorting", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public Sorting Sorting { get; set; }
    [JsonProperty("paging", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public Paging Paging { get; set; }
  }

  public class Paging {
    [JsonProperty("limit", Order = 1), JsonConverter(typeof(StringPrimitiveConverter<int>))]
    public int Limit { get; set; }
    [JsonProperty("offset", Order = 2), JsonConverter(typeof(StringPrimitiveConverter<int>))]
    public int Offset { get; set; }
  }

  public class Sorting {
    [JsonProperty("orderBy", Order = 1)]
    public string OrderBy { get; set; }
    [JsonProperty("orderDescending", Order = 2)]
    public bool Descending { get; set; }
  }

  public class TransactionListResponse : IAuthorizeNetResponse {
    [JsonProperty("messages")]
    public ResponseStatus Status { get; set; }
    [JsonProperty("transactions")]
    public IEnumerable<TransactionSummary> Transactions { get; set; }
    [JsonProperty("totalNumInResultSet")]
    public int TotalResults { get; set; }
  }

  public class TransactionSummary {
    [JsonProperty("transId")]
    public long TransactionID { get; set; }
    [JsonProperty("submitTimeUTC")]
    public DateTime SubmittedUtc { get; set; }
    [JsonProperty("submitTimeLocal")]
    public DateTime SubmittedLocal { get; set; }
    [JsonProperty("transactionStatus")]
    public string TransactionStatus { get; set; }
    [JsonProperty("invoiceNumber")]
    public string InvoiceNumber { get; set; }
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    [JsonProperty("accountType")]
    public string AccountType { get; set; }
    [JsonProperty("accountNumber")]
    public string AccountNumber { get; set; }
    [JsonProperty("settleAmount")]
    public decimal SettlementAmount { get; set; }
    [JsonProperty("marketType")]
    public string MarketType { get; set; }
    [JsonProperty("product")]
    public string Product { get; set; }
    [JsonProperty("mobileDeviceId")]
    public string MobileDeviceID { get; set; }
    // subscription
    [JsonProperty("hasReturnedItems")]
    public bool HasReturnedItems { get; set; }
    //faudInformation
  }
}