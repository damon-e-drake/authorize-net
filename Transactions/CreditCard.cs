using AuthorizeNetLite.Interfaces;
using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  public sealed class CreditCard : IPayment {
    [JsonProperty("cardNumber", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
    public string CardNumber { get; set; }
    [JsonProperty("cardType", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string CardType { get; set; }
    [JsonProperty("expirationDate", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public string ExpirationDate { get; set; }
    [JsonProperty("cardCode", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
    public string CardCode { get; set; }
    [JsonProperty("track1", Order = 5, NullValueHandling = NullValueHandling.Ignore)]
    public string FirstDataTrack { get; set; }
    [JsonProperty("track2", Order = 6, NullValueHandling = NullValueHandling.Ignore)]
    public string SecondDataTrack { get; set; }
  }
}