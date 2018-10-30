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
		public partial class SitePage : BizObject {
		
		#region Properties

		protected static DAL.SitePageElement Settings {
			get { return Globals.Settings.SitePages; }
		}

		/// <summary>
		/// SitePageId
		/// </summary>
		public System.Int32 SitePageId { get; set; }		
		/// <summary>
		/// ShortName
		/// </summary>
		public System.String ShortName { get; set; }		
		/// <summary>
		/// Description
		/// </summary>
		public System.String Description { get; set; }		
		/// <summary>
		/// URL
		/// </summary>
		public System.String URL { get; set; }		
		/// <summary>
		/// SiteSectionNo
		/// </summary>
		public System.Int32? SiteSectionNo { get; set; }		
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
		/// GetList
		/// Calls [usp_selectAll_SitePage]
		/// </summary>
		public static List<SitePage> GetList() {
			List<SitePageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SitePage.GetList();
			if (lstDetails == null) {
				return new List<SitePage>();
			} else {
				List<SitePage> lst = new List<SitePage>();
				foreach (SitePageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SitePage obj = new Rebound.GlobalTrader.BLL.SitePage();
					obj.SitePageId = objDetails.SitePageId;
					obj.ShortName = objDetails.ShortName;
					obj.Description = objDetails.Description;
					obj.URL = objDetails.URL;
					obj.SiteSectionNo = objDetails.SiteSectionNo;
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
		/// GetListHavingSecurityFunctionBySiteSection
		/// Calls [usp_selectAll_SitePage_having_SecurityFunction_by_SiteSection]
		/// </summary>
		public static List<SitePage> GetListHavingSecurityFunctionBySiteSection(System.Int32? siteSectionNo) {
			List<SitePageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SitePage.GetListHavingSecurityFunctionBySiteSection(siteSectionNo);
			if (lstDetails == null) {
				return new List<SitePage>();
			} else {
				List<SitePage> lst = new List<SitePage>();
				foreach (SitePageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SitePage obj = new Rebound.GlobalTrader.BLL.SitePage();
					obj.SitePageId = objDetails.SitePageId;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static SitePage PopulateFromDBDetailsObject(SitePageDetails obj) {
            SitePage objNew = new SitePage();
			objNew.SitePageId = obj.SitePageId;
			objNew.ShortName = obj.ShortName;
			objNew.Description = obj.Description;
			objNew.URL = obj.URL;
			objNew.SiteSectionNo = obj.SiteSectionNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}