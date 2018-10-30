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
	
	public class ReportCategoryDetails {
		
		#region Constructors
		
		public ReportCategoryDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ReportCategoryId (from Table)
		/// </summary>
		public System.Int32 ReportCategoryId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }
		/// <summary>
		/// ReportCategoryGroupNo (from usp_select_Report)
		/// </summary>
		public System.Int32? ReportCategoryGroupNo { get; set; }
		/// <summary>
		/// SortOrder (from Table)
		/// </summary>
		public System.Int32? SortOrder { get; set; }

		#endregion

	}
}