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
		public partial class HelpFaq : BizObject {
		
		#region Properties

		protected static DAL.HelpFaqElement Settings {
			get { return Globals.Settings.HelpFaqs; }
		}

		/// <summary>
		/// HelpFAQId
		/// </summary>
		public System.Int32 HelpFAQId { get; set; }		
		/// <summary>
		/// HelpGroupNo
		/// </summary>
		public System.Int32 HelpGroupNo { get; set; }		
		/// <summary>
		/// Question
		/// </summary>
		public System.String Question { get; set; }		
		/// <summary>
		/// Answer
		/// </summary>
		public System.String Answer { get; set; }		
		/// <summary>
		/// SortOrder
		/// </summary>
		public System.Int32? SortOrder { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Get
		/// Calls [usp_select_HelpFAQ]
		/// </summary>
		public static HelpFaq Get(System.Int32? helpFaqId) {
			Rebound.GlobalTrader.DAL.HelpFaqDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpFaq.Get(helpFaqId);
			if (objDetails == null) {
				return null;
			} else {
				HelpFaq obj = new HelpFaq();
				obj.HelpFAQId = objDetails.HelpFAQId;
				obj.HelpGroupNo = objDetails.HelpGroupNo;
				obj.Question = objDetails.Question;
				obj.Answer = objDetails.Answer;
				obj.SortOrder = objDetails.SortOrder;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpFAQ]
		/// </summary>
		public static List<HelpFaq> GetList() {
			List<HelpFaqDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpFaq.GetList();
			if (lstDetails == null) {
				return new List<HelpFaq>();
			} else {
				List<HelpFaq> lst = new List<HelpFaq>();
				foreach (HelpFaqDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.HelpFaq obj = new Rebound.GlobalTrader.BLL.HelpFaq();
					obj.HelpFAQId = objDetails.HelpFAQId;
					obj.HelpGroupNo = objDetails.HelpGroupNo;
					obj.Question = objDetails.Question;
					obj.Answer = objDetails.Answer;
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
		/// Calls [usp_selectAll_HelpFAQ_for_Group]
		/// </summary>
		public static List<HelpFaq> GetListForGroup(System.Int32? helpGroupNo) {
			List<HelpFaqDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpFaq.GetListForGroup(helpGroupNo);
			if (lstDetails == null) {
				return new List<HelpFaq>();
			} else {
				List<HelpFaq> lst = new List<HelpFaq>();
				foreach (HelpFaqDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.HelpFaq obj = new Rebound.GlobalTrader.BLL.HelpFaq();
					obj.HelpFAQId = objDetails.HelpFAQId;
					obj.HelpGroupNo = objDetails.HelpGroupNo;
					obj.Question = objDetails.Question;
					obj.Answer = objDetails.Answer;
					obj.SortOrder = objDetails.SortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static HelpFaq PopulateFromDBDetailsObject(HelpFaqDetails obj) {
            HelpFaq objNew = new HelpFaq();
			objNew.HelpFAQId = obj.HelpFAQId;
			objNew.HelpGroupNo = obj.HelpGroupNo;
			objNew.Question = obj.Question;
			objNew.Answer = obj.Answer;
			objNew.SortOrder = obj.SortOrder;
            return objNew;
        }
		
		#endregion
		
	}
}