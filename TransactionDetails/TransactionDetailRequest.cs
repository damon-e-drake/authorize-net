using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("getTransactionDetailsRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionDetailRequest {
    [XmlElement("merchantAuthentication")]
    public Authentication Credentials { get; set; }
    [XmlElement("transId")]
    public long TransactionID { get; set; }

    [XmlIgnore]
    public TransactionDetailResponse Response { get; set; }

    public void Post(GatewayUrl url) {
      byte[] xml;

      var serializer = new XmlSerializer(GetType());
      var xn = new XmlSerializerNamespaces();
      xn.Add("", "");
      using (MemoryStream ms = new MemoryStream()) {
        using (StreamWriter sw = new StreamWriter(ms)) {
          serializer.Serialize(sw, this);
          xml = ms.ToArray();
        }
      }

      HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(StringEnum.GetValue(url));
      authRequest.Method = "POST";
      authRequest.ContentLength = xml.Length;
      authRequest.ContentType = "text/xml";

      using (authRequest.GetRequestStream()) {
        sw.Write(xml, 0, xml.Length);
      }

      Response = null;

      HttpWebResponse authResponse = (HttpWebResponse)authRequest.GetResponse();

      using (StreamReader sr = new StreamReader(authResponse.GetResponseStream())) {
        var ser = new XmlSerializer(typeof(TransactionDetailResponse));
        Response = (TransactionDetailResponse)ser.Deserialize(new StringReader(sr.ReadToEnd()));
      }
    }
  }
}
