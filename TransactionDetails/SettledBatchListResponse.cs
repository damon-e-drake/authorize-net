using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "getSettledBatchListResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class SettledBatchListResponse : BaseResponse {
    [DataMember(Name = "batchList", Order = 1)]
    public List<Batch> Batches { get; set; }
  }
}