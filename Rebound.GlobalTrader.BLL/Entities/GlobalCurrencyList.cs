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
		public partial class GlobalCurrencyList : BizObject {
		
		#region Properties

		protected static DAL.GlobalCurrencyListElement Settings {
			get { return Globals.Settings.GlobalCurrencyLists; }
		}

		/// <summary>
		/// GlobalCurrencyId
		/// </summary>
		public System.Int32 GlobalCurrencyId { get; set; }		
		/// <summary>
		/// GlobalCurrencyName
		/// </summary>
		public System.String GlobalCurrencyName { get; set; }		
		/// <summary>
		/// GlobalCurrencyDescription
		/// </summary>
		public System.String GlobalCurrencyDescription { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// Priority
		/// </summary>
		public System.Boolean Priority { get; set; }		
		/// <summary>
		/// Symbol
		/// </summary>
		public System.String Symbol { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_GlobalCurrencyList]
		/// </summary>
		public static List<GlobalCurrencyList> DropDown(System.Boolean? includeSelected, System.Int32? clientNo) {
			List<GlobalCurrencyListDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalCurrencyList.DropDown(includeSelected, clientNo);
			if (lstDetails == null) {
				return new List<GlobalCurrencyList>();
			} else {
				List<GlobalCurrencyList> lst = new List<GlobalCurrencyList>();
				foreach (GlobalCurrencyListDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GlobalCurrencyList obj = new Rebound.GlobalTrader.BLL.GlobalCurrencyList();
					obj.GlobalCurrencyId = objDetails.GlobalCurrencyId;
					obj.GlobalCurrencyName = objDetails.GlobalCurrencyName;
					obj.GlobalCurrencyDescription = objDetails.GlobalCurrencyDescription;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_GlobalCurrencyList]
		/// </summary>
		public static Int32 Insert(System.String globalCurrencyName, System.String globalCurrencyDescription, System.String symbol, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GlobalCurrencyList.Insert(globalCurrencyName, globalCurrencyDescription, symbol, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_GlobalCurrencyList]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.GlobalCurrencyList.Insert(GlobalCurrencyName, GlobalCurrencyDescription, Symbol, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_GlobalCurrencyList]
		/// </summary>
		public static GlobalCurrencyList Get(System.Int32? currencyId) {
			Rebound.GlobalTrader.DAL.GlobalCurrencyListDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalCurrencyList.Get(currencyId);
			if (objDetails == null) {
				return null;
			} else {
				GlobalCurrencyList obj = new GlobalCurrencyList();
				obj.GlobalCurrencyId = objDetails.GlobalCurrencyId;
				obj.GlobalCurrencyName = objDetails.GlobalCurrencyName;
				obj.GlobalCurrencyDescription = objDetails.GlobalCurrencyDescription;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.Priority = objDetails.Priority;
				obj.Symbol = objDetails.Symbol;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_GlobalCurrencyList]
		/// </summary>
		public static List<GlobalCurrencyList> GetList() {
			List<GlobalCurrencyListDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalCurrencyList.GetList();
			if (lstDetails == null) {
				return new List<GlobalCurrencyList>();
			} else {
				List<GlobalCurrencyList> lst = new List<GlobalCurrencyList>();
				foreach (GlobalCurrencyListDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GlobalCurrencyList obj = new Rebound.GlobalTrader.BLL.GlobalCurrencyList();
					obj.GlobalCurrencyId = objDetails.GlobalCurrencyId;
					obj.GlobalCurrencyName = objDetails.GlobalCurrencyName;
					obj.GlobalCurrencyDescription = objDetails.GlobalCurrencyDescription;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.Priority = objDetails.Priority;
					obj.Symbol = objDetails.Symbol;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_GlobalCurrencyList]
		/// </summary>
		public static bool Update(System.Int32? globalCurrencyId, System.String globalCurrencyName, System.String globalCurrencyDescription, System.String symbol, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.GlobalCurrencyList.Update(globalCurrencyId, globalCurrencyName, globalCurrencyDescription, symbol, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_GlobalCurrencyList]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.GlobalCurrencyList.Update(GlobalCurrencyId, GlobalCurrencyName, GlobalCurrencyDescription, Symbol, UpdatedBy);
		}

        private static GlobalCurrencyList PopulateFromDBDetailsObject(GlobalCurrencyListDetails obj) {
            GlobalCurrencyList objNew = new GlobalCurrencyList();
			objNew.GlobalCurrencyId = obj.GlobalCurrencyId;
			objNew.GlobalCurrencyName = obj.GlobalCurrencyName;
			objNew.GlobalCurrencyDescription = obj.GlobalCurrencyDescription;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.Priority = obj.Priority;
			objNew.Symbol = obj.Symbol;
            return objNew;
        }
		
		#endregion
		
	}
}