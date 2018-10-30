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
    public partial class QuoteStatus {
		/// <summary>
		/// An enum representation of the 'tbQuoteStatus' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbQuoteStatus</remark>
		[Serializable]
		public enum List {
			Offered = 1, 
			Accepted = 2, 
			Declined = 3
		}		

	

		
	}
}