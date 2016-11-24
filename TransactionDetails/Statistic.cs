using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("statistic")]
  public sealed class BatchStatistic {
    [XmlElement("accountType")]
    public string Account { get; set; }
    [XmlElement("chargeAmount")]
    public decimal ChargeAmount { get; set; }
    [XmlElement("chargeCount")]
    public int ChargeCount { get; set; }
    [XmlElement("refundAmount")]
    public decimal RefundAmount { get; set; }
    [XmlElement("refundCount")]
    public int RefundCount { get; set; }
    [XmlElement("voidCount")]
    public int VoidCount { get; set; }
    [XmlElement("DeclineCount")]
    public int DeclineCount { get; set; }
    [XmlElement("ErrorCount")]
    public int ErrorCount { get; set; }
  }
}