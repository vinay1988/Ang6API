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
	
	public class DropDownDetails {
		
		#region Constructors
		
		public DropDownDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// DropDownId (from Table)
		/// </summary>
		public System.Int32 DropDownId { get; set; }
		/// <summary>
		/// ShortName (from Table)
		/// </summary>
		public System.String ShortName { get; set; }
		/// <summary>
		/// Description (from Table)
		/// </summary>
		public System.String Description { get; set; }

		#endregion

	}
}