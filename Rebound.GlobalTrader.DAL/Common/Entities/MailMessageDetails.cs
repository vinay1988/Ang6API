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
	
	public class MailMessageDetails {
		
		#region Constructors
		
		public MailMessageDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// MailMessageId (from Table)
		/// </summary>
		public System.Int32 MailMessageId { get; set; }
		/// <summary>
		/// MailMessageFolderNo (from Table)
		/// </summary>
		public System.Int32? MailMessageFolderNo { get; set; }
		/// <summary>
		/// FromLoginNo (from Table)
		/// </summary>
		public System.Int32? FromLoginNo { get; set; }
		/// <summary>
		/// ToLoginNo (from Table)
		/// </summary>
		public System.Int32? ToLoginNo { get; set; }
		/// <summary>
		/// Subject (from Table)
		/// </summary>
		public System.String Subject { get; set; }
		/// <summary>
		/// Body (from Table)
		/// </summary>
		public System.String Body { get; set; }
		/// <summary>
		/// DateSent (from Table)
		/// </summary>
		public System.DateTime? DateSent { get; set; }
		/// <summary>
		/// CompanyNo (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime? DLUP { get; set; }
		/// <summary>
		/// RecipientHasBeenNotified (from Table)
		/// </summary>
		public System.Boolean RecipientHasBeenNotified { get; set; }
		/// <summary>
		/// HasBeenRead (from Table)
		/// </summary>
		public System.Boolean HasBeenRead { get; set; }
		/// <summary>
		/// FromLoginName (from usp_select_MailMessage)
		/// </summary>
		public System.String FromLoginName { get; set; }
		/// <summary>
		/// ToLoginName (from usp_select_MailMessage)
		/// </summary>
		public System.String ToLoginName { get; set; }
		/// <summary>
		/// CompanyName (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CompanyName { get; set; }

		#endregion

	}
}