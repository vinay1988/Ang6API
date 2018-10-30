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
	
	public class SaleTypeDetails {
		
		#region Constructors
		
		public SaleTypeDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SaleTypeId (from Table)
		/// </summary>
		public System.Int32 SaleTypeId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }

		#endregion

	}
}