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
		public partial class CountingMethod : BizObject {
		
		#region Properties

		protected static DAL.CountingMethodElement Settings {
			get { return Globals.Settings.CountingMethods; }
		}

		/// <summary>
		/// CountingMethodId
		/// </summary>
		public System.Int32 CountingMethodId { get; set; }		
		/// <summary>
		/// CountingMethodDescription
		/// </summary>
		public System.String CountingMethodDescription { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
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
		/// Delete
		/// Calls [usp_delete_CountingMethod]
		/// </summary>
		public static bool Delete(System.Int32? countingMethodId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CountingMethod.Delete(countingMethodId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_CountingMethod]
		/// </summary>
		public static List<CountingMethod> DropDown() {
			List<CountingMethodDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CountingMethod.DropDown();
			if (lstDetails == null) {
				return new List<CountingMethod>();
			} else {
				List<CountingMethod> lst = new List<CountingMethod>();
				foreach (CountingMethodDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CountingMethod obj = new Rebound.GlobalTrader.BLL.CountingMethod();
					obj.CountingMethodId = objDetails.CountingMethodId;
					obj.CountingMethodDescription = objDetails.CountingMethodDescription;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CountingMethod]
		/// </summary>
		public static Int32 Insert(System.String countingMethodDescription, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CountingMethod.Insert(countingMethodDescription, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CountingMethod]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CountingMethod.Insert(CountingMethodDescription, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_CountingMethod]
		/// </summary>
		public static CountingMethod Get(System.Int32? countingMethodId) {
			Rebound.GlobalTrader.DAL.CountingMethodDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CountingMethod.Get(countingMethodId);
			if (objDetails == null) {
				return null;
			} else {
				CountingMethod obj = new CountingMethod();
				obj.CountingMethodId = objDetails.CountingMethodId;
				obj.CountingMethodDescription = objDetails.CountingMethodDescription;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_CountingMethod]
		/// </summary>
		public static List<CountingMethod> GetList() {
			List<CountingMethodDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CountingMethod.GetList();
			if (lstDetails == null) {
				return new List<CountingMethod>();
			} else {
				List<CountingMethod> lst = new List<CountingMethod>();
				foreach (CountingMethodDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CountingMethod obj = new Rebound.GlobalTrader.BLL.CountingMethod();
					obj.CountingMethodId = objDetails.CountingMethodId;
					obj.CountingMethodDescription = objDetails.CountingMethodDescription;
					obj.Inactive = objDetails.Inactive;
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
		/// Calls [usp_update_CountingMethod]
		/// </summary>
		public static bool Update(System.Int32? countingMethodId, System.String countingMethodDescription, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CountingMethod.Update(countingMethodId, countingMethodDescription, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CountingMethod]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CountingMethod.Update(CountingMethodId, CountingMethodDescription, Inactive, UpdatedBy);
		}

        private static CountingMethod PopulateFromDBDetailsObject(CountingMethodDetails obj) {
            CountingMethod objNew = new CountingMethod();
			objNew.CountingMethodId = obj.CountingMethodId;
			objNew.CountingMethodDescription = obj.CountingMethodDescription;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}