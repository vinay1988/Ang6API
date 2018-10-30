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
		public partial class HelpGroup : BizObject {
		
		#region Properties

		protected static DAL.HelpGroupElement Settings {
			get { return Globals.Settings.HelpGroups; }
		}

		/// <summary>
		/// HelpGroupId
		/// </summary>
		public System.Int32 HelpGroupId { get; set; }		
		/// <summary>
		/// Title
		/// </summary>
		public System.String Title { get; set; }		
		/// <summary>
		/// SortOrder
		/// </summary>
		public System.Int32? SortOrder { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpGroup]
		/// </summary>
		public static List<HelpGroup> GetList() {
			List<HelpGroupDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpGroup.GetList();
			if (lstDetails == null) {
				return new List<HelpGroup>();
			} else {
				List<HelpGroup> lst = new List<HelpGroup>();
				foreach (HelpGroupDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.HelpGroup obj = new Rebound.GlobalTrader.BLL.HelpGroup();
					obj.HelpGroupId = objDetails.HelpGroupId;
					obj.Title = objDetails.Title;
					obj.SortOrder = objDetails.SortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static HelpGroup PopulateFromDBDetailsObject(HelpGroupDetails obj) {
            HelpGroup objNew = new HelpGroup();
			objNew.HelpGroupId = obj.HelpGroupId;
			objNew.Title = obj.Title;
			objNew.SortOrder = obj.SortOrder;
            return objNew;
        }
		
		#endregion
		
	}
}