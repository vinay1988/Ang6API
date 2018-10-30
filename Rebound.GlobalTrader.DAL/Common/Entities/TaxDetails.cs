//Marker     Changed by      Date               Remarks
//[001]      Vinay           15/07/2013         ESMS Ref##-37 Add New Column named as purchage code under Setup => Company Settings => Tax Section 
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
	
	public class TaxDetails {
		
		#region Constructors
		
		public TaxDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// TaxId (from Table)
		/// </summary>
		public System.Int32 TaxId { get; set; }
		/// <summary>
		/// TaxName (from usp_select_Country)
		/// </summary>
		public System.String TaxName { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
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
		/// TaxCode (from Table)
		/// </summary>
		public System.String TaxCode { get; set; }
		/// <summary>
		/// PrintNotes (from usp_select_Invoice_for_Print)
		/// </summary>
		public System.String PrintNotes { get; set; }

        //[001] code start
        /// <summary>
        /// PurchaseTaxCode
        /// </summary>
        public System.String PurchaseTaxCode { get; set; }
        //[001] code end

		#endregion

	}
}