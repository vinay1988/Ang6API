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
	
	public class SecurityGroupSecurityFunctionPermissionDetails {
		
		#region Constructors
		
		public SecurityGroupSecurityFunctionPermissionDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SecurityGroupSecurityFunctionPermissionId (from Table)
		/// </summary>
		public System.Int32 SecurityGroupSecurityFunctionPermissionId { get; set; }
		/// <summary>
		/// SecurityGroupNo (from Table)
		/// </summary>
		public System.Int32 SecurityGroupNo { get; set; }
		/// <summary>
		/// SecurityFunctionNo (from Table)
		/// </summary>
		public System.Int32 SecurityFunctionNo { get; set; }
		/// <summary>
		/// IsAllowed (from Table)
		/// </summary>
		public System.Boolean IsAllowed { get; set; }
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