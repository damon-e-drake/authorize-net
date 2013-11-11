using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Response {
  [Serializable]
  [XmlRoot("message")]
  public class StatusMessage {
    [XmlElement("code")]
    public string Code { get; set; }
    [XmlElement("text")]
    public string Text { get; set; }
  }
}