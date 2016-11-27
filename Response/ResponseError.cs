using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Response {
  [XmlRoot("error")]
  public class ResponseError {
    [XmlElement("errorCode")]
    public string Code { get; set; }
    [XmlElement("errorText")]
    public string Text { get; set; }
  }
}