using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace AuthorizeNetLite {
  public static class Util {
    public static string ConvertToXml<T>(T obj) {
      try {
        using (var ms = new MemoryStream()) {
          var serializer = new DataContractSerializer(typeof(T));
          serializer.WriteObject(ms, obj);
          ms.Position = 0;
          return Encoding.UTF8.GetString(ms.ToArray());
        }
      }
      catch {
        return null;
      }
    }

    public static T ConvertFromXml<T>(string xml) {
      try {
        using (var ms = new MemoryStream()) {
          var serializer = new DataContractSerializer(typeof(T));
          byte[] data = Encoding.UTF8.GetBytes(xml);
          ms.Write(data, 0, data.Length);
          ms.Position = 0;
          return (T)serializer.ReadObject(ms);
        }
      }
      catch {
        return default(T);
      }
    }
  }
}
