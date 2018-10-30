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
	
	public class ReportColumnFormatDetails {
		
		#region Constructors
		
		public ReportColumnFormatDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ReportColumnFormatId (from Table)
		/// </summary>
		public System.Int32 ReportColumnFormatId { get; set; }
		/// <summary>
		/// ReportColumnFormatName (from Table)
		/// </summary>
		public System.String ReportColumnFormatName { get; set; }

		#endregion

	}
}