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
		public partial class StockLogType : BizObject {
		
		#region Properties

		protected static DAL.StockLogTypeElement Settings {
			get { return Globals.Settings.StockLogTypes; }
		}

		/// <summary>
		/// StockLogTypeId
		/// </summary>
		public System.Int32 StockLogTypeId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		
		/// <summary>
		/// ParentStockLogTypeNo
		/// </summary>
		public System.Int32? ParentStockLogTypeNo { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_StockLogType]
		/// </summary>
		public static bool Delete(System.Int32? stockLogTypeId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLogType.Delete(stockLogTypeId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_StockLogType]
		/// </summary>
		public static List<StockLogType> DropDown() {
			List<StockLogTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockLogType.DropDown();
			if (lstDetails == null) {
				return new List<StockLogType>();
			} else {
				List<StockLogType> lst = new List<StockLogType>();
				foreach (StockLogTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.StockLogType obj = new Rebound.GlobalTrader.BLL.StockLogType();
					obj.StockLogTypeId = objDetails.StockLogTypeId;
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
		/// Calls [usp_insert_StockLogType]
		/// </summary>
		public static Int32 Insert(System.String name, System.Int32? parentStockLogTypeNo) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.StockLogType.Insert(name, parentStockLogTypeNo);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_StockLogType]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLogType.Insert(Name, ParentStockLogTypeNo);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_StockLogType]
		/// </summary>
		public static StockLogType Get(System.Int32? stockLogTypeId) {
			Rebound.GlobalTrader.DAL.StockLogTypeDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockLogType.Get(stockLogTypeId);
			if (objDetails == null) {
				return null;
			} else {
				StockLogType obj = new StockLogType();
				obj.StockLogTypeId = objDetails.StockLogTypeId;
				obj.Name = objDetails.Name;
				obj.ParentStockLogTypeNo = objDetails.ParentStockLogTypeNo;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_StockLogType]
		/// </summary>
		public static bool Update(System.String name, System.Int32? parentStockLogTypeNo, System.Int32? stockLogTypeId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLogType.Update(name, parentStockLogTypeNo, stockLogTypeId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_StockLogType]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLogType.Update(Name, ParentStockLogTypeNo, StockLogTypeId);
		}

        private static StockLogType PopulateFromDBDetailsObject(StockLogTypeDetails obj) {
            StockLogType objNew = new StockLogType();
			objNew.StockLogTypeId = obj.StockLogTypeId;
			objNew.Name = obj.Name;
			objNew.ParentStockLogTypeNo = obj.ParentStockLogTypeNo;
            return objNew;
        }
		
		#endregion
		
	}
}