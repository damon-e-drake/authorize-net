using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AuthorizeNetLite.Response;

namespace AuthorizeNetLite.TransactionDetails {
  [Serializable]
  [XmlRoot("getTransactionDetailsResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionDetailResponse {
    [XmlElement("messages")]
    public Status Status { get; set; }

  }


}