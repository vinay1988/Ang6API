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
	
	public class ToDoDetails {
		
		#region Constructors
		
		public ToDoDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ToDoId (from Table)
		/// </summary>
		public System.Int32 ToDoId { get; set; }
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32? LoginNo { get; set; }
		/// <summary>
		/// Subject (from Table)
		/// </summary>
		public System.String Subject { get; set; }
		/// <summary>
		/// DateAdded (from Table)
		/// </summary>
		public System.DateTime? DateAdded { get; set; }
		/// <summary>
		/// DueDate (from Table)
		/// </summary>
		public System.DateTime? DueDate { get; set; }
		/// <summary>
		/// ToDoText (from Table)
		/// </summary>
		public System.String ToDoText { get; set; }
		/// <summary>
		/// Priority (from Table)
		/// </summary>
		public System.Int32? Priority { get; set; }
		/// <summary>
		/// IsComplete (from Table)
		/// </summary>
		public System.Boolean IsComplete { get; set; }
		/// <summary>
		/// ReminderDate (from Table)
		/// </summary>
		public System.DateTime? ReminderDate { get; set; }
		/// <summary>
		/// ReminderText (from Table)
		/// </summary>
		public System.String ReminderText { get; set; }
		/// <summary>
		/// CompanyNo (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// ReminderHasBeenNotified (from Table)
		/// </summary>
		public System.Boolean ReminderHasBeenNotified { get; set; }
		/// <summary>
		/// RelatedMailMessageNo (from Table)
		/// </summary>
		public System.Int32? RelatedMailMessageNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// LoginName (from Table)
		/// </summary>
		public System.String LoginName { get; set; }

		#endregion

	}
}