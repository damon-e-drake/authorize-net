using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHTC.AuthorizeNet.TransactionDetails.Requests {
  public class SettledBatchListRequest {

    public MerchantAuthentication Authentication { get; private set; }

    [WebXmlValue("Include Statistics", "includeStatistics")]
    public bool IncludeStats { get; set; }

    [WebXmlValue("Start Date", "firstSettlementDate")]
    public DateTime StartDate { get; set; }

    [WebXmlValue("End Date", "lastSettlementDate")]
    public DateTime EndDate { get; set; }

    public SettledBatchListRequest(MerchantAuthentication Credentials) {
      this.Authentication = Credentials;
    }

  }
}
