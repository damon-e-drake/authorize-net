using System.Configuration;
using System.Reflection;

namespace AuthorizeNetLite.Configuration {
  public class CardCodeConfiguration : ConfigurationSection {
    [ConfigurationProperty("CardCodes", IsDefaultCollection = false)]
    [ConfigurationCollection(typeof(CardCodeCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
    public CardCodeCollection CardCodes {
      get { return (CardCodeCollection)base["CardCodes"]; }
    }

    public static CardCodeCollection Codes {
      get {
        return ((CardCodeConfiguration)ConfigurationManager.GetSection("CardCodeSection")).CardCodes;
      }
    }
  }

  public class CardCode : ConfigurationElement {
    public CardCode() { }

    public CardCode(string code, string description) {
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

  public class CardCodeCollection : ConfigurationElementCollection {
    public CardCode this[int index] {
      get { return (CardCode)BaseGet(index); }
      set {
        if (BaseGet(index) != null) { BaseRemoveAt(index); }
        BaseAdd(index, value);
      }
    }

    public CardCode this[string key] {
      get { return (CardCode)BaseGet(key); }
    }

    public void Add(CardCode config) { BaseAdd(config); }
    public void Clear() { BaseClear(); }
    public void Remove(CardCode config) { BaseRemove(config.Code); }
    public void RemoveAt(int index) { BaseRemoveAt(index); }
    public void Remove(string name) { BaseRemove(name); }

    protected override ConfigurationElement CreateNewElement() { return new CardCode(); }
    protected override object GetElementKey(ConfigurationElement element) { return ((CardCode)element).Code; }
  }
}