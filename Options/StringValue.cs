using System;
using AuthorizeNetLite.Attributes;

namespace AuthorizeNetLite.Options {
  public class StringEnum {
    public static string GetValue(Enum value) {
      string output = null;

      StringValue[] attrs = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(StringValue), false) as StringValue[];
      if (attrs.Length > 0) { output = attrs[0].Value; }

      return output;
    }
  }
}
