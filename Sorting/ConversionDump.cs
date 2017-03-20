using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizeNetLite.Sorting {
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public class ApiNameAttribute : Attribute {
    public string Name { get; private set; }
    public ApiNameAttribute(string name) {
      Name = name;
    }
  }

  public class MoneyStringConverter : JsonConverter {
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      JToken jt = JToken.ReadFrom(reader);

      return jt.Value<decimal>();
    }

    public override bool CanConvert(Type objectType) {
      return typeof(decimal).Equals(objectType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      serializer.Serialize(writer, value.ToString());
    }
  }

  public class LineItemsConverter : JsonConverter {
    public override bool CanConvert(Type objectType) {
      throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      writer.WriteRawValue("{\"lineItem\":" + JsonConvert.SerializeObject(value) + "}");
    }
  }

  public class TransactionSettingsConverter : JsonConverter {
    public override bool CanConvert(Type objectType) {
      throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      writer.WriteRawValue("{\"setting\":" + JsonConvert.SerializeObject(value) + "}");
    }
  }

  public class UserFieldsConverter : JsonConverter {
    public override bool CanConvert(Type objectType) {
      throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      writer.WriteRawValue("{\"userField\":" + JsonConvert.SerializeObject(value) + "}");
    }
  }

  public class PaymentConverter : JsonConverter {
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      var json = JToken.Load(reader).ToString(Formatting.None);

      if (json.StartsWith("{\"creditCard\":")) {
        json = json.Remove(json.Length - 1, 1).Replace("{\"creditCard\":", "");
        return JsonConvert.DeserializeObject<CreditCard>(json);
      }

      return new CreditCard();
    }

    public override bool CanConvert(Type objectType) {
      return typeof(decimal).Equals(objectType);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      if (value.GetType() == typeof(CreditCard)) {
        writer.WriteRawValue("{\"creditCard\":" + JsonConvert.SerializeObject(value) + "}");
      }
      //serializer.Serialize(writer, value);
    }
  }

  public enum TransactionType {
    [EnumMember(Value = "authOnlyTransaction")]
    AuthOnly,
    [EnumMember(Value = "authCaptureTransaction")]
    AuthCapture,
    [EnumMember(Value = "captureOnlyTransaction")]
    CaptureOnly,
    [EnumMember(Value = "refundTransaction")]
    Refund,
    [EnumMember(Value = "priorAuthCaptureTransaction")]
    PriorAuthCapture,
    [EnumMember(Value = "voidTransaction")]
    Void,
    [EnumMember(Value = "getDetailsTransaction")]
    GetDetails,
    [EnumMember(Value = "authOnlyContinueTransaction")]
    AuthOnlyContinue,
    [EnumMember(Value = "authCaptureContinueTransaction")]
    AuthCaptureContinue
  }

  public enum BankAccountType {
    [EnumMember(Value = "checking")]
    Checking,
    [EnumMember(Value = "savings")]
    Savings,
    [EnumMember(Value = "businessChecking")]
    BusinessChecking
  }


  public interface IAuthorizeNetRequest {
    Authentication Credentials { get; set; }

  }

  [ApiName("authenticateTestRequest")]
  public class AuthenticateTestRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication", Order = 1)]
    public Authentication Credentials { get; set; }
  }

  [ApiName("createTransactionRequest")]
  public class TransactionRequest : IAuthorizeNetRequest {
    [JsonProperty("merchantAuthentication", Order = 1)]
    public Authentication Credentials { get; set; }
    [JsonProperty("refId", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string ReferenceID { get; set; }
    [JsonProperty("transactionRequest", Order = 3)]
    public TransactionRequestBody TransactionBody { get; set; }
  }

  public sealed class CustomerProfile {
    public bool CreateProfile { get; set; }
    public string ID { get; set; }
    public string PaymentProfile { get; set; }
    public string ShippingProfileID { get; set; }
  }
  public class TransactionRequestBody {
    [JsonProperty("transactionType", Order = 1), JsonConverter(typeof(StringEnumConverter))]
    public TransactionType TransactionType { get; set; }
    [JsonProperty("amount", Order = 2), JsonConverter(typeof(MoneyStringConverter))]
    public decimal Amount { get; set; }
    [JsonProperty("currencyCode", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public string CurrencyCode { get; set; }
    [JsonProperty("payment", Order = 4)]
    public IPayment Payment { get; set; }
    //profile 5
    //solution 6
    //callId 7
    //terminalNumber 8
    [JsonProperty("authCode", Order = 9, NullValueHandling = NullValueHandling.Ignore)]
    public string AuthorizationCode { get; set; }
    [JsonProperty("refTransId", Order = 10, NullValueHandling = NullValueHandling.Ignore)]
    public string ReferencedTransactionID { get; set; }
    //splitTenderId 11
    [JsonProperty("order", Order = 12, NullValueHandling = NullValueHandling.Ignore)]
    public Order OrderInformation { get; set; }
    [JsonProperty("lineItems", Order = 13, NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(LineItemsConverter))]
    public List<LineItem> LineItems { get; set; }
    [JsonProperty("tax", Order = 14, NullValueHandling = NullValueHandling.Ignore)]
    public TransactionCharges Tax { get; set; }
    [JsonProperty("duty", Order = 15, NullValueHandling = NullValueHandling.Ignore)]
    public TransactionCharges Duty { get; set; }
    [JsonProperty("shipping", Order = 16, NullValueHandling = NullValueHandling.Ignore)]
    public TransactionCharges Shipping { get; set; }
    //taxExempt bool 17
    [JsonProperty("poNumber", Order = 18, NullValueHandling = NullValueHandling.Ignore)]
    public string PurchaseOrderNumber { get; set; }
    [JsonProperty("customer", Order = 19, NullValueHandling = NullValueHandling.Ignore)]
    public Customer Customer { get; set; }
    [JsonProperty("billTo", Order = 20, NullValueHandling = NullValueHandling.Ignore)]
    public Address BillingAddress { get; set; }
    [JsonProperty("shipTo", Order = 21, NullValueHandling = NullValueHandling.Ignore)]
    public Address ShippingAddress { get; set; }
    [JsonProperty("customerIP", Order = 22, NullValueHandling = NullValueHandling.Ignore)]
    public string CustomerIPAddress { get; set; }
    //cardholderAuthentication 23
    //retial 24
    //employeeId 25
    [JsonProperty("transactionSettings", Order = 26, NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(TransactionSettingsConverter))]
    public List<TransactionSetting> Settings { get; set; }
    [JsonProperty("userFields", Order = 27, NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(UserFieldsConverter))]
    public List<UserField> UserFields { get; set; }
  }
  public enum TransactionSettingType {
    [EnumMember(Value = "emailCustomer")]
    EmailCustomer,
    [EnumMember(Value = "merchantEmail")]
    MerchantEmail,
    [EnumMember(Value = "allowPartialAuth")]
    AllowPartialAuthorization,
    [EnumMember(Value = "headerEmailReceipt")]
    ReceiptHeader,
    [EnumMember(Value = "footerEmailReceipt")]
    ReceiptFooter,
    [EnumMember(Value = "recurringBilling")]
    RecurringBilling,
    [EnumMember(Value = "duplicateWindow")]
    DuplicateWindow,
    [EnumMember(Value = "testRequest")]
    TestRequest
  }

  public sealed class UserField {
    [JsonProperty("name", Order = 1)]
    public string Name { get; set; }
    [JsonProperty("value", Order = 2)]
    public string Value { get; set; }
  }


  public sealed class TransactionSetting {
    [JsonProperty("settingName", Order = 1), JsonConverter(typeof(StringEnumConverter))]
    public TransactionSettingType Setting { get; set; }
    [JsonProperty("settingValue", Order = 2)]
    public string Value { get; set; }
  }
  public sealed class Address {
    [JsonProperty("firstName", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
    public string FirstName { get; set; }
    [JsonProperty("lastName", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string LastName { get; set; }
    [JsonProperty("company", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public string Company { get; set; }
    [JsonProperty("address", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
    public string Street { get; set; }
    [JsonProperty("city", Order = 5, NullValueHandling = NullValueHandling.Ignore)]
    public string City { get; set; }
    [JsonProperty("state", Order = 6, NullValueHandling = NullValueHandling.Ignore)]
    public string State { get; set; }
    [JsonProperty("zip", Order = 7, NullValueHandling = NullValueHandling.Ignore)]
    public string ZipCode { get; set; }
    [JsonProperty("country", Order = 8, NullValueHandling = NullValueHandling.Ignore)]
    public string Country { get; set; }
    [JsonProperty("phoneNumber", Order = 9, NullValueHandling = NullValueHandling.Ignore)]
    public string PhoneNumber { get; set; }
    [JsonProperty("faxNumber", Order = 10, NullValueHandling = NullValueHandling.Ignore)]
    public string FaxNumber { get; set; }
    [JsonProperty("customerIP", Order = 11, NullValueHandling = NullValueHandling.Ignore)]
    public string CustomerIPAddress { get; set; }
  }

  public sealed class Customer {
    [JsonProperty("id", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
    public string ID { get; set; }

    [JsonProperty("email", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string EMail { get; set; }
  }

  public sealed class TransactionCharges {
    [JsonProperty("amount", Order = 1), JsonConverter(typeof(MoneyStringConverter))]
    public decimal Amount { get; set; }

    [JsonProperty("name", Order = 2)]
    public string Name { get; set; }

    [JsonProperty("description", Order = 3)]
    public string Description { get; set; }
  }

  public sealed class Order {
    [JsonProperty("invoiceNumber", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
    public string InvoiceNumber { get; set; }
    [JsonProperty("description", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }
  }

  public sealed class LineItem {
    [JsonProperty("itemId", Order = 1)]
    public string ItemID { get; set; }
    [JsonProperty("name", Order = 2)]
    public string Name { get; set; }
    [JsonProperty("description", Order = 3)]
    public string Description { get; set; }
    [JsonProperty("quantity", Order = 4), JsonConverter(typeof(MoneyStringConverter))]
    public decimal Quantity { get; set; }
    [JsonProperty("unitPrice", Order = 5), JsonConverter(typeof(MoneyStringConverter))]
    public decimal Price { get; set; }
    [JsonProperty("taxable", Order = 6)]
    public bool Taxable { get; set; }
  }

  public interface IPayment {

  }

  public sealed class CreditCard : IPayment {
    [JsonProperty("cardNumber", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
    public string CardNumber { get; set; }
    [JsonProperty("cardType", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
    public string CardType { get; set; }
    [JsonProperty("expirationDate", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
    public string ExpirationDate { get; set; }
    [JsonProperty("cardCode", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
    public string CardCode { get; set; }
    [JsonProperty("track1", Order = 5, NullValueHandling = NullValueHandling.Ignore)]
    public string FirstDataTrack { get; set; }
    [JsonProperty("track2", Order = 6, NullValueHandling = NullValueHandling.Ignore)]
    public string SecondDataTrack { get; set; }
  }

  public class Authentication {
    [JsonProperty("name", Order = 1)]
    public string Code { get; set; }
    [JsonProperty("transactionKey", Order = 2)]
    public string Key { get; set; }
  }
}
