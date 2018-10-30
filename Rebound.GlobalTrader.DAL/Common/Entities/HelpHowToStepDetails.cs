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
	
	public class HelpHowToStepDetails {
		
		#region Constructors
		
		public HelpHowToStepDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// HelpHowToStepId (from Table)
		/// </summary>
		public System.Int32 HelpHowToStepId { get; set; }
		/// <summary>
		/// HelpHowToNo (from Table)
		/// </summary>
		public System.Int32 HelpHowToNo { get; set; }
		/// <summary>
		/// HTMLText (from Table)
		/// </summary>
		public System.String HTMLText { get; set; }

		#endregion

	}
}