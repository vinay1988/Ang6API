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
		public partial class BackOrder : BizObject {
		
		#region Properties

		protected static DAL.BackOrderElement Settings {
			get { return Globals.Settings.BackOrders; }
		}

		/// <summary>
		/// BackOrderId
		/// </summary>
		public System.Int32 BackOrderId { get; set; }		
		/// <summary>
		/// SalesOrderLineNo
		/// </summary>
		public System.Int32 SalesOrderLineNo { get; set; }		
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32 Quantity { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_BackOrder]
		/// </summary>
		public static bool Delete(System.Int32? salesOrderLineNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.BackOrder.Delete(salesOrderLineNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_BackOrder]
		/// </summary>
		public static Int32 Insert(System.Int32? salesOrderLineNo, System.Int32? quantity, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.BackOrder.Insert(salesOrderLineNo, quantity, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_BackOrder]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.BackOrder.Insert(SalesOrderLineNo, Quantity, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_BackOrder]
		/// </summary>
		public static BackOrder Get(System.Int32? salesOrderLineNo) {
			Rebound.GlobalTrader.DAL.BackOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.BackOrder.Get(salesOrderLineNo);
			if (objDetails == null) {
				return null;
			} else {
				BackOrder obj = new BackOrder();
				obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
				obj.Quantity = objDetails.Quantity;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_BackOrder]
		/// </summary>
		public static List<BackOrder> GetList(System.Int32? pageIndex, System.Int32? pageSize) {
			List<BackOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.BackOrder.GetList(pageIndex, pageSize);
			if (lstDetails == null) {
				return new List<BackOrder>();
			} else {
				List<BackOrder> lst = new List<BackOrder>();
				foreach (BackOrderDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.BackOrder obj = new Rebound.GlobalTrader.BLL.BackOrder();
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.Quantity = objDetails.Quantity;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.RowNum = objDetails.RowNum;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_BackOrder]
		/// </summary>
		public static bool Update(System.Int32? salesOrderLineNo, System.Int32? quantity, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.BackOrder.Update(salesOrderLineNo, quantity, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_BackOrder]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.BackOrder.Update(SalesOrderLineNo, Quantity, UpdatedBy);
		}

        private static BackOrder PopulateFromDBDetailsObject(BackOrderDetails obj) {
            BackOrder objNew = new BackOrder();
			objNew.BackOrderId = obj.BackOrderId;
			objNew.SalesOrderLineNo = obj.SalesOrderLineNo;
			objNew.Quantity = obj.Quantity;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.RowNum = obj.RowNum;
            return objNew;
        }
		
		#endregion
		
	}
}