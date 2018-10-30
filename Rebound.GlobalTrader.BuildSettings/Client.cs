using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace Rebound.GlobalTrader {

	public struct ClientDetails {
        
        public int ClientID;
        public string ClientName;

        public ClientDetails(int intClientID, string strClientName) {
            ClientID = intClientID;
            ClientName = strClientName;
        }

	}
}