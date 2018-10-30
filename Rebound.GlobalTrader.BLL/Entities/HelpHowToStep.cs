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
		public partial class HelpHowToStep : BizObject {
		
		#region Properties

		protected static DAL.HelpHowToStepElement Settings {
			get { return Globals.Settings.HelpHowToSteps; }
		}

		/// <summary>
		/// HelpHowToStepId
		/// </summary>
		public System.Int32 HelpHowToStepId { get; set; }		
		/// <summary>
		/// HelpHowToNo
		/// </summary>
		public System.Int32 HelpHowToNo { get; set; }		
		/// <summary>
		/// HTMLText
		/// </summary>
		public System.String HTMLText { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpHowToStep]
		/// </summary>
		public static List<HelpHowToStep> GetList(System.Int32? helpHowToNo) {
			List<HelpHowToStepDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.HelpHowToStep.GetList(helpHowToNo);
			if (lstDetails == null) {
				return new List<HelpHowToStep>();
			} else {
				List<HelpHowToStep> lst = new List<HelpHowToStep>();
				foreach (HelpHowToStepDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.HelpHowToStep obj = new Rebound.GlobalTrader.BLL.HelpHowToStep();
					obj.HelpHowToStepId = objDetails.HelpHowToStepId;
					obj.HelpHowToNo = objDetails.HelpHowToNo;
					obj.HTMLText = objDetails.HTMLText;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static HelpHowToStep PopulateFromDBDetailsObject(HelpHowToStepDetails obj) {
            HelpHowToStep objNew = new HelpHowToStep();
			objNew.HelpHowToStepId = obj.HelpHowToStepId;
			objNew.HelpHowToNo = obj.HelpHowToNo;
			objNew.HTMLText = obj.HTMLText;
            return objNew;
        }
		
		#endregion
		
	}
}