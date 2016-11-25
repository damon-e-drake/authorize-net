using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.Response;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.Request {
  public abstract class RequestBase<TRequest, TResponse> where TRequest : RequestBase<TRequest, TResponse> where TResponse : ResponseBase {
    [XmlElement("merchantAuthentication")]
    public Authentication Credentials { get; set; } = Configuration.MerchantAuthentication;

    static readonly XmlSerializer requestSerializer = new XmlSerializer(typeof(TRequest));
    static readonly XmlSerializer responseSerializer = new XmlSerializer(typeof(TResponse));
    static readonly XmlSerializer errorSerializer = new XmlSerializer(typeof(ErrorResponse));

    public async Task<TResponse> GetResponseAsync(GatewayUrl? url = null, CancellationToken cancellationToken = default(CancellationToken)) {
      using (var client = new HttpClient())
      using (var stream = new MemoryStream()) {
        requestSerializer.Serialize(stream, this);

        using (var response = await client.PostAsync(StringEnum.GetValue(url ?? Configuration.Endpoint), new ByteArrayContent(stream.ToArray()) {
          Headers = { ContentType = new MediaTypeHeaderValue("text/xml") }
        }, cancellationToken).ConfigureAwait(false)) {
          response.EnsureSuccessStatusCode();
          using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false)) {
            try {
              return (TResponse)responseSerializer.Deserialize(responseStream);
            } catch (InvalidOperationException) { // This is the only way to tell if it was <ErrorResponse> instead :(
              responseStream.Position = 0;
              throw new AuthNetException((ErrorResponse)errorSerializer.Deserialize(responseStream));
            }
          }
        }
      }
    }
  }
  public abstract class ResponseBase {
    [XmlElement("messages")]
    public Status Status { get; set; }
  }

  class AuthNetException : Exception {
    public AuthNetException(ErrorResponse response) : base(response.Status.Message.Text) {
      Response = response;
    }
    public ErrorResponse Response { get; }
  }
}
