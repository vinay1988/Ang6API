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
	
	public class TermsDetails {
		
		#region Constructors
		
		public TermsDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// TermsId (from Table)
		/// </summary>
		public System.Int32 TermsId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// Days (from Table)
		/// </summary>
		public System.Int32 Days { get; set; }
		/// <summary>
		/// TermsName (from usp_datalistnugget_Company_as_Customers)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// Buy (from Table)
		/// </summary>
		public System.Boolean Buy { get; set; }
		/// <summary>
		/// Sell (from Table)
		/// </summary>
		public System.Boolean Sell { get; set; }
		/// <summary>
		/// InAdvance (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.Boolean InAdvance { get; set; }
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
		/// RowNum (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int64? RowNum { get; set; }
        //[001] code start
        /// <summary>
        /// BankFee
        /// </summary>
        public System.Double? BankFee { get; set; }
        /// <summary>
        /// IsApplyBankFee
        /// </summary>
        public System.Boolean? IsApplyBankFee { get; set; }
        //[001] code end
        //[002] code start
        /// <summary>
        /// POBankFee
        /// </summary>
        public System.Double? POBankFee { get; set; }
        /// <summary>
        /// IsApplyPOBankFee
        /// </summary>
        public System.Boolean? IsApplyPOBankFee { get; set; }
        //[002] code end

		#endregion

	}
}