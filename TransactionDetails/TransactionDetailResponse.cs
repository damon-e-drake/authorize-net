using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using AuthorizeNetLite.Response;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "getTransactionDetailsResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionDetailResponse : BaseResponse {
    [DataMember(Name = "transaction", Order = 1)]
    public TransactionDetail Transaction { get; set; }
  }
}