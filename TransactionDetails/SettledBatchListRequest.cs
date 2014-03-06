using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNetLite.Options;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "getSettledBatchListRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class SettledBatchListRequest : BaseRequest {
    [DataMember(Name = "includeStatistics", Order = 1)]
    public bool IncludeStatistics { get; set; }
    [DataMember(Name = "firstSettlementDate", Order = 2)]
    public DateTime StartDate { get; set; }
    [DataMember(Name = "lastSettlementDate", Order = 3)]
    public DateTime EndDate { get; set; }

    public SettledBatchListRequest() {
      this.Credentials = Configuration.MerchantAuthentication;
    }

    public async Task<SettledBatchListResponse> Response() {
      using (var request = new HttpClient()) {
        var result = await request.PostAsync(StringEnum.GetValue(Configuration.Endpoint), new StringContent(Util.ConvertToXml<SettledBatchListRequest>(this), Encoding.UTF8, "text/xml"));
        return Util.ConvertFromXml<SettledBatchListResponse>(await result.Content.ReadAsStringAsync());
      }
    }
  }
}