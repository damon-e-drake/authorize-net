using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.Response;

namespace AuthorizeNetLite.Request {
  [Serializable]
  [DataContract(Name = "createTransactionRequest", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class TransactionRequest : BaseRequest {
    [DataMember(Name = "refId", Order = 1, EmitDefaultValue = false)]
    public string TransactionReferenceID { get; set; }

    [DataMember(Name = "transactionRequest", Order = 2)]
    public TransactionBody Transaction { get; set; }

    public TransactionRequest() {
      this.Credentials = Configuration.MerchantAuthentication;
    }

    public string Xml { get { return Util.ConvertToXml(this); } }

    public async Task<object> Response() {
      using (var request = new HttpClient()) {
        var result = await request.PostAsync(StringEnum.GetValue(Configuration.Endpoint), new StringContent(Util.ConvertToXml(this), Encoding.UTF8, "text/xml"));
        var r = Util.ConvertFromXml<TransactionResponse>(await result.Content.ReadAsStringAsync()) ?? (object)Util.ConvertFromXml<ErrorResponse>(await result.Content.ReadAsStringAsync());
        return r;
      }
    }
  }
}