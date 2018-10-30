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
		public partial class ReportCategoryGroup : BizObject {
		
		#region Properties

		protected static DAL.ReportCategoryGroupElement Settings {
			get { return Globals.Settings.ReportCategoryGroups; }
		}

		/// <summary>
		/// ReportCategoryGroupId
		/// </summary>
		public System.Int32 ReportCategoryGroupId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		
		/// <summary>
		/// SortOrder
		/// </summary>
		public System.String SortOrder { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_ReportCategoryGroup]
		/// </summary>
		public static List<ReportCategoryGroup> GetList() {
			List<ReportCategoryGroupDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ReportCategoryGroup.GetList();
			if (lstDetails == null) {
				return new List<ReportCategoryGroup>();
			} else {
				List<ReportCategoryGroup> lst = new List<ReportCategoryGroup>();
				foreach (ReportCategoryGroupDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ReportCategoryGroup obj = new Rebound.GlobalTrader.BLL.ReportCategoryGroup();
					obj.ReportCategoryGroupId = objDetails.ReportCategoryGroupId;
					obj.Name = objDetails.Name;
					obj.SortOrder = objDetails.SortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static ReportCategoryGroup PopulateFromDBDetailsObject(ReportCategoryGroupDetails obj) {
            ReportCategoryGroup objNew = new ReportCategoryGroup();
			objNew.ReportCategoryGroupId = obj.ReportCategoryGroupId;
			objNew.Name = obj.Name;
			objNew.SortOrder = obj.SortOrder;
            return objNew;
        }
		
		#endregion
		
	}
}