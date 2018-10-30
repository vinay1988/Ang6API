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
		public partial class SiteSection : BizObject {
		
		#region Properties

		protected static DAL.SiteSectionElement Settings {
			get { return Globals.Settings.SiteSections; }
		}

		/// <summary>
		/// SiteSectionId
		/// </summary>
		public System.Int32 SiteSectionId { get; set; }		
		/// <summary>
		/// SiteSectionName
		/// </summary>
		public System.String SiteSectionName { get; set; }		
		/// <summary>
		/// Description
		/// </summary>
		public System.String Description { get; set; }		
		/// <summary>
		/// URL
		/// </summary>
		public System.String URL { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SiteSection]
		/// </summary>
		public static List<SiteSection> GetList() {
			List<SiteSectionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SiteSection.GetList();
			if (lstDetails == null) {
				return new List<SiteSection>();
			} else {
				List<SiteSection> lst = new List<SiteSection>();
				foreach (SiteSectionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SiteSection obj = new Rebound.GlobalTrader.BLL.SiteSection();
					obj.SiteSectionId = objDetails.SiteSectionId;
					obj.SiteSectionName = objDetails.SiteSectionName;
					obj.Description = objDetails.Description;
					obj.URL = objDetails.URL;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static SiteSection PopulateFromDBDetailsObject(SiteSectionDetails obj) {
            SiteSection objNew = new SiteSection();
			objNew.SiteSectionId = obj.SiteSectionId;
			objNew.SiteSectionName = obj.SiteSectionName;
			objNew.Description = obj.Description;
			objNew.URL = obj.URL;
            return objNew;
        }
		
		#endregion
		
	}
}