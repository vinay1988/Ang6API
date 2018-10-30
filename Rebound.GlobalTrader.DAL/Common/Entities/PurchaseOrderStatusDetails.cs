using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {
	
	public class PurchaseOrderStatusDetails {
		
		#region Constructors
		
		public PurchaseOrderStatusDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// PurchaseOrderStatusId (from Table)
		/// </summary>
		public System.Int32 PurchaseOrderStatusId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }

		#endregion

	}
}