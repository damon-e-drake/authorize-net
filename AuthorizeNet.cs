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