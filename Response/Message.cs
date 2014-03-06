using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizeNetLite.Response {
  [DataContract(Name = "message", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public sealed class Message {
    [DataMember(Name="code", EmitDefaultValue = false, Order = 0)]
    public string Code { get; set; }
    [DataMember(Name = "description", EmitDefaultValue = false, Order = 1)]
    public string Description { get; set; }
  }
}
