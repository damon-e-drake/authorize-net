using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "creditCard", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class CreditCard {
    [DataMember(Name = "cardNumber", Order = 0, EmitDefaultValue = false)]
    public string CardNumber { get; set; }
    [DataMember(Name = "expirationDate", Order = 1, EmitDefaultValue = false)]
    public string ExpirationDate { get; set; }
    [DataMember(Name = "accountType", Order = 2, EmitDefaultValue = false)]
    public string CardType { get; set; }
    [DataMember(Name = "cardCode", Order = 3, EmitDefaultValue = false)]
    public string CardCode { get; set; }
    [DataMember(Name = "track1", Order = 4, EmitDefaultValue = false)]
    public string FirstDataTrack { get; set; }
    [DataMember(Name = "track2", Order = 5, EmitDefaultValue = false)]
    public string SecondDataTrack { get; set; }
  }
}