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
	
	public class ReportDetails {
		
		#region Constructors
		
		public ReportDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ReportId (from Table)
		/// </summary>
		public System.Int32 ReportId { get; set; }
		/// <summary>
		/// ReportName (from Table)
		/// </summary>
		public System.String ReportName { get; set; }
		/// <summary>
		/// ReportCategoryNo (from Table)
		/// </summary>
		public System.Int32? ReportCategoryNo { get; set; }
		/// <summary>
		/// StoredProcName (from Table)
		/// </summary>
		public System.String StoredProcName { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// AvailableAsPDF (from Table)
		/// </summary>
		public System.Boolean AvailableAsPDF { get; set; }
		/// <summary>
		/// SortOrder (from Table)
		/// </summary>
		public System.Int32? SortOrder { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// ReportCategoryName (from usp_select_Report)
		/// </summary>
		public System.String ReportCategoryName { get; set; }
		/// <summary>
		/// ReportCategorySortOrder (from usp_select_Report)
		/// </summary>
		public System.Int32? ReportCategorySortOrder { get; set; }
		/// <summary>
		/// ReportCategoryGroupNo (from usp_select_Report)
		/// </summary>
		public System.Int32? ReportCategoryGroupNo { get; set; }
		/// <summary>
		/// ReportCategoryGroupName (from usp_select_Report)
		/// </summary>
		public System.String ReportCategoryGroupName { get; set; }
		/// <summary>
		/// ReportCategoryGroupSortOrder (from usp_select_Report)
		/// </summary>
		public System.String ReportCategoryGroupSortOrder { get; set; }
        public System.Boolean? HUBReport { get; set; }

		#endregion

	}
}