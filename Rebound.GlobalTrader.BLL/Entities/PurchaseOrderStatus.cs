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
		public partial class PurchaseOrderStatus : BizObject {
		
		#region Properties

		protected static DAL.PurchaseOrderStatusElement Settings {
			get { return Globals.Settings.PurchaseOrderStatuss; }
		}

		/// <summary>
		/// PurchaseOrderStatusId
		/// </summary>
		public System.Int32 PurchaseOrderStatusId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_PurchaseOrderStatus]
		/// </summary>
		public static bool Delete(System.Int32? purchaseOrderStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderStatus.Delete(purchaseOrderStatusId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_PurchaseOrderStatus]
		/// </summary>
		public static List<PurchaseOrderStatus> DropDown() {
			List<PurchaseOrderStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderStatus.DropDown();
			if (lstDetails == null) {
				return new List<PurchaseOrderStatus>();
			} else {
				List<PurchaseOrderStatus> lst = new List<PurchaseOrderStatus>();
				foreach (PurchaseOrderStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.PurchaseOrderStatus obj = new Rebound.GlobalTrader.BLL.PurchaseOrderStatus();
					obj.PurchaseOrderStatusId = objDetails.PurchaseOrderStatusId;
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
		/// Calls [usp_insert_PurchaseOrderStatus]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderStatus.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_PurchaseOrderStatus]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderStatus.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_PurchaseOrderStatus]
		/// </summary>
		public static PurchaseOrderStatus Get(System.Int32? purchaseOrderStatusId) {
			Rebound.GlobalTrader.DAL.PurchaseOrderStatusDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderStatus.Get(purchaseOrderStatusId);
			if (objDetails == null) {
				return null;
			} else {
				PurchaseOrderStatus obj = new PurchaseOrderStatus();
				obj.PurchaseOrderStatusId = objDetails.PurchaseOrderStatusId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_PurchaseOrderStatus]
		/// </summary>
		public static List<PurchaseOrderStatus> GetList() {
			List<PurchaseOrderStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderStatus.GetList();
			if (lstDetails == null) {
				return new List<PurchaseOrderStatus>();
			} else {
				List<PurchaseOrderStatus> lst = new List<PurchaseOrderStatus>();
				foreach (PurchaseOrderStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.PurchaseOrderStatus obj = new Rebound.GlobalTrader.BLL.PurchaseOrderStatus();
					obj.PurchaseOrderStatusId = objDetails.PurchaseOrderStatusId;
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
		/// Calls [usp_update_PurchaseOrderStatus]
		/// </summary>
		public static bool Update(System.String name, System.Int32? purchaseOrderStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderStatus.Update(name, purchaseOrderStatusId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_PurchaseOrderStatus]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderStatus.Update(Name, PurchaseOrderStatusId);
		}

        private static PurchaseOrderStatus PopulateFromDBDetailsObject(PurchaseOrderStatusDetails obj) {
            PurchaseOrderStatus objNew = new PurchaseOrderStatus();
			objNew.PurchaseOrderStatusId = obj.PurchaseOrderStatusId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}