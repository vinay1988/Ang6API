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
	
	public class MailGroupDetails {
		
		#region Constructors
		
		public MailGroupDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// MailGroupId (from Table)
		/// </summary>
		public System.Int32 MailGroupId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime? DLUP { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32? ClientNo { get; set; }
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32? LoginNo { get; set; }
		/// <summary>
		/// NumberOfMembers (from usp_selectAll_Division_for_Client)
		/// </summary>
		public System.Int32? NumberOfMembers { get; set; }
      

		#endregion

	}
}