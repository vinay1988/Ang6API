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
	
	public class SessionDetails {
		
		#region Constructors
		
		public SessionDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32 LoginNo { get; set; }
		/// <summary>
		/// SessionName (from Table)
		/// </summary>
		public System.String SessionName { get; set; }
		/// <summary>
		/// SessionTimestamp (from Table)
		/// </summary>
		public System.DateTime SessionTimestamp { get; set; }
		/// <summary>
		/// StartTime (from Table)
		/// </summary>
		public System.DateTime StartTime { get; set; }
		/// <summary>
		/// IPAddress (from Table)
		/// </summary>
		public System.String IPAddress { get; set; }
		/// <summary>
		/// EmployeeName (from usp_selectAll_Audit_authorisation_for_SalesOrder)
		/// </summary>
		public System.String EmployeeName { get; set; }
        /// <summary>
        /// ServerIP
        /// </summary>
        public System.String ServerIP { get; set; }

		#endregion

	}
}