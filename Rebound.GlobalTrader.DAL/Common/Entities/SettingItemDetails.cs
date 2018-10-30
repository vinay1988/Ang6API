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
	
	public class SettingItemDetails {
		
		#region Constructors
		
		public SettingItemDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SettingItemID (from Table)
		/// </summary>
		public System.Int32 SettingItemID { get; set; }
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