/*
Marker     Changed by      Date         Remarks
[001]      Vinay           04/07/2012   This need to notify the user by email.
*/
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
		public partial class LoginPreference : BizObject {
		
		#region Properties

		protected static DAL.LoginPreferenceElement Settings {
			get { return Globals.Settings.LoginPreferences; }
		}

		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32 LoginNo { get; set; }		
		/// <summary>
		/// ShowMessageAlert
		/// </summary>
		public System.Boolean ShowMessageAlert { get; set; }		
		/// <summary>
		/// DefaultSiteLanguageNo
		/// </summary>
		public System.Int32? DefaultSiteLanguageNo { get; set; }		
		/// <summary>
		/// DefaultListPageSize
		/// </summary>
		public System.Int32 DefaultListPageSize { get; set; }		
		/// <summary>
		/// NumberRecentlyViewedPages
		/// </summary>
		public System.Int32 NumberRecentlyViewedPages { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime? DLUP { get; set; }		
		/// <summary>
		/// DefaultHomePageTab
		/// </summary>
		public System.Int32 DefaultHomePageTab { get; set; }		
		/// <summary>
		/// DefaultListPageView
		/// </summary>
		public System.Int32 DefaultListPageView { get; set; }		
		/// <summary>
		/// BackgroundImage
		/// </summary>
		public System.String BackgroundImage { get; set; }		
		/// <summary>
		/// SaveDataListNuggetStateByDefault
		/// </summary>
		public System.Boolean SaveDataListNuggetStateByDefault { get; set; }		
		/// <summary>
		/// LoginTimeout
		/// </summary>
		public System.Int32 LoginTimeout { get; set; }		
		/// <summary>
		/// DefaultSiteLanguageCode
		/// </summary>
		public System.String DefaultSiteLanguageCode { get; set; }
        //[001] code start
        /// <summary>
        /// SendEmail
        /// </summary>
        public System.Boolean? SendEmail { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public System.String Email { get; set; }
        //[001] code end
        /// <summary>
        /// PrinterNo
        /// </summary>
        public System.Int32? PrinterNo { get; set; }
        /// <summary>
        /// PrinterName
        /// </summary>
        public System.String PrinterName { get; set; }

        public System.Int32? LabelPathNo { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_LoginPreference]
		/// </summary>
		public static Int32 Insert(System.Int32? loginNo, System.Boolean? showMessageAlert, System.Int32? defaultSiteLanguageNo, System.Int32? defaultListPageSize, System.Int32? numberRecentlyViewedPages, System.Int32? defaultHomePageTab, System.Int32? defaultListPageView, System.String backgroundImage, System.Boolean? saveDataListNuggetStateByDefault, System.Int32? loginTimeout, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.LoginPreference.Insert(loginNo, showMessageAlert, defaultSiteLanguageNo, defaultListPageSize, numberRecentlyViewedPages, defaultHomePageTab, defaultListPageView, backgroundImage, saveDataListNuggetStateByDefault, loginTimeout, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_LoginPreference]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.LoginPreference.Insert(LoginNo, ShowMessageAlert, DefaultSiteLanguageNo, DefaultListPageSize, NumberRecentlyViewedPages, DefaultHomePageTab, DefaultListPageView, BackgroundImage, SaveDataListNuggetStateByDefault, LoginTimeout, UpdatedBy);
		}
		/// <summary>
		/// GetByLogin
		/// Calls [usp_select_LoginPreference_by_Login]
		/// </summary>
		public static LoginPreference GetByLogin(System.Int32? loginNo) {
			Rebound.GlobalTrader.DAL.LoginPreferenceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.LoginPreference.GetByLogin(loginNo);
			if (objDetails == null) {
				return null;
			} else {
				LoginPreference obj = new LoginPreference();
				obj.LoginNo = objDetails.LoginNo;
				obj.ShowMessageAlert = objDetails.ShowMessageAlert;
				obj.DefaultSiteLanguageNo = objDetails.DefaultSiteLanguageNo;
				obj.DefaultListPageSize = objDetails.DefaultListPageSize;
				obj.NumberRecentlyViewedPages = objDetails.NumberRecentlyViewedPages;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.DefaultHomePageTab = objDetails.DefaultHomePageTab;
				obj.DefaultListPageView = objDetails.DefaultListPageView;
				obj.BackgroundImage = objDetails.BackgroundImage;
				obj.SaveDataListNuggetStateByDefault = objDetails.SaveDataListNuggetStateByDefault;
				obj.LoginTimeout = objDetails.LoginTimeout;
				obj.DefaultSiteLanguageCode = objDetails.DefaultSiteLanguageCode;
                //[001] code start
                obj.SendEmail = objDetails.SendEmail;
                //[001] code end
                obj.PrinterNo = objDetails.PrinterNo;
                obj.PrinterName = objDetails.PrinterName;
                obj.LabelPathNo = objDetails.LabelPathNo;
				objDetails = null;
				return obj;
			}
		}

        //[001] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_LoginPreference]
		/// </summary>
        public static bool Update(System.Int32? loginNo, System.Boolean? showMessageAlert, System.Int32? defaultSiteLanguageNo, System.Int32? defaultListPageSize, System.Int32? numberRecentlyViewedPages, System.Int32? defaultHomePageTab, System.Int32? defaultListPageView, System.String backgroundImage, System.Boolean? saveDataListNuggetStateByDefault, System.Int32? loginTimeout, System.Boolean? SendEmail, System.Int32? updatedBy, System.Int32? printerNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.LoginPreference.Update(loginNo, showMessageAlert, defaultSiteLanguageNo, defaultListPageSize, numberRecentlyViewedPages, defaultHomePageTab, defaultListPageView, backgroundImage, saveDataListNuggetStateByDefault, loginTimeout, updatedBy, SendEmail, printerNo);
		}
        /// <summary>
        /// usp_select_login_for_sendemail
        /// </summary>
        /// <param name="loginNo"></param>
        /// <returns></returns>
        public static LoginPreference GetByLoginForSendEmail(System.Int32? loginId) {
            Rebound.GlobalTrader.DAL.LoginPreferenceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.LoginPreference.GetByLoginForSendEmail(loginId);
			if (objDetails == null) {
				return null;
			} else {
				LoginPreference obj = new LoginPreference();
                obj.SendEmail = objDetails.SendEmail;
                obj.Email = objDetails.Email;
				objDetails = null;
				return obj;
			}
		}
        //[001] code end
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_LoginPreference]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.LoginPreference.Update(LoginNo, ShowMessageAlert, DefaultSiteLanguageNo, DefaultListPageSize, NumberRecentlyViewedPages, DefaultHomePageTab, DefaultListPageView, BackgroundImage, SaveDataListNuggetStateByDefault, LoginTimeout, UpdatedBy,SendEmail, PrinterNo);
		}

        private static LoginPreference PopulateFromDBDetailsObject(LoginPreferenceDetails obj) {
            LoginPreference objNew = new LoginPreference();
			objNew.LoginNo = obj.LoginNo;
			objNew.ShowMessageAlert = obj.ShowMessageAlert;
			objNew.DefaultSiteLanguageNo = obj.DefaultSiteLanguageNo;
			objNew.DefaultListPageSize = obj.DefaultListPageSize;
			objNew.NumberRecentlyViewedPages = obj.NumberRecentlyViewedPages;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.DefaultHomePageTab = obj.DefaultHomePageTab;
			objNew.DefaultListPageView = obj.DefaultListPageView;
			objNew.BackgroundImage = obj.BackgroundImage;
			objNew.SaveDataListNuggetStateByDefault = obj.SaveDataListNuggetStateByDefault;
			objNew.LoginTimeout = obj.LoginTimeout;
			objNew.DefaultSiteLanguageCode = obj.DefaultSiteLanguageCode;
            return objNew;
        }
		
		#endregion
		
	}
}