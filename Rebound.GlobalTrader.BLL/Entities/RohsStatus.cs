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
		public partial class RohsStatus : BizObject {
		
		#region Properties

		protected static DAL.RohsStatusElement Settings {
			get { return Globals.Settings.RohsStatuss; }
		}

		/// <summary>
		/// ROHSStatusId
		/// </summary>
		public System.Int32 ROHSStatusId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ROHSStatus]
		/// </summary>
		public static bool Delete(System.Int32? rohsStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.RohsStatus.Delete(rohsStatusId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_ROHSStatus]
		/// </summary>
		public static List<RohsStatus> DropDown() {
			List<RohsStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.RohsStatus.DropDown();
			if (lstDetails == null) {
				return new List<RohsStatus>();
			} else {
				List<RohsStatus> lst = new List<RohsStatus>();
				foreach (RohsStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.RohsStatus obj = new Rebound.GlobalTrader.BLL.RohsStatus();
					obj.ROHSStatusId = objDetails.ROHSStatusId;
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
		/// Calls [usp_insert_ROHSStatus]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.RohsStatus.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_ROHSStatus]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.RohsStatus.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_ROHSStatus]
		/// </summary>
		public static RohsStatus Get(System.Int32? rohsStatusId) {
			Rebound.GlobalTrader.DAL.RohsStatusDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.RohsStatus.Get(rohsStatusId);
			if (objDetails == null) {
				return null;
			} else {
				RohsStatus obj = new RohsStatus();
				obj.ROHSStatusId = objDetails.ROHSStatusId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_ROHSStatus]
		/// </summary>
		public static List<RohsStatus> GetList() {
			List<RohsStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.RohsStatus.GetList();
			if (lstDetails == null) {
				return new List<RohsStatus>();
			} else {
				List<RohsStatus> lst = new List<RohsStatus>();
				foreach (RohsStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.RohsStatus obj = new Rebound.GlobalTrader.BLL.RohsStatus();
					obj.ROHSStatusId = objDetails.ROHSStatusId;
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
		/// Calls [usp_update_ROHSStatus]
		/// </summary>
		public static bool Update(System.Int32? rohsStatusId, System.String name) {
			return Rebound.GlobalTrader.DAL.SiteProvider.RohsStatus.Update(rohsStatusId, name);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_ROHSStatus]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.RohsStatus.Update(ROHSStatusId, Name);
		}

        private static RohsStatus PopulateFromDBDetailsObject(RohsStatusDetails obj) {
            RohsStatus objNew = new RohsStatus();
			objNew.ROHSStatusId = obj.ROHSStatusId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}