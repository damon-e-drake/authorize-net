using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNetLite.Options;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "getTransactionDetailsRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionDetailRequest : BaseRequest {
    [DataMember(Name = "transId", EmitDefaultValue = false, Order = 1)]
    public long TransactionID { get; set; }

    public TransactionDetailRequest() {
      this.Credentials = Configuration.MerchantAuthentication;
    }

    public async Task<TransactionDetailResponse> Response() {
      using (var request = new HttpClient()) {
        var result = await request.PostAsync(StringEnum.GetValue(Configuration.Endpoint), new StringContent(Util.ConvertToXml<TransactionDetailRequest>(this), Encoding.UTF8, "text/xml"));
        return Util.ConvertFromXml<TransactionDetailResponse>(await result.Content.ReadAsStringAsync());
      }
    }

  }
}