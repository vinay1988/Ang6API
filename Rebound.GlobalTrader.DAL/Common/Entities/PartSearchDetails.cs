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
	
	public class PartSearchDetails {
		
		#region Constructors
		
		public PartSearchDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// PartSearchID (from Table)
		/// </summary>
		public System.Int32 PartSearchID { get; set; }
		/// <summary>
		/// SearchPart (from Table)
		/// </summary>
		public System.String SearchPart { get; set; }
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32? LoginNo { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime? DLUP { get; set; }

		#endregion

	}
}