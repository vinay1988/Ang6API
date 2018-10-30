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
	
	public class UserAuditDetails {
		
		#region Constructors
		
		public UserAuditDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32 LoginNo { get; set; }
		/// <summary>
		/// IPAddress (from Table)
		/// </summary>
		public System.String IPAddress { get; set; }
		/// <summary>
		/// StartTime (from Table)
		/// </summary>
		public System.DateTime StartTime { get; set; }
		/// <summary>
		/// EndTime (from Table)
		/// </summary>
		public System.DateTime? EndTime { get; set; }

		#endregion

	}
}