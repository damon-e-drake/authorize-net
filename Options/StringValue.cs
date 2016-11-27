using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AuthorizeNetLite.Attributes;

namespace AuthorizeNetLite.Options {
  static class StringEnum {
    static class Cache<TEnum> where TEnum : struct {
      public static readonly IReadOnlyDictionary<TEnum, string> Values =
        typeof(TEnum).GetTypeInfo().DeclaredFields
          .Where(f => f.IsStatic)
          .ToDictionary(
            f => (TEnum)f.GetValue(null),
            f => f.GetCustomAttribute<StringValue>().Value);
    }
    public static string GetValue<TEnum>(TEnum value) where TEnum : struct {
      return Cache<TEnum>.Values[value];
    }
  }
}
