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
		public partial class Setting : BizObject {
		
		#region Properties

		protected static DAL.SettingElement Settings {
			get { return Globals.Settings.Settings; }
		}

		/// <summary>
		/// SettingID
		/// </summary>
		public System.Int32 SettingID { get; set; }		
		/// <summary>
		/// SettingItemID
		/// </summary>
		public System.Int32 SettingItemID { get; set; }		
		/// <summary>
		/// ClientID
		/// </summary>
		public System.Int32? ClientID { get; set; }		
		/// <summary>
		/// SettingValue
		/// </summary>
		public System.String SettingValue { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime? DLUP { get; set; }		
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
		/// Insert
		/// Calls [usp_insert_Setting]
		/// </summary>
		public static Int32 Insert(System.Int32? settingItemId, System.Int32? clientId, System.String settingValue, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Setting.Insert(settingItemId, clientId, settingValue, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Setting]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Setting.Insert(SettingItemID, ClientID, SettingValue, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Setting]
		/// </summary>
		public static Setting Get(System.Int32? settingId) {
			Rebound.GlobalTrader.DAL.SettingDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Setting.Get(settingId);
			if (objDetails == null) {
				return null;
			} else {
				Setting obj = new Setting();
				obj.SettingID = objDetails.SettingID;
				obj.SettingItemID = objDetails.SettingItemID;
				obj.ClientID = objDetails.ClientID;
				obj.SettingValue = objDetails.SettingValue;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetValue
		/// Calls [usp_select_Setting_Value]
		/// </summary>
		public static Setting GetValue(System.Int32? settingItemId, System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.SettingDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Setting.GetValue(settingItemId, clientId);
			if (objDetails == null) {
				return null;
			} else {
				Setting obj = new Setting();
				obj.SettingValue = objDetails.SettingValue;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListValues
		/// Calls [usp_selectAll_Setting_values]
		/// </summary>
		public static List<Setting> GetListValues(System.Int32? clientId) {
			List<SettingDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Setting.GetListValues(clientId);
			if (lstDetails == null) {
				return new List<Setting>();
			} else {
				List<Setting> lst = new List<Setting>();
				foreach (SettingDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Setting obj = new Rebound.GlobalTrader.BLL.Setting();
					obj.SettingItemID = objDetails.SettingItemID;
					obj.SettingItemName = objDetails.SettingItemName;
					obj.SettingValue = objDetails.SettingValue;
					obj.DefaultValue = objDetails.DefaultValue;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Setting]
		/// </summary>
		public static bool Update(System.Int32? settingItemId, System.Int32? clientId, System.String settingValue, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Setting.Update(settingItemId, clientId, settingValue, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Setting]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Setting.Update(SettingItemID, ClientID, SettingValue, UpdatedBy);
		}

        private static Setting PopulateFromDBDetailsObject(SettingDetails obj) {
            Setting objNew = new Setting();
			objNew.SettingID = obj.SettingID;
			objNew.SettingItemID = obj.SettingItemID;
			objNew.ClientID = obj.ClientID;
			objNew.SettingValue = obj.SettingValue;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.SettingItemName = obj.SettingItemName;
			objNew.DefaultValue = obj.DefaultValue;
            return objNew;
        }
		
		#endregion
		
	}
}