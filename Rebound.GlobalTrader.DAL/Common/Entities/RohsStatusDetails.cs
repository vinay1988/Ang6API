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
	
	public class RohsStatusDetails {
		
		#region Constructors
		
		public RohsStatusDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ROHSStatusId (from Table)
		/// </summary>
		public System.Int32 ROHSStatusId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }

		#endregion

	}
}