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
	
	public class SystemDocumentFooterDetails {
		
		#region Constructors
		
		public SystemDocumentFooterDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SystemDocumentFooterId (from Table)
		/// </summary>
		public System.Int32 SystemDocumentFooterId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// SystemDocumentNo (from Table)
		/// </summary>
		public System.Int32 SystemDocumentNo { get; set; }
		/// <summary>
		/// FooterText (from Table)
		/// </summary>
		public System.String FooterText { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime? DLUP { get; set; }
		/// <summary>
		/// SystemDocumentName (from usp_selectAll_SystemDocumentFooter_for_Client)
		/// </summary>
		public System.String SystemDocumentName { get; set; }

		#endregion

	}
}