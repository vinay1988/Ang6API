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
	
	public class HelpGlossaryDetails {
		
		#region Constructors
		
		public HelpGlossaryDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// HelpGlossaryId (from Table)
		/// </summary>
		public System.Int32 HelpGlossaryId { get; set; }
		/// <summary>
		/// Title (from Table)
		/// </summary>
		public System.String Title { get; set; }
		/// <summary>
		/// HTMLText (from Table)
		/// </summary>
		public System.String HTMLText { get; set; }

		#endregion

	}
}