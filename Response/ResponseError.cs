using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Response {
  [Serializable]
  [XmlRoot("error")]
  public class ResponseError {
    [XmlElement("errorCode")]
    public string Code { get; set; }
    [XmlElement("errorText")]
    public string Text { get; set; }
  }
}