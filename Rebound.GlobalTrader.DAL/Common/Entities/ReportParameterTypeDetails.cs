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
	
	public class ReportParameterTypeDetails {
		
		#region Constructors
		
		public ReportParameterTypeDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ReportParameterTypeId (from Table)
		/// </summary>
		public System.Int32 ReportParameterTypeId { get; set; }
		/// <summary>
		/// ReportParameterName (from Table)
		/// </summary>
		public System.String ReportParameterName { get; set; }

		#endregion

	}
}