//Marker     changed by      date          Remarks
//[001]      Vinay           24/08/2012    ESMS Ref:## - Disable create so button if quantity is 0 
//[002]      Vinay           21/01/2014   CR:- Add AS9120 Requirement in GT application
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
	

	public class QuoteDetails {
		
		#region Constructors
		
		public QuoteDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// QuoteId (from Table)
		/// </summary>
		public System.Int32 QuoteId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// QuoteNumber (from Table)
		/// </summary>
		public System.Int32 QuoteNumber { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// DateQuoted (from Table)
		/// </summary>
		public System.DateTime DateQuoted { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// Salesman (from Table)
		/// </summary>
		public System.Int32 Salesman { get; set; }
		/// <summary>
		/// TermsNo (from Table)
		/// </summary>
		public System.Int32? TermsNo { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32 DivisionNo { get; set; }
		/// <summary>
		/// Freight (from Table)
		/// </summary>
		public System.Double? Freight { get; set; }
		/// <summary>
		/// Closed (from Table)
		/// </summary>
		public System.Boolean? Closed { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// IncotermNo (from Table)
		/// </summary>
		public System.Int32? IncotermNo { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyOnStop (from usp_select_Quote)
		/// </summary>
		public System.Boolean? CompanyOnStop { get; set; }
		/// <summary>
		/// CompanySOApproved (from usp_select_Quote)
		/// </summary>
		public System.Boolean? CompanySOApproved { get; set; }
		/// <summary>
		/// ContactName (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// SalesmanName (from usp_select_Quote)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// QuoteValue (from usp_select_Quote)
		/// </summary>
		public System.Double? QuoteValue { get; set; }
		/// <summary>
		/// TermsName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// OpenLines (from usp_select_Quote)
		/// </summary>
		public System.Int32? OpenLines { get; set; }
		/// <summary>
		/// IncotermName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String IncotermName { get; set; }
		/// <summary>
		/// ContactEmail (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String ContactEmail { get; set; }
		/// <summary>
		/// CreditLimit (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.Double? CreditLimit { get; set; }
		/// <summary>
		/// Balance (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.Double? Balance { get; set; }
        //[001] code start
        public System.Int32? TotalQuantityLines { get; set; }
        //[001] code end
        public System.Int32 TeamNo { get; set; }
        //[002] code start
        /// <summary>
        /// AS9120
        /// </summary>
        public System.Boolean? AS9120 { get; set; }
        public System.Int32 GlobalCurrencyNo { get; set; }
        //[002] code end
        /// <summary>
        /// IsCurrencyInSameFaimly
        /// </summary>
        public System.Boolean? IsCurrencyInSameFaimly { get; set; }
        public System.Boolean? IsImportant { get; set; }
        public System.Int32? QuoteStatus { get; set; }
        public System.String QuoteStatusName { get; set; }
		#endregion

	}
}
