using AuthorizeNetLite.Transactions;
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace AuthorizeNetLite.Request {

  [DataContract(Name = "transactionRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionBody {
    [DataMember(Name = "transactionType", Order = 0, EmitDefaultValue = false)]
    public string Type { get; set; }

    [DataMember(Name = "amount", Order = 1, EmitDefaultValue = false)]
    public decimal Amount { get; set; }

    [DataMember(Name = "payment", Order = 2, EmitDefaultValue = false)]
    public Payment Payment { get; set; }

    [DataMember(Name = "authCode", Order = 3, EmitDefaultValue = false)]
    public string AuthorizationCode { get; set; }

    [DataMember(Name = "refTransId", Order = 4, EmitDefaultValue = false)]
    public long ReferencedTransactionID { get; set; }

    [DataMember(Name = "order", Order = 5, EmitDefaultValue = false)]
    public Order OrderInformation { get; set; }

    [DataMember(Name = "lineItems", Order = 6, EmitDefaultValue = false )]
    public List<LineItem> Items { get; set; }

    [DataMember(Name = "tax", Order = 7, EmitDefaultValue = false)]
    public TransactionCharges Tax { get; set; }
    [DataMember(Name = "duty", Order = 8, EmitDefaultValue = false)]
    public TransactionCharges Duty { get; set; }
    [DataMember(Name = "shipping", Order = 9, EmitDefaultValue = false)]
    public TransactionCharges Shipping { get; set; }

    [DataMember(Name = "customer", Order = 10, EmitDefaultValue = false)]
    public Customer Customer { get; set; }

    [DataMember(Name = "billTo", Order = 11, EmitDefaultValue = false)]
    public Address BillingAddress { get; set; }
    [DataMember(Name = "shipTo", Order = 12, EmitDefaultValue = false)]
    public Address ShippingAddress { get; set; }

    [DataMember(Name = "poNumber", Order = 13, EmitDefaultValue = false)]
    public string PONumber { get; set; }

    [DataMember(Name = "customerIP", Order = 14, EmitDefaultValue = false)]
    public string CustomerIP { get; set; }

    [DataMember(Name = "transactionSettings", Order = 15, EmitDefaultValue = false)]
    public List<Setting> Settings { get; set; }

    [DataMember(Name = "userFields", Order = 16, EmitDefaultValue = false)]
    public List<UserField> UserFields { get; set; }
  }
}