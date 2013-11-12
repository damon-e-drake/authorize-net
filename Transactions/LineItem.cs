using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AuthorizeNetLite.Transactions {
  [Serializable]
  [XmlRoot("lineItem")]
  public sealed class LineItem {
    [XmlElement("itemId")]
    public string ItemID { get; set; }
    [XmlElement("name")]
    public string Name { get; set; }
    [XmlElement("description")]
    public string Description { get; set; }
    [XmlElement("quantity")]
    public decimal Quantity { get; set; }
    [XmlElement("unitPrice")]
    public decimal Price { get; set; }
  }
}