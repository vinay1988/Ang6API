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
	
	public class RecentlyViewedDetails {
		
		#region Constructors
		
		public RecentlyViewedDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// RecentlyViewedId (from Table)
		/// </summary>
		public System.Int32 RecentlyViewedId { get; set; }
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32? LoginNo { get; set; }
		/// <summary>
		/// PageTitle (from Table)
		/// </summary>
		public System.String PageTitle { get; set; }
		/// <summary>
		/// PageURL (from Table)
		/// </summary>
		public System.String PageURL { get; set; }
		/// <summary>
		/// DateAdded (from Table)
		/// </summary>
		public System.DateTime? DateAdded { get; set; }
		/// <summary>
		/// Locked (from Table)
		/// </summary>
		public System.Boolean? Locked { get; set; }
		/// <summary>
		/// RowNum (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int64? RowNum { get; set; }

		#endregion

	}
}