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
    public partial class CompanyAddressType {
		/// <summary>
		/// An enum representation of the 'tbCompanyAddressType' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbCompanyAddressType</remark>
		[Serializable]
		public enum List {
			Billing_Address = 1, 
			Shipping_Address = 2, 
			Division_Address = 3, 
			Warehouse_Address = 4, 
			General_Company_Address = 5
		}		

	
	}
}