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
		public partial class QuoteStatus : BizObject {
		
		#region Properties

		protected static DAL.QuoteStatusElement Settings {
			get { return Globals.Settings.QuoteStatuss; }
		}

		/// <summary>
		/// QuoteStatusId
		/// </summary>
		public System.Int32 QuoteStatusId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_QuoteStatus]
		/// </summary>
		public static bool Delete(System.Int32? quoteStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.QuoteStatus.Delete(quoteStatusId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_QuoteStatus]
		/// </summary>
		public static List<QuoteStatus> DropDown() {
			List<QuoteStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteStatus.DropDown();
			if (lstDetails == null) {
				return new List<QuoteStatus>();
			} else {
				List<QuoteStatus> lst = new List<QuoteStatus>();
				foreach (QuoteStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.QuoteStatus obj = new Rebound.GlobalTrader.BLL.QuoteStatus();
					obj.QuoteStatusId = objDetails.QuoteStatusId;
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
		/// Calls [usp_insert_QuoteStatus]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.QuoteStatus.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_QuoteStatus]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.QuoteStatus.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_QuoteStatus]
		/// </summary>
		public static QuoteStatus Get(System.Int32? quoteStatusId) {
			Rebound.GlobalTrader.DAL.QuoteStatusDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteStatus.Get(quoteStatusId);
			if (objDetails == null) {
				return null;
			} else {
				QuoteStatus obj = new QuoteStatus();
				obj.QuoteStatusId = objDetails.QuoteStatusId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_QuoteStatus]
		/// </summary>
		public static List<QuoteStatus> GetList() {
			List<QuoteStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteStatus.GetList();
			if (lstDetails == null) {
				return new List<QuoteStatus>();
			} else {
				List<QuoteStatus> lst = new List<QuoteStatus>();
				foreach (QuoteStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.QuoteStatus obj = new Rebound.GlobalTrader.BLL.QuoteStatus();
					obj.QuoteStatusId = objDetails.QuoteStatusId;
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
		/// Calls [usp_update_QuoteStatus]
		/// </summary>
		public static bool Update(System.String name, System.Int32? quoteStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.QuoteStatus.Update(name, quoteStatusId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_QuoteStatus]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.QuoteStatus.Update(Name, QuoteStatusId);
		}

        private static QuoteStatus PopulateFromDBDetailsObject(QuoteStatusDetails obj) {
            QuoteStatus objNew = new QuoteStatus();
			objNew.QuoteStatusId = obj.QuoteStatusId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}