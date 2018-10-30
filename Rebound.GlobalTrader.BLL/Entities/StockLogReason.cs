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
		public partial class StockLogReason : BizObject {
		
		#region Properties

		protected static DAL.StockLogReasonElement Settings {
			get { return Globals.Settings.StockLogReasons; }
		}

		/// <summary>
		/// StockLogReasonId
		/// </summary>
		public System.Int32 StockLogReasonId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_StockLogReason]
		/// </summary>
		public static bool Delete(System.Int32? stockLogReasonId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLogReason.Delete(stockLogReasonId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_StockLogReason]
		/// </summary>
		public static List<StockLogReason> DropDown(System.Int32? clientNo) {
			List<StockLogReasonDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockLogReason.DropDown(clientNo);
			if (lstDetails == null) {
				return new List<StockLogReason>();
			} else {
				List<StockLogReason> lst = new List<StockLogReason>();
				foreach (StockLogReasonDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.StockLogReason obj = new Rebound.GlobalTrader.BLL.StockLogReason();
					obj.StockLogReasonId = objDetails.StockLogReasonId;
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
		/// Calls [usp_insert_StockLogReason]
		/// </summary>
		public static Int32 Insert(System.String name, System.Int32? clientNo) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.StockLogReason.Insert(name, clientNo);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_StockLogReason]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLogReason.Insert(Name, ClientNo);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_StockLogReason]
		/// </summary>
		public static StockLogReason Get(System.Int32? stockLogReasonId) {
			Rebound.GlobalTrader.DAL.StockLogReasonDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockLogReason.Get(stockLogReasonId);
			if (objDetails == null) {
				return null;
			} else {
				StockLogReason obj = new StockLogReason();
				obj.StockLogReasonId = objDetails.StockLogReasonId;
				obj.Name = objDetails.Name;
				obj.ClientNo = objDetails.ClientNo;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_StockLogReason_for_Client]
		/// </summary>
		public static List<StockLogReason> GetListForClient(System.Int32? clientNo) {
			List<StockLogReasonDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockLogReason.GetListForClient(clientNo);
			if (lstDetails == null) {
				return new List<StockLogReason>();
			} else {
				List<StockLogReason> lst = new List<StockLogReason>();
				foreach (StockLogReasonDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.StockLogReason obj = new Rebound.GlobalTrader.BLL.StockLogReason();
					obj.StockLogReasonId = objDetails.StockLogReasonId;
					obj.Name = objDetails.Name;
					obj.ClientNo = objDetails.ClientNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_StockLogReason]
		/// </summary>
		public static bool Update(System.String name, System.Int32? stockLogReasonId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLogReason.Update(name, stockLogReasonId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_StockLogReason]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLogReason.Update(Name, StockLogReasonId);
		}

        private static StockLogReason PopulateFromDBDetailsObject(StockLogReasonDetails obj) {
            StockLogReason objNew = new StockLogReason();
			objNew.StockLogReasonId = obj.StockLogReasonId;
			objNew.Name = obj.Name;
			objNew.ClientNo = obj.ClientNo;
            return objNew;
        }
		
		#endregion
		
	}
}