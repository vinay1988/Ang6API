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
		public partial class HelpGlossary : BizObject {
		
		#region Properties

		protected static DAL.HelpGlossaryElement Settings {
			get { return Globals.Settings.HelpGlossarys; }
		}

		/// <summary>
		/// HelpGlossaryId
		/// </summary>
		public System.Int32 HelpGlossaryId { get; set; }		
		/// <summary>
		/// Title
		/// </summary>
		public System.String Title { get; set; }		
		/// <summary>
		/// HTMLText
		/// </summary>
		public System.String HTMLText { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Get
		/// Calls [usp_select_HelpGlossary]
		/// </summary>
		public static HelpGlossary Get(System.Int32? helpGlossaryId) {
			Rebound.GlobalTrader.DAL.HelpGlossaryDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpGlossary.Get(helpGlossaryId);
			if (objDetails == null) {
				return null;
			} else {
				HelpGlossary obj = new HelpGlossary();
				obj.HelpGlossaryId = objDetails.HelpGlossaryId;
				obj.Title = objDetails.Title;
				obj.HTMLText = objDetails.HTMLText;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpGlossary]
		/// </summary>
		public static List<HelpGlossary> GetList() {
			List<HelpGlossaryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpGlossary.GetList();
			if (lstDetails == null) {
				return new List<HelpGlossary>();
			} else {
				List<HelpGlossary> lst = new List<HelpGlossary>();
				foreach (HelpGlossaryDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.HelpGlossary obj = new Rebound.GlobalTrader.BLL.HelpGlossary();
					obj.HelpGlossaryId = objDetails.HelpGlossaryId;
					obj.Title = objDetails.Title;
					obj.HTMLText = objDetails.HTMLText;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListByFirstLetter
		/// Calls [usp_selectAll_HelpGlossary_by_FirstLetter]
		/// </summary>
		public static List<HelpGlossary> GetListByFirstLetter(System.String firstLetter) {
			List<HelpGlossaryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpGlossary.GetListByFirstLetter(firstLetter);
			if (lstDetails == null) {
				return new List<HelpGlossary>();
			} else {
				List<HelpGlossary> lst = new List<HelpGlossary>();
				foreach (HelpGlossaryDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.HelpGlossary obj = new Rebound.GlobalTrader.BLL.HelpGlossary();
					obj.HelpGlossaryId = objDetails.HelpGlossaryId;
					obj.Title = objDetails.Title;
					obj.HTMLText = objDetails.HTMLText;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static HelpGlossary PopulateFromDBDetailsObject(HelpGlossaryDetails obj) {
            HelpGlossary objNew = new HelpGlossary();
			objNew.HelpGlossaryId = obj.HelpGlossaryId;
			objNew.Title = obj.Title;
			objNew.HTMLText = obj.HTMLText;
            return objNew;
        }
		
		#endregion
		
	}
}