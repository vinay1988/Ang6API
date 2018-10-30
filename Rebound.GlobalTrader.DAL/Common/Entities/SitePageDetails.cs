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
	
	public class SitePageDetails {
		
		#region Constructors
		
		public SitePageDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SitePageId (from Table)
		/// </summary>
		public System.Int32 SitePageId { get; set; }
		/// <summary>
		/// ShortName (from Table)
		/// </summary>
		public System.String ShortName { get; set; }
		/// <summary>
		/// Description (from Table)
		/// </summary>
		public System.String Description { get; set; }
		/// <summary>
		/// URL (from Table)
		/// </summary>
		public System.String URL { get; set; }
		/// <summary>
		/// SiteSectionNo (from Table)
		/// </summary>
		public System.Int32? SiteSectionNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }

		#endregion

	}
}