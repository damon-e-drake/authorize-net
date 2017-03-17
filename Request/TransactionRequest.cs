using AuthorizeNetLite.Options;
using AuthorizeNetLite.Response;
using AuthorizeNetLite.Transactions;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Request {
  [XmlRoot("createTransactionRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionRequest : RequestBase<TransactionRequest, TransactionResponse> {
    [XmlElement("refId")]
    public string TransactionReferenceID { get; set; }

    [XmlElement("transactionRequest")]
    public TransactionBody Transaction { get; set; }
  }
}