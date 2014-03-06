using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AuthorizeNetLite.Response {
  [DataContract(Name = "transactionResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class TransactionSummary {
    [DataMember(Name = "responseCode", EmitDefaultValue = false, Order = 0)]
    public int ResponseCode { get; set; }
    [DataMember(Name = "authCode", EmitDefaultValue = false, Order = 1)]
    public string AuthorizationCode { get; set; }

    [DataMember(Name = "avsResultCode", EmitDefaultValue = false, Order = 2)]
    public string AvsResultCode { get; set; }
    [DataMember(Name = "cvvResultCode", EmitDefaultValue = false, Order = 3)]
    public string CvvResultCode { get; set; }
    [DataMember(Name = "cavResultCode", EmitDefaultValue = false, Order = 4)]
    public string CavResultCode { get; set; }
    [DataMember(Name = "transId", EmitDefaultValue = false, Order = 5)]
    public long TransactionID { get; set; }
    [DataMember(Name = "reftransId", EmitDefaultValue = false, Order = 6)]
    public long ReferencedTransactionID { get; set; }
    [DataMember(Name = "transHash", EmitDefaultValue = false, Order = 7)]
    public string Hash { get; set; }
    [DataMember(Name = "testRequest", EmitDefaultValue = false, Order = 8)]
    public bool TestRequest { get; set; }
    [DataMember(Name = "accountNumber", EmitDefaultValue = false, Order = 9)]
    public string AccountNumber { get; set; }
    [DataMember(Name = "accountType", EmitDefaultValue = false, Order = 10)]
    public string AccountType { get; set; }

    [DataMember(Name = "messages", EmitDefaultValue = false, Order = 11)]
    public List<Message> Messages { get; set; }
    [DataMember(Name = "errors", EmitDefaultValue = false, Order = 12)]
    public List<ResponseError> Errors { get; set; }
  }
}