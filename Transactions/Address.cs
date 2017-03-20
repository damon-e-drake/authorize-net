using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  public sealed class Address {
    [JsonProperty("firstName", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
    public string FirstName { get; set; }
    [JsonProperty("lastName", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string LastName { get; set; }
    [JsonProperty("company", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public string Company { get; set; }
    [JsonProperty("address", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
    public string Street { get; set; }
    [JsonProperty("city", Order = 5, NullValueHandling = NullValueHandling.Ignore)]
    public string City { get; set; }
    [JsonProperty("state", Order = 6, NullValueHandling = NullValueHandling.Ignore)]
    public string State { get; set; }
    [JsonProperty("zip", Order = 7, NullValueHandling = NullValueHandling.Ignore)]
    public string ZipCode { get; set; }
    [JsonProperty("country", Order = 8, NullValueHandling = NullValueHandling.Ignore)]
    public string Country { get; set; }
    [JsonProperty("phoneNumber", Order = 9, NullValueHandling = NullValueHandling.Ignore)]
    public string PhoneNumber { get; set; }
    [JsonProperty("faxNumber", Order = 10, NullValueHandling = NullValueHandling.Ignore)]
    public string FaxNumber { get; set; }
  }
}