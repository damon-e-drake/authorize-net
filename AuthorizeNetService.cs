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
  public class AuthorizeNetService : IDisposable {
    private HttpClient _client { get; set; }
    private Authentication _credentials { get; set; }
    private string _endpoint { get; set; }
    private bool _disposed { get; set; }

    /// <summary>
    /// This creates an instance of the base AuthorizeNet service. This is meant to be used in a static context for an entire
    /// application.
    /// </summary>
    /// <param name="credentials">API login credentials</param>
    /// <param name="endpoint">Optional - Defaults to Production</param>
    public AuthorizeNetService(Authentication credentials, ApiEndpoint endpoint = ApiEndpoint.Production) {
      _client = new HttpClient();
      _credentials = credentials;
      _endpoint = endpoint == ApiEndpoint.Sandbox ? "https://apitest.authorize.net/xml/v1/request.api" : "https://api.authorize.net/xml/v1/request.api";
      _disposed = false;
    }

    public string GenerateRequestJson<T>(T obj, Formatting format = Formatting.None) {
      if (!typeof(IAuthorizeNetRequest).IsAssignableFrom(typeof(T))) { throw new Exception("Can't create a request from type: " + typeof(T).ToString()); }

      ((IAuthorizeNetRequest)obj).Credentials = _credentials;
      return "{\"" + GetApiName<T>() + "\":" + JsonConvert.SerializeObject(obj, format) + "}";
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
      return default(Response);
    }

    public async Task<string> ExecuteAsync<T>(T obj, CancellationToken token = default(CancellationToken)) {
      if (!typeof(IAuthorizeNetRequest).IsAssignableFrom(typeof(T))) { throw new Exception("Can't create a request from type: " + typeof(T).ToString()); }

      ((IAuthorizeNetRequest)obj).Credentials = _credentials;
      var json = "{\"" + GetApiName<T>() + "\":" + JsonConvert.SerializeObject(obj) + "}";

      return await ExecuteAsync(json);
    }

    private string GetApiName<T>() {
      var attr = typeof(T).GetTypeInfo().GetCustomAttributes(typeof(ApiNameAttribute), true).FirstOrDefault() as ApiNameAttribute;
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
