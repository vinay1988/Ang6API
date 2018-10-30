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
	
	public class SiteSectionDetails {
		
		#region Constructors
		
		public SiteSectionDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SiteSectionId (from Table)
		/// </summary>
		public System.Int32 SiteSectionId { get; set; }
		/// <summary>
		/// SiteSectionName (from usp_selectAll_SecurityFunction_Section)
		/// </summary>
		public System.String SiteSectionName { get; set; }
		/// <summary>
		/// Description (from Table)
		/// </summary>
		public System.String Description { get; set; }
		/// <summary>
		/// URL (from Table)
		/// </summary>
		public System.String URL { get; set; }

		#endregion

	}
}