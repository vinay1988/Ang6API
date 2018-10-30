//Marker     Changed by      Date         Remarks
//[001]      Vinay           20/06/2012   This need to notify the user by email.
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
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class LoginPreferenceProvider : DataAccess {
		static private LoginPreferenceProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public LoginPreferenceProvider Instance {
			get {
				if (_instance == null) _instance = (LoginPreferenceProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.LoginPreferences.ProviderType));
				return _instance;
			}
		}
		public LoginPreferenceProvider() {
			this.ConnectionString = Globals.Settings.LoginPreferences.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_LoginPreference]
		/// </summary>
		public abstract Int32 Insert(System.Int32? loginNo, System.Boolean? showMessageAlert, System.Int32? defaultSiteLanguageNo, System.Int32? defaultListPageSize, System.Int32? numberRecentlyViewedPages, System.Int32? defaultHomePageTab, System.Int32? defaultListPageView, System.String backgroundImage, System.Boolean? saveDataListNuggetStateByDefault, System.Int32? loginTimeout, System.Int32? updatedBy);
		/// <summary>
		/// GetByLogin
		/// Calls [usp_select_LoginPreference_by_Login]
		/// </summary>
		public abstract LoginPreferenceDetails GetByLogin(System.Int32? loginNo);
        //[001] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_LoginPreference]
		/// </summary>
        public abstract bool Update(System.Int32? loginNo, System.Boolean? showMessageAlert, System.Int32? defaultSiteLanguageNo, System.Int32? defaultListPageSize, System.Int32? numberRecentlyViewedPages, System.Int32? defaultHomePageTab, System.Int32? defaultListPageView, System.String backgroundImage, System.Boolean? saveDataListNuggetStateByDefault, System.Int32? loginTimeout, System.Int32? updatedBy, System.Boolean? SendEmail, System.Int32? printerNo);
        /// <summary>
        /// GetByLoginForSendEmail
        /// usp_select_login_for_sendemail
        /// </summary>
        /// <param name="loginNo"></param>
        /// <returns></returns>
        public abstract LoginPreferenceDetails GetByLoginForSendEmail(System.Int32? loginId);
        //[001] code end
		#endregion
				
		/// <summary>
		/// Returns a new LoginPreferenceDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual LoginPreferenceDetails GetLoginPreferenceFromReader(DbDataReader reader) {
			LoginPreferenceDetails loginPreference = new LoginPreferenceDetails();
			if (reader.HasRows) {
				loginPreference.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0); //From: [Table]
				loginPreference.ShowMessageAlert = GetReaderValue_Boolean(reader, "ShowMessageAlert", false); //From: [Table]
				loginPreference.DefaultSiteLanguageNo = GetReaderValue_NullableInt32(reader, "DefaultSiteLanguageNo", null); //From: [Table]
				loginPreference.DefaultListPageSize = GetReaderValue_Int32(reader, "DefaultListPageSize", 0); //From: [Table]
				loginPreference.NumberRecentlyViewedPages = GetReaderValue_Int32(reader, "NumberRecentlyViewedPages", 0); //From: [Table]
				loginPreference.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				loginPreference.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
				loginPreference.DefaultHomePageTab = GetReaderValue_Int32(reader, "DefaultHomePageTab", 0); //From: [Table]
				loginPreference.DefaultListPageView = GetReaderValue_Int32(reader, "DefaultListPageView", 0); //From: [Table]
				loginPreference.BackgroundImage = GetReaderValue_String(reader, "BackgroundImage", ""); //From: [Table]
				loginPreference.SaveDataListNuggetStateByDefault = GetReaderValue_Boolean(reader, "SaveDataListNuggetStateByDefault", false); //From: [Table]
				loginPreference.LoginTimeout = GetReaderValue_Int32(reader, "LoginTimeout", 0); //From: [Table]
				loginPreference.DefaultSiteLanguageCode = GetReaderValue_String(reader, "DefaultSiteLanguageCode", ""); //From: [usp_select_LoginPreference_by_Login]
			}
			return loginPreference;
		}
	
		/// <summary>
		/// Returns a collection of LoginPreferenceDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<LoginPreferenceDetails> GetLoginPreferenceCollectionFromReader(DbDataReader reader) {
			List<LoginPreferenceDetails> loginPreferences = new List<LoginPreferenceDetails>();
			while (reader.Read()) loginPreferences.Add(GetLoginPreferenceFromReader(reader));
			return loginPreferences;
		}
		
		
	}
}