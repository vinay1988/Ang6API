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
	
	public class SecurityGroupLoginDetails {
		
		#region Constructors
		
		public SecurityGroupLoginDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SecurityGroupLoginId (from Table)
		/// </summary>
		public System.Int32 SecurityGroupLoginId { get; set; }
		/// <summary>
		/// SecurityGroupNo (from Table)
		/// </summary>
		public System.Int32 SecurityGroupNo { get; set; }
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32 LoginNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// EmployeeName (from usp_selectAll_Audit_authorisation_for_SalesOrder)
		/// </summary>
		public System.String EmployeeName { get; set; }
		/// <summary>
		/// KeyLogin (from Table)
		/// </summary>
		public System.Boolean KeyLogin { get; set; }
		/// <summary>
		/// Administrator (from usp_selectAll_Login_for_Client_including_Disabled)
		/// </summary>
		public System.Boolean Administrator { get; set; }
        /// <summary>
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }

		#endregion

	}
}