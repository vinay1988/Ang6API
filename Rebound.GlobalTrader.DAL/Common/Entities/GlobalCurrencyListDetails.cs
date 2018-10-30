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
	
	public class GlobalCurrencyListDetails {
		
		#region Constructors
		
		public GlobalCurrencyListDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// GlobalCurrencyId (from Table)
		/// </summary>
		public System.Int32 GlobalCurrencyId { get; set; }
		/// <summary>
		/// GlobalCurrencyName (from Table)
		/// </summary>
		public System.String GlobalCurrencyName { get; set; }
		/// <summary>
		/// GlobalCurrencyDescription (from Table)
		/// </summary>
		public System.String GlobalCurrencyDescription { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// Priority (from Table)
		/// </summary>
		public System.Boolean Priority { get; set; }
		/// <summary>
		/// Symbol (from Table)
		/// </summary>
		public System.String Symbol { get; set; }

		#endregion

	}
}