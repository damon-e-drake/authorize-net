using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Reflection;
using AuthorizeNetLite.Enumerations;

namespace AuthorizeNetLite {
  public class AuthorizeNetService {
    private HttpClient _client { get; set; }
    private Authentication _credentials { get; set; }
    private string _endpoint { get; set; }

    public AuthorizeNetService(Authentication credentials, ApiEndpoint endpoint = ApiEndpoint.Production) {
      _client = new HttpClient();
      _credentials = credentials;
      _endpoint = endpoint == ApiEndpoint.Sandbox? "https://apitest.authorize.net/xml/v1/request.api" : "https://api.authorize.net/xml/v1/request.api";
    }

    public Response ExecuteRequest<Request, Response>(Request obj) {
      if (!typeof(IAuthorizeNetRequest).IsAssignableFrom(typeof(Request))) {
        throw new Exception("Can't create a request from type: " + typeof(Request).ToString());
      }
      var sb = new StringBuilder();
      sb.Append("{\"" + GetApiName<Request>() + "\":");
      ((IAuthorizeNetRequest)obj).Credentials = _credentials;
      sb.Append(JsonConvert.SerializeObject(obj));
      sb.Append("}");
      return default(Response);
    }

    private string GetApiName<T>() {
      var attr = typeof(T).GetTypeInfo().GetCustomAttributes(typeof(ApiNameAttribute), true).FirstOrDefault() as ApiNameAttribute;
      if (attr != null) { return attr.Name; }

      return typeof(T).Name.ToLower();
    }
  }
}