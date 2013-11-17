using AuthorizeNetLite.Options;
using AuthorizeNetLite.Transactions;
using System.Collections.Generic;
using System.Configuration;

namespace AuthorizeNetLite {
  public static class Configuration {
    public static Authentication MerchantAuthentication { get; private set; }
    public static GatewayUrl Endpoint { get; private set; }
    public static Dictionary<string, string> AvsCodes { get; private set; }
    public static Dictionary<string, string> CardCodes { get; private set; }
    public static Dictionary<string, string> TransactionCodes { get; private set; }

    public static void RegisterConfiguration(
      GatewayUrl Endpoint = GatewayUrl.Production,
      Authentication MerchantAuthentication = null,
      Dictionary<string, string> AvsCodes = null,
      Dictionary<string, string> CardCodes = null,
      Dictionary<string, string> TransactionCodes = null
      ) {

      Configuration.Endpoint = Endpoint;

      if (MerchantAuthentication == null) {
        MerchantAuthentication = new Authentication {
          ApiLogin = ConfigurationManager.AppSettings["AuthorizeNetApiLogin"].ToString(),
          TransactionKey = ConfigurationManager.AppSettings["AuthorizeNetTransactionKey"].ToString()
        };
      }
      Configuration.MerchantAuthentication = MerchantAuthentication;

      if (AvsCodes == null) {
        AvsCodes = new Dictionary<string, string>();
        AvsCodes.Add("A", "Address (Street) matches, Zip Code does not match.");
        AvsCodes.Add("B", "Address information was not provided for Address Verification System check.");
        AvsCodes.Add("E", "Address Verification System encountered an error.");
        AvsCodes.Add("G", "Non-US Carding Issuing Bank.");
        AvsCodes.Add("N", "Address (Street) and ZipCode does not match.");
        AvsCodes.Add("P", "Address Verification System was not applicable for this transaction.");
        AvsCodes.Add("R", "Retry. Address Verification System was unavailable or timed out.");
        AvsCodes.Add("S", "Address Verification Service is not supported by the issuer.");
        AvsCodes.Add("U", "Address information is unavailable.");
        AvsCodes.Add("W", "Address (Street) does not match, 9 Digit ZipCode does match.");
        AvsCodes.Add("X", "Address (Street) and 9 Digit ZipCode does match.");
        AvsCodes.Add("Y", "Address (Street) and 5 Digit ZipCode does match.");
        AvsCodes.Add("Z", "Address (Street) does not match, 5 Digit ZipCode does match.");
      }
      Configuration.AvsCodes = AvsCodes;

      if (CardCodes == null) {
        CardCodes = new Dictionary<string, string>();
        CardCodes.Add("M", "Card Code matches.");
        CardCodes.Add("N", "Card Code does not match.");
        CardCodes.Add("P", "Card Code was not processed.");
        CardCodes.Add("S", "Card Code should have been present.");
        CardCodes.Add("U", "Issuer was unable to process Card Code request.");
      }
      Configuration.CardCodes = CardCodes;

      if (TransactionCodes == null) {
        TransactionCodes = new Dictionary<string, string>();
        TransactionCodes.Add("authorizedPendingCapture", "Authorized - Pending Capture");
        TransactionCodes.Add("capturedPendingSettlement", "Captured - Pending Settlement");
        TransactionCodes.Add("communicationError", "Communication Error");
        TransactionCodes.Add("refundSettledSuccessfully", "Refund Settled Successfully");
        TransactionCodes.Add("refundPendingSettlement", "Refund Pending Settlement");
        TransactionCodes.Add("approvedReview", "Passed Review");
        TransactionCodes.Add("declined", "Declined");
        TransactionCodes.Add("couldNotVoid", "Could Not Void");
        TransactionCodes.Add("expired", "Expired");
        TransactionCodes.Add("generalError", "General Error");
        TransactionCodes.Add("pendingFinalSettlement", "Pending Final Settlement");
        TransactionCodes.Add("pendingSettlement", "Pending Settlement");
        TransactionCodes.Add("failedReview", "Failed Review");
        TransactionCodes.Add("settledSuccessfully", "Settled Successfully");
        TransactionCodes.Add("settlementError", "Settlement Error");
        TransactionCodes.Add("underReview", "Under Review");
        TransactionCodes.Add("updatingSettlement", "Updating Settlement");
        TransactionCodes.Add("voided", "Voided");
        TransactionCodes.Add("FDSPendingReview", "Pending Fraud Detection Suite Review");
        TransactionCodes.Add("FDSAuthorizedPendingReview", "Passed Fraud Detection Suite Review");
        TransactionCodes.Add("returnedItem", "Returned Item");
        TransactionCodes.Add("chargeback", "Chargeback");
        TransactionCodes.Add("chargebackReversal", "Chargeback Reversal");
        TransactionCodes.Add("authorizedPendingRelease", "Authorized Pending Release");
      }
      Configuration.TransactionCodes = TransactionCodes;

    }
  }
}