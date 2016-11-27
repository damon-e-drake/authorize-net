using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Response {
  [XmlRoot("messages")]
  public sealed class Status {
    [XmlElement("resultCode")]
    public string ResultCode { get; set; }
    [XmlElement("message")]
    public StatusMessage Message { get; set; }
  }
}