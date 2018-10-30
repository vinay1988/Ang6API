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
	
	public class BackOrderDetails {
		
		#region Constructors
		
		public BackOrderDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// BackOrderId (from Table)
		/// </summary>
		public System.Int32 BackOrderId { get; set; }
		/// <summary>
		/// SalesOrderLineNo (from Table)
		/// </summary>
		public System.Int32 SalesOrderLineNo { get; set; }
		/// <summary>
		/// Quantity (from Table)
		/// </summary>
		public System.Int32 Quantity { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// RowNum (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int64? RowNum { get; set; }

		#endregion

	}
}