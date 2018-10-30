using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {
	
	public class LoginDetails {
		
		#region Constructors
		
		public LoginDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// LoginId (from Table)
		/// </summary>
		public System.Int32 LoginId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// LoginName (from Table)
		/// </summary>
		public System.String LoginName { get; set; }
		/// <summary>
		/// EmployeeName (from usp_selectAll_Audit_authorisation_for_SalesOrder)
		/// </summary>
		public System.String EmployeeName { get; set; }
		/// <summary>
		/// EmployeePassword (from Table)
		/// </summary>
		public System.Byte[] EmployeePassword { get; set; }
		/// <summary>
		/// FirstName (from Table)
		/// </summary>
		public System.String FirstName { get; set; }
		/// <summary>
		/// LastName (from Table)
		/// </summary>
		public System.String LastName { get; set; }
		/// <summary>
		/// AddressNo (from Table)
		/// </summary>
		public System.Int32? AddressNo { get; set; }
		/// <summary>
		/// Title (from Table)
		/// </summary>
		public System.String Title { get; set; }
		/// <summary>
		/// Extension (from Table)
		/// </summary>
		public System.String Extension { get; set; }
		/// <summary>
		/// Telephone (from Table)
		/// </summary>
		public System.String Telephone { get; set; }
		/// <summary>
		/// Fax (from Table)
		/// </summary>
		public System.String Fax { get; set; }
		/// <summary>
		/// EMail (from Table)
		/// </summary>
		public System.String EMail { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// HomeTelephone (from Table)
		/// </summary>
		public System.String HomeTelephone { get; set; }
		/// <summary>
		/// HomeFax (from Table)
		/// </summary>
		public System.String HomeFax { get; set; }
		/// <summary>
		/// HomeEmail (from Table)
		/// </summary>
		public System.String HomeEmail { get; set; }
		/// <summary>
		/// Mobile (from Table)
		/// </summary>
		public System.String Mobile { get; set; }
		/// <summary>
		/// DivisionNo (from usp_select_Contact)
		/// </summary>
		public System.Int32 DivisionNo { get; set; }
		/// <summary>
		/// TeamNo (from Table)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// Salutation (from Table)
		/// </summary>
		public System.String Salutation { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// KeyLogin (from Table)
		/// </summary>
		public System.Boolean KeyLogin { get; set; }
		/// <summary>
		/// MailMessageAddressType (from usp_autosearch_Login_for_Mail)
		/// </summary>
		public System.String MailMessageAddressType { get; set; }
		/// <summary>
		/// MailMessageAddressSort (from usp_autosearch_Login_for_Mail)
		/// </summary>
		public System.String MailMessageAddressSort { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_Credit)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// TeamName (from usp_select_Company)
		/// </summary>
		public System.String TeamName { get; set; }
		/// <summary>
		/// ClientName (from Table)
		/// </summary>
		public System.String ClientName { get; set; }
		/// <summary>
		/// ClientCurrencyNo (from usp_select_Login_by_Name)
		/// </summary>
		public System.Int32? ClientCurrencyNo { get; set; }
		/// <summary>
		/// ClientCurrencyCode (from usp_select_Login_by_Name)
		/// </summary>
		public System.String ClientCurrencyCode { get; set; }
		/// <summary>
		/// OpenShippingCost (from usp_select_Client_LastMonth_GP)
		/// </summary>
		public System.Double OpenShippingCost { get; set; }
		/// <summary>
		/// OpenFreightCharge (from usp_select_Client_LastMonth_GP)
		/// </summary>
		public System.Double OpenFreightCharge { get; set; }
		/// <summary>
		/// OpenLandedCost (from usp_select_Client_LastMonth_GP)
		/// </summary>
		public System.Double OpenLandedCost { get; set; }
		/// <summary>
		/// OpenSalesValue (from usp_select_Client_LastMonth_GP)
		/// </summary>
		public System.Double OpenSalesValue { get; set; }
		/// <summary>
		/// ShippedShippingCost (from usp_select_Client_LastMonth_GP)
		/// </summary>
		public System.Double ShippedShippingCost { get; set; }
		/// <summary>
		/// ShippedFreightCharge (from usp_select_Client_LastMonth_GP)
		/// </summary>
		public System.Double ShippedFreightCharge { get; set; }
		/// <summary>
		/// ShippedLandedCost (from usp_select_Client_LastMonth_GP)
		/// </summary>
		public System.Double ShippedLandedCost { get; set; }
		/// <summary>
		/// ShippedSalesValue (from usp_select_Client_LastMonth_GP)
		/// </summary>
		public System.Double ShippedSalesValue { get; set; }
		/// <summary>
		/// Administrator (from usp_selectAll_Login_for_Client_including_Disabled)
		/// </summary>
		public System.Boolean? Administrator { get; set; }
		/// <summary>
		/// NumberOfSalesAccounts (from usp_selectAll_Login_for_Client_including_Disabled)
		/// </summary>
		public System.Int32? NumberOfSalesAccounts { get; set; }
		/// <summary>
		/// Cost (from usp_selectAll_Login_Top_Salespersons)
		/// </summary>
		public System.Double? Cost { get; set; }
		/// <summary>
		/// Resale (from usp_selectAll_Login_Top_Salespersons)
		/// </summary>
		public System.Double? Resale { get; set; }
		/// <summary>
		/// GrossProfit (from usp_selectAll_Login_Top_Salespersons)
		/// </summary>
		public System.Double? GrossProfit { get; set; }
		/// <summary>
		/// Margin (from usp_selectAll_Login_Top_Salespersons)
		/// </summary>
		public System.Double? Margin { get; set; }
		/// <summary>
		/// NoOfOrders (from usp_selectAll_Login_Top_Salespersons)
		/// </summary>
		public System.Int32? NoOfOrders { get; set; }
		/// <summary>
		/// NoOfCredits (from usp_selectAll_Login_Top_Salespersons)
		/// </summary>
		public System.Int32? NoOfCredits { get; set; }
        /// <summary>
        /// Client Code(from usp_select_Login_by_Name)
        /// </summary>
        public System.String ClientCode { get; set; }
        /// <summary>
        /// Client Local Currency(from usp_select_Login_by_Name)
        /// </summary>
        public System.String ClientLocalCurrencyCode { get; set; }
        /// <summary>
        /// PrinterNo
        /// </summary>
        public System.Int32? PrinterNo { get; set; }
        /// <summary>
        /// PrinterName
        /// </summary>
        public System.String PrinterName { get; set; }
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
        /// <summary>
        /// POHubMailGroupId
        /// </summary>
        public int? POHubMailGroupId { get; set; }
        /// <summary>
        /// IsGlobalUser
        /// </summary>
        public System.Boolean? IsGlobalUser { get; set; }

		#endregion

	}
}
