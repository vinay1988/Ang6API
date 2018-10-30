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
	
	public class CountryDetails {
		
		#region Constructors
		
		public CountryDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CountryId (from Table)
		/// </summary>
		public System.Int32 CountryId { get; set; }
		/// <summary>
		/// CountryName (from usp_dropdown_Address_for_Company)
		/// </summary>
		public System.String CountryName { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// TelephonePrefix (from Table)
		/// </summary>
		public System.String TelephonePrefix { get; set; }
		/// <summary>
		/// Duty (from Table)
		/// </summary>
		public System.Boolean Duty { get; set; }
		/// <summary>
		/// TaxNo (from Table)
		/// </summary>
		public System.Int32? TaxNo { get; set; }
		/// <summary>
		/// ShippingCost (from Table)
		/// </summary>
		public System.Double? ShippingCost { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// GlobalCountryNo (from Table)
		/// </summary>
		public System.Int32? GlobalCountryNo { get; set; }
		/// <summary>
		/// DeliveryLeadTimeAir (from Table)
		/// </summary>
		public System.Int32? DeliveryLeadTimeAir { get; set; }
		/// <summary>
		/// DeliveryLeadTimeSurface (from Table)
		/// </summary>
		public System.Int32? DeliveryLeadTimeSurface { get; set; }
		/// <summary>
		/// IsPriorityForLists (from Table)
		/// </summary>
		public System.Boolean IsPriorityForLists { get; set; }
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
		/// TaxName (from usp_select_Country)
		/// </summary>
		public System.String TaxName { get; set; }

        /// <summary>
        /// RegionId (from Table)
        /// </summary>
        public System.Int32 RegionId { get; set; }
        /// <summary>
        /// RegionName 
        /// </summary>
        public System.String RegionName { get; set; }
        /// <summary>
        /// ShipSurchargePer
        /// </summary>
        public System.Double? ShipSurchargePer { get; set; }
		#endregion

	}
}