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
	
	public class ManufacturerDetails {
		
		#region Constructors
		
		public ManufacturerDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ManufacturerId (from Table)
		/// </summary>
		public System.Int32 ManufacturerId { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
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
		/// URL (from Table)
		/// </summary>
		public System.String URL { get; set; }
		/// <summary>
		/// FullName (from Table)
		/// </summary>
		public System.String FullName { get; set; }
		/// <summary>
		/// RowNum (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean IsPDFAvailable { get; set; }
        /// <summary>
        /// ConflictResource
        /// </summary>
        public System.String ConflictResource { get; set; }


		#endregion

	}
}