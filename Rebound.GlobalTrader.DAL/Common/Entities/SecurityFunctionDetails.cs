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
	
	public class SecurityFunctionDetails {
		
		#region Constructors
		
		public SecurityFunctionDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SecurityFunctionId (from Table)
		/// </summary>
		public System.Int32 SecurityFunctionId { get; set; }
		/// <summary>
		/// FunctionName (from Table)
		/// </summary>
		public System.String FunctionName { get; set; }
		/// <summary>
		/// Description (from Table)
		/// </summary>
		public System.String Description { get; set; }
		/// <summary>
		/// SitePageNo (from Table)
		/// </summary>
		public System.Int32? SitePageNo { get; set; }
		/// <summary>
		/// SiteSectionNo (from Table)
		/// </summary>
		public System.Int32? SiteSectionNo { get; set; }
		/// <summary>
		/// ReportNo (from Table)
		/// </summary>
		public System.Int32? ReportNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// InitiallyProhibitedForNewLogins (from Table)
		/// </summary>
		public System.Boolean InitiallyProhibitedForNewLogins { get; set; }
		/// <summary>
		/// DisplaySortOrder (from Table)
		/// </summary>
		public System.Int32? DisplaySortOrder { get; set; }
		/// <summary>
		/// IsAllowed (from usp_select_SecurityFunction_Permission_by_Login)
		/// </summary>
		public System.Boolean? IsAllowed { get; set; }
		/// <summary>
		/// ReportId (from Table)
		/// </summary>
		public System.Int32 ReportId { get; set; }
		/// <summary>
		/// ReportName (from Table)
		/// </summary>
		public System.String ReportName { get; set; }
		/// <summary>
		/// ReportCategoryName (from usp_select_Report)
		/// </summary>
		public System.String ReportCategoryName { get; set; }
		/// <summary>
		/// ReportCategoryGroupName (from usp_select_Report)
		/// </summary>
		public System.String ReportCategoryGroupName { get; set; }
		/// <summary>
		/// SiteSectionName (from usp_selectAll_SecurityFunction_Section)
		/// </summary>
		public System.String SiteSectionName { get; set; }

		#endregion

	}
}