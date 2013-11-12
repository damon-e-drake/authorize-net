//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Xml;
//using System.Xml.Linq;
//using AuthorizeNetLite.Attributes;
//using AuthorizeNetLite.Options;
//using System.Runtime.Serialization;
//using AuthorizeNetLite.Response;
//using System.Xml.Serialization;

//namespace AuthorizeNetLite {
  
//  public interface iAuthNetXmlUsuable {
//    string ToXml();
//  }

//  public class ECheckInformation : iAuthNetXmlUsuable {
//    [WebXmlValue("Account Type", "accountType")]
//    public string AccountType { get; set; }

//    [WebXmlValue("Routing Number", "routingNumber")]
//    public string RoutingNumber { get; set; }

//    [WebXmlValue("Account Number", "accountNumber")]
//    public string AccountNumber { get; set; }

//    [WebXmlValue("Name on Account", "nameOnAccount")]
//    public string AccountName { get; set; }

//    [WebXmlValue("Check Type", "echeckType")]
//    public string CheckType { get; set; }

//    [WebXmlValue("Bank Name", "bankName")]
//    public string BankName { get; set; }

//    [WebXmlValue("Check Number", "checkNumber")]
//    public string CheckNumber { get; set; }


//    public string ToXml() {
//      StringBuilder sb = new StringBuilder();
//      sb.Append("<bankAccount>");

//      foreach (var prop in this.GetType().GetProperties()) {
//        WebXmlValue[] vals = prop.GetCustomAttributes(typeof(WebXmlValue), false) as WebXmlValue[];
//        if (vals.Length > 0) {
//          try {
//            sb.AppendFormat("<{0}>{1}</{0}>", vals[0].XmlElement, prop.GetValue(this, null).ToString());
//          }
//          catch {

//          }
//        }
//      }

//      sb.Append("</bankAccount>");
//      return sb.ToString();
//    }
//  }



//  public class UserField : iAuthNetXmlUsuable {
//    [WebXmlValue("User Defined Name", "name")]
//    public String Name { get; set; }

//    [WebXmlValue("User Defined Value", "value")]
//    public String Value { get; set; }

//    public string ToXml() {
//      StringBuilder sb = new StringBuilder();
//      sb.Append("<userField>");

//      foreach (var prop in this.GetType().GetProperties()) {
//        WebXmlValue[] vals = prop.GetCustomAttributes(typeof(WebXmlValue), false) as WebXmlValue[];
//        if (vals.Length > 0) {
//          try {
//            sb.AppendFormat("<{0}>{1}</{0}>", vals[0].XmlElement, prop.GetValue(this, null).ToString());
//          }
//          catch {

//          }
//        }
//      }

//      sb.Append("</userField>");
//      return sb.ToString();
//    }
//  }
//  
//  public class TransactionSetting : iAuthNetXmlUsuable {
//    [WebXmlValue("Setting Name", "settingName")]
//    public String Name { get; set; }

//    [WebXmlValue("Setting Value", "settingValue")]
//    public String Value { get; set; }

//    public string ToXml() {
//      StringBuilder sb = new StringBuilder();
//      sb.Append("<setting>");

//      foreach (var prop in this.GetType().GetProperties()) {
//        WebXmlValue[] vals = prop.GetCustomAttributes(typeof(WebXmlValue), false) as WebXmlValue[];
//        if (vals.Length > 0) {
//          try {
//            sb.AppendFormat("<{0}>{1}</{0}>", vals[0].XmlElement, prop.GetValue(this, null).ToString());
//          }
//          catch {

//          }
//        }
//      }

//      sb.Append("</setting>");
//      return sb.ToString();
//    }
//  }

//  public class ResponseError {
//    private XmlNode ErrorNode { get; set; }
//    public string ErrorCode {
//      get {
//        return this.ErrorNode.SelectSingleNode("errorCode") != null ? this.ErrorNode.SelectSingleNode("errorCode").InnerText : null;
//      }
//    }

//    public string ErrorText {
//      get {
//        return this.ErrorNode.SelectSingleNode("errorText") != null ? this.ErrorNode.SelectSingleNode("errorText").InnerText : null;
//      }
//    }

//    public ResponseError(XmlNode XNode) {
//      this.ErrorNode = XNode;
//    }
//  }
//  public class ResponseMessage {
//    private XmlNode MsgNode { get; set; }
//    public string Code {
//      get {
//        return this.MsgNode.SelectSingleNode("code") != null ? this.MsgNode.SelectSingleNode("code").InnerText : null;
//      }
//    }

