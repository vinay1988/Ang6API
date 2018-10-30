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
	
	public class CountingMethodDetails {
		
		#region Constructors
		
		public CountingMethodDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CountingMethodId (from Table)
		/// </summary>
		public System.Int32 CountingMethodId { get; set; }
		/// <summary>
		/// CountingMethodDescription (from Table)
		/// </summary>
		public System.String CountingMethodDescription { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }

		#endregion

	}
}