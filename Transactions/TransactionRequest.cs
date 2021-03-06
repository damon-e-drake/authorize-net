﻿using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  [ApiMethod("createTransactionRequest")]
  public class TransactionRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication", Order = 1)]
    public Authentication Credentials { get; set; }
    [JsonProperty("refId", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string ReferenceID { get; set; }
    [JsonProperty("transactionRequest", Order = 3)]
    public TransactionRequestBody TransactionBody { get; set; }
  }
}