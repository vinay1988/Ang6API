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
	
	public class HelpHowToDetails {
		
		#region Constructors
		
		public HelpHowToDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// HelpHowToId (from Table)
		/// </summary>
		public System.Int32 HelpHowToId { get; set; }
		/// <summary>
		/// HelpGroupNo (from Table)
		/// </summary>
		public System.Int32 HelpGroupNo { get; set; }
		/// <summary>
		/// Title (from Table)
		/// </summary>
		public System.String Title { get; set; }
		/// <summary>
		/// ImageName (from Table)
		/// </summary>
		public System.String ImageName { get; set; }
		/// <summary>
		/// SortOrder (from Table)
		/// </summary>
		public System.Int32? SortOrder { get; set; }

		#endregion

	}
}