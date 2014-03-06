using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizeNetLite.Transactions {
  [DataContract(Name = "payment", Namespace = "AnetApi/xml/v1/schema/AnetApiSchema.xsd")]
  public class Payment {
    [DataMember(Name = "creditCard", Order = 0, EmitDefaultValue = false)]
    public CreditCard CreditCard { get; set; }

    [DataMember(Name = "bankAccount", Order = 0, EmitDefaultValue = false)]
    public ECheck ECheck { get; set; }
  }
}