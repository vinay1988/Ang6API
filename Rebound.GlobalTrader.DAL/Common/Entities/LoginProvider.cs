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
	
	public abstract class LoginProvider : DataAccess {
		static private LoginProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public LoginProvider Instance {
			get {
				if (_instance == null) _instance = (LoginProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Logins.ProviderType));
				return _instance;
			}
		}
		public LoginProvider() {
			this.ConnectionString = Globals.Settings.Logins.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// AutoSearchForMail
		/// Calls [usp_autosearch_Login_for_Mail]
		/// </summary>
		public abstract List<LoginDetails> AutoSearchForMail(System.Int32? clientId, System.Int32? loginId, System.String nameSearch);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Login]
		/// </summary>
		public abstract bool Delete(System.Int32? loginId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Login_for_Client]
		/// </summary>
		public abstract List<LoginDetails> DropDownForClient(System.Int32? clientNo, System.Int32? teamNo, System.Int32? divisionNo, System.Int32? excludeLoginNo);

        /// <summary>
        /// DropDownForClient
        /// Calls [usp_dropdown_Login_for_ClientNPR]
        /// </summary>
        public abstract List<LoginDetails> DropDownForClientNPR(System.Int32? goodsInLineNo, System.Int32? teamNo, System.Int32? divisionNo, System.Int32? excludeLoginNo);

		/// <summary>
		/// Insert
		/// Calls [usp_insert_Login]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.String loginName, System.String employeeName, System.String firstName, System.String lastName, System.Int32? addressNo, System.String title, System.String extension, System.String telephone, System.String fax, System.String email, System.String notes, System.String homeTelephone, System.String homeFax, System.String homeEmail, System.String mobile, System.Int32? divisionNo, System.Int32? teamNo, System.String salutation, System.Boolean? keyLogin, System.Int32? updatedBy);
		/// <summary>
		/// Login
		/// Calls [usp_login_Login]
		/// </summary>
        public abstract Int32 Login(System.String loginName, System.String password, System.String ipAddress, System.String sessionId, System.String serverIP);
		/// <summary>
		/// Logout
		/// Calls [usp_logout_Login]
		/// </summary>
		public abstract void Logout(System.Int32? loginId, System.String sessionName);
		/// <summary>
		/// Get
		/// Calls [usp_select_Login]
		/// </summary>
		public abstract LoginDetails Get(System.Int32? loginId);
		/// <summary>
		/// GetByName
		/// Calls [usp_select_Login_by_Name]
		/// </summary>
		public abstract LoginDetails GetByName(System.String loginName);
		/// <summary>
		/// GetForRebound
		/// Calls [usp_select_Login_for_Boris]
		/// </summary>
		public abstract LoginDetails GetForBoris(System.Int32? clientId);
		/// <summary>
		/// GetLastMonthGP
		/// Calls [usp_select_Login_LastMonth_GP]
		/// </summary>
		public abstract LoginDetails GetLastMonthGP(System.Int32? loginId);
		/// <summary>
		/// GetLastYearGP
		/// Calls [usp_select_Login_LastYear_GP]
		/// </summary>
		public abstract LoginDetails GetLastYearGP(System.Int32? loginId);
		/// <summary>
		/// GetName
		/// Calls [usp_select_Login_Name]
		/// </summary>
		public abstract LoginDetails GetName(System.Int32? loginId);
		/// <summary>
		/// GetNextMonthGP
		/// Calls [usp_select_Login_NextMonth_GP]
		/// </summary>
		public abstract LoginDetails GetNextMonthGP(System.Int32? loginId);
		/// <summary>
		/// GetThisMonthGP
		/// Calls [usp_select_Login_ThisMonth_GP]
		/// </summary>
		public abstract LoginDetails GetThisMonthGP(System.Int32? loginId);
		/// <summary>
		/// GetThisYearGP
		/// Calls [usp_select_Login_ThisYear_GP]
		/// </summary>
		public abstract LoginDetails GetThisYearGP(System.Int32? loginId);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Login_for_Client]
		/// </summary>
		public abstract List<LoginDetails> GetListForClient(System.Int32? clientId);
		/// <summary>
		/// GetListForClientIncludingDisabled
		/// Calls [usp_selectAll_Login_for_Client_including_Disabled]
		/// </summary>
		public abstract List<LoginDetails> GetListForClientIncludingDisabled(System.Int32? clientNo);
		/// <summary>
		/// GetListForDivision
		/// Calls [usp_selectAll_Login_for_Division]
		/// </summary>
		public abstract List<LoginDetails> GetListForDivision(System.Int32? divisionId);
		/// <summary>
		/// GetListForTeam
		/// Calls [usp_selectAll_Login_for_Team]
		/// </summary>
		public abstract List<LoginDetails> GetListForTeam(System.Int32? teamId);
		/// <summary>
		/// GetListTopSalespersons
		/// Calls [usp_selectAll_Login_Top_Salespersons]
		/// </summary>
		public abstract List<LoginDetails> GetListTopSalespersons(System.Int32? clientNo, System.Int32? topToSelect);
		/// <summary>
		/// Update
		/// Calls [usp_update_Login]
		/// </summary>
        public abstract bool Update(System.Int32? loginId, System.Int32? clientNo, System.String loginName, System.String employeeName, System.String firstName, System.String lastName, System.Int32? addressNo, System.String title, System.String extension, System.String telephone, System.String fax, System.String email, System.String notes, System.String homeTelephone, System.String homeFax, System.String homeEmail, System.String mobile, System.Int32? divisionNo, System.Int32? teamNo, System.String salutation, System.Boolean? inactive, System.Boolean? keyLogin, System.Int32? updatedBy, System.Int32? printerNo, System.Int32? labelPathNo,System.String adLogin,System.Boolean? groupAccess);
		/// <summary>
		/// UpdateDivision
		/// Calls [usp_update_Login_Division]
		/// </summary>
		public abstract bool UpdateDivision(System.Int32? loginId, System.Int32? divisionNo);
		/// <summary>
		/// UpdateInactive
		/// Calls [usp_update_Login_Inactive]
		/// </summary>
		public abstract bool UpdateInactive(System.Int32? loginId, System.Boolean? inactive);
		/// <summary>
		/// UpdatePassword
		/// Calls [usp_update_Login_Password]
		/// </summary>
		public abstract bool UpdatePassword(System.Int32? loginId, System.String oldPassword, System.String newPassword, System.Int32? updatedBy);
		/// <summary>
		/// UpdateResetPassword
		/// Calls [usp_update_Login_ResetPassword]
		/// </summary>
		public abstract bool UpdateResetPassword(System.Int32? loginId);
		/// <summary>
		/// UpdateTeam
		/// Calls [usp_update_Login_Team]
		/// </summary>
		public abstract bool UpdateTeam(System.Int32? loginId, System.Int32? teamNo);

        /// <summary>
        /// Forgot Password
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public abstract Int32 ForgotPassword(System.String loginName, out System.String password, out System.String email);
        /// <summary>
        /// Calls [usp_get_password_by_Email_client]
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public abstract List<LoginDetails> ForgotUserName(System.Int32? clientNo, System.String email);

        /// <summary>
        /// DropDownForPurchasehub
        /// Calls [usp_dropdown_Login_for_PurchaseHubClient]
        /// </summary>
        public abstract List<LoginDetails> DropDownForPurchaseHub(System.Int32? clientNo, System.Int32? teamNo, System.Int32? divisionNo, System.Int32? excludeLoginNo);

		#endregion
				
		/// <summary>
		/// Returns a new LoginDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual LoginDetails GetLoginFromReader(DbDataReader reader) {
			LoginDetails login = new LoginDetails();
			if (reader.HasRows) {
				login.LoginId = GetReaderValue_Int32(reader, "LoginId", 0); //From: [Table]
				login.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				login.LoginName = GetReaderValue_String(reader, "LoginName", ""); //From: [Table]
				login.EmployeeName = GetReaderValue_String(reader, "EmployeeName", ""); //From: [usp_selectAll_Audit_authorisation_for_SalesOrder]
				login.FirstName = GetReaderValue_String(reader, "FirstName", ""); //From: [Table]
				login.LastName = GetReaderValue_String(reader, "LastName", ""); //From: [Table]
				login.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null); //From: [Table]
				login.Title = GetReaderValue_String(reader, "Title", ""); //From: [Table]
				login.Extension = GetReaderValue_String(reader, "Extension", ""); //From: [Table]
				login.Telephone = GetReaderValue_String(reader, "Telephone", ""); //From: [Table]
				login.Fax = GetReaderValue_String(reader, "Fax", ""); //From: [Table]
				login.EMail = GetReaderValue_String(reader, "EMail", ""); //From: [Table]
				login.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				login.HomeTelephone = GetReaderValue_String(reader, "HomeTelephone", ""); //From: [Table]
				login.HomeFax = GetReaderValue_String(reader, "HomeFax", ""); //From: [Table]
				login.HomeEmail = GetReaderValue_String(reader, "HomeEmail", ""); //From: [Table]
				login.Mobile = GetReaderValue_String(reader, "Mobile", ""); //From: [Table]
				login.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [usp_select_Contact]
				login.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [Table]
				login.Salutation = GetReaderValue_String(reader, "Salutation", ""); //From: [Table]
				login.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				login.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				login.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				login.KeyLogin = GetReaderValue_Boolean(reader, "KeyLogin", false); //From: [Table]
				login.MailMessageAddressType = GetReaderValue_String(reader, "MailMessageAddressType", ""); //From: [usp_autosearch_Login_for_Mail]
				login.MailMessageAddressSort = GetReaderValue_String(reader, "MailMessageAddressSort", ""); //From: [usp_autosearch_Login_for_Mail]
				login.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_Credit]
				login.TeamName = GetReaderValue_String(reader, "TeamName", ""); //From: [usp_select_Company]
				login.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [Table]
				login.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", null); //From: [usp_select_Login_by_Name]
				login.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", ""); //From: [usp_select_Login_by_Name]
				login.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0); //From: [usp_select_Client_LastMonth_GP]
				login.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0); //From: [usp_select_Client_LastMonth_GP]
				login.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0); //From: [usp_select_Client_LastMonth_GP]
				login.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0); //From: [usp_select_Client_LastMonth_GP]
				login.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0); //From: [usp_select_Client_LastMonth_GP]
				login.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0); //From: [usp_select_Client_LastMonth_GP]
				login.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0); //From: [usp_select_Client_LastMonth_GP]
				login.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0); //From: [usp_select_Client_LastMonth_GP]
				login.Administrator = GetReaderValue_NullableBoolean(reader, "Administrator", null); //From: [usp_selectAll_Login_for_Client_including_Disabled]
				login.NumberOfSalesAccounts = GetReaderValue_NullableInt32(reader, "NumberOfSalesAccounts", null); //From: [usp_selectAll_Login_for_Client_including_Disabled]
				login.Cost = GetReaderValue_NullableDouble(reader, "Cost", null); //From: [usp_selectAll_Login_Top_Salespersons]
				login.Resale = GetReaderValue_NullableDouble(reader, "Resale", null); //From: [usp_selectAll_Login_Top_Salespersons]
				login.GrossProfit = GetReaderValue_NullableDouble(reader, "GrossProfit", null); //From: [usp_selectAll_Login_Top_Salespersons]
				login.Margin = GetReaderValue_NullableDouble(reader, "Margin", null); //From: [usp_selectAll_Login_Top_Salespersons]
				login.NoOfOrders = GetReaderValue_NullableInt32(reader, "NoOfOrders", null); //From: [usp_selectAll_Login_Top_Salespersons]
				login.NoOfCredits = GetReaderValue_NullableInt32(reader, "NoOfCredits", null); //From: [usp_selectAll_Login_Top_Salespersons]
			 
            }
			return login;
		}
	
		/// <summary>
		/// Returns a collection of LoginDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<LoginDetails> GetLoginCollectionFromReader(DbDataReader reader) {
			List<LoginDetails> logins = new List<LoginDetails>();
			while (reader.Read()) logins.Add(GetLoginFromReader(reader));
			return logins;
		}
		
		
	}
}