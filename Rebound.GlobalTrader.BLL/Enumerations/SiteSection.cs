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
    public partial class SiteSection {
		/// <summary>
		/// An enum representation of the 'tbSiteSection' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbSiteSection</remark>
		[Serializable]
		public enum List {
			Contact = 1, 
			Orders = 2, 
			Warehouse = 3, 
			Profile = 4, 
			Reports = 5, 
			Setup = 6,
            Dashboards = 7
		}		

	

		
	}
}