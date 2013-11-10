using System;

namespace AuthorizeNetLite.Attributes {
  [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
  public class StringValue : Attribute {
    public string Value { get; private set; }

    public StringValue(string Value) {
      this.Value = Value;
    }
  }
}