using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNetLite.Options;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "batch", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class Batch {
    [DataMember(Name = "batchId", Order = 0)]
    public long BatchID { get; set; }
    [DataMember(Name = "settlementTimeUTC", Order = 1)]
    public DateTime SettledUTC { get; set; }
    [DataMember(Name = "settlementTimeLocal", Order = 2)]
    public DateTime SettledLocal { get; set; }
    [DataMember(Name = "settlementState", Order = 3)]
    public string Status { get; set; }
    [DataMember(Name = "paymentMethod", Order = 4)]
    public string PaymentMethod { get; set; }
    [DataMember(Name = "statistics", Order = 5)]
    public List<BatchStatistic> Statistics { get; set; }

    public async Task<List<TransactionDetailSummary>> Transactions() {
      using (var request = new HttpClient()) {
        var transactions = new BatchTransactionsRequest() { BatchID = this.BatchID };

        var result = await request.PostAsync(StringEnum.GetValue(Configuration.Endpoint), new StringContent(Util.ConvertToXml<BatchTransactionsRequest>(transactions), Encoding.UTF8, "text/xml"));
        var response = Util.ConvertFromXml<BatchTransactionsResponse>(await result.Content.ReadAsStringAsync());
        return response.Transactions;
      }
    }
  }
}