//    public string Description {
//      get {
//        return this.MsgNode.SelectSingleNode("description") != null ? this.MsgNode.SelectSingleNode("description").InnerText : null;
//      }
//    }

//    public ResponseMessage(XmlNode XNode) {
//      this.MsgNode = XNode;
//    }
//  }

//  public class BatchTransactionsResponse {
//    private XmlDocument xDoc = new XmlDocument();
//    public bool Valid { get; private set; }

//    public List<Transaction> Transactions { get; private set; }

//    public BatchTransactionsResponse(string XmlResponse) {
//      this.Transactions = new List<Transaction>();

//      try {
//        this.xDoc.LoadXml(XmlResponse);

//        if (this.xDoc.DocumentElement.SelectSingleNode("messages/resultCode").InnerText == "Ok") {
//          foreach (XmlNode n in this.xDoc.DocumentElement.SelectNodes("transactions/transaction")) {
//            this.Transactions.Add(new Transaction(n));
//          }
//        }
//      }
//      catch (Exception) {
//        this.Valid = false;
//      }
//    }
//  }
//  public class SettledBatchResponse {

//    private XmlDocument xDoc = new XmlDocument();
//    public bool Valid { get; private set; }

//    public List<Batch> Batches { get; private set; }

//    public SettledBatchResponse(string XmlResponse) {
//      this.Batches = new List<Batch>();

//      try {
//        this.xDoc.LoadXml(XmlResponse);

//        if (this.xDoc.DocumentElement.SelectSingleNode("messages/resultCode").InnerText == "Ok") {
//          foreach (XmlNode n in this.xDoc.DocumentElement.SelectNodes("batchList/batch")) {
//            this.Batches.Add(new Batch(n));
//          }
//        }

//      }
//      catch (Exception) {
//        this.Valid = false;
//      }
//    }
//  }
//  public class Transaction {
//    private XmlNode TxnInfo { get; set; }

//    public Int64 ID {
//      get {
//        return this.TxnInfo.SelectSingleNode("transId") != null ? Int64.Parse(this.TxnInfo.SelectSingleNode("transId").InnerText) : 0;
//      }
//    }
//    public Int64 BatchID { get; set; }
//    public DateTime SubmitTime {
//      get {
//        return DateTime.Parse(this.TxnInfo.SelectSingleNode("submitTimeLocal").InnerText);
//      }
//    }
//    private string _status = null;
//    public string Status {
//      get {
//        if (string.IsNullOrEmpty(this._status)) {
//          this._status = this.TxnInfo.SelectSingleNode("transactionStatus").InnerText;
//        }
//        return this._status;
//      }
//      set {
//        this._status = value;
//      }
//    }
//    public string Invoice {
//      get {
//        return this.TxnInfo.SelectSingleNode("invoice") != null ? this.TxnInfo.SelectSingleNode("invoice").InnerText : null;
//      }
//    }
//    public string FirstName {
//      get {
//        return this.TxnInfo.SelectSingleNode("firstName") != null ? this.TxnInfo.SelectSingleNode("firstName").InnerText : null;
//      }
//    }
//    public string LastName {
//      get {
//        return this.TxnInfo.SelectSingleNode("lastName") != null ? this.TxnInfo.SelectSingleNode("lastName").InnerText : null;
//      }
//    }
//    public string AccountType {
//      get {
//        return this.TxnInfo.SelectSingleNode("accountType") != null ? this.TxnInfo.SelectSingleNode("accountType").InnerText : null;
//      }
//    }
//    public string AccountNumber {
//      get {
//        return this.TxnInfo.SelectSingleNode("accountNumber") != null ? this.TxnInfo.SelectSingleNode("accountNumber").InnerText : null;
//      }
//    }
//    public decimal Amount {
//      get {
//        return this.TxnInfo.SelectSingleNode("settleAmount") != null ? decimal.Parse(this.TxnInfo.SelectSingleNode("settleAmount").InnerText) : 0.0m;
//      }
//    }

