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
		public partial class PartSearch : BizObject {
		
		#region Properties

		protected static DAL.PartSearchElement Settings {
			get { return Globals.Settings.PartSearchs; }
		}

		/// <summary>
		/// PartSearchID
		/// </summary>
		public System.Int32 PartSearchID { get; set; }		
		/// <summary>
		/// SearchPart
		/// </summary>
		public System.String SearchPart { get; set; }		
		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32? LoginNo { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime? DLUP { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_PartSearch]
		/// </summary>
		public static Int32 Insert(System.Int32? loginNo, System.String searchPart) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.PartSearch.Insert(loginNo, searchPart);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_PartSearch]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.PartSearch.Insert(LoginNo, SearchPart);
		}
		/// <summary>
		/// GetListForLogin
		/// Calls [usp_selectAll_PartSearch_for_Login]
		/// </summary>
		public static List<PartSearch> GetListForLogin(System.Int32? loginNo, System.String partSearch) {
			List<PartSearchDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.PartSearch.GetListForLogin(loginNo, partSearch);
			if (lstDetails == null) {
				return new List<PartSearch>();
			} else {
				List<PartSearch> lst = new List<PartSearch>();
				foreach (PartSearchDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.PartSearch obj = new Rebound.GlobalTrader.BLL.PartSearch();
					obj.LoginNo = objDetails.LoginNo;
					obj.SearchPart = objDetails.SearchPart;
					obj.DLUP = objDetails.DLUP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static PartSearch PopulateFromDBDetailsObject(PartSearchDetails obj) {
            PartSearch objNew = new PartSearch();
			objNew.PartSearchID = obj.PartSearchID;
			objNew.SearchPart = obj.SearchPart;
			objNew.LoginNo = obj.LoginNo;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}