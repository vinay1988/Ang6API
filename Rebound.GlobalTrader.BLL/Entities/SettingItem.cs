using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
		public partial class SettingItem : BizObject {
		
		#region Properties

		protected static DAL.SettingItemElement Settings {
			get { return Globals.Settings.SettingItems; }
		}

		/// <summary>
		/// SettingItemID
		/// </summary>
		public System.Int32 SettingItemID { get; set; }		
		/// <summary>
		/// SettingItemName
		/// </summary>
		public System.String SettingItemName { get; set; }		
		/// <summary>
		/// DefaultValue
		/// </summary>
		public System.String DefaultValue { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SettingItem]
		/// </summary>
		public static List<SettingItem> GetList() {
			List<SettingItemDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SettingItem.GetList();
			if (lstDetails == null) {
				return new List<SettingItem>();
			} else {
				List<SettingItem> lst = new List<SettingItem>();
				foreach (SettingItemDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SettingItem obj = new Rebound.GlobalTrader.BLL.SettingItem();
					obj.SettingItemID = objDetails.SettingItemID;
					obj.SettingItemName = objDetails.SettingItemName;
					obj.DefaultValue = objDetails.DefaultValue;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static SettingItem PopulateFromDBDetailsObject(SettingItemDetails obj) {
            SettingItem objNew = new SettingItem();
			objNew.SettingItemID = obj.SettingItemID;
			objNew.SettingItemName = obj.SettingItemName;
			objNew.DefaultValue = obj.DefaultValue;
            return objNew;
        }
		
		#endregion
		
	}
}