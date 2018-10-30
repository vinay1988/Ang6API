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
	
	public class ReportCategoryGroupDetails {
		
		#region Constructors
		
		public ReportCategoryGroupDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ReportCategoryGroupId (from Table)
		/// </summary>
		public System.Int32 ReportCategoryGroupId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }
		/// <summary>
		/// SortOrder (from Table)
		/// </summary>
		public System.String SortOrder { get; set; }

		#endregion

	}
}