using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.Request;
using AuthorizeNetLite.Response;
using AuthorizeNetLite.Transactions;

namespace AuthorizeNetLite.Helpers {
  public class LightCharge {
    public string InvoiceNumber { get; set; }
    public string Description { get; set; }
    public string CustomerID { get; set; }
    public string CustomerIP { get; set; }
    public string EMail { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string FaxNumber { get; set; }

    public string CardNumber { get; set; }
    public string Expiration { get; set; }
    public string CardCode { get; set; }

    public string AccountName { get; set; }
    public string BankName { get; set; }
    public string RoutingNumber { get; set; }
    public string AccountNumber { get; set; }

    public decimal Amount { get; set; }

    public async Task<object> Charge(TransactionType type) {
      Payment p = new Payment();

      if (!string.IsNullOrEmpty(CardNumber)) {
        p.CreditCard = new CreditCard { CardNumber = CardNumber, CardCode = CardCode, ExpirationDate = Expiration };
      }
      else {
        p.ECheck = new ECheck { AccountType = "checking", AccountName = AccountName, AccountNumber = AccountNumber, RoutingNumber = RoutingNumber, BankName = BankName };
      }

      var txn = new TransactionRequest {
        Transaction = new TransactionBody {
          Customer = new Customer { ID = CustomerID, EMail = EMail },
          OrderInformation = new Order { InvoiceNumber = InvoiceNumber, Description = Description },
          Payment = p,
          BillingAddress = new Address { 
            FirstName = FirstName, 
            LastName = LastName, 
            Company = Company, 
            Street = Street, 
            City = City, 
            State = State, 
            ZipCode = ZipCode, 
            Country = Country, 
            PhoneNumber = PhoneNumber, 
            FaxNumber = FaxNumber 
          },
          Type = StringEnum.GetValue(type),
          CustomerIP = CustomerIP,
          Amount = Amount
        }
      };

      return await txn.Response();
    }
  }
}
