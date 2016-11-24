using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("batch")]
  public sealed class Batch {
    [XmlElement("batchId")]
    public long BatchID { get; set; }
    [XmlElement("settlementTimeUTC")]
    public DateTime SettledUTC { get; set; }
    [XmlElement("settlementTimeLocal")]
    public DateTime SettledLocal { get; set; }
    [XmlElement("settlementState")]
    public string Status { get; set; }
    [XmlElement("paymentMethod")]
    public string PaymentMethod { get; set; }

    [XmlArray("statistics")]
    [XmlArrayItem("statistic", typeof(BatchStatistic))]
    public BatchStatistic[] Statistics { get; set; }
  }
}