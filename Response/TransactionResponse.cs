using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.Response {
  [DataContract(Name = "createTransactionResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class TransactionResponse : BaseResponse {
    [DataMember(Name = "transactionResponse", EmitDefaultValue = false, Order = 2)]
    public TransactionSummary Transaction { get; set; }
  }
}