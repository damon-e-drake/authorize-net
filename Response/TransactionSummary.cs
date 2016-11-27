using System;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Response {
  [XmlRoot("transactionResponse")]
  public class TransactionSummary {
    [XmlElement("authCode")]
    public string AuthorizationCode { get; set; }
    [XmlElement("responseCode")]
    public int ResponseCode { get; set; }
    [XmlElement("avsResultCode")]
    public string AvsResultCode { get; set; }
    [XmlElement("cvvResultCode")]
    public string CvvResultCode { get; set; }
    [XmlElement("cavResultCode")]
    public int? CavResultCode { get; set; }
    [XmlElement("transId")]
    public long TransactionID { get; set; }
    [XmlElement("reftransId")]
    public long? ReferencedTransactionID { get; set; }
    [XmlElement("transHash")]
    public string Hash { get; set; }
    [XmlElement("testRequest")]
    public bool TestRequest { get; set; }
    [XmlElement("accountNumber")]
    public string AccountNumber { get; set; }
    [XmlElement("accountType")]
    public string AccountType { get; set; }

    [XmlArray("errors")]
    [XmlArrayItem("error", typeof(ResponseError))]
    public ResponseError[] Errors { get; set; }
  }
}