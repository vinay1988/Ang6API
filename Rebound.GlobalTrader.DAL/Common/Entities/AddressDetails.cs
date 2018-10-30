//Marker     Changed by      Date         Remarks
//[001]      Vinay           11/06/2012   This need to Add Incoterms field in company section
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
	
	public class AddressDetails {
		
		#region Constructors
		
		public AddressDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// AddressId (from Table)
		/// </summary>
		public System.Int32 AddressId { get; set; }
		/// <summary>
		/// AddressName (from Table)
		/// </summary>
		public System.String AddressName { get; set; }
		/// <summary>
		/// Line1 (from Table)
		/// </summary>
		public System.String Line1 { get; set; }
		/// <summary>
		/// Line2 (from Table)
		/// </summary>
		public System.String Line2 { get; set; }
		/// <summary>
		/// Line3 (from Table)
		/// </summary>
		public System.String Line3 { get; set; }
		/// <summary>
		/// County (from Table)
		/// </summary>
		public System.String County { get; set; }
		/// <summary>
		/// City (from Table)
		/// </summary>
		public System.String City { get; set; }
		/// <summary>
		/// State (from Table)
		/// </summary>
		public System.String State { get; set; }
		/// <summary>
		/// CountryNo (from Table)
		/// </summary>
		public System.Int32? CountryNo { get; set; }
		/// <summary>
		/// ZIP (from Table)
		/// </summary>
		public System.String ZIP { get; set; }
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
		/// CountryName (from usp_dropdown_Address_for_Company)
		/// </summary>
		public System.String CountryName { get; set; }
		/// <summary>
		/// CompanyAddressId (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.Int32 CompanyAddressId { get; set; }
		/// <summary>
		/// DefaultBilling (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.Boolean DefaultBilling { get; set; }
		/// <summary>
		/// DefaultShipping (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.Boolean DefaultShipping { get; set; }
		/// <summary>
		/// CeaseDate (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.DateTime? CeaseDate { get; set; }
		/// <summary>
		/// ShipViaNo (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.Int32? ShipViaNo { get; set; }
		/// <summary>
		/// ShipViaAccount (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String ShipViaAccount { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// ShippingNotes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String ShippingNotes { get; set; }
		/// <summary>
		/// CompanyNo (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// ShipViaName (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String ShipViaName { get; set; }        
        /// <summary>
        /// TaxbyAddress
        /// </summary>
        public System.Int32? TaxbyAddress { get; set; }
        /// <summary>
        /// TaxValue
        /// </summary>
        public System.String TaxValue { get; set; }
        //[001] code start
        /// <summary>
        /// IncotermName 
        /// </summary>
        public System.String IncotermName { get; set; }
        /// <summary>
        /// IncotermNo
        /// </summary>
        public System.Int32? IncotermNo { get; set; }
        //[001] code end
        /// <summary>
        /// VatNo
        /// </summary>
        public System.String VatNo { get; set; }
        /// <summary>
        /// RecievingNotes
        /// </summary>
        public System.String RecievingNotes { get; set; }

		#endregion

	}
}