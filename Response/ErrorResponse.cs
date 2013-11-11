using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Response {
  [Serializable]
  [XmlRoot("ErrorResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class ErrorResponse {
    [XmlElement("messages")]
    public Status Status { get; set; }
  }
}