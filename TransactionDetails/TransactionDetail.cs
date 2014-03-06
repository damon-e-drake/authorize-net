using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "transaction", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionDetail {
    [DataMember(Name = "transId", EmitDefaultValue = false, Order = 0)]
    public long TransactionID { get; set; }
    [DataMember(Name = "refTransId", EmitDefaultValue = false, Order = 1)]
    public long ReferencedTransaction { get; set; }
    [DataMember(Name = "splitTenderId", EmitDefaultValue = false, Order = 2)]
    public long SplitTenderID { get; set; }
    [DataMember(Name = "submitTimeUTC", EmitDefaultValue = false, Order = 3)]
    public DateTime SubmittedUTC { get; set; }
    [DataMember(Name = "submitTimeLocal", EmitDefaultValue = false, Order = 4)]
    public DateTime SubmittedLocal { get; set; }
    [DataMember(Name = "transactionType", EmitDefaultValue = false, Order = 5)]
    public string TransactionType { get; set; }
    [DataMember(Name = "transactionStatus", EmitDefaultValue = false, Order = 6)]
    public string Status { get; set; }
    [DataMember(Name = "responseCode", EmitDefaultValue = false, Order = 7)]
    public int ResponseCode { get; set; }
    [DataMember(Name = "responseReasonCode", EmitDefaultValue = false, Order = 8)]
    public int ResponseReasonCode { get; set; }
    [DataMember(Name = "responseReasonDescription", EmitDefaultValue = false, Order = 9)]
    public string ResponseReasonDescription { get; set; }
    [DataMember(Name = "authCode", EmitDefaultValue = false, Order = 10)]
    public string AuthorizationCode { get; set; }
    [DataMember(Name = "AVSResponse", EmitDefaultValue = false, Order = 11)]
    public string AVSResponse { get; set; }
    [DataMember(Name = "cardCodeResponse", EmitDefaultValue = false, Order = 12)]
    public string CardCodeResponse { get; set; }
    [DataMember(Name = "CAVVResponse", EmitDefaultValue = false, Order = 13)]
    public string CardAuthResponse { get; set; }
    [DataMember(Name = "FDSFilterAction", EmitDefaultValue = false, Order = 14)]
    public string FraudFilterAction { get; set; }
    [DataMember(Name = "FDSFilters", EmitDefaultValue = false, Order = 15)]
    public List<FraudFilter> FraudFilters { get; set; }
    [DataMember(Name = "batch", EmitDefaultValue = false, Order = 16)]
    public Batch Batch { get; set; }
    [DataMember(Name = "order", EmitDefaultValue = false, Order = 17)]
    public Order OrderInformation { get; set; }
    [DataMember(Name = "requestedAmount", EmitDefaultValue = false, Order = 18)]
    public decimal RequestedAmount { get; set; }
    [DataMember(Name = "authAmount", EmitDefaultValue = false, Order = 19)]
    public decimal AuthorizedAmount { get; set; }
    [DataMember(Name = "settleAmount", EmitDefaultValue = false, Order = 20)]
    public decimal SettledAmount { get; set; }
    [DataMember(Name = "tax", EmitDefaultValue = false, Order = 21)]
    public TransactionCharges Tax { get; set; }
    [DataMember(Name = "shipping", EmitDefaultValue = false, Order = 22)]
    public TransactionCharges Shipping { get; set; }
    [DataMember(Name = "duty", EmitDefaultValue = false, Order = 23)]
    public TransactionCharges Duty { get; set; }
    [DataMember(Name = "lineItems", EmitDefaultValue = false, Order = 24)]
    public List<LineItem> Items { get; set; }
    [DataMember(Name = "prepaidBalanceRemaining", EmitDefaultValue = false, Order = 25)]
    public decimal PrepaidBalance { get; set; }
    [DataMember(Name = "taxExempt", EmitDefaultValue = false, Order = 26)]
    public bool TaxExempt { get; set; }
    [DataMember(Name = "payment", EmitDefaultValue = false, Order = 27)]
    public Payment Payment { get; set; }
    [DataMember(Name = "customer", EmitDefaultValue = false, Order = 28)]
    public Customer Customer { get; set; }
    [DataMember(Name = "billTo", EmitDefaultValue = false, Order = 29)]
    public Address BillingAddress { get; set; }
    [DataMember(Name = "shipTo", EmitDefaultValue = false, Order = 30)]
    public Address ShippingAddress { get; set; }
    [DataMember(Name = "recurringBilling", EmitDefaultValue = false, Order = 31)]
    public bool RecurringBilling { get; set; }
    [DataMember(Name = "customerIP", EmitDefaultValue = false, Order = 32)]
    public string CustomerIP { get; set; }
  }

  [DataContract(Name = "FDSFilter", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class FraudFilter {
    [DataMember(Name = "name", EmitDefaultValue = false, Order = 0)]
    public string Name { get; set; }
    [DataMember(Name = "action", EmitDefaultValue = false, Order = 1)]
    public string Action { get; set; }
  }
}