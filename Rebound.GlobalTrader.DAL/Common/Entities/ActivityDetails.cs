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
	
	public class ActivityDetails {
		
		#region Constructors
		
		public ActivityDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ActivityId (from Table)
		/// </summary>
		public System.Int32 ActivityId { get; set; }
		/// <summary>
		/// TableName (from Table)
		/// </summary>
		public System.String TableName { get; set; }
		/// <summary>
		/// KeyNo (from Table)
		/// </summary>
		public System.Int32 KeyNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32? ClientNo { get; set; }
		/// <summary>
		/// RowId (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32 RowId { get; set; }
		/// <summary>
		/// RowNumber (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32 RowNumber { get; set; }
		/// <summary>
		/// CompanyNo (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// CompanyName (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// PartName (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String PartName { get; set; }
		/// <summary>
		/// RowValue (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Double? RowValue { get; set; }
		/// <summary>
		/// RowDate (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.DateTime RowDate { get; set; }
		/// <summary>
		/// ContactName (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// RowCnt (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// RowNum (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int64? RowNum { get; set; }

		#endregion

	}
}