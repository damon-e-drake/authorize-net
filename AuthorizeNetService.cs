using AuthorizeNetLite.Attributes;
using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Reflection;

namespace AuthorizeNetLite {
  public class AuthorizeNetService {
    private static HttpClient _client { get; set; }
    public Authentication Credentials { get; private set; }

    public AuthorizeNetService(Authentication credentials) {
      _client = new HttpClient();
      Credentials = credentials;
    }

    public Response ExecuteRequest<Request, Response>(Request obj) {
      if (!typeof(IAuthorizeNetRequest).IsAssignableFrom(typeof(Request))) {
        throw new Exception("Can't create a request from type: " + typeof(Request).ToString());
      }
      var sb = new StringBuilder();
      sb.Append("{\"" + GetApiName<Request>() + "\":");
      ((IAuthorizeNetRequest)obj).Credentials = Credentials;
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