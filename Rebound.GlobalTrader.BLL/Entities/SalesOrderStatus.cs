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
		public partial class SalesOrderStatus : BizObject {
		
		#region Properties

		protected static DAL.SalesOrderStatusElement Settings {
			get { return Globals.Settings.SalesOrderStatuss; }
		}

		/// <summary>
		/// SalesOrderStatusId
		/// </summary>
		public System.Int32 SalesOrderStatusId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SalesOrderStatus]
		/// </summary>
		public static bool Delete(System.Int32? salesOrderStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderStatus.Delete(salesOrderStatusId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_SalesOrderStatus]
		/// </summary>
		public static List<SalesOrderStatus> DropDown() {
			List<SalesOrderStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderStatus.DropDown();
			if (lstDetails == null) {
				return new List<SalesOrderStatus>();
			} else {
				List<SalesOrderStatus> lst = new List<SalesOrderStatus>();
				foreach (SalesOrderStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SalesOrderStatus obj = new Rebound.GlobalTrader.BLL.SalesOrderStatus();
					obj.SalesOrderStatusId = objDetails.SalesOrderStatusId;
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
		/// Calls [usp_insert_SalesOrderStatus]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderStatus.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_SalesOrderStatus]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderStatus.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_SalesOrderStatus]
		/// </summary>
		public static SalesOrderStatus Get(System.Int32? salesOrderStatusId) {
			Rebound.GlobalTrader.DAL.SalesOrderStatusDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderStatus.Get(salesOrderStatusId);
			if (objDetails == null) {
				return null;
			} else {
				SalesOrderStatus obj = new SalesOrderStatus();
				obj.SalesOrderStatusId = objDetails.SalesOrderStatusId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SalesOrderStatus]
		/// </summary>
		public static List<SalesOrderStatus> GetList() {
			List<SalesOrderStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderStatus.GetList();
			if (lstDetails == null) {
				return new List<SalesOrderStatus>();
			} else {
				List<SalesOrderStatus> lst = new List<SalesOrderStatus>();
				foreach (SalesOrderStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SalesOrderStatus obj = new Rebound.GlobalTrader.BLL.SalesOrderStatus();
					obj.SalesOrderStatusId = objDetails.SalesOrderStatusId;
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
		/// Calls [usp_update_SalesOrderStatus]
		/// </summary>
		public static bool Update(System.String name, System.Int32? salesOrderStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderStatus.Update(name, salesOrderStatusId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_SalesOrderStatus]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderStatus.Update(Name, SalesOrderStatusId);
		}

        private static SalesOrderStatus PopulateFromDBDetailsObject(SalesOrderStatusDetails obj) {
            SalesOrderStatus objNew = new SalesOrderStatus();
			objNew.SalesOrderStatusId = obj.SalesOrderStatusId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}