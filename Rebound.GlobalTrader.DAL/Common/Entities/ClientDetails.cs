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
	
	public class ClientDetails {
		
		#region Constructors
		
		public ClientDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ClientId (from Table)
		/// </summary>
		public System.Int32 ClientId { get; set; }
		/// <summary>
		/// ClientName (from Table)
		/// </summary>
		public System.String ClientName { get; set; }
		/// <summary>
		/// ParentClientNo (from Table)
		/// </summary>
		public System.Int32? ParentClientNo { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
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
		/// URL (from Table)
		/// </summary>
		public System.String URL { get; set; }
		/// <summary>
		/// ResaleLicense (from Table)
		/// </summary>
		public System.String ResaleLicense { get; set; }
		/// <summary>
		/// CompanyRegistration (from Table)
		/// </summary>
		public System.String CompanyRegistration { get; set; }
		/// <summary>
		/// DocumentFontName (from Table)
		/// </summary>
		public System.String DocumentFontName { get; set; }
		/// <summary>
		/// DocumentFontSize (from Table)
		/// </summary>
		public System.Int32? DocumentFontSize { get; set; }
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
		/// Login (from Table)
		/// </summary>
		public System.String Login { get; set; }
		/// <summary>
		/// DefaultSiteLanguageNo (from Table)
		/// </summary>
		public System.Int32 DefaultSiteLanguageNo { get; set; }
		/// <summary>
		/// HasDocumentHeaderImage (from Table)
		/// </summary>
		public System.Boolean HasDocumentHeaderImage { get; set; }
		/// <summary>
		/// Header (from Table)
		/// </summary>
		public System.String Header { get; set; }
		/// <summary>
		/// OwnDataVisibleToOthers (from Table)
		/// </summary>
		public System.Boolean? OwnDataVisibleToOthers { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_Client)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_Client)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// NumberOfUsers (from usp_select_Client)
		/// </summary>
		public System.Int32? NumberOfUsers { get; set; }
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
        public System.Boolean? IsPOHub { get; set; }

		#endregion

	}
}