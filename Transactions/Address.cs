using System.Runtime.Serialization;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "address", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class Address {
    [DataMember(Name = "firstName", Order = 0, EmitDefaultValue = false)]
    public string FirstName { get; set; }
    [DataMember(Name = "lastName", Order = 1, EmitDefaultValue = false)]
    public string LastName { get; set; }
    [DataMember(Name = "company", Order = 2, EmitDefaultValue = false)]
    public string Company { get; set; }
    [DataMember(Name = "address", Order = 3, EmitDefaultValue = false)]
    public string Street { get; set; }
    [DataMember(Name = "city", Order = 4, EmitDefaultValue = false)]
    public string City { get; set; }
    [DataMember(Name = "state", Order = 5, EmitDefaultValue = false)]
    public string State { get; set; }
    [DataMember(Name = "zip", Order = 6, EmitDefaultValue = false)]
    public string ZipCode { get; set; }
    [DataMember(Name = "country", Order = 7, EmitDefaultValue = false)]
    public string Country { get; set; }
    [DataMember(Name = "phoneNumber", Order = 8, EmitDefaultValue = false)]
    public string PhoneNumber { get; set; }
    [DataMember(Name = "faxNumber", Order = 9, EmitDefaultValue = false)]
    public string FaxNumber { get; set; }
  }
}