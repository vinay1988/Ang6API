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
	
	public class SaleCommissionDetails {
		
		#region Constructors
		
		public SaleCommissionDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SaleCommissionId (from Table)
		/// </summary>
		public System.Int32 SaleCommissionId { get; set; }
		/// <summary>
		/// SaleTypeNo (from Table)
		/// </summary>
		public System.Int32 SaleTypeNo { get; set; }
		/// <summary>
		/// CommissionPercent (from Table)
		/// </summary>
		public System.Double CommissionPercent { get; set; }
		/// <summary>
		/// UpToAmount (from Table)
		/// </summary>
		public System.Double UpToAmount { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }

		#endregion

	}
}