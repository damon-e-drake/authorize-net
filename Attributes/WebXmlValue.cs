using System;

namespace AuthorizeNetLite.Attributes {
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
  public class WebXmlValue : Attribute {
    public string WebLabel { get; private set; }
    public string XmlElement { get; private set; }

    public WebXmlValue(string WebLabel, string XmlElement) {
      this.WebLabel = WebLabel;
      this.XmlElement = XmlElement;
    }
  }
}