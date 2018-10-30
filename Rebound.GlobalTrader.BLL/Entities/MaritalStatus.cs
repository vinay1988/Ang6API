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
		public partial class MaritalStatus : BizObject {
		
		#region Properties

		protected static DAL.MaritalStatusElement Settings {
			get { return Globals.Settings.MaritalStatuss; }
		}

		/// <summary>
		/// MaritalStatusId
		/// </summary>
		public System.Int32 MaritalStatusId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_MaritalStatus]
		/// </summary>
		public static bool Delete(System.Int32? maritalStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MaritalStatus.Delete(maritalStatusId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_MaritalStatus]
		/// </summary>
		public static List<MaritalStatus> DropDown() {
			List<MaritalStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MaritalStatus.DropDown();
			if (lstDetails == null) {
				return new List<MaritalStatus>();
			} else {
				List<MaritalStatus> lst = new List<MaritalStatus>();
				foreach (MaritalStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MaritalStatus obj = new Rebound.GlobalTrader.BLL.MaritalStatus();
					obj.MaritalStatusId = objDetails.MaritalStatusId;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_MaritalStatus]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.MaritalStatus.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_MaritalStatus]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.MaritalStatus.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_MaritalStatus]
		/// </summary>
		public static MaritalStatus Get(System.Int32? maritalStatusId) {
			Rebound.GlobalTrader.DAL.MaritalStatusDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.MaritalStatus.Get(maritalStatusId);
			if (objDetails == null) {
				return null;
			} else {
				MaritalStatus obj = new MaritalStatus();
				obj.MaritalStatusId = objDetails.MaritalStatusId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_MaritalStatus]
		/// </summary>
		public static List<MaritalStatus> GetList() {
			List<MaritalStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MaritalStatus.GetList();
			if (lstDetails == null) {
				return new List<MaritalStatus>();
			} else {
				List<MaritalStatus> lst = new List<MaritalStatus>();
				foreach (MaritalStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MaritalStatus obj = new Rebound.GlobalTrader.BLL.MaritalStatus();
					obj.MaritalStatusId = objDetails.MaritalStatusId;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_MaritalStatus]
		/// </summary>
		public static bool Update(System.String name, System.Int32? maritalStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MaritalStatus.Update(name, maritalStatusId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_MaritalStatus]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.MaritalStatus.Update(Name, MaritalStatusId);
		}

        private static MaritalStatus PopulateFromDBDetailsObject(MaritalStatusDetails obj) {
            MaritalStatus objNew = new MaritalStatus();
			objNew.MaritalStatusId = obj.MaritalStatusId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}