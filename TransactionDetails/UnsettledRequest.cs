using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.TransactionDetails {
  [DataContract(Name = "getUnsettledTransactionListRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class UnsettledRequest : BaseRequest {
    public UnsettledRequest() {
      this.Credentials = Configuration.MerchantAuthentication;
    }

    public async Task<UnsettledResponse> Response() {
      using (var request = new HttpClient()) {
        var result = await request.PostAsync(StringEnum.GetValue(Configuration.Endpoint), new StringContent(Util.ConvertToXml<UnsettledRequest>(this), Encoding.UTF8, "text/xml"));
        return Util.ConvertFromXml<UnsettledResponse>(await result.Content.ReadAsStringAsync());
      }
    }
  }
}