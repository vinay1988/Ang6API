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
    public partial class SalesOrderStatus {
		/// <summary>
		/// An enum representation of the 'tbSalesOrderStatus' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbSalesOrderStatus</remark>
		[Serializable]
		public enum List {
			New = 1, 
			Unposted = 2, 
			PartPosted = 3, 
			Posted = 4, 
			PartAllocated = 5, 
			Allocated = 6, 
			AuthorisedPartAllocated = 7, 
			Authorised = 8, 
			PartShipped = 9, 
			Complete = 10
		}		

	

		
	}
}