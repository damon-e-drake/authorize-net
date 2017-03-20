using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Reflection;
using AuthorizeNetLite.Enumerations;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorizeNetLite {
  public class AuthorizeNetService {
    private HttpClient _client { get; set; }
    private Authentication _credentials { get; set; }
    private string _endpoint { get; set; }

    public AuthorizeNetService(Authentication credentials, ApiEndpoint endpoint = ApiEndpoint.Production) {
      _client = new HttpClient();
      _credentials = credentials;
      _endpoint = endpoint == ApiEndpoint.Sandbox ? "https://apitest.authorize.net/xml/v1/request.api" : "https://api.authorize.net/xml/v1/request.api";
    }

    public async Task<Response> ExecuteRequestAsync<Request, Response>(Request obj) {
      var json = await ExecuteRequestRawAsync(obj);
      return default(Response);
    }

    public async Task<string> ExecuteRequestRawAsync<T>(T obj, CancellationToken token = default(CancellationToken)) {
      if (!typeof(IAuthorizeNetRequest).IsAssignableFrom(typeof(T))) { throw new Exception("Can't create a request from type: " + typeof(T).ToString()); }

      ((IAuthorizeNetRequest)obj).Credentials = _credentials;
      var json = "{\"" + GetApiName<T>() + "\":" + JsonConvert.SerializeObject(obj) + "}";

      using (var response = await _client.PostAsync(_endpoint, new StringContent(json, Encoding.UTF8, "application/json"), token).ConfigureAwait(false)) {
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      }
    }

    private string GetApiName<T>() {
      var attr = typeof(T).GetTypeInfo().GetCustomAttributes(typeof(ApiNameAttribute), true).FirstOrDefault() as ApiNameAttribute;
      if (attr != null) { return attr.Name; }

      return typeof(T).Name.ToLower();
    }
  }
}
