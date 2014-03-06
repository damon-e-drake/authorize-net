using System;
using System.Runtime.Serialization;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "transaction", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionDetailSummary {
    [DataMember(Name = "transId", Order = 0)]
    public long TransactionID { get; set; }
    [DataMember(Name = "submitTimeUTC", Order = 1)]
    public DateTime SubmittedUTC { get; set; }
    [DataMember(Name = "submitTimeLocal", Order = 2)]
    public DateTime SubmittedLocal { get; set; }
    [DataMember(Name = "transactionStatus", Order = 3)]
    public string Status { get; set; }
    [DataMember(Name = "invoiceNumber", Order = 4)]
    public string InvoiceNumber { get; set; }
    [DataMember(Name = "firstName", Order = 5)]
    public string FirstName { get; set; }
    [DataMember(Name = "lastName", Order = 6)]
    public string LastName { get; set; }
    [DataMember(Name = "accountType", Order = 7)]
    public string AccountType { get; set; }
    [DataMember(Name = "accountNumber", Order = 8)]
    public string AccountNumber { get; set; }
    [DataMember(Name = "settleAmount" , Order = 9)]
    public decimal SettlementAmount { get; set; }
  }
}