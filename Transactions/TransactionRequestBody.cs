using AuthorizeNetLite.Converters;
using AuthorizeNetLite.Enumerations;
using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace AuthorizeNetLite.Transactions {
  public class TransactionRequestBody {
    [JsonProperty("transactionType", Order = 1), JsonConverter(typeof(StringEnumConverter))]
    public TransactionType TransactionType { get; set; }
    [JsonProperty("amount", Order = 2), JsonConverter(typeof(StringPrimitiveConverter<decimal>))]
    public decimal Amount { get; set; }
    [JsonProperty("currencyCode", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public string CurrencyCode { get; set; }
    [JsonProperty("payment", Order = 4), JsonConverter(typeof(PaymentConverter))]
    public IPayment Payment { get; set; }
    //profile 5
    //solution 6
    //callId 7
    //terminalNumber 8
    [JsonProperty("authCode", Order = 9, NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorizationCode { get; set; }
    [JsonProperty("refTransID", Order = 10, NullValueHandling = NullValueHandling.Ignore)]
    public string ReferencedTransactionID { get; set; }
    //splitTenderId 11
    [JsonProperty("order", Order = 12, NullValueHandling = NullValueHandling.Ignore)]
    public Order OrderInformation { get; set; }
    [JsonProperty("lineItems", Order = 13, NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(LineItemsConverter))]
    public List<LineItem> LineItems { get; set; }
    [JsonProperty("tax", Order = 14, NullValueHandling = NullValueHandling.Ignore)]
    public TransactionCharge Tax { get; set; }
    [JsonProperty("duty", Order = 15, NullValueHandling = NullValueHandling.Ignore)]
    public TransactionCharge Duty { get; set; }
    [JsonProperty("shipping", Order = 16, NullValueHandling = NullValueHandling.Ignore)]
    public TransactionCharge Shipping { get; set; }
    //taxExempt bool 17
    [JsonProperty("poNumber", Order = 18, NullValueHandling = NullValueHandling.Ignore)]
    public string PurchaseOrderNumber { get; set; }
    [JsonProperty("customer", Order = 19, NullValueHandling = NullValueHandling.Ignore)]
    public Customer Customer { get; set; }
    [JsonProperty("billTo", Order = 20, NullValueHandling = NullValueHandling.Ignore)]
    public Address BillingAddress { get; set; }
    [JsonProperty("shipTo", Order = 21, NullValueHandling = NullValueHandling.Ignore)]
    public Address ShippingAddress { get; set; }
    [JsonProperty("customerIP", Order = 22, NullValueHandling = NullValueHandling.Ignore)]
    public string CustomerIPAddress { get; set; }
    //cardholderAuthentication 23
    //retial 24
    //employeeId 25
    [JsonProperty("transactionSettings", Order = 26, NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(TransactionSettingsConverter))]
    public List<TransactionSetting> Settings { get; set; }
    [JsonProperty("userFields", Order = 27, NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(UserFieldsConverter))]
    public List<UserField> UserFields { get; set; }
  }
}