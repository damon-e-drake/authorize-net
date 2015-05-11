using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.TransactionDetails {
  [Serializable]
  [XmlRoot("getSettledBatchListRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class SettledBatchListRequest {
    [XmlElement("merchantAuthentication")]
    public Authentication Credentials { get; set; }
    [XmlElement("includeStatistics")]
    public bool IncludeStatistics { get; set; }
    [XmlElement("firstSettlementDate")]
    public DateTime StartDate { get; set; }
    [XmlElement("lastSettlementDate")]
    public DateTime EndDate { get; set; }

    [XmlIgnore]
    public SettledBatchListResponse Response {
      get {
        string xml = "";

        var serializer = new XmlSerializer(GetType());
        var xn = new XmlSerializerNamespaces();
        xn.Add("", "");
        using (MemoryStream ms = new MemoryStream()) {
          using (StreamWriter sw = new StreamWriter(ms)) {
            serializer.Serialize(sw, this);
            ms.Position = 0;
            xml = Encoding.UTF8.GetString(ms.ToArray());
          }
        }

        SettledBatchListResponse response = null;
        HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(StringEnum.GetValue(Configuration.Endpoint));
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
            var ser = new XmlSerializer(typeof(SettledBatchListResponse));
            response = (SettledBatchListResponse)ser.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
          }
          catch (Exception e) {
            response = null;
          }
        }

        return response;

      }
    }

    public SettledBatchListRequest() {
      Credentials = Configuration.MerchantAuthentication;
    }
  }
}