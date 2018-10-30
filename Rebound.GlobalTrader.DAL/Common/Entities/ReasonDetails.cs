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
	
	public class ReasonDetails {
		
		#region Constructors
		
		public ReasonDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ReasonId (from Table)
		/// </summary>
		public System.Int32 ReasonId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }
		/// <summary>
		/// Locked (from Table)
		/// </summary>
		public System.Boolean Locked { get; set; }
		/// <summary>
		/// Sold (from Table)
		/// </summary>
		public System.Boolean Sold { get; set; }
		/// <summary>
		/// NotQuoted (from Table)
		/// </summary>
		public System.Boolean NotQuoted { get; set; }

		#endregion

	}
}