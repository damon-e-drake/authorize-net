using System;
using System.Xml.Serialization;
using AuthorizeNetLite.Response;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("getSettledBatchListResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class SettledBatchListResponse {
    [XmlElement("messages")]
    public Status Status { get; set; }

    [XmlArray("batchList")]
    [XmlArrayItem("batch", typeof(Batch))]
    public Batch[] Batches { get; set; }
  }
}