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
	
	public class ShipViaDetails {
		
		#region Constructors
		
		public ShipViaDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ShipViaId (from Table)
		/// </summary>
		public System.Int32 ShipViaId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// ShipViaName (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String ShipViaName { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// Service (from Table)
		/// </summary>
		public System.String Service { get; set; }
		/// <summary>
		/// Shipper (from Table)
		/// </summary>
		public System.String Shipper { get; set; }
		/// <summary>
		/// Buy (from Table)
		/// </summary>
		public System.Boolean Buy { get; set; }
		/// <summary>
		/// Sell (from Table)
		/// </summary>
		public System.Boolean Sell { get; set; }
		/// <summary>
		/// Cost (from usp_selectAll_Login_Top_Salespersons)
		/// </summary>
		public System.Double? Cost { get; set; }
		/// <summary>
		/// Charge (from Table)
		/// </summary>
		public System.Double? Charge { get; set; }
		/// <summary>
		/// PickUp (from usp_select_SalesOrder)
		/// </summary>
		public System.String PickUp { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
        /// <summary>
        /// IsSameAsShipCost
        /// </summary>
        public System.Boolean IsSameAsShipCost { get; set; }	

		#endregion

	}
}