using System;

namespace AuthorizeNetLite.Attributes {
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public class ApiMethodAttribute : Attribute {
    public string Name { get; private set; }
    public ApiMethodAttribute(string name) {
      Name = name;
    }
  }
}