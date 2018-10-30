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
		public partial class Feedback : BizObject {
		
		#region Properties

		protected static DAL.FeedbackElement Settings {
			get { return Globals.Settings.Feedbacks; }
		}

		/// <summary>
		/// FeedbackId
		/// </summary>
		public System.Int32 FeedbackId { get; set; }		
		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32 LoginNo { get; set; }		
		/// <summary>
		/// FeedbackText
		/// </summary>
		public System.String FeedbackText { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime? DLUP { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Feedback]
		/// </summary>
		public static Int32 Insert(System.Int32? loginNo, System.String feedbackText) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Feedback.Insert(loginNo, feedbackText);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Feedback]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Feedback.Insert(LoginNo, FeedbackText);
		}

        private static Feedback PopulateFromDBDetailsObject(FeedbackDetails obj) {
            Feedback objNew = new Feedback();
			objNew.FeedbackId = obj.FeedbackId;
			objNew.LoginNo = obj.LoginNo;
			objNew.FeedbackText = obj.FeedbackText;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}