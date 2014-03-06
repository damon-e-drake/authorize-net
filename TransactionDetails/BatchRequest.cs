using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNetLite.Options;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "getBatchStatisticsRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class BatchRequest : BaseRequest {
    [DataMember(Name = "batchId", Order = 1)]
    public long BatchID { get; set; }

    public BatchRequest() {
      this.Credentials = Configuration.MerchantAuthentication;
    }

    public async Task<BatchResponse> Response() {
      using (var request = new HttpClient()) {
        var result = await request.PostAsync(StringEnum.GetValue(Configuration.Endpoint), new StringContent(Util.ConvertToXml<BatchRequest>(this), Encoding.UTF8, "text/xml"));
          return Util.ConvertFromXml<BatchResponse>(await result.Content.ReadAsStringAsync());
      }
    }
  }

  [DataContract(Name = "getBatchStatisticsResponse", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class BatchResponse : BaseResponse {
    [DataMember(Name = "batch", Order = 1)]
    public Batch Batch { get; set; }
  }
}