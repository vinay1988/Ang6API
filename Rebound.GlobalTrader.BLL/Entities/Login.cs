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
		public partial class Login : BizObject {
		
		#region Properties

		protected static DAL.LoginElement Settings {
			get { return Globals.Settings.Logins; }
		}

		/// <summary>
		/// LoginId
		/// </summary>
		public System.Int32 LoginId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// LoginName
		/// </summary>
		public System.String LoginName { get; set; }		
		/// <summary>
		/// EmployeeName
		/// </summary>
		public System.String EmployeeName { get; set; }		
		/// <summary>
		/// EmployeePassword
		/// </summary>
		public System.Byte[] EmployeePassword { get; set; }		
		/// <summary>
		/// FirstName
		/// </summary>
		public System.String FirstName { get; set; }		
		/// <summary>
		/// LastName
		/// </summary>
		public System.String LastName { get; set; }		
		/// <summary>
		/// AddressNo
		/// </summary>
		public System.Int32? AddressNo { get; set; }		
		/// <summary>
		/// Title
		/// </summary>
		public System.String Title { get; set; }		
		/// <summary>
		/// Extension
		/// </summary>
		public System.String Extension { get; set; }		
		/// <summary>
		/// Telephone
		/// </summary>
		public System.String Telephone { get; set; }		
		/// <summary>
		/// Fax
		/// </summary>
		public System.String Fax { get; set; }		
		/// <summary>
		/// EMail
		/// </summary>
		public System.String EMail { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// HomeTelephone
		/// </summary>
		public System.String HomeTelephone { get; set; }		
		/// <summary>
		/// HomeFax
		/// </summary>
		public System.String HomeFax { get; set; }		
		/// <summary>
		/// HomeEmail
		/// </summary>
		public System.String HomeEmail { get; set; }		
		/// <summary>
		/// Mobile
		/// </summary>
		public System.String Mobile { get; set; }		
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32 DivisionNo { get; set; }		
		/// <summary>
		/// TeamNo
		/// </summary>
		public System.Int32? TeamNo { get; set; }		
		/// <summary>
		/// Salutation
		/// </summary>
		public System.String Salutation { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// KeyLogin
		/// </summary>
		public System.Boolean KeyLogin { get; set; }		
		/// <summary>
		/// MailMessageAddressType
		/// </summary>
		public System.String MailMessageAddressType { get; set; }		
		/// <summary>
		/// MailMessageAddressSort
		/// </summary>
		public System.String MailMessageAddressSort { get; set; }		
		/// <summary>
		/// DivisionName
		/// </summary>
		public System.String DivisionName { get; set; }		
		/// <summary>
		/// TeamName
		/// </summary>
		public System.String TeamName { get; set; }		
		/// <summary>
		/// ClientName
		/// </summary>
		public System.String ClientName { get; set; }		
		/// <summary>
		/// ClientCurrencyNo
		/// </summary>
		public System.Int32? ClientCurrencyNo { get; set; }		
		/// <summary>
		/// ClientCurrencyCode
		/// </summary>
		public System.String ClientCurrencyCode { get; set; }		
		/// <summary>
		/// OpenShippingCost
		/// </summary>
		public System.Double OpenShippingCost { get; set; }		
		/// <summary>
		/// OpenFreightCharge
		/// </summary>
		public System.Double OpenFreightCharge { get; set; }		
		/// <summary>
		/// OpenLandedCost
		/// </summary>
		public System.Double OpenLandedCost { get; set; }		
		/// <summary>
		/// OpenSalesValue
		/// </summary>
		public System.Double OpenSalesValue { get; set; }		
		/// <summary>
		/// ShippedShippingCost
		/// </summary>
		public System.Double ShippedShippingCost { get; set; }		
		/// <summary>
		/// ShippedFreightCharge
		/// </summary>
		public System.Double ShippedFreightCharge { get; set; }		
		/// <summary>
		/// ShippedLandedCost
		/// </summary>
		public System.Double ShippedLandedCost { get; set; }		
		/// <summary>
		/// ShippedSalesValue
		/// </summary>
		public System.Double ShippedSalesValue { get; set; }		
		/// <summary>
		/// Administrator
		/// </summary>
		public System.Boolean? Administrator { get; set; }		
		/// <summary>
		/// NumberOfSalesAccounts
		/// </summary>
		public System.Int32? NumberOfSalesAccounts { get; set; }		
		/// <summary>
		/// Cost
		/// </summary>
		public System.Double? Cost { get; set; }		
		/// <summary>
		/// Resale
		/// </summary>
		public System.Double? Resale { get; set; }		
		/// <summary>
		/// GrossProfit
		/// </summary>
		public System.Double? GrossProfit { get; set; }		
		/// <summary>
		/// Margin
		/// </summary>
		public System.Double? Margin { get; set; }		
		/// <summary>
		/// NoOfOrders
		/// </summary>
		public System.Int32? NoOfOrders { get; set; }		
		/// <summary>
		/// NoOfCredits
		/// </summary>
		public System.Int32? NoOfCredits { get; set; }
        /// <summary>
        /// PrinterNo
        /// </summary>
        public System.Int32? PrinterNo { get; set; }
        /// <summary>
        /// PrinterName
        /// </summary>
        public System.String PrinterName { get; set; }		
        /// <summary>
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }
        /// <summary>
        /// ClientLocalCurrencyCode
        /// </summary>
        public System.String ClientLocalCurrencyCode { get; set; }
        /// <summary>
        /// LabelPathNo
        /// </summary>
        public System.Int32? LabelPathNo { get; set; }
        /// <summary>
        /// LabelPath
        /// </summary>
        public System.String LabelPath { get; set; }
        /// <summary>
        /// ADLogin
        /// </summary>
        public System.String ADLogin { get; set; }
        /// <summary>
        /// GroupAccess
        /// </summary>
        public System.Boolean? GroupAccess { get; set; }
        /// <summary>
        /// IsPOHub
        /// </summary>
        public System.Boolean? IsPOHub { get; set; }
        public int? POHubMailGroupId { get; set; }
        /// <summary>
        /// IsGlobalUser
        /// </summary>
        public System.Boolean? IsGlobalUser { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// AutoSearchForMail
		/// Calls [usp_autosearch_Login_for_Mail]
		/// </summary>
		public static List<Login> AutoSearchForMail(System.Int32? clientId, System.Int32? loginId, System.String nameSearch) {
			List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.AutoSearchForMail(clientId, loginId, nameSearch);
			if (lstDetails == null) {
				return new List<Login>();
			} else {
				List<Login> lst = new List<Login>();
				foreach (LoginDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
					obj.LoginId = objDetails.LoginId;
					obj.EmployeeName = objDetails.EmployeeName;
					obj.MailMessageAddressType = objDetails.MailMessageAddressType;
					obj.MailMessageAddressSort = objDetails.MailMessageAddressSort;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Login]
		/// </summary>
		public static bool Delete(System.Int32? loginId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Login.Delete(loginId);
		}
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Login_for_Client]
		/// </summary>
		public static List<Login> DropDownForClient(System.Int32? clientNo, System.Int32? teamNo, System.Int32? divisionNo, System.Int32? excludeLoginNo) {
			List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.DropDownForClient(clientNo, teamNo, divisionNo, excludeLoginNo);
			if (lstDetails == null) {
				return new List<Login>();
			} else {
				List<Login> lst = new List<Login>();
				foreach (LoginDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
					obj.LoginId = objDetails.LoginId;
					obj.EmployeeName = objDetails.EmployeeName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        /// <summary>
        /// DropDownForClient
        /// Calls [usp_dropdown_Login_for_ClientNPR]
        /// </summary>
        public static List<Login> DropDownForClientNPR(System.Int32? goodsInLineNo, System.Int32? teamNo, System.Int32? divisionNo, System.Int32? excludeLoginNo)
        {
            List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.DropDownForClientNPR(goodsInLineNo, teamNo, divisionNo, excludeLoginNo);
            if (lstDetails == null)
            {
                return new List<Login>();
            }
            else
            {
                List<Login> lst = new List<Login>();
                foreach (LoginDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
                    obj.LoginId = objDetails.LoginId;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Login]
		/// </summary>
		public static Int32 Insert(System.Int32? clientNo, System.String loginName, System.String employeeName, System.String firstName, System.String lastName, System.Int32? addressNo, System.String title, System.String extension, System.String telephone, System.String fax, System.String email, System.String notes, System.String homeTelephone, System.String homeFax, System.String homeEmail, System.String mobile, System.Int32? divisionNo, System.Int32? teamNo, System.String salutation, System.Boolean? keyLogin, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Login.Insert(clientNo, loginName, employeeName, firstName, lastName, addressNo, title, extension, telephone, fax, email, notes, homeTelephone, homeFax, homeEmail, mobile, divisionNo, teamNo, salutation, keyLogin, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Login]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Login.Insert(ClientNo, LoginName, EmployeeName, FirstName, LastName, AddressNo, Title, Extension, Telephone, Fax, EMail, Notes, HomeTelephone, HomeFax, HomeEmail, Mobile, DivisionNo, TeamNo, Salutation, KeyLogin, UpdatedBy);
		}
		/// <summary>
		/// Login
		/// Calls [usp_login_Login]
		/// </summary>
        public static Int32 DoLogin(System.String loginName, System.String password, System.String ipAddress, System.String sessionId, System.String serverIP)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Login.Login(loginName, password, ipAddress, sessionId,serverIP);
		}
		/// <summary>
		/// Logout
		/// Calls [usp_logout_Login]
		/// </summary>
		public static void Logout(System.Int32? loginId, System.String sessionName) {
			Rebound.GlobalTrader.DAL.SiteProvider.Login.Logout(loginId, sessionName);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Login]
		/// </summary>
		public static Login Get(System.Int32? loginId) {
			Rebound.GlobalTrader.DAL.LoginDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.Get(loginId);
			if (objDetails == null) {
				return null;
			} else {
				Login obj = new Login();
				obj.LoginId = objDetails.LoginId;
				obj.ClientNo = objDetails.ClientNo;
				obj.LoginName = objDetails.LoginName;
				obj.EmployeeName = objDetails.EmployeeName;
				obj.EmployeePassword = objDetails.EmployeePassword;
				obj.FirstName = objDetails.FirstName;
				obj.LastName = objDetails.LastName;
				obj.AddressNo = objDetails.AddressNo;
				obj.Title = objDetails.Title;
				obj.Extension = objDetails.Extension;
				obj.Telephone = objDetails.Telephone;
				obj.Fax = objDetails.Fax;
				obj.EMail = objDetails.EMail;
				obj.Notes = objDetails.Notes;
				obj.HomeTelephone = objDetails.HomeTelephone;
				obj.HomeFax = objDetails.HomeFax;
				obj.HomeEmail = objDetails.HomeEmail;
				obj.Mobile = objDetails.Mobile;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.Salutation = objDetails.Salutation;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.KeyLogin = objDetails.KeyLogin;
				obj.DivisionName = objDetails.DivisionName;
				obj.TeamName = objDetails.TeamName;
                obj.PrinterNo = objDetails.PrinterNo;
                obj.PrinterName = objDetails.PrinterName;
                obj.LabelPathNo = objDetails.LabelPathNo;
                obj.LabelPath = objDetails.LabelPath;
                obj.ADLogin = objDetails.ADLogin;
                obj.GroupAccess = objDetails.GroupAccess;
                obj.IsPOHub = objDetails.IsPOHub;

				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetByName
		/// Calls [usp_select_Login_by_Name]
		/// </summary>
		public static Login GetByName(System.String loginName) {
			Rebound.GlobalTrader.DAL.LoginDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetByName(loginName);
			if (objDetails == null) {
				return null;
			} else {
				Login obj = new Login();
				obj.LoginId = objDetails.LoginId;
				obj.ClientNo = objDetails.ClientNo;
				obj.LoginName = objDetails.LoginName;
				obj.EmployeeName = objDetails.EmployeeName;
				obj.EmployeePassword = objDetails.EmployeePassword;
				obj.FirstName = objDetails.FirstName;
				obj.LastName = objDetails.LastName;
				obj.AddressNo = objDetails.AddressNo;
				obj.Title = objDetails.Title;
				obj.Extension = objDetails.Extension;
				obj.Telephone = objDetails.Telephone;
				obj.Fax = objDetails.Fax;
				obj.EMail = objDetails.EMail;
				obj.Notes = objDetails.Notes;
				obj.HomeTelephone = objDetails.HomeTelephone;
				obj.HomeFax = objDetails.HomeFax;
				obj.HomeEmail = objDetails.HomeEmail;
				obj.Mobile = objDetails.Mobile;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.Salutation = objDetails.Salutation;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.KeyLogin = objDetails.KeyLogin;
				obj.DivisionName = objDetails.DivisionName;
				obj.TeamName = objDetails.TeamName;
				obj.ClientName = objDetails.ClientName;
				obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
				obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
                obj.ClientCode = objDetails.ClientCode;
                obj.ClientLocalCurrencyCode = objDetails.ClientLocalCurrencyCode;
                obj.ADLogin = objDetails.ADLogin;
                obj.IsPOHub = objDetails.IsPOHub;
                obj.POHubMailGroupId = objDetails.POHubMailGroupId;
                obj.IsGlobalUser = objDetails.IsGlobalUser;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForBoris
		/// Calls [usp_select_Login_for_Boris]
		/// </summary>
		public static Login GetForBoris(System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.LoginDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetForBoris(clientId);
			if (objDetails == null) {
				return null;
			} else {
				Login obj = new Login();
				obj.LoginId = objDetails.LoginId;
				obj.ClientNo = objDetails.ClientNo;
				obj.ClientName = objDetails.ClientName;
				obj.EmployeeName = objDetails.EmployeeName;
				obj.FirstName = objDetails.FirstName;
				obj.LastName = objDetails.LastName;
				obj.EMail = objDetails.EMail;
				obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
				obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.DivisionName = objDetails.DivisionName;
				obj.TeamNo = objDetails.TeamNo;
				obj.TeamName = objDetails.TeamName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetLastMonthGP
		/// Calls [usp_select_Login_LastMonth_GP]
		/// </summary>
		public static Login GetLastMonthGP(System.Int32? loginId) {
			Rebound.GlobalTrader.DAL.LoginDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetLastMonthGP(loginId);
			if (objDetails == null) {
				return null;
			} else {
				Login obj = new Login();
				obj.OpenShippingCost = objDetails.OpenShippingCost;
				obj.OpenFreightCharge = objDetails.OpenFreightCharge;
				obj.OpenLandedCost = objDetails.OpenLandedCost;
				obj.OpenSalesValue = objDetails.OpenSalesValue;
				obj.ShippedShippingCost = objDetails.ShippedShippingCost;
				obj.ShippedFreightCharge = objDetails.ShippedFreightCharge;
				obj.ShippedLandedCost = objDetails.ShippedLandedCost;
				obj.ShippedSalesValue = objDetails.ShippedSalesValue;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetLastYearGP
		/// Calls [usp_select_Login_LastYear_GP]
		/// </summary>
		public static Login GetLastYearGP(System.Int32? loginId) {
			Rebound.GlobalTrader.DAL.LoginDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetLastYearGP(loginId);
			if (objDetails == null) {
				return null;
			} else {
				Login obj = new Login();
				obj.OpenShippingCost = objDetails.OpenShippingCost;
				obj.OpenFreightCharge = objDetails.OpenFreightCharge;
				obj.OpenLandedCost = objDetails.OpenLandedCost;
				obj.OpenSalesValue = objDetails.OpenSalesValue;
				obj.ShippedShippingCost = objDetails.ShippedShippingCost;
				obj.ShippedFreightCharge = objDetails.ShippedFreightCharge;
				obj.ShippedLandedCost = objDetails.ShippedLandedCost;
				obj.ShippedSalesValue = objDetails.ShippedSalesValue;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetName
		/// Calls [usp_select_Login_Name]
		/// </summary>
		public static Login GetName(System.Int32? loginId) {
			Rebound.GlobalTrader.DAL.LoginDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetName(loginId);
			if (objDetails == null) {
				return null;
			} else {
				Login obj = new Login();
				obj.EmployeeName = objDetails.EmployeeName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetNextMonthGP
		/// Calls [usp_select_Login_NextMonth_GP]
		/// </summary>
		public static Login GetNextMonthGP(System.Int32? loginId) {
			Rebound.GlobalTrader.DAL.LoginDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetNextMonthGP(loginId);
			if (objDetails == null) {
				return null;
			} else {
				Login obj = new Login();
				obj.OpenShippingCost = objDetails.OpenShippingCost;
				obj.OpenFreightCharge = objDetails.OpenFreightCharge;
				obj.OpenLandedCost = objDetails.OpenLandedCost;
				obj.OpenSalesValue = objDetails.OpenSalesValue;
				obj.ShippedShippingCost = objDetails.ShippedShippingCost;
				obj.ShippedFreightCharge = objDetails.ShippedFreightCharge;
				obj.ShippedLandedCost = objDetails.ShippedLandedCost;
				obj.ShippedSalesValue = objDetails.ShippedSalesValue;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetThisMonthGP
		/// Calls [usp_select_Login_ThisMonth_GP]
		/// </summary>
		public static Login GetThisMonthGP(System.Int32? loginId) {
			Rebound.GlobalTrader.DAL.LoginDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetThisMonthGP(loginId);
			if (objDetails == null) {
				return null;
			} else {
				Login obj = new Login();
				obj.OpenShippingCost = objDetails.OpenShippingCost;
				obj.OpenFreightCharge = objDetails.OpenFreightCharge;
				obj.OpenLandedCost = objDetails.OpenLandedCost;
				obj.OpenSalesValue = objDetails.OpenSalesValue;
				obj.ShippedShippingCost = objDetails.ShippedShippingCost;
				obj.ShippedFreightCharge = objDetails.ShippedFreightCharge;
				obj.ShippedLandedCost = objDetails.ShippedLandedCost;
				obj.ShippedSalesValue = objDetails.ShippedSalesValue;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetThisYearGP
		/// Calls [usp_select_Login_ThisYear_GP]
		/// </summary>
		public static Login GetThisYearGP(System.Int32? loginId) {
			Rebound.GlobalTrader.DAL.LoginDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetThisYearGP(loginId);
			if (objDetails == null) {
				return null;
			} else {
				Login obj = new Login();
				obj.OpenShippingCost = objDetails.OpenShippingCost;
				obj.OpenFreightCharge = objDetails.OpenFreightCharge;
				obj.OpenLandedCost = objDetails.OpenLandedCost;
				obj.OpenSalesValue = objDetails.OpenSalesValue;
				obj.ShippedShippingCost = objDetails.ShippedShippingCost;
				obj.ShippedFreightCharge = objDetails.ShippedFreightCharge;
				obj.ShippedLandedCost = objDetails.ShippedLandedCost;
				obj.ShippedSalesValue = objDetails.ShippedSalesValue;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Login_for_Client]
		/// </summary>
		public static List<Login> GetListForClient(System.Int32? clientId) {
			List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetListForClient(clientId);
			if (lstDetails == null) {
				return new List<Login>();
			} else {
				List<Login> lst = new List<Login>();
				foreach (LoginDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
					obj.LoginId = objDetails.LoginId;
					obj.ClientNo = objDetails.ClientNo;
					obj.LoginName = objDetails.LoginName;
					obj.EmployeeName = objDetails.EmployeeName;
					obj.EmployeePassword = objDetails.EmployeePassword;
					obj.FirstName = objDetails.FirstName;
					obj.LastName = objDetails.LastName;
					obj.AddressNo = objDetails.AddressNo;
					obj.Title = objDetails.Title;
					obj.Extension = objDetails.Extension;
					obj.Telephone = objDetails.Telephone;
					obj.Fax = objDetails.Fax;
					obj.EMail = objDetails.EMail;
					obj.Notes = objDetails.Notes;
					obj.HomeTelephone = objDetails.HomeTelephone;
					obj.HomeFax = objDetails.HomeFax;
					obj.HomeEmail = objDetails.HomeEmail;
					obj.Mobile = objDetails.Mobile;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.Salutation = objDetails.Salutation;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.KeyLogin = objDetails.KeyLogin;
					obj.DivisionName = objDetails.DivisionName;
					obj.TeamName = objDetails.TeamName;
					obj.ClientName = objDetails.ClientName;
					obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
					obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForClientIncludingDisabled
		/// Calls [usp_selectAll_Login_for_Client_including_Disabled]
		/// </summary>
		public static List<Login> GetListForClientIncludingDisabled(System.Int32? clientNo) {
			List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetListForClientIncludingDisabled(clientNo);
			if (lstDetails == null) {
				return new List<Login>();
			} else {
				List<Login> lst = new List<Login>();
				foreach (LoginDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
					obj.LoginId = objDetails.LoginId;
					obj.EmployeeName = objDetails.EmployeeName;
					obj.Inactive = objDetails.Inactive;
					obj.LoginName = objDetails.LoginName;
					obj.Administrator = objDetails.Administrator;
					obj.NumberOfSalesAccounts = objDetails.NumberOfSalesAccounts;
					obj.TeamName = objDetails.TeamName;
					obj.DivisionName = objDetails.DivisionName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForDivision
		/// Calls [usp_selectAll_Login_for_Division]
		/// </summary>
		public static List<Login> GetListForDivision(System.Int32? divisionId) {
			List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetListForDivision(divisionId);
			if (lstDetails == null) {
				return new List<Login>();
			} else {
				List<Login> lst = new List<Login>();
				foreach (LoginDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
					obj.LoginId = objDetails.LoginId;
					obj.ClientNo = objDetails.ClientNo;
					obj.LoginName = objDetails.LoginName;
					obj.EmployeeName = objDetails.EmployeeName;
					obj.EmployeePassword = objDetails.EmployeePassword;
					obj.FirstName = objDetails.FirstName;
					obj.LastName = objDetails.LastName;
					obj.AddressNo = objDetails.AddressNo;
					obj.Title = objDetails.Title;
					obj.Extension = objDetails.Extension;
					obj.Telephone = objDetails.Telephone;
					obj.Fax = objDetails.Fax;
					obj.EMail = objDetails.EMail;
					obj.Notes = objDetails.Notes;
					obj.HomeTelephone = objDetails.HomeTelephone;
					obj.HomeFax = objDetails.HomeFax;
					obj.HomeEmail = objDetails.HomeEmail;
					obj.Mobile = objDetails.Mobile;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.Salutation = objDetails.Salutation;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.KeyLogin = objDetails.KeyLogin;
					obj.DivisionName = objDetails.DivisionName;
					obj.TeamName = objDetails.TeamName;
					obj.ClientName = objDetails.ClientName;
					obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
					obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForTeam
		/// Calls [usp_selectAll_Login_for_Team]
		/// </summary>
		public static List<Login> GetListForTeam(System.Int32? teamId) {
			List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetListForTeam(teamId);
			if (lstDetails == null) {
				return new List<Login>();
			} else {
				List<Login> lst = new List<Login>();
				foreach (LoginDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
					obj.LoginId = objDetails.LoginId;
					obj.ClientNo = objDetails.ClientNo;
					obj.LoginName = objDetails.LoginName;
					obj.EmployeeName = objDetails.EmployeeName;
					obj.EmployeePassword = objDetails.EmployeePassword;
					obj.FirstName = objDetails.FirstName;
					obj.LastName = objDetails.LastName;
					obj.AddressNo = objDetails.AddressNo;
					obj.Title = objDetails.Title;
					obj.Extension = objDetails.Extension;
					obj.Telephone = objDetails.Telephone;
					obj.Fax = objDetails.Fax;
					obj.EMail = objDetails.EMail;
					obj.Notes = objDetails.Notes;
					obj.HomeTelephone = objDetails.HomeTelephone;
					obj.HomeFax = objDetails.HomeFax;
					obj.HomeEmail = objDetails.HomeEmail;
					obj.Mobile = objDetails.Mobile;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.Salutation = objDetails.Salutation;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.KeyLogin = objDetails.KeyLogin;
					obj.DivisionName = objDetails.DivisionName;
					obj.TeamName = objDetails.TeamName;
					obj.ClientName = objDetails.ClientName;
					obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
					obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListTopSalespersons
		/// Calls [usp_selectAll_Login_Top_Salespersons]
		/// </summary>
		public static List<Login> GetListTopSalespersons(System.Int32? clientNo, System.Int32? topToSelect) {
			List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.GetListTopSalespersons(clientNo, topToSelect);
			if (lstDetails == null) {
				return new List<Login>();
			} else {
				List<Login> lst = new List<Login>();
				foreach (LoginDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
					obj.LoginId = objDetails.LoginId;
					obj.EmployeeName = objDetails.EmployeeName;
					obj.Cost = objDetails.Cost;
					obj.Resale = objDetails.Resale;
					obj.GrossProfit = objDetails.GrossProfit;
					obj.Margin = objDetails.Margin;
					obj.NoOfOrders = objDetails.NoOfOrders;
					obj.NoOfCredits = objDetails.NoOfCredits;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Login]
		/// </summary>
        public static bool Update(System.Int32? loginId, System.Int32? clientNo, System.String loginName, System.String employeeName, System.String firstName, System.String lastName, System.Int32? addressNo, System.String title, System.String extension, System.String telephone, System.String fax, System.String email, System.String notes, System.String homeTelephone, System.String homeFax, System.String homeEmail, System.String mobile, System.Int32? divisionNo, System.Int32? teamNo, System.String salutation, System.Boolean? inactive, System.Boolean? keyLogin, System.Int32? updatedBy, System.Int32? printerNo, System.Int32? labelPathNo, System.String adLogin, System.Boolean? groupAccess)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Login.Update(loginId, clientNo, loginName, employeeName, firstName, lastName, addressNo, title, extension, telephone, fax, email, notes, homeTelephone, homeFax, homeEmail, mobile, divisionNo, teamNo, salutation, inactive, keyLogin, updatedBy, printerNo, labelPathNo,adLogin,groupAccess);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Login]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Login.Update(LoginId, ClientNo, LoginName, EmployeeName, FirstName, LastName, AddressNo, Title, Extension, Telephone, Fax, EMail, Notes, HomeTelephone, HomeFax, HomeEmail, Mobile, DivisionNo, TeamNo, Salutation, Inactive, KeyLogin, UpdatedBy, PrinterNo,LabelPathNo,ADLogin,GroupAccess);
		}
		/// <summary>
		/// UpdateDivision
		/// Calls [usp_update_Login_Division]
		/// </summary>
		public static bool UpdateDivision(System.Int32? loginId, System.Int32? divisionNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Login.UpdateDivision(loginId, divisionNo);
		}
		/// <summary>
		/// UpdateInactive
		/// Calls [usp_update_Login_Inactive]
		/// </summary>
		public static bool UpdateInactive(System.Int32? loginId, System.Boolean? inactive) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Login.UpdateInactive(loginId, inactive);
		}
		/// <summary>
		/// UpdatePassword
		/// Calls [usp_update_Login_Password]
		/// </summary>
		public static bool UpdatePassword(System.Int32? loginId, System.String oldPassword, System.String newPassword, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Login.UpdatePassword(loginId, oldPassword, newPassword, updatedBy);
		}
		/// <summary>
		/// UpdateResetPassword
		/// Calls [usp_update_Login_ResetPassword]
		/// </summary>
		public static bool UpdateResetPassword(System.Int32? loginId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Login.UpdateResetPassword(loginId);
		}
		/// <summary>
		/// UpdateTeam
		/// Calls [usp_update_Login_Team]
		/// </summary>
		public static bool UpdateTeam(System.Int32? loginId, System.Int32? teamNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Login.UpdateTeam(loginId, teamNo);
		}

        private static Login PopulateFromDBDetailsObject(LoginDetails obj) {
            Login objNew = new Login();
			objNew.LoginId = obj.LoginId;
			objNew.ClientNo = obj.ClientNo;
			objNew.LoginName = obj.LoginName;
			objNew.EmployeeName = obj.EmployeeName;
			objNew.EmployeePassword = obj.EmployeePassword;
			objNew.FirstName = obj.FirstName;
			objNew.LastName = obj.LastName;
			objNew.AddressNo = obj.AddressNo;
			objNew.Title = obj.Title;
			objNew.Extension = obj.Extension;
			objNew.Telephone = obj.Telephone;
			objNew.Fax = obj.Fax;
			objNew.EMail = obj.EMail;
			objNew.Notes = obj.Notes;
			objNew.HomeTelephone = obj.HomeTelephone;
			objNew.HomeFax = obj.HomeFax;
			objNew.HomeEmail = obj.HomeEmail;
			objNew.Mobile = obj.Mobile;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.TeamNo = obj.TeamNo;
			objNew.Salutation = obj.Salutation;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.KeyLogin = obj.KeyLogin;
			objNew.MailMessageAddressType = obj.MailMessageAddressType;
			objNew.MailMessageAddressSort = obj.MailMessageAddressSort;
			objNew.DivisionName = obj.DivisionName;
			objNew.TeamName = obj.TeamName;
			objNew.ClientName = obj.ClientName;
			objNew.ClientCurrencyNo = obj.ClientCurrencyNo;
			objNew.ClientCurrencyCode = obj.ClientCurrencyCode;
			objNew.OpenShippingCost = obj.OpenShippingCost;
			objNew.OpenFreightCharge = obj.OpenFreightCharge;
			objNew.OpenLandedCost = obj.OpenLandedCost;
			objNew.OpenSalesValue = obj.OpenSalesValue;
			objNew.ShippedShippingCost = obj.ShippedShippingCost;
			objNew.ShippedFreightCharge = obj.ShippedFreightCharge;
			objNew.ShippedLandedCost = obj.ShippedLandedCost;
			objNew.ShippedSalesValue = obj.ShippedSalesValue;
			objNew.Administrator = obj.Administrator;
			objNew.NumberOfSalesAccounts = obj.NumberOfSalesAccounts;
			objNew.Cost = obj.Cost;
			objNew.Resale = obj.Resale;
			objNew.GrossProfit = obj.GrossProfit;
			objNew.Margin = obj.Margin;
			objNew.NoOfOrders = obj.NoOfOrders;
			objNew.NoOfCredits = obj.NoOfCredits;
            return objNew;
        }
        /// <summary>
        /// Forgot password
        /// Call [usp_get_password]
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Int32 ForgotPassword(System.String loginName, out System.String password, out System.String email)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Login.ForgotPassword(loginName, out password, out email);
        }
        /// <summary>
        /// Calls [usp_get_password_by_Email_client]
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static List<Login> ForgotUserName(System.Int32? clientNo, System.String email)
        {
            List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.ForgotUserName(clientNo, email);
            if (lstDetails == null)
            {
                return new List<Login>();
            }
            else
            {
                List<Login> lst = new List<Login>();
                foreach (LoginDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
                    obj.LoginName = objDetails.LoginName;
                    obj.ClientName = objDetails.ClientName;
                    obj.LastName = objDetails.LastName;
                    obj.EMail = objDetails.EMail;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// DropDownForPurchaseHub
        /// Calls [usp_dropdown_Login_for_PurchaseHubClient]
        /// </summary>
        public static List<Login> DropDownForPurchaseHub(System.Int32? clientNo, System.Int32? teamNo, System.Int32? divisionNo, System.Int32? excludeLoginNo)
        {
            List<LoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Login.DropDownForPurchaseHub(clientNo, teamNo, divisionNo, excludeLoginNo);
            if (lstDetails == null)
            {
                return new List<Login>();
            }
            else
            {
                List<Login> lst = new List<Login>();
                foreach (LoginDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Login obj = new Rebound.GlobalTrader.BLL.Login();
                    obj.LoginId = objDetails.LoginId;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		#endregion
		
	}
}
