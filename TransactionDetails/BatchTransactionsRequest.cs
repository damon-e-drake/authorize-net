using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNetLite.Options;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "getTransactionListRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class BatchTransactionsRequest : BaseRequest {
    [DataMember(Name = "batchId", Order = 1)]
    public long BatchID { get; set; }

    public BatchTransactionsRequest() {
      this.Credentials = Configuration.MerchantAuthentication;
    }

    public async Task<BatchTransactionsResponse> Response() {
      using (var request = new HttpClient()) {
        var result = await request.PostAsync(StringEnum.GetValue(Configuration.Endpoint), new StringContent(Util.ConvertToXml<BatchTransactionsRequest>(this), Encoding.UTF8, "text/xml"));
        return Util.ConvertFromXml<BatchTransactionsResponse>(await result.Content.ReadAsStringAsync());
      }
    } 
  }
}