//    public Transaction(XmlNode XNode) {
//      this.TxnInfo = XNode;
//    }
//  }
//  public class Batch {
//    private XmlNode BatchNode { get; set; }
//    public Int64 ID {
//      get {
//        return this.BatchNode.SelectSingleNode("batchId") != null ? Int64.Parse(this.BatchNode.SelectSingleNode("batchId").InnerText) : 0;
//      }
//    }
//    public DateTime SettlementDate {
//      get {
//        return DateTime.Parse(this.BatchNode.SelectSingleNode("settlementTimeLocal").InnerText);
//      }
//    }
//    public string Status {
//      get {
//        string status = this.BatchNode.SelectSingleNode("settlementState").InnerText;
//        //using (AuthorizeNetDataContext ctx = new AuthorizeNetDataContext()) {
//        //  var x = (from t in ctx.DataValuePairs where t.Parameter == "settlementState" && t.AuthNetCode == status select new { t.Value }).Single();
//        //  status = x.Value;
//        //}
//        return status;
//      }
//    }
//    public List<BatchStatistic> BatchStatistics { get; set; }

//    public Batch(XmlNode XNode) {
//      this.BatchNode = XNode;
//      this.BatchStatistics = new List<BatchStatistic>();

//      foreach (XmlNode x in XNode.SelectNodes("statistics/statistic")) {
//        this.BatchStatistics.Add(new BatchStatistic(x));
//      }
//    }
//  }
//  public class BatchStatistic {

//    private XmlNode Statistic { get; set; }

//    public string AccountType {
//      get {
//        return Statistic.SelectSingleNode("accountType") != null ? Statistic.SelectSingleNode("accountType").InnerText : "";
//      }
//    }
//    public decimal ChargeAmount {
//      get {
//        return Statistic.SelectSingleNode("chargeAmount") != null ? decimal.Parse(Statistic.SelectSingleNode("chargeAmount").InnerText) : 0.0m;
//      }
//    }
//    public int ChargeCount {
//      get {
//        return Statistic.SelectSingleNode("chargeCount") != null ? int.Parse(Statistic.SelectSingleNode("chargeCount").InnerText) : 0;
//      }
//    }
//    public decimal RefundAmount {
//      get {
//        return Statistic.SelectSingleNode("refundAmount") != null ? decimal.Parse(Statistic.SelectSingleNode("refundAmount").InnerText) : 0.0m;
//      }
//    }
//    public int RefundCount {
//      get {
//        return Statistic.SelectSingleNode("refundCount") != null ? int.Parse(Statistic.SelectSingleNode("refundCount").InnerText) : 0;
//      }
//    }
//    public int VoidCount {
//      get {
//        return Statistic.SelectSingleNode("voidCount") != null ? int.Parse(Statistic.SelectSingleNode("voidCount").InnerText) : 0;
//      }
//    }
//    public int DeclineCount {
//      get {
//        return Statistic.SelectSingleNode("declineCount") != null ? int.Parse(Statistic.SelectSingleNode("declineCount").InnerText) : 0;
//      }
//    }
//    public int ErrorCount {
//      get {
//        return Statistic.SelectSingleNode("errorCount") != null ? int.Parse(Statistic.SelectSingleNode("errorCount").InnerText) : 0;
//      }
//    }
//    public BatchStatistic(XmlNode XNode) {
//      this.Statistic = XNode;
//    }
//  }

//  public class AuthorizeNetRequest {
//    private string APILogin { get; set; }
//    private string TransactionKey { get; set; }

//    public StringBuilder RequestXml { get; private set; }
//    public string ResponseXml { get; private set; }
//    public TransactionResponse Response { get; private set; }

//    public double Amount { get; set; }
//    public string CustomerIP { get; set; }
//    public string ReferenceID { get; set; }

//    public GatewayUrl GatewayUrl { get; set; }
//    public TransactionType TransactionType { get; set; }
//    public ChargeType ChargeType { get; set; }

//    public CreditCardInformation CardInformation { get; set; }
//    public ECheckInformation CheckInformation { get; set; }

//    public CustomerInformation CustomerInfo { get; set; }
//    public AddressInformation BillingInfo { get; set; }
//    public AddressInformation ShippingInfo { get; set; }

//    public Order OrderInformation { get; set; }
//    public List<LineItem> LineItems { get; set; }
//    public List<UserField> UserFields { get; set; }
//    public List<TransactionSetting> TransactionSettings { get; set; }

//    public AuthorizeNetRequest(string APILogin, string TransactionKey) {
//      this.APILogin = APILogin;
//      this.TransactionKey = TransactionKey;
//      this.LineItems = new List<LineItem>();
//      this.UserFields = new List<UserField>();
//      this.TransactionSettings = new List<TransactionSetting>();

//      this.RequestXml = new StringBuilder();
//    }

