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
		public partial class Client : BizObject {
		
		#region Properties

		protected static DAL.ClientElement Settings {
			get { return Globals.Settings.Clients; }
		}

		/// <summary>
		/// ClientId
		/// </summary>
		public System.Int32 ClientId { get; set; }		
		/// <summary>
		/// ClientName
		/// </summary>
		public System.String ClientName { get; set; }		
		/// <summary>
		/// ParentClientNo
		/// </summary>
		public System.Int32? ParentClientNo { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }		
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
		/// URL
		/// </summary>
		public System.String URL { get; set; }		
		/// <summary>
		/// ResaleLicense
		/// </summary>
		public System.String ResaleLicense { get; set; }		
		/// <summary>
		/// CompanyRegistration
		/// </summary>
		public System.String CompanyRegistration { get; set; }		
		/// <summary>
		/// DocumentFontName
		/// </summary>
		public System.String DocumentFontName { get; set; }		
		/// <summary>
		/// DocumentFontSize
		/// </summary>
		public System.Int32? DocumentFontSize { get; set; }		
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
		/// Login
		/// </summary>
		public System.String Login { get; set; }		
		/// <summary>
		/// DefaultSiteLanguageNo
		/// </summary>
		public System.Int32 DefaultSiteLanguageNo { get; set; }		
		/// <summary>
		/// HasDocumentHeaderImage
		/// </summary>
		public System.Boolean HasDocumentHeaderImage { get; set; }		
		/// <summary>
		/// Header
		/// </summary>
		public System.String Header { get; set; }		
		/// <summary>
		/// OwnDataVisibleToOthers
		/// </summary>
		public System.Boolean? OwnDataVisibleToOthers { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }		
		/// <summary>
		/// NumberOfUsers
		/// </summary>
		public System.Int32? NumberOfUsers { get; set; }		
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
        /// LocalCurrency
        /// </summary>
        public System.Int32 LocalCurrencyNo { get; set; }
        /// <summary>
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }
        /// <summary>
        /// HasDocumentHeaderImage
        /// </summary>
        public System.Boolean? IsPOHub { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Count
		/// Calls [usp_count_Client]
		/// </summary>
		public static Int32 Count() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Client.Count();
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_Client]
		/// </summary>
		public static bool Delete(System.Int32? clientId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Client.Delete(clientId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Client]
		/// </summary>
        public static Int32 Insert(System.String clientName, System.Int32? parentClientNo, System.Int32? currencyNo, System.String telephone, System.String fax, System.String email, System.String url, System.String resaleLicense, System.String companyRegistration, System.String documentFontName, System.Int32? documentFontSize, System.Int32? defaultSiteLanguageNo, System.Int32? updatedBy, System.Int32 localCurrencyNo, System.String clientCode)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Client.Insert(clientName, parentClientNo, currencyNo, telephone, fax, email, url, resaleLicense, companyRegistration, documentFontName, documentFontSize, defaultSiteLanguageNo, updatedBy, localCurrencyNo, clientCode);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Client]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Client.Insert(ClientName, ParentClientNo, CurrencyNo, Telephone, Fax, EMail, URL, ResaleLicense, CompanyRegistration, DocumentFontName, DocumentFontSize, DefaultSiteLanguageNo, UpdatedBy, LocalCurrencyNo, ClientCode);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Client]
		/// </summary>
		public static Client Get(System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.ClientDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Client.Get(clientId);
			if (objDetails == null) {
				return null;
			} else {
				Client obj = new Client();
				obj.ClientId = objDetails.ClientId;
				obj.ClientName = objDetails.ClientName;
				obj.ParentClientNo = objDetails.ParentClientNo;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.Telephone = objDetails.Telephone;
				obj.Fax = objDetails.Fax;
				obj.EMail = objDetails.EMail;
				obj.URL = objDetails.URL;
				obj.ResaleLicense = objDetails.ResaleLicense;
				obj.CompanyRegistration = objDetails.CompanyRegistration;
				obj.DocumentFontName = objDetails.DocumentFontName;
				obj.DocumentFontSize = objDetails.DocumentFontSize;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.Login = objDetails.Login;
				obj.DefaultSiteLanguageNo = objDetails.DefaultSiteLanguageNo;
				obj.HasDocumentHeaderImage = objDetails.HasDocumentHeaderImage;
				obj.Header = objDetails.Header;
				obj.OwnDataVisibleToOthers = objDetails.OwnDataVisibleToOthers;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.NumberOfUsers = objDetails.NumberOfUsers;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetLastMonthGP
		/// Calls [usp_select_Client_LastMonth_GP]
		/// </summary>
		public static Client GetLastMonthGP(System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.ClientDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Client.GetLastMonthGP(clientId);
			if (objDetails == null) {
				return null;
			} else {
				Client obj = new Client();
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
		/// Calls [usp_select_Client_LastYear_GP]
		/// </summary>
		public static Client GetLastYearGP(System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.ClientDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Client.GetLastYearGP(clientId);
			if (objDetails == null) {
				return null;
			} else {
				Client obj = new Client();
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
		/// GetNextMonthGP
		/// Calls [usp_select_Client_NextMonth_GP]
		/// </summary>
		public static Client GetNextMonthGP(System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.ClientDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Client.GetNextMonthGP(clientId);
			if (objDetails == null) {
				return null;
			} else {
				Client obj = new Client();
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
		/// Calls [usp_select_Client_ThisMonth_GP]
		/// </summary>
		public static Client GetThisMonthGP(System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.ClientDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Client.GetThisMonthGP(clientId);
			if (objDetails == null) {
				return null;
			} else {
				Client obj = new Client();
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
		/// Calls [usp_select_Client_ThisYear_GP]
		/// </summary>
		public static Client GetThisYearGP(System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.ClientDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Client.GetThisYearGP(clientId);
			if (objDetails == null) {
				return null;
			} else {
				Client obj = new Client();
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
		/// GetList
		/// Calls [usp_selectAll_Client]
		/// </summary>
		public static List<Client> GetList() {
			List<ClientDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Client.GetList();
			if (lstDetails == null) {
				return new List<Client>();
			} else {
				List<Client> lst = new List<Client>();
				foreach (ClientDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Client obj = new Rebound.GlobalTrader.BLL.Client();
					obj.ClientId = objDetails.ClientId;
					obj.ClientName = objDetails.ClientName;
					obj.ParentClientNo = objDetails.ParentClientNo;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.Telephone = objDetails.Telephone;
					obj.Fax = objDetails.Fax;
					obj.EMail = objDetails.EMail;
					obj.URL = objDetails.URL;
					obj.ResaleLicense = objDetails.ResaleLicense;
					obj.CompanyRegistration = objDetails.CompanyRegistration;
					obj.DocumentFontName = objDetails.DocumentFontName;
					obj.DocumentFontSize = objDetails.DocumentFontSize;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.Login = objDetails.Login;
					obj.DefaultSiteLanguageNo = objDetails.DefaultSiteLanguageNo;
					obj.HasDocumentHeaderImage = objDetails.HasDocumentHeaderImage;
					obj.Header = objDetails.Header;
					obj.OwnDataVisibleToOthers = objDetails.OwnDataVisibleToOthers;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.NumberOfUsers = objDetails.NumberOfUsers;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListActive
		/// Calls [usp_selectAll_Client_Active]
		/// </summary>
		public static List<Client> GetListActive() {
			List<ClientDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Client.GetListActive();
			if (lstDetails == null) {
				return new List<Client>();
			} else {
				List<Client> lst = new List<Client>();
				foreach (ClientDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Client obj = new Rebound.GlobalTrader.BLL.Client();
					obj.ClientId = objDetails.ClientId;
					obj.ClientName = objDetails.ClientName;
					obj.ParentClientNo = objDetails.ParentClientNo;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.Telephone = objDetails.Telephone;
					obj.Fax = objDetails.Fax;
					obj.EMail = objDetails.EMail;
					obj.URL = objDetails.URL;
					obj.ResaleLicense = objDetails.ResaleLicense;
					obj.CompanyRegistration = objDetails.CompanyRegistration;
					obj.DocumentFontName = objDetails.DocumentFontName;
					obj.DocumentFontSize = objDetails.DocumentFontSize;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.Login = objDetails.Login;
					obj.DefaultSiteLanguageNo = objDetails.DefaultSiteLanguageNo;
					obj.HasDocumentHeaderImage = objDetails.HasDocumentHeaderImage;
					obj.Header = objDetails.Header;
					obj.OwnDataVisibleToOthers = objDetails.OwnDataVisibleToOthers;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.NumberOfUsers = objDetails.NumberOfUsers;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Client]
		/// </summary>
		public static bool Update(System.Int32? clientId, System.String clientName, System.Int32? parentClientNo, System.Int32? currencyNo, System.String telephone, System.String fax, System.String email, System.String url, System.String resaleLicense, System.String companyRegistration, System.String documentFontName, System.Int32? documentFontSize, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Client.Update(clientId, clientName, parentClientNo, currencyNo, telephone, fax, email, url, resaleLicense, companyRegistration, documentFontName, documentFontSize, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Client]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Client.Update(ClientId, ClientName, ParentClientNo, CurrencyNo, Telephone, Fax, EMail, URL, ResaleLicense, CompanyRegistration, DocumentFontName, DocumentFontSize, Inactive, UpdatedBy);
		}
		/// <summary>
		/// UpdateDocumentHeaderImage
		/// Calls [usp_update_Client_DocumentHeaderImage]
		/// </summary>
		public static bool UpdateDocumentHeaderImage(System.Int32? clientNo, System.Boolean? hasDocumentHeaderImage, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Client.UpdateDocumentHeaderImage(clientNo, hasDocumentHeaderImage, updatedBy);
		}
		/// <summary>
		/// UpdateInactive
		/// Calls [usp_update_Client_Inactive]
		/// </summary>
		public static bool UpdateInactive(System.Int32? clientId, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Client.UpdateInactive(clientId, inactive, updatedBy);
		}
		/// <summary>
		/// UpdateOwnDataVisibleToOthers
		/// Calls [usp_update_Client_OwnDataVisibleToOthers]
		/// </summary>
		public static bool UpdateOwnDataVisibleToOthers(System.Int32? clientNo, System.Boolean? ownDataVisibleToOthers, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Client.UpdateOwnDataVisibleToOthers(clientNo, ownDataVisibleToOthers, updatedBy);
		}

        private static Client PopulateFromDBDetailsObject(ClientDetails obj) {
            Client objNew = new Client();
			objNew.ClientId = obj.ClientId;
			objNew.ClientName = obj.ClientName;
			objNew.ParentClientNo = obj.ParentClientNo;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.Telephone = obj.Telephone;
			objNew.Fax = obj.Fax;
			objNew.EMail = obj.EMail;
			objNew.URL = obj.URL;
			objNew.ResaleLicense = obj.ResaleLicense;
			objNew.CompanyRegistration = obj.CompanyRegistration;
			objNew.DocumentFontName = obj.DocumentFontName;
			objNew.DocumentFontSize = obj.DocumentFontSize;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.Login = obj.Login;
			objNew.DefaultSiteLanguageNo = obj.DefaultSiteLanguageNo;
			objNew.HasDocumentHeaderImage = obj.HasDocumentHeaderImage;
			objNew.Header = obj.Header;
			objNew.OwnDataVisibleToOthers = obj.OwnDataVisibleToOthers;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.CurrencyDescription = obj.CurrencyDescription;
			objNew.NumberOfUsers = obj.NumberOfUsers;
			objNew.OpenShippingCost = obj.OpenShippingCost;
			objNew.OpenFreightCharge = obj.OpenFreightCharge;
			objNew.OpenLandedCost = obj.OpenLandedCost;
			objNew.OpenSalesValue = obj.OpenSalesValue;
			objNew.ShippedShippingCost = obj.ShippedShippingCost;
			objNew.ShippedFreightCharge = obj.ShippedFreightCharge;
			objNew.ShippedLandedCost = obj.ShippedLandedCost;
			objNew.ShippedSalesValue = obj.ShippedSalesValue;
            return objNew;
        }
		
		#endregion
		
	}
}