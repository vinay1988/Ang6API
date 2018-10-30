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
	
	public class GlobalCountryListDetails {
		
		#region Constructors
		
		public GlobalCountryListDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// GlobalCountryId (from Table)
		/// </summary>
		public System.Int32 GlobalCountryId { get; set; }
		/// <summary>
		/// GlobalCountryName (from Table)
		/// </summary>
		public System.String GlobalCountryName { get; set; }
		/// <summary>
		/// EECMember (from Table)
		/// </summary>
		public System.Boolean EECMember { get; set; }
		/// <summary>
		/// TelephonePrefix (from Table)
		/// </summary>
		public System.String TelephonePrefix { get; set; }
		/// <summary>
		/// Include (from Table)
		/// </summary>
		public System.Boolean Include { get; set; }
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