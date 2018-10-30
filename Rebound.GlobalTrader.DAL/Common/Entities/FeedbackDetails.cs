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
	
	public class FeedbackDetails {
		
		#region Constructors
		
		public FeedbackDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// FeedbackId (from Table)
		/// </summary>
		public System.Int32 FeedbackId { get; set; }
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32 LoginNo { get; set; }
		/// <summary>
		/// FeedbackText (from Table)
		/// </summary>
		public System.String FeedbackText { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime? DLUP { get; set; }

		#endregion

	}
}