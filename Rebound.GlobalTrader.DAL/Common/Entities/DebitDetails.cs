//Marker     Changed by      Date         Remarks
//[001]      Vinay           30/07/2012   Add compulsory incoterms field when create Credit and debit note. :ESMS No:- 105
//[003]      Abhinav         06/11/2013   Add VATNO, CuostmerCode in Print document
//[004]      Aashu Singh      01/06/2018   Quick Jump in Global Warehouse 

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
	
	public class DebitDetails {
		
		#region Constructors
		
		public DebitDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// DebitId (from Table)
		/// </summary>
		public System.Int32 DebitId { get; set; }
		/// <summary>
		/// DebitNumber (from Table)
		/// </summary>
		public System.Int32 DebitNumber { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// DebitDate (from Table)
		/// </summary>
		public System.DateTime DebitDate { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// RaisedBy (from Table)
		/// </summary>
		public System.Int32? RaisedBy { get; set; }
		/// <summary>
		/// Buyer (from Table)
		/// </summary>
		public System.Int32 Buyer { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// Freight (from Table)
		/// </summary>
		public System.Double? Freight { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32 DivisionNo { get; set; }
		/// <summary>
		/// TaxNo (from Table)
		/// </summary>
		public System.Int32? TaxNo { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from Table)
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }
		/// <summary>
		/// SupplierRMANo (from Table)
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// ReferenceDate (from Table)
		/// </summary>
		public System.DateTime ReferenceDate { get; set; }
		/// <summary>
		/// SupplierInvoice (from Table)
		/// </summary>
		public System.String SupplierInvoice { get; set; }
		/// <summary>
		/// SupplierRMA (from Table)
		/// </summary>
		public System.String SupplierRMA { get; set; }
		/// <summary>
		/// SupplierCredit (from Table)
		/// </summary>
		public System.String SupplierCredit { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_Debit)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// ContactName (from usp_itemsearch_Debit)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// RaiserName (from usp_itemsearch_Debit)
		/// </summary>
		public System.String RaiserName { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int32 PurchaseOrderNumber { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }
		/// <summary>
		/// RowNum (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_Debit)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_Debit)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// BuyerName (from usp_select_Debit)
		/// </summary>
		public System.String BuyerName { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_Debit)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_Debit)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// TaxName (from usp_select_Debit)
		/// </summary>
		public System.String TaxName { get; set; }
		/// <summary>
		/// PurchaseOrderDate (from usp_select_Debit)
		/// </summary>
		public System.DateTime PurchaseOrderDate { get; set; }
		/// <summary>
		/// DebitValue (from usp_select_Debit)
		/// </summary>
		public System.Double? DebitValue { get; set; }
		/// <summary>
		/// TaxRate (from usp_select_Debit)
		/// </summary>
		public System.Double? TaxRate { get; set; }
		/// <summary>
		/// CompanyTelephone (from usp_select_Debit_for_Print)
		/// </summary>
		public System.String CompanyTelephone { get; set; }
		/// <summary>
		/// CompanyFax (from usp_select_Debit_for_Print)
		/// </summary>
		public System.String CompanyFax { get; set; }
		/// <summary>
		/// ContactEmail (from usp_select_Debit_for_Print)
		/// </summary>
		public System.String ContactEmail { get; set; }
        //[001] code start
        /// <summary>
        /// IncotermNo
        /// </summary>
        public System.Int32? IncotermsNo { get; set; }
        /// <summary>
        /// IncotermName
        /// </summary>
        public System.String IncotermsName { get; set; }
        //[001] code end
        //[003] code start
        /// <summary>
        /// SupplierCode (from usp_select_PurchaseOrder_for_Print)
        /// </summary>
        public System.String SupplierCode { get; set; }
        /// <summary>
        /// VATNO (from usp_select_PurchaseOrder_for_Print)
        /// </summary>
        public System.String VATNO { get; set; }
        //[003] code end
        public System.Int32? InternalPurchaseOrderNo { get; set; }
        public System.Int32? InternalPurchaseOrderNumber { get; set; }
        public System.Int32? POHubCompanyNo { get; set; }
        public System.String POHubCompanyName { get; set; }
        public System.Int32? RefNumber { get; set; }
        public System.String ClientRefNo { get; set; }
        public System.Int32? DebitParentId { get; set; }
        public System.Boolean? ishublocked { get; set; }
        public System.String ClientName { get; set; }

        /// <summary>
        /// DebitDetailNumber
        /// </summary>
        // [004] start
        public System.String DebitDetailNumber { get; set; }
        //[004]  end
		#endregion

	}
}