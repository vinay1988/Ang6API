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
		public partial class ReportCategory : BizObject {
		
		#region Properties

		protected static DAL.ReportCategoryElement Settings {
			get { return Globals.Settings.ReportCategorys; }
		}

		/// <summary>
		/// ReportCategoryId
		/// </summary>
		public System.Int32 ReportCategoryId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		
		/// <summary>
		/// ReportCategoryGroupNo
		/// </summary>
		public System.Int32? ReportCategoryGroupNo { get; set; }		
		/// <summary>
		/// SortOrder
		/// </summary>
		public System.Int32? SortOrder { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_ReportCategory]
		/// </summary>
		public static List<ReportCategory> GetList() {
			List<ReportCategoryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ReportCategory.GetList();
			if (lstDetails == null) {
				return new List<ReportCategory>();
			} else {
				List<ReportCategory> lst = new List<ReportCategory>();
				foreach (ReportCategoryDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ReportCategory obj = new Rebound.GlobalTrader.BLL.ReportCategory();
					obj.ReportCategoryId = objDetails.ReportCategoryId;
					obj.Name = objDetails.Name;
					obj.ReportCategoryGroupNo = objDetails.ReportCategoryGroupNo;
					obj.SortOrder = objDetails.SortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForGroup
		/// Calls [usp_selectAll_ReportCategory_for_Group]
		/// </summary>
		public static List<ReportCategory> GetListForGroup(System.Int32? reportCategoryGroupNo) {
			List<ReportCategoryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ReportCategory.GetListForGroup(reportCategoryGroupNo);
			if (lstDetails == null) {
				return new List<ReportCategory>();
			} else {
				List<ReportCategory> lst = new List<ReportCategory>();
				foreach (ReportCategoryDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ReportCategory obj = new Rebound.GlobalTrader.BLL.ReportCategory();
					obj.ReportCategoryId = objDetails.ReportCategoryId;
					obj.Name = objDetails.Name;
					obj.ReportCategoryGroupNo = objDetails.ReportCategoryGroupNo;
					obj.SortOrder = objDetails.SortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static ReportCategory PopulateFromDBDetailsObject(ReportCategoryDetails obj) {
            ReportCategory objNew = new ReportCategory();
			objNew.ReportCategoryId = obj.ReportCategoryId;
			objNew.Name = obj.Name;
			objNew.ReportCategoryGroupNo = obj.ReportCategoryGroupNo;
			objNew.SortOrder = obj.SortOrder;
            return objNew;
        }
		
		#endregion
		
	}
}