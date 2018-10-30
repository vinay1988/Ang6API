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
	
	public class HelpFaqDetails {
		
		#region Constructors
		
		public HelpFaqDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// HelpFAQId (from Table)
		/// </summary>
		public System.Int32 HelpFAQId { get; set; }
		/// <summary>
		/// HelpGroupNo (from Table)
		/// </summary>
		public System.Int32 HelpGroupNo { get; set; }
		/// <summary>
		/// Question (from Table)
		/// </summary>
		public System.String Question { get; set; }
		/// <summary>
		/// Answer (from Table)
		/// </summary>
		public System.String Answer { get; set; }
		/// <summary>
		/// SortOrder (from Table)
		/// </summary>
		public System.Int32? SortOrder { get; set; }

		#endregion

	}
}