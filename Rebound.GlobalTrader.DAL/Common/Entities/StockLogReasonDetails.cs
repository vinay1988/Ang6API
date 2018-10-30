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
	
	public class StockLogReasonDetails {
		
		#region Constructors
		
		public StockLogReasonDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// StockLogReasonId (from Table)
		/// </summary>
		public System.Int32 StockLogReasonId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }

		#endregion

	}
}