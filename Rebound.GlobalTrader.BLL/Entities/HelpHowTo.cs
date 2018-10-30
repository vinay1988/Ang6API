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
		public partial class HelpHowTo : BizObject {
		
		#region Properties

		protected static DAL.HelpHowToElement Settings {
			get { return Globals.Settings.HelpHowTos; }
		}

		/// <summary>
		/// HelpHowToId
		/// </summary>
		public System.Int32 HelpHowToId { get; set; }		
		/// <summary>
		/// HelpGroupNo
		/// </summary>
		public System.Int32 HelpGroupNo { get; set; }		
		/// <summary>
		/// Title
		/// </summary>
		public System.String Title { get; set; }		
		/// <summary>
		/// ImageName
		/// </summary>
		public System.String ImageName { get; set; }		
		/// <summary>
		/// SortOrder
		/// </summary>
		public System.Int32? SortOrder { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpHowTo]
		/// </summary>
		public static List<HelpHowTo> GetList() {
			List<HelpHowToDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpHowTo.GetList();
			if (lstDetails == null) {
				return new List<HelpHowTo>();
			} else {
				List<HelpHowTo> lst = new List<HelpHowTo>();
				foreach (HelpHowToDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.HelpHowTo obj = new Rebound.GlobalTrader.BLL.HelpHowTo();
					obj.HelpHowToId = objDetails.HelpHowToId;
					obj.HelpGroupNo = objDetails.HelpGroupNo;
					obj.Title = objDetails.Title;
					obj.ImageName = objDetails.ImageName;
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
		/// Calls [usp_selectAll_HelpHowTo_for_Group]
		/// </summary>
		public static List<HelpHowTo> GetListForGroup(System.Int32? helpGroupNo) {
			List<HelpHowToDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpHowTo.GetListForGroup(helpGroupNo);
			if (lstDetails == null) {
				return new List<HelpHowTo>();
			} else {
				List<HelpHowTo> lst = new List<HelpHowTo>();
				foreach (HelpHowToDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.HelpHowTo obj = new Rebound.GlobalTrader.BLL.HelpHowTo();
					obj.HelpHowToId = objDetails.HelpHowToId;
					obj.HelpGroupNo = objDetails.HelpGroupNo;
					obj.Title = objDetails.Title;
					obj.ImageName = objDetails.ImageName;
					obj.SortOrder = objDetails.SortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static HelpHowTo PopulateFromDBDetailsObject(HelpHowToDetails obj) {
            HelpHowTo objNew = new HelpHowTo();
			objNew.HelpHowToId = obj.HelpHowToId;
			objNew.HelpGroupNo = obj.HelpGroupNo;
			objNew.Title = obj.Title;
			objNew.ImageName = obj.ImageName;
			objNew.SortOrder = obj.SortOrder;
            return objNew;
        }
		
		#endregion
		
	}
}