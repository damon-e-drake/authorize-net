using System;

namespace AuthorizeNetLite.Attributes {
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public class ApiNameAttribute : Attribute {
    public string Name { get; private set; }
    public ApiNameAttribute(string name) {
      Name = name;
    }
  }
}