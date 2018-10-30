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
	
	public class SourcingLinkDetails {
		
		#region Constructors
		
		public SourcingLinkDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SourcingLinkId (from Table)
		/// </summary>
		public System.Int32 SourcingLinkId { get; set; }
		/// <summary>
		/// SourcingLinkName (from Table)
		/// </summary>
		public System.String SourcingLinkName { get; set; }
		/// <summary>
		/// URL (from Table)
		/// </summary>
		public System.String URL { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
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