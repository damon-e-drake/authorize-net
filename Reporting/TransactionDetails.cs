using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizeNetLite.Transactions;
using AuthorizeNetLite.Converters;
using Newtonsoft.Json.Converters;
using AuthorizeNetLite.Enumerations;

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

  }

}
