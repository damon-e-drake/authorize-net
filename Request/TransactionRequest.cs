using AuthorizeNetLite.Options;
using AuthorizeNetLite.Response;
using AuthorizeNetLite.Transactions;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Request {
  [Serializable]
  [XmlRoot("createTransactionRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransationRequest {
    [XmlElement("merchantAuthentication")]
    public Authentication Credentials { get; set; }
    [XmlElement("refId")]
    public string TransactionReferenceID { get; set; }

    [XmlElement("transactionRequest")]
    public TransactionBody Transaction { get; set; }

    [XmlIgnore]
    public TransactionResponse Response { get; private set; }
    [XmlIgnore]
    public ErrorResponse Error { get; private set; }

    public void Post(GatewayUrl url) {
      string xml = "";

      var serializer = new XmlSerializer(this.GetType());
      var xn = new XmlSerializerNamespaces();
      xn.Add("", "");
      using (MemoryStream ms = new MemoryStream()) {
        using (StreamWriter sw = new StreamWriter(ms)) {
          serializer.Serialize(sw, this);
          ms.Position = 0;
          xml = Encoding.UTF8.GetString(ms.ToArray());
        }
      }

      this.Response = null;
      this.Error = null;

      try {
        HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(StringEnum.GetValue(url));
        authRequest.Method = "POST";
        authRequest.ContentLength = xml.Length;
        authRequest.ContentType = "text/xml";

        using (StreamWriter sw = new StreamWriter(authRequest.GetRequestStream())) {
          sw.Write(xml);
        }

        HttpWebResponse authResponse = (HttpWebResponse)authRequest.GetResponse();

        using (StreamReader sr = new StreamReader(authResponse.GetResponseStream())) {
          xml = sr.ReadToEnd();
          try {
            var ser = new XmlSerializer(typeof(TransactionResponse));
            this.Response = (TransactionResponse)ser.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
          }
          catch {
            this.Response = null;
            var ser = new XmlSerializer(typeof(ErrorResponse));
            this.Error = (ErrorResponse)ser.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
          }
        }
      }
      catch (WebException w) {
        Console.WriteLine(w.Message);
      }
    }
  }
}
