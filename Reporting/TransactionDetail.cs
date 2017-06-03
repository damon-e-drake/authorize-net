using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Converters;
using AuthorizeNetLite.Enumerations;
using AuthorizeNetLite.Interfaces;
using AuthorizeNetLite.Transactions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthorizeNetLite.Reporting {
  [ApiMethod("getTransactionDetailsRequest")]
  public class TransactionDetailRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication", Order = 1)]
    public Authentication Credentials { get; set; }
    [JsonProperty("transId", Order = 2), JsonConverter(typeof(StringPrimitiveConverter<long>))]
    public long TransactionID { get; set; }
  }

  public class TransactionDetailResponse : IAuthorizeNetResponse {
    [JsonProperty("transaction")]
    public TransactionDetail Transaction { get; set; }
    [JsonProperty("messages")]
    public ResponseStatus Status { get; set; }
  }

  public class TransactionDetail {
    [JsonProperty("transId"), JsonConverter(typeof(StringPrimitiveConverter<long>))]
    public long TransactionID { get; set; }
    [JsonProperty("refTransId"), JsonConverter(typeof(StringPrimitiveConverter<long>))]
    public long ReferencedTransactionID { get; set; }
    [JsonProperty("splitTenderId"), JsonConverter(typeof(StringPrimitiveConverter<long>))]
    public long SplitTenderID { get; set; }
    [JsonProperty("submitTimeUTC")]
    public DateTime SubmittedUtc { get; set; }
    [JsonProperty("submitTimeLocal")]
    public DateTime SubmittedLocal { get; set; }
    [JsonProperty("transactionType"), JsonConverter(typeof(StringEnumConverter))]
    public TransactionType TransactionType { get; set; }
    [JsonProperty("transactionStatus")]
    public string Status { get; set; }
    [JsonProperty("responseCode")]
    public int ResponseCode { get; set; }
    [JsonProperty("responseReasonCode")]
    public int ReasonCode { get; set; }
    [JsonProperty("responseReasonDescription")]
    public string ReasonDescription { get; set; }
    [JsonProperty("authCode")]
    public string AuthorizationCode { get; set; }
    [JsonProperty("AVSResponse")]
    public string AVSResponse { get; set; }
    [JsonProperty("cardCodeResponse")]
    public string CardCodeResponse { get; set; }
    [JsonProperty("batch")]
    public Batch Batch { get; set; }
    [JsonProperty("order")]
    public Order Order { get; set; }
    [JsonProperty("requestedAmount")]
    public decimal RequestedAmount { get; set; }
    [JsonProperty("authAmount")]
    public decimal AuthorizedAmount { get; set; }
    [JsonProperty("settleAmount")]
    public decimal SettledAmount { get; set; }
    [JsonProperty("tax")]
    public TransactionCharge Tax { get; set; }
    [JsonProperty("shipping")]
    public TransactionCharge Shipping { get; set; }
    [JsonProperty("duty")]
    public TransactionCharge Duty { get; set; }
    [JsonProperty("lineItems")]
    public IEnumerable<LineItem> LineItems { get; set; }
    [JsonProperty("prepaidBalanceRemaining")]
    public decimal PrepaidBalanceRemaining { get; set; }
    [JsonProperty("taxExempt")]
    public bool IsTaxExempt { get; set; }
    [JsonProperty("payment")]
    public IPayment Payment { get; set; }
    [JsonProperty("customer")]
    public Customer Customer { get; set; }
    [JsonProperty("billTo")]
    public Address BillingAddress { get; set; }
    [JsonProperty("shipTo")]
    public Address ShippingAddress { get; set; }
    [JsonProperty("recurringBilling")]
    public bool IsRecurring { get; set; }
    [JsonProperty("customerIP")]
    public string IPAddress { get; set; }
    [JsonProperty("product")]
    public string Product { get; set; }
    [JsonProperty("marketType")]
    public string MarketType { get; set; }
    [JsonProperty("mobileDeviceId")]
    public string MobileDeviceID { get; set; }
    [JsonProperty("customersSignature")]
    public string CustomerSignature { get; set; }
    [JsonProperty("returnItems")]
    public IEnumerable<ReturnedItem> ReturnedItems { get; set; }
    [JsonProperty("solution")]
    public Solution Solution { get; set; }
    [JsonProperty("emvDetails")]
    public EmvDetail EmvDetail { get; set; }
    [JsonProperty("FDSFilterAction")]
    public string FraudAction { get; set; }
    [JsonProperty("FDSFilters")]
    public IEnumerable<FraudFilter> FraudFilters { get; set; }
    //profile

    public TransactionDetail() {
      LineItems = Enumerable.Empty<LineItem>();
      ReturnedItems = Enumerable.Empty<ReturnedItem>();
      FraudFilters = Enumerable.Empty<FraudFilter>();
    }
  }
  public class EmvDetail {
    [JsonProperty("tagId")]
    public string TagID { get; set; }
    [JsonProperty("data")]
    public string Data { get; set; }
  }

  public class ReturnedItem {
    [JsonProperty("id")]
    public string ID { get; set; }
    [JsonProperty("dateUTC")]
    public DateTime UtcDate { get; set; }
    [JsonProperty("dateLocal")]
    public DateTime LocalDate { get; set; }
    [JsonProperty("code")]
    public string Code { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
  }

  public class Solution {
    [JsonProperty("id")]
    public string ID { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("vendorName")]
    public string Vendor { get; set; }
  }

  public class FraudFilter {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("action")]
    public string Action { get; set; }
  }
}