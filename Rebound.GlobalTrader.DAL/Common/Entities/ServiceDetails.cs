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
	
	public class ServiceDetails {
		
		#region Constructors
		
		public ServiceDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ServiceId (from Table)
		/// </summary>
		public System.Int32 ServiceId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// ServiceName (from Table)
		/// </summary>
		public System.String ServiceName { get; set; }
		/// <summary>
		/// ServiceDescription (from Table)
		/// </summary>
		public System.String ServiceDescription { get; set; }
		/// <summary>
		/// Price (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Double? Price { get; set; }
		/// <summary>
		/// Cost (from usp_selectAll_Login_Top_Salespersons)
		/// </summary>
		public System.Double? Cost { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// LotNo (from Table)
		/// </summary>
		public System.Int32? LotNo { get; set; }
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
		/// LotName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String LotName { get; set; }
		/// <summary>
		/// RowNum (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// Allocations (from usp_select_Service)
		/// </summary>
		public System.Int32? Allocations { get; set; }
        public System.String ClientBaseCurrencyCode { get; set; }

		#endregion

	}
}