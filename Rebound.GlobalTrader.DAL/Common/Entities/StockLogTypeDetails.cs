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
	
	public class StockLogTypeDetails {
		
		#region Constructors
		
		public StockLogTypeDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// StockLogTypeId (from Table)
		/// </summary>
		public System.Int32 StockLogTypeId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }
		/// <summary>
		/// ParentStockLogTypeNo (from Table)
		/// </summary>
		public System.Int32? ParentStockLogTypeNo { get; set; }

		#endregion

	}
}