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
    public partial class GoodsInStatus {
		/// <summary>
		/// An enum representation of the 'tbGoodsInStatus' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbGoodsInStatus</remark>
		[Serializable]
		public enum List {
			New = 1, 
			Received = 2, 
			Inspected = 3, 
			PartInspected = 4, 
			Quarantined = 5, 
			InvoicePaid = 6
		}		

	

		
	}
}