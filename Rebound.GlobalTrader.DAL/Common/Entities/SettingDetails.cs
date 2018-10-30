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
	
	public class SettingDetails {
		
		#region Constructors
		
		public SettingDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SettingID (from Table)
		/// </summary>
		public System.Int32 SettingID { get; set; }
		/// <summary>
		/// SettingItemID (from Table)
		/// </summary>
		public System.Int32 SettingItemID { get; set; }
		/// <summary>
		/// ClientID (from Table)
		/// </summary>
		public System.Int32? ClientID { get; set; }
		/// <summary>
		/// SettingValue (from Table)
		/// </summary>
		public System.String SettingValue { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime? DLUP { get; set; }
		/// <summary>
		/// SettingItemName (from usp_selectAll_Setting_values)
		/// </summary>
		public System.String SettingItemName { get; set; }
		/// <summary>
		/// DefaultValue (from usp_selectAll_Setting_values)
		/// </summary>
		public System.String DefaultValue { get; set; }

		#endregion

	}
}