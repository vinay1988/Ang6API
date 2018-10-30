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
	
	public class TeamDetails {
		
		#region Constructors
		
		public TeamDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// TeamId (from Table)
		/// </summary>
		public System.Int32 TeamId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// TeamName (from usp_select_Company)
		/// </summary>
		public System.String TeamName { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// NumberOfMembers (from usp_selectAll_Division_for_Client)
		/// </summary>
		public System.Int32? NumberOfMembers { get; set; }

		#endregion

	}
}