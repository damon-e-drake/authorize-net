using AuthorizeNetLite.Options;
using AuthorizeNetLite.Transactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizeNetLite {
  public static class Configuration {
    public static Authentication MerchantAuthentication { get; private set; }
    public static GatewayUrl Endpoint { get; private set; }
    public static Dictionary<int, string> ResponseCodes { get; private set; }
    public static Dictionary<string, string> AvsCodes { get; private set; }
    public static Dictionary<string, string> CardCodes { get; private set; }
    public static Dictionary<string, string> TransactionCodes { get; private set; }
    public static Dictionary<string, string> CardVerficationCodes { get; private set; }
    public static Dictionary<string, string> FDSActions { get; private set; }

    public static void RegisterConfiguration(
      GatewayUrl Endpoint = GatewayUrl.Production,
      Authentication MerchantAuthentication = null,
      Dictionary<int, string> ResponseCodes = null,
      Dictionary<string, string> AvsCodes = null,
      Dictionary<string, string> CardCodes = null,
      Dictionary<string, string> TransactionCodes = null,
      Dictionary<string, string> CardVerificationCodes = null,
      Dictionary<string, string> FDSActions = null
      ) {

      Configuration.Endpoint = Endpoint;

      if (MerchantAuthentication == null) {
        MerchantAuthentication = new Authentication {
          ApiLogin = ConfigurationManager.AppSettings["AuthorizeNetApiLogin"],
          TransactionKey = ConfigurationManager.AppSettings["AuthorizeNetTransactionKey"]
        };
      }
      Configuration.MerchantAuthentication = MerchantAuthentication;

      if (ResponseCodes == null) {
        ResponseCodes = new Dictionary<int, string> {
          {1, "Approved"},
          {2, "Declined"},
          {3, "Errored"},
          {4, "Held For Review"}
        };
      }
      Configuration.ResponseCodes = ResponseCodes;


      if (AvsCodes == null) {
        AvsCodes = new Dictionary<string, string> {
          {"A", "Address (Street) matches, Zip Code does not match."},
          {"B", "Address information was not provided for Address Verification System check."},
          {"E", "Address Verification System encountered an error."},
          {"G", "Non-US Carding Issuing Bank."},
          {"N", "Address (Street) and Zip Code does not match."},
          {"P", "Address Verification System was not applicable for this transaction."},
          {"R", "Retry. Address Verification System was unavailable or timed out."},
          {"S", "Address Verification Service is not supported by the issuer."},
          {"U", "Address information is unavailable."},
          {"W", "Address (Street) does not match, 9 Digit Zip Code match."},
          {"X", "Address (Street) and 9 Digit ZipCode match."},
          {"Y", "Address (Street) and 5 Digit ZipCode match."},
          {"Z", "Address (Street) does not match, 5 Digit Zip Code match."}
        };
      }
      Configuration.AvsCodes = AvsCodes;

      if (CardCodes == null) {
        CardCodes = new Dictionary<string, string> {
          {"M", "Card Code matches."},
          {"N", "Card Code does not match."},
          {"P", "Card Code was not processed."},
          {"S", "Card Code should have been present."},
          {"U", "Issuer was unable to process Card Code request."}
        };
      }
      Configuration.CardCodes = CardCodes;

      if (TransactionCodes == null) {
        TransactionCodes = new Dictionary<string, string> {
          {"authorizedPendingCapture", "Authorized - Pending Capture"},
          {"capturedPendingSettlement", "Captured - Pending Settlement"},
          {"communicationError", "Communication Error"},
          {"refundSettledSuccessfully", "Refund Settled Successfully"},
          {"refundPendingSettlement", "Refund Pending Settlement"},
          {"approvedReview", "Passed Review"},
          {"declined", "Declined"},
          {"couldNotVoid", "Could Not Void"},
          {"expired", "Expired"},
          {"generalError", "General Error"},
          {"pendingFinalSettlement", "Pending Final Settlement"},
          {"pendingSettlement", "Pending Settlement"},
          {"failedReview", "Failed Review"},
          {"settledSuccessfully", "Settled Successfully"},
          {"settlementError", "Settlement Error"},
          {"underReview", "Under Review"},
          {"updatingSettlement", "Updating Settlement"},
          {"voided", "Voided"},
          {"FDSPendingReview", "Pending Fraud Detection Suite Review"},
          {"FDSAuthorizedPendingReview", "Passed Fraud Detection Suite Review"},
          {"returnedItem", "Returned Item"},
          {"chargeback", "Chargeback"},
          {"chargebackReversal", "Chargeback Reversal"},
          {"authorizedPendingRelease", "Authorized Pending Release"}
        };
      }
      Configuration.TransactionCodes = TransactionCodes;

      if (CardVerificationCodes == null) {
        CardVerificationCodes = new Dictionary<string, string> {
          {"0", "Not validated because erroneous data was submitted."},
          {"1", "Failed validation."},
          {"2", "Passed validation."},
          {"3", "Validation could not be performed. Issuer attempt was incomplete."},
          {"4", "Validation could not be performed. Issuer encountered a system error."},
          {"5", "Response reserved for future use."},
          {"6", "Response reserved for future use."},
          {"7", "Failed validation. Issuer was unavailable. US issued card / non-US acquirer."},
          {"8", "Passed validation. Issuer was unavailable. US issued card / non-US acquirer."},
          {"9", "Failed valdiation. Issuer was unavailable. US issued card / non-US acquirer."},
          {"A", "Passed validation. Issuer was unavailable. US issued card / non-US acquirer."},
          {"B", "Passed validation. Information only, no liability shift."}
        };
      }
      Configuration.CardVerficationCodes = CardVerificationCodes;

      if (FDSActions == null) {
        FDSActions = new Dictionary<string, string> {
          {"reject", "Reject"},
          {"decline", "Decline"},
          {"hold", "Hold"},
          {"authAndHold", "Authorize and Hold"},
          {"report", "Report"}
        };
      }
      Configuration.FDSActions = FDSActions;

    }
  }
}