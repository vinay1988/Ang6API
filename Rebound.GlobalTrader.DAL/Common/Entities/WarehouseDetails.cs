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
	
	public class WarehouseDetails {
		
		#region Constructors
		
		public WarehouseDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// WarehouseId (from Table)
		/// </summary>
		public System.Int32 WarehouseId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// WarehouseName (from Table)
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// AddressNo (from Table)
		/// </summary>
		public System.Int32? AddressNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// VirtualWarehouse (from Table)
		/// </summary>
		public System.Boolean VirtualWarehouse { get; set; }
		/// <summary>
		/// DefaultWarehouse (from Table)
		/// </summary>
		public System.Boolean DefaultWarehouse { get; set; }
		/// <summary>
		/// AddressName (from usp_select_Warehouse)
		/// </summary>
		public System.String AddressName { get; set; }
		/// <summary>
		/// Line1 (from usp_select_Warehouse)
		/// </summary>
		public System.String Line1 { get; set; }
		/// <summary>
		/// Line2 (from usp_select_Warehouse)
		/// </summary>
		public System.String Line2 { get; set; }
		/// <summary>
		/// Line3 (from usp_select_Warehouse)
		/// </summary>
		public System.String Line3 { get; set; }
		/// <summary>
		/// County (from usp_select_Warehouse)
		/// </summary>
		public System.String County { get; set; }
		/// <summary>
		/// City (from usp_select_Warehouse)
		/// </summary>
		public System.String City { get; set; }
		/// <summary>
		/// State (from usp_select_Warehouse)
		/// </summary>
		public System.String State { get; set; }
		/// <summary>
		/// ZIP (from usp_select_Warehouse)
		/// </summary>
		public System.String ZIP { get; set; }
		/// <summary>
		/// CountryName (from usp_select_Warehouse)
		/// </summary>
		public System.String CountryName { get; set; }
		/// <summary>
		/// CountryNo (from usp_select_Warehouse)
		/// </summary>
		public System.Int32? CountryNo { get; set; }

		#endregion

	}
}