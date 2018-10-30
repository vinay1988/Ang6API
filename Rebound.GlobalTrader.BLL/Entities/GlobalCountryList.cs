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
		public partial class GlobalCountryList : BizObject {
		
		#region Properties

		protected static DAL.GlobalCountryListElement Settings {
			get { return Globals.Settings.GlobalCountryLists; }
		}

		/// <summary>
		/// GlobalCountryId
		/// </summary>
		public System.Int32 GlobalCountryId { get; set; }		
		/// <summary>
		/// GlobalCountryName
		/// </summary>
		public System.String GlobalCountryName { get; set; }		
		/// <summary>
		/// EECMember
		/// </summary>
		public System.Boolean EECMember { get; set; }		
		/// <summary>
		/// TelephonePrefix
		/// </summary>
		public System.String TelephonePrefix { get; set; }		
		/// <summary>
		/// Include
		/// </summary>
		public System.Boolean Include { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_GlobalCountryList]
		/// </summary>
		public static List<GlobalCountryList> DropDown(System.Boolean? includeSelected, System.Int32? clientNo) {
			List<GlobalCountryListDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalCountryList.DropDown(includeSelected, clientNo);
			if (lstDetails == null) {
				return new List<GlobalCountryList>();
			} else {
				List<GlobalCountryList> lst = new List<GlobalCountryList>();
				foreach (GlobalCountryListDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GlobalCountryList obj = new Rebound.GlobalTrader.BLL.GlobalCountryList();
					obj.GlobalCountryId = objDetails.GlobalCountryId;
					obj.GlobalCountryName = objDetails.GlobalCountryName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_GlobalCountryList]
		/// </summary>
		public static Int32 Insert(System.String globalCountryName, System.Boolean? eecMember, System.String telephonePrefix, System.Boolean? include, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GlobalCountryList.Insert(globalCountryName, eecMember, telephonePrefix, include, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_GlobalCountryList]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.GlobalCountryList.Insert(GlobalCountryName, EECMember, TelephonePrefix, Include, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_GlobalCountryList]
		/// </summary>
		public static GlobalCountryList Get(System.Int32? countryNo) {
			Rebound.GlobalTrader.DAL.GlobalCountryListDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalCountryList.Get(countryNo);
			if (objDetails == null) {
				return null;
			} else {
				GlobalCountryList obj = new GlobalCountryList();
				obj.GlobalCountryId = objDetails.GlobalCountryId;
				obj.GlobalCountryName = objDetails.GlobalCountryName;
				obj.EECMember = objDetails.EECMember;
				obj.TelephonePrefix = objDetails.TelephonePrefix;
				obj.Include = objDetails.Include;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_GlobalCountryList]
		/// </summary>
		public static List<GlobalCountryList> GetList() {
			List<GlobalCountryListDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalCountryList.GetList();
			if (lstDetails == null) {
				return new List<GlobalCountryList>();
			} else {
				List<GlobalCountryList> lst = new List<GlobalCountryList>();
				foreach (GlobalCountryListDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GlobalCountryList obj = new Rebound.GlobalTrader.BLL.GlobalCountryList();
					obj.GlobalCountryId = objDetails.GlobalCountryId;
					obj.GlobalCountryName = objDetails.GlobalCountryName;
					obj.EECMember = objDetails.EECMember;
					obj.TelephonePrefix = objDetails.TelephonePrefix;
					obj.Include = objDetails.Include;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_GlobalCountryList]
		/// </summary>
		public static bool Update(System.Int32? globalCountryId, System.String globalCountryName, System.String telephonePrefix, System.Boolean? eecMember, System.Boolean? include, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.GlobalCountryList.Update(globalCountryId, globalCountryName, telephonePrefix, eecMember, include, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_GlobalCountryList]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.GlobalCountryList.Update(GlobalCountryId, GlobalCountryName, TelephonePrefix, EECMember, Include, UpdatedBy);
		}

        private static GlobalCountryList PopulateFromDBDetailsObject(GlobalCountryListDetails obj) {
            GlobalCountryList objNew = new GlobalCountryList();
			objNew.GlobalCountryId = obj.GlobalCountryId;
			objNew.GlobalCountryName = obj.GlobalCountryName;
			objNew.EECMember = obj.EECMember;
			objNew.TelephonePrefix = obj.TelephonePrefix;
			objNew.Include = obj.Include;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}