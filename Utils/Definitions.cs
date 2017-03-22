using AuthorizeNetLite.Enumerations;
using System.Collections.Generic;

namespace AuthorizeNetLite.Utils {
  public static class Definitions {
    public static Dictionary<string, string> AvsCodes { get; private set; }
    public static Dictionary<string, string> CardCodes { get; private set; }
    public static Dictionary<string, string> TransactionCodes { get; private set; }
    public static Dictionary<TransactionType, string> TransactionTypes { get; private set; }

    static Definitions() {
      RegisterAvsCodes();
      RegisterCardCodes();
      RegisterTransactionCodes();
      RegisterTransactionTypes();
    }

    private static void RegisterAvsCodes() {
      AvsCodes = new Dictionary<string, string>() {
          { "A", "Address (Street) matches, Zip Code does not match." },
          { "B", "Address information was not provided for Address Verification System check." },
          { "E", "Address Verification System encountered an error." },
          { "G", "Non-US Carding Issuing Bank." },
          { "N", "Address (Street) and ZipCode does not match." },
          { "P", "Address Verification System was not applicable for this transaction." },
          { "R", "Retry. Address Verification System was unavailable or timed out." },
          { "S", "Address Verification Service is not supported by the issuer." },
          { "U", "Address information is unavailable." },
          { "W", "Address (Street) does not match, 9 Digit ZipCode does match." },
          { "X", "Address (Street) and 9 Digit ZipCode does match." },
          { "Y", "Address (Street) and 5 Digit ZipCode does match." },
          { "Z", "Address (Street) does not match, 5 Digit ZipCode does match." }
        };
    }
    private static void RegisterCardCodes() {
      CardCodes = new Dictionary<string, string>() {
          { "M", "Card Code matches." },
          { "N", "Card Code does not match." },
          { "P", "Card Code was not processed." },
          { "S", "Card Code should have been present." },
          { "U", "Issuer was unable to process Card Code request." }
        };
    }
    private static void RegisterTransactionCodes() {
      TransactionCodes = new Dictionary<string, string>() {
          { "authorizedPendingCapture", "Authorized - Pending Capture" },
          { "capturedPendingSettlement", "Captured - Pending Settlement" },
          { "communicationError", "Communication Error" },
          { "refundSettledSuccessfully", "Refund Settled Successfully" },
          { "refundPendingSettlement", "Refund Pending Settlement" },
          { "approvedReview", "Passed Review" },
          { "declined", "Declined" },
          { "couldNotVoid", "Could Not Void" },
          { "expired", "Expired" },
          { "generalError", "General Error" },
          { "pendingFinalSettlement", "Pending Final Settlement" },
          { "pendingSettlement", "Pending Settlement" },
          { "failedReview", "Failed Review" },
          { "settledSuccessfully", "Settled Successfully" },
          { "settlementError", "Settlement Error" },
          { "underReview", "Under Review" },
          { "updatingSettlement", "Updating Settlement" },
          { "voided", "Voided" },
          { "FDSPendingReview", "Pending Fraud Detection Suite Review" },
          { "FDSAuthorizedPendingReview", "Passed Fraud Detection Suite Review" },
          { "returnedItem", "Returned Item" },
          { "chargeback", "Chargeback" },
          { "chargebackReversal", "Chargeback Reversal" },
          { "authorizedPendingRelease", "Authorized Pending Release" },
        };
    }
    private static void RegisterTransactionTypes() {
      TransactionTypes = new Dictionary<TransactionType, string> {
        { TransactionType.AuthCapture, "Authorize & Capture" },
        { TransactionType.AuthCaptureContinue, "Authorize & Capture Continue" },
        { TransactionType.AuthOnly, "Authorize Only" },
        { TransactionType.AuthOnlyContinue, "Authorize Only Continue" },
        { TransactionType.CaptureOnly, "Capture Only" },
        { TransactionType.GetDetails, "Get Details" },
        { TransactionType.PriorAuthCapture, "Prior Authorization Capture" },
        { TransactionType.Refund, "Refund" },
        { TransactionType.Void, "Void" }
      };
    }
  }
}
