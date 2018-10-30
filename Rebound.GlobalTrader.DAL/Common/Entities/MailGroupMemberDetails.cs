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
	
	public class MailGroupMemberDetails {
		
		#region Constructors
		
		public MailGroupMemberDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// MailGroupMemberId (from Table)
		/// </summary>
		public System.Int32 MailGroupMemberId { get; set; }
		/// <summary>
		/// MailGroupNo (from Table)
		/// </summary>
		public System.Int32 MailGroupNo { get; set; }
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32 LoginNo { get; set; }
		/// <summary>
		/// EmployeeName (from usp_selectAll_Audit_authorisation_for_SalesOrder)
		/// </summary>
		public System.String EmployeeName { get; set; }

        public System.String EmailID { get; set; }
		#endregion

	}
}