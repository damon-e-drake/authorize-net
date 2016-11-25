using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.TransactionDetails {
  [XmlRoot("transaction")]
  public sealed class TransactionDetail {
    [XmlElement("transId")]
    public long TransactionID { get; set; }
    [XmlElement("submitTimeUTC")]
    public DateTime SubmittedUTC { get; set; }
    [XmlElement("submitTimeLocal")]
    public DateTime SubmittedLocal { get; set; }
    [XmlElement("transactionType")]
    public string TransactionType { get; set; }

    [XmlElement("responseCode")]
    public int ResponseCode { get; set; }
    [XmlElement("responseReasonCode")]
    public int ResponseReasonCode { get; set; }
    [XmlElement("responseReasonDescription")]
    public string ResponseReasonDescription { get; set; }

    [XmlElement("authCode")]
    public string AuthorizationCode { get; set; }

    [XmlElement("AVSResponse")]
    public string AVSResponse { get; set; }
    [XmlElement("cardCodeResponse")]
    public string CardCodeResponse { get; set; }

    [XmlElement("order")]
    public Order OrderInformation { get; set; }

    [XmlElement("taxExempt")]
    public bool TaxExempt { get; set; }

    [XmlElement("authAmount")]
    public decimal AuthorizedAmount { get; set; }
    [XmlElement("settleAmount")]
    public decimal SettledAmount { get; set; }

    [XmlElement("transactionStatus")]
    public string Status { get; set; }

    [XmlArray("payment")]
    [XmlArrayItem("creditCard", typeof(CreditCard))]
    [XmlArrayItem("bankAccount", typeof(ECheck))]
    public Payment[] Payment { get; set; }

    [XmlArray("lineItems")]
    [XmlArrayItem("lineItem", typeof(LineItem))]
    public LineItem[] Items { get; set; }

    [XmlElement("tax")]
    public TransactionCharges Tax { get; set; }
    [XmlElement("duty")]
    public TransactionCharges Duty { get; set; }
    [XmlElement("shipping")]
    public TransactionCharges Shipping { get; set; }

    [XmlElement("customer")]
    public Customer Customer { get; set; }

    [XmlElement("billTo")]
    public Address BillingAddress { get; set; }
    [XmlElement("shipTo")]
    public Address ShippingAddress { get; set; }

    [XmlElement("customerIP")]
    public string CustomerIP { get; set; }

    [XmlArray("transactionSettings")]
    [XmlArrayItem("setting", typeof(Setting))]
    public Setting[] Settings { get; set; }

    [XmlArray("userFields")]
    [XmlArrayItem("userField", typeof(UserField))]
    public UserField[] UserFields { get; set; }
  }
}
