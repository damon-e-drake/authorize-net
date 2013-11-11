using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [XmlRoot("merchantAuthentication")]
  public sealed class Authentication {
    [XmlElement("name")]
    public string ApiLogin { get; set; }
    [XmlElement("transactionKey")]
    public string TransactionKey { get; set; }
  }
}
