namespace AuthorizeNetLite.Transactions {
  public sealed class CustomerProfile {
    public bool CreateProfile { get; set; }
    public string ID { get; set; }
    public string PaymentProfile { get; set; }
    public string ShippingProfileID { get; set; }
  }
}