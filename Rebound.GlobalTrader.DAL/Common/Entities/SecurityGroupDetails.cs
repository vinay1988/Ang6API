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
	
	public class SecurityGroupDetails {
		
		#region Constructors
		
		public SecurityGroupDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SecurityGroupId (from Table)
		/// </summary>
		public System.Int32 SecurityGroupId { get; set; }
		/// <summary>
		/// SecurityGroupName (from Table)
		/// </summary>
		public System.String SecurityGroupName { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// Locked (from Table)
		/// </summary>
		public System.Boolean Locked { get; set; }
		/// <summary>
		/// Administrator (from usp_selectAll_Login_for_Client_including_Disabled)
		/// </summary>
		public System.Boolean Administrator { get; set; }
		/// <summary>
		/// NumberOfMembers (from usp_selectAll_Division_for_Client)
		/// </summary>
		public System.Int32? NumberOfMembers { get; set; }

		#endregion

	}
}