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
		public partial class OfferStatus : BizObject {
		
		#region Properties

		protected static DAL.OfferStatusElement Settings {
			get { return Globals.Settings.OfferStatuss; }
		}

		/// <summary>
		/// OfferStatusId
		/// </summary>
		public System.Int32 OfferStatusId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_OfferStatus]
		/// </summary>
		public static bool Delete(System.Int32? offerStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.OfferStatus.Delete(offerStatusId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_OfferStatus]
		/// </summary>
		public static List<OfferStatus> DropDown() {
			List<OfferStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.OfferStatus.DropDown();
			if (lstDetails == null) {
				return new List<OfferStatus>();
			} else {
				List<OfferStatus> lst = new List<OfferStatus>();
				foreach (OfferStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.OfferStatus obj = new Rebound.GlobalTrader.BLL.OfferStatus();
					obj.OfferStatusId = objDetails.OfferStatusId;
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
		/// Calls [usp_insert_OfferStatus]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.OfferStatus.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_OfferStatus]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.OfferStatus.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_OfferStatus]
		/// </summary>
		public static OfferStatus Get(System.Int32? offerStatusId) {
			Rebound.GlobalTrader.DAL.OfferStatusDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.OfferStatus.Get(offerStatusId);
			if (objDetails == null) {
				return null;
			} else {
				OfferStatus obj = new OfferStatus();
				obj.OfferStatusId = objDetails.OfferStatusId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_OfferStatus]
		/// </summary>
		public static List<OfferStatus> GetList() {
			List<OfferStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.OfferStatus.GetList();
			if (lstDetails == null) {
				return new List<OfferStatus>();
			} else {
				List<OfferStatus> lst = new List<OfferStatus>();
				foreach (OfferStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.OfferStatus obj = new Rebound.GlobalTrader.BLL.OfferStatus();
					obj.OfferStatusId = objDetails.OfferStatusId;
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
		/// Calls [usp_update_OfferStatus]
		/// </summary>
		public static bool Update(System.String name, System.Int32? offerStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.OfferStatus.Update(name, offerStatusId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_OfferStatus]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.OfferStatus.Update(Name, OfferStatusId);
		}

        private static OfferStatus PopulateFromDBDetailsObject(OfferStatusDetails obj) {
            OfferStatus objNew = new OfferStatus();
			objNew.OfferStatusId = obj.OfferStatusId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}