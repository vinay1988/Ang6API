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
	
	public class CompanyAddressDetails {
		
		#region Constructors
		
		public CompanyAddressDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CompanyAddressId (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.Int32 CompanyAddressId { get; set; }
		/// <summary>
		/// CompanyNo (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// AddressNo (from Table)
		/// </summary>
		public System.Int32 AddressNo { get; set; }
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
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// DefaultBilling (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.Boolean DefaultBilling { get; set; }
		/// <summary>
		/// DefaultShipping (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.Boolean DefaultShipping { get; set; }
		/// <summary>
		/// ShippingNotes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String ShippingNotes { get; set; }
        /// <summary>
        /// ESMS #14 TaxbyAddress
        /// </summary>
        public System.Int32? TaxbyAddress { get; set; }	

		#endregion

	}
}