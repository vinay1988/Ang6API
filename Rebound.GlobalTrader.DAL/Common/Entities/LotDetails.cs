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
	
	public class LotDetails {
		
		#region Constructors
		
		public LotDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// LotId (from Table)
		/// </summary>
		public System.Int32 LotId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// LotName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String LotName { get; set; }
		/// <summary>
		/// Cost (from usp_selectAll_Login_Top_Salespersons)
		/// </summary>
		public System.Double? Cost { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// OnHold (from Table)
		/// </summary>
		public System.Boolean OnHold { get; set; }
		/// <summary>
		/// Consignment (from Table)
		/// </summary>
		public System.Boolean Consignment { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// LotCode (from Table)
		/// </summary>
		public System.String LotCode { get; set; }
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
		/// CurrencyCode (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// StockCount (from usp_datalistnugget_Lot)
		/// </summary>
		public System.Int32? StockCount { get; set; }
		/// <summary>
		/// RowNum (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_Client)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// LockForCustomerNo
        /// </summary>
        public System.Int32? LockForCustomerNo { get; set; }
        /// <summary>
        /// LockForCustomer
        /// </summary>
        public System.String LockForCustomer { get; set; }

		#endregion

	}
}