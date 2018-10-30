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
		public partial class RecentlyViewed : BizObject {
		
		#region Properties

		protected static DAL.RecentlyViewedElement Settings {
			get { return Globals.Settings.RecentlyVieweds; }
		}

		/// <summary>
		/// RecentlyViewedId
		/// </summary>
		public System.Int32 RecentlyViewedId { get; set; }		
		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32? LoginNo { get; set; }		
		/// <summary>
		/// PageTitle
		/// </summary>
		public System.String PageTitle { get; set; }		
		/// <summary>
		/// PageURL
		/// </summary>
		public System.String PageURL { get; set; }		
		/// <summary>
		/// DateAdded
		/// </summary>
		public System.DateTime? DateAdded { get; set; }		
		/// <summary>
		/// Locked
		/// </summary>
		public System.Boolean? Locked { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_RecentlyViewed]
		/// </summary>
		public static bool Delete(System.Int32? recentlyViewedId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.RecentlyViewed.Delete(recentlyViewedId);
		}
		/// <summary>
		/// DeleteByLoginAndPageTitle
		/// Calls [usp_delete_RecentlyViewed_by_Login_and_PageTitle]
		/// </summary>
		public static bool DeleteByLoginAndPageTitle(System.Int32? loginNo, System.String pageTitle) {
			return Rebound.GlobalTrader.DAL.SiteProvider.RecentlyViewed.DeleteByLoginAndPageTitle(loginNo, pageTitle);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_RecentlyViewed]
		/// </summary>
		public static Int32 Insert(System.Int32? loginNo, System.String pageTitle, System.String pageUrl) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.RecentlyViewed.Insert(loginNo, pageTitle, pageUrl);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_RecentlyViewed]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.RecentlyViewed.Insert(LoginNo, PageTitle, PageURL);
		}
		/// <summary>
		/// GetListForUser
		/// Calls [usp_selectAll_RecentlyViewed_for_User]
		/// </summary>
		public static List<RecentlyViewed> GetListForUser(System.Int32? loginNo) {
			List<RecentlyViewedDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.RecentlyViewed.GetListForUser(loginNo);
			if (lstDetails == null) {
				return new List<RecentlyViewed>();
			} else {
				List<RecentlyViewed> lst = new List<RecentlyViewed>();
				foreach (RecentlyViewedDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.RecentlyViewed obj = new Rebound.GlobalTrader.BLL.RecentlyViewed();
					obj.RecentlyViewedId = objDetails.RecentlyViewedId;
					obj.LoginNo = objDetails.LoginNo;
					obj.PageTitle = objDetails.PageTitle;
					obj.PageURL = objDetails.PageURL;
					obj.DateAdded = objDetails.DateAdded;
					obj.Locked = objDetails.Locked;
					obj.RowNum = objDetails.RowNum;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// UpdateLock
		/// Calls [usp_update_RecentlyViewed_Lock]
		/// </summary>
		public static bool UpdateLock(System.Int32? recentlyViewedId, System.Boolean? locked) {
			return Rebound.GlobalTrader.DAL.SiteProvider.RecentlyViewed.UpdateLock(recentlyViewedId, locked);
		}

        private static RecentlyViewed PopulateFromDBDetailsObject(RecentlyViewedDetails obj) {
            RecentlyViewed objNew = new RecentlyViewed();
			objNew.RecentlyViewedId = obj.RecentlyViewedId;
			objNew.LoginNo = obj.LoginNo;
			objNew.PageTitle = obj.PageTitle;
			objNew.PageURL = obj.PageURL;
			objNew.DateAdded = obj.DateAdded;
			objNew.Locked = obj.Locked;
			objNew.RowNum = obj.RowNum;
            return objNew;
        }
		
		#endregion
		
	}
}