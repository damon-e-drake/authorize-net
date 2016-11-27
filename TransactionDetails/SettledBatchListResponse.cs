using System;
using System.Xml.Serialization;
using AuthorizeNetLite.Request;
using AuthorizeNetLite.Response;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("getSettledBatchListResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class SettledBatchListResponse : ResponseBase {

    [XmlArray("batchList")]
    [XmlArrayItem("batch", typeof(Batch))]
    public Batch[] Batches { get; set; }
  }
}