//    private void ConfigureChargeRequest() {
//      this.RequestXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
//      this.RequestXml.Append("<createTransactionRequest xmlns=\"AnetApi/xml/v1/schema/AnetApiSchema.xsd\">");

//      this.RequestXml.Append("<merchantAuthentication>");
//      this.RequestXml.AppendFormat("<name>{0}</name>", this.APILogin);
//      this.RequestXml.AppendFormat("<transactionKey>{0}</transactionKey>", this.TransactionKey);
//      this.RequestXml.Append("</merchantAuthentication>");

//      this.RequestXml.Append("<transactionRequest>");
//      this.RequestXml.AppendFormat("<transactionType>{0}</transactionType>", StringEnum.GetValue(this.TransactionType));
//      this.RequestXml.AppendFormat("<amount>{0}</amount>", this.Amount);

//      this.RequestXml.Append("<payment>");
//      if (this.ChargeType == ChargeType.ECheck) { this.RequestXml.Append(this.CheckInformation.ToXml()); } else { this.RequestXml.Append(this.CardInformation.ToXml()); }
//      this.RequestXml.Append("</payment>");

//      if (this.OrderInformation != null) { this.RequestXml.Append(this.OrderInformation.ToXml()); }

//      if (this.LineItems.Count > 0) {
//        this.RequestXml.Append("<lineItems>");
//        foreach (LineItem item in this.LineItems) { this.RequestXml.Append(item.ToXml()); }
//        this.RequestXml.Append("</lineItems>");
//      }

//      if (this.CustomerInfo != null) { this.RequestXml.Append(this.CustomerInfo.ToXml()); }
//      if (this.BillingInfo != null) { this.RequestXml.AppendFormat("<billTo>{0}</billTo>", this.BillingInfo.ToXml()); }
//      if (this.ShippingInfo != null) { this.RequestXml.AppendFormat("<shipTo>{0}</shipTo>", this.ShippingInfo.ToXml()); }

//      if (!string.IsNullOrEmpty(this.CustomerIP)) { this.RequestXml.AppendFormat("<{0}>{1}</{0}>", "customerIP", this.CustomerIP); }

//      if (this.TransactionSettings.Count > 0) {
//        this.RequestXml.Append("<transactionSettings>");
//        foreach (TransactionSetting item in this.TransactionSettings) { this.RequestXml.Append(item.ToXml()); }
//        this.RequestXml.Append("</transactionSettings>");
//      }

//      if (this.UserFields.Count > 0) {
//        this.RequestXml.Append("<userFields>");
//        foreach (UserField item in this.UserFields) { this.RequestXml.Append(item.ToXml()); }
//        this.RequestXml.Append("</userFields>");
//      }

//      this.RequestXml.Append("</transactionRequest>");
//      this.RequestXml.Append("</createTransactionRequest>");
//    }
//    private void ConfigureVoidRequest() {
//      this.RequestXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
//      this.RequestXml.Append("<createTransactionRequest xmlns=\"AnetApi/xml/v1/schema/AnetApiSchema.xsd\">");

//      this.RequestXml.Append("<merchantAuthentication>");
//      this.RequestXml.AppendFormat("<name>{0}</name>", this.APILogin);
//      this.RequestXml.AppendFormat("<transactionKey>{0}</transactionKey>", this.TransactionKey);
//      this.RequestXml.Append("</merchantAuthentication>");
//      this.RequestXml.Append("<transactionRequest>");
//      this.RequestXml.AppendFormat("<transactionType>{0}</transactionType>", StringEnum.GetValue(this.TransactionType));
//      this.RequestXml.AppendFormat("<{0}>{1}</{0}>", "refTransId", this.ReferenceID);
//      this.RequestXml.Append("</transactionRequest>");
//      this.RequestXml.Append("</createTransactionRequest>");
//    }
//    private void ConfigureUnsettledBatchRequestList() {
//      this.RequestXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
//      this.RequestXml.Append("<getUnsettledTransactionListRequest xmlns=\"AnetApi/xml/v1/schema/AnetApiSchema.xsd\">");

//      this.RequestXml.Append("<merchantAuthentication>");
//      this.RequestXml.AppendFormat("<name>{0}</name>", this.APILogin);
//      this.RequestXml.AppendFormat("<transactionKey>{0}</transactionKey>", this.TransactionKey);
//      this.RequestXml.Append("</merchantAuthentication>");
//      this.RequestXml.Append("</getUnsettledTransactionListRequest>");
//    }
//    private void ConfigureSettledBatchRequestList() {
//      this.RequestXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
//      this.RequestXml.Append("<getSettledBatchListRequest xmlns=\"AnetApi/xml/v1/schema/AnetApiSchema.xsd\">");

//      this.RequestXml.Append("<merchantAuthentication>");
//      this.RequestXml.AppendFormat("<name>{0}</name>", this.APILogin);
//      this.RequestXml.AppendFormat("<transactionKey>{0}</transactionKey>", this.TransactionKey);
//      this.RequestXml.Append("</merchantAuthentication>");
//      this.RequestXml.Append("<includeStatistics>true</includeStatistics>");
//      this.RequestXml.AppendFormat("<firstSettlementDate>{0}</firstSettlementDate>", string.Format("{0:yyyy-MM-ddTHH:mm:ss}", DateTime.Now.AddDays(-31)));
//      this.RequestXml.AppendFormat("<lastSettlementDate>{0}</lastSettlementDate>", string.Format("{0:yyyy-MM-ddTHH:mm:ss}", DateTime.Now));
//      this.RequestXml.Append("</getSettledBatchListRequest>");
//    }
//    private void ConfigureTransactionListRequest(string BatchID) {
//      this.RequestXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
//      this.RequestXml.Append("<getTransactionListRequest xmlns=\"AnetApi/xml/v1/schema/AnetApiSchema.xsd\">");

//      this.RequestXml.Append("<merchantAuthentication>");
//      this.RequestXml.AppendFormat("<name>{0}</name>", this.APILogin);
//      this.RequestXml.AppendFormat("<transactionKey>{0}</transactionKey>", this.TransactionKey);
//      this.RequestXml.Append("</merchantAuthentication>");
//      this.RequestXml.AppendFormat("<batchId>{0}</batchId>", BatchID);
//      this.RequestXml.Append("</getTransactionListRequest>");
//    }
//    private void ConfigureTransactionDetailRequest(string TransactionID) {
//      this.RequestXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
//      this.RequestXml.Append("<getTransactionDetailsRequest xmlns=\"AnetApi/xml/v1/schema/AnetApiSchema.xsd\">");

//      this.RequestXml.Append("<merchantAuthentication>");
//      this.RequestXml.AppendFormat("<name>{0}</name>", this.APILogin);
//      this.RequestXml.AppendFormat("<transactionKey>{0}</transactionKey>", this.TransactionKey);
//      this.RequestXml.Append("</merchantAuthentication>");
//      this.RequestXml.AppendFormat("<transId>{0}</transId>", TransactionID);
//      this.RequestXml.Append("</getTransactionDetailsRequest>");
//    }
//    private void PostToAuthorizeNet() {
//      try {
//        HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(StringEnum.GetValue(this.GatewayUrl));
//        authRequest.Method = "POST";
//        authRequest.ContentLength = this.RequestXml.ToString().Length;
//        authRequest.ContentType = "text/xml";

//        using (StreamWriter sw = new StreamWriter(authRequest.GetRequestStream())) {
//          sw.Write(this.RequestXml.ToString());
//          sw.Close();
//        }

//        HttpWebResponse authResponse = (HttpWebResponse)authRequest.GetResponse();

//        using (StreamReader sr = new StreamReader(authResponse.GetResponseStream())) {
//          this.ResponseXml = sr.ReadToEnd();
//          this.ResponseXml = Regex.Replace(this.ResponseXml, @"(\s*xmlns:?[^=]*=[""][^""]*[""])", String.Empty);

//          var serializer = new XmlSerializer(typeof(TransactionResponse));
//          this.Response = (TransactionResponse)serializer.Deserialize(sr);
//        }
//      }
//      catch (WebException w) {
//        Console.WriteLine(w.Message);
//      }
//    }

//    public void PostTransaction(string OptionalInformation) {
//      switch ((int)this.TransactionType) {
//        case 0:
//        case 1:
//        case 2:
//        case 3:
//          this.ConfigureChargeRequest();
//          break;
//        case 4:
//          this.ConfigureVoidRequest();
//          break;
//        case 6:
//          this.ConfigureSettledBatchRequestList();
//          break;
//        case 7:
//          this.ConfigureTransactionListRequest(OptionalInformation);
//          break;
//        case 8:
//          this.ConfigureTransactionDetailRequest(OptionalInformation);
//          break;
//        case 9:
//          this.ConfigureUnsettledBatchRequestList();
//          break;
//      }

//      this.PostToAuthorizeNet();
//    }
//  }
//}