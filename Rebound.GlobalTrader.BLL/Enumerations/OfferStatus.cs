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

namespace Rebound.GlobalTrader.BLL {
    public partial class OfferStatus {
		/// <summary>
		/// An enum representation of the 'tbOfferStatus' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbOfferStatus</remark>
		[Serializable]
		public enum List {
			Emailed = 1, 
			Faxed = 2, 
			Confirmed = 3, 
			FaxedAndEmailed = 4, 
			NoStock = 5
		}		

	

		
	}
}