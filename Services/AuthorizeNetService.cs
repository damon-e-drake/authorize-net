using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Enumerations;
using AuthorizeNetLite.Interfaces;
using AuthorizeNetLite.Security;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorizeNetLite {
  public class AuthorizeNetService : IDisposable {
    private static bool _hasValidCredentials = false;
    private HttpClient _client { get; set; }
    private Authentication _credentials { get; set; }
    private string _endpoint { get; set; }
    private bool _disposed { get; set; }

    public AuthorizeNetService(Authentication credentials, ApiEndpoint endpoint = ApiEndpoint.Production) {
      _client = new HttpClient();
      _credentials = credentials;
      _endpoint = endpoint == ApiEndpoint.Sandbox ? "https://apitest.authorize.net/xml/v1/request.api" : "https://api.authorize.net/xml/v1/request.api";
      _disposed = false;

      if (!_hasValidCredentials) {
        var auth = new AuthenticateTestRequest();
        var response = ExecuteAsync<AuthenticateTestRequest, AuthenticateTestResponse>(auth).Result;

        if (response == null || response.Status.Code.ToLower() != "ok") { throw new Exception("Could not authenticate with supplied credentials."); }
        _hasValidCredentials = true;
      }
    }

    public string GenerateRequestJson<T>(T obj, Formatting format = Formatting.None) {
      if (!typeof(IAuthorizeNetRequest).IsAssignableFrom(typeof(T))) { throw new Exception(typeof(T).ToString() + " does not implement IAuthorizeNetRequest."); }

      ((IAuthorizeNetRequest)obj).Credentials = _credentials;
      return "{\"" + GetApiMethod<T>() + "\":" + JsonConvert.SerializeObject(obj, format) + "}";
    }

    public async Task<string> ExecuteAsync(string json, CancellationToken token = default(CancellationToken)) {
      using (var response = await _client.PostAsync(_endpoint, new StringContent(json, Encoding.UTF8, "application/json"), token).ConfigureAwait(false)) {
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      }
    }

    public async Task<Response> ExecuteAsync<Request, Response>(Request obj) {
      var json = await ExecuteAsync(obj);
      if (!typeof(IAuthorizeNetResponse).IsAssignableFrom(typeof(Response))) { throw new Exception(typeof(Response).ToString() + " does not implement IAuthorizeNetResponse."); }
      return (Response)(object)JsonConvert.DeserializeObject<Response>(json);
    }

    public async Task<string> ExecuteAsync<T>(T obj, CancellationToken token = default(CancellationToken)) {
      if (!typeof(IAuthorizeNetRequest).IsAssignableFrom(typeof(T))) { throw new Exception(typeof(T).ToString() + " does not implement IAuthorizeNetRequest."); }

      ((IAuthorizeNetRequest)obj).Credentials = _credentials;
      var json = "{\"" + GetApiMethod<T>() + "\":" + JsonConvert.SerializeObject(obj) + "}";

      return await ExecuteAsync(json);
    }

    private string GetApiMethod<T>() {
      var attr = typeof(T).GetTypeInfo().GetCustomAttributes(typeof(ApiMethodAttribute), true).FirstOrDefault() as ApiMethodAttribute;
      if (attr != null) { return attr.Name; }

      return typeof(T).Name.ToLower();
    }

    protected virtual void Dispose(bool disposing) {
      if (!_disposed) {
        if (disposing) {
          _credentials = null;
          _endpoint = null;
        }

        _client.Dispose();
        _disposed = true;
      }
    }

    ~AuthorizeNetService() {
      Dispose(false);
    }

    public void Dispose() {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
