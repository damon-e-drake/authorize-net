using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "statistic", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class BatchStatistic {
    [DataMember(Name = "accountType", Order = 0)]
    public string Account { get; set; }
    [DataMember(Name = "chargeAmount", Order = 1)]
    public decimal ChargeAmount { get; set; }
    [DataMember(Name = "chargeCount", Order = 2)]
    public int ChargeCount { get; set; }
    [DataMember(Name = "refundAmount", Order = 3)]
    public decimal RefundAmount { get; set; }
    [DataMember(Name = "refundCount", Order = 4)]
    public int RefundCount { get; set; }
    [DataMember(Name = "voidCount", Order = 5)]
    public int VoidCount { get; set; }
    [DataMember(Name = "DeclineCount", Order = 6)]
    public int DeclineCount { get; set; }
    [DataMember(Name = "ErrorCount", Order = 7)]
    public int ErrorCount { get; set; }
  }
}