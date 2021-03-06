﻿using AuthorizeNetLite.Converters;
using Newtonsoft.Json;

namespace AuthorizeNetLite.Transactions {
  public sealed class LineItem {
    [JsonProperty("itemId", Order = 1)]
    public string ItemID { get; set; }
    [JsonProperty("name", Order = 2)]
    public string Name { get; set; }
    [JsonProperty("description", Order = 3)]
    public string Description { get; set; }
    [JsonProperty("quantity", Order = 4), JsonConverter(typeof(StringPrimitiveConverter<decimal>))]
    public decimal Quantity { get; set; }
    [JsonProperty("unitPrice", Order = 5), JsonConverter(typeof(StringPrimitiveConverter<decimal>))]
    public decimal Price { get; set; }
    [JsonProperty("taxable", Order = 6)]
    public bool Taxable { get; set; }
  }
}