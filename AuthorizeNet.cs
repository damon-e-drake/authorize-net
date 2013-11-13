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