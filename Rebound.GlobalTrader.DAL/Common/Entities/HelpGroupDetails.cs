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
	
	public class HelpGroupDetails {
		
		#region Constructors
		
		public HelpGroupDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// HelpGroupId (from Table)
		/// </summary>
		public System.Int32 HelpGroupId { get; set; }
		/// <summary>
		/// Title (from Table)
		/// </summary>
		public System.String Title { get; set; }
		/// <summary>
		/// SortOrder (from Table)
		/// </summary>
		public System.Int32? SortOrder { get; set; }

		#endregion

	}
}