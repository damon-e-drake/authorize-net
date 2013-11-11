using System.Configuration;
using System.Reflection;

namespace AuthorizeNetLite.Configuration {

  public class AvsCodeConfiguration : ConfigurationSection {
    [ConfigurationProperty("AvsCodes", IsDefaultCollection = false)]
    [ConfigurationCollection(typeof(AvsCodeCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
    public AvsCodeCollection AvsCodes {
      get { return (AvsCodeCollection)base["AvsCodes"]; }
    }

    public static AvsCodeCollection Codes {
      get {
        var fileMap = new ConfigurationFileMap(string.Format("{0}.config", Assembly.GetExecutingAssembly().Location)); //Path to your config file
        var configuration = System.Configuration.ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
        return ((AvsCodeConfiguration)configuration.GetSection("AvsCodeSection")).AvsCodes; 
      }
    }
  }

  public class AvsCode : ConfigurationElement {
    public AvsCode() { }

    public AvsCode(string code, string description) {
      Code = code;
      Description = description;
    }

    [ConfigurationProperty("code", DefaultValue = "", IsRequired = true, IsKey = true)]
    public string Code {
      get { return this["code"] as string; }
      set { this["code"] = value; }
    }

    [ConfigurationProperty("description", DefaultValue = "", IsRequired = true, IsKey = false)]
    public string Description {
      get { return (string)this["description"]; }
      set { this["description"] = value; }
    }
  }

  public class AvsCodeCollection : ConfigurationElementCollection {
    public AvsCode this[int index] {
      get { return (AvsCode)BaseGet(index); }
      set {
        if (BaseGet(index) != null) { BaseRemoveAt(index); }
        BaseAdd(index, value);
      }
    }

    public AvsCode this[string key] {
      get { return (AvsCode)BaseGet(key); }
    }

    public void Add(AvsCode config) { BaseAdd(config); }
    public void Clear() { BaseClear(); }
    public void Remove(AvsCode config) { BaseRemove(config.Code); }
    public void RemoveAt(int index) { BaseRemoveAt(index); }
    public void Remove(string name) { BaseRemove(name); }

    protected override ConfigurationElement CreateNewElement() { return new AvsCode(); }
    protected override object GetElementKey(ConfigurationElement element) { return ((AvsCode)element).Code; }
  }
}