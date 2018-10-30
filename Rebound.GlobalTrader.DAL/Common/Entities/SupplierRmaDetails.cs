/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for supplierRMA section
[002]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse 
[003]      Aashu Singh     26/06/2018   Save internal log for SRMA

*/
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
	
	public class SupplierRmaDetails {
		
		#region Constructors
		
		public SupplierRmaDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SupplierRMAId (from Table)
		/// </summary>
		public System.Int32 SupplierRMAId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Int32 SupplierRMANumber { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from Table)
		/// </summary>
		public System.Int32 PurchaseOrderNo { get; set; }
		/// <summary>
		/// AuthorisedBy (from Table)
		/// </summary>
		public System.Int32 AuthorisedBy { get; set; }
		/// <summary>
		/// SupplierRMADate (from Table)
		/// </summary>
		public System.DateTime SupplierRMADate { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// ShipViaNo (from Table)
		/// </summary>
		public System.Int32? ShipViaNo { get; set; }
		/// <summary>
		/// Account (from Table)
		/// </summary>
		public System.String Account { get; set; }
		/// <summary>
		/// ShipToAddressNo (from Table)
		/// </summary>
		public System.Int32 ShipToAddressNo { get; set; }
		/// <summary>
		/// Reference (from Table)
		/// </summary>
		public System.String Reference { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32? ContactNo { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32 DivisionNo { get; set; }
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
		/// BuyerName (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.String BuyerName { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from Table)
		/// </summary>
		public System.Int32 PurchaseOrderNumber { get; set; }
		/// <summary>
		/// RowNum (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// AuthoriserName (from usp_select_SupplierRMA)
		/// </summary>
		public System.String AuthoriserName { get; set; }
		/// <summary>
		/// ShipViaName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String ShipViaName { get; set; }
		/// <summary>
		/// FullCompanyName (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.String FullCompanyName { get; set; }
		/// <summary>
		/// ContactName (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_SalesOrder)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// CustomerCode (from usp_select_SalesOrder)
		/// </summary>
		public System.String CustomerCode { get; set; }
		/// <summary>
		/// TaxNo (from Table)
		/// </summary>
		public System.Int32 TaxNo { get; set; }
		/// <summary>
		/// TaxName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String TaxName { get; set; }
		/// <summary>
		/// Buyer (from Table)
		/// </summary>
		public System.Int32 Buyer { get; set; }
		/// <summary>
		/// Quantity (from usp_selectAll_SalesOrder_open_for_Login)
		/// </summary>
		public System.Int32? Quantity { get; set; }
		/// <summary>
		/// QuantityShipped (from usp_select_SupplierRMA)
		/// </summary>
		public System.Int32? QuantityShipped { get; set; }
		/// <summary>
		/// IncotermName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String IncotermName { get; set; }
		/// <summary>
		/// CompanyTelephone (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String CompanyTelephone { get; set; }
		/// <summary>
		/// CompanyFax (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String CompanyFax { get; set; }
		/// <summary>
		/// TermsName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// ContactEmail (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String ContactEmail { get; set; }
        // [001] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [001] code end
        public System.String POBuyerName { get; set; }
        public System.Int32? ClientSupplierRMANo { get; set; }
        public System.Int32? InternalPurchaseOrderNo { get; set; }
        public System.Int32? InternalPurchaseOrderNumber { get; set; }
        public System.Int32? POHubCompanyNo { get; set; }
        public System.String POHubCompanyName { get; set; }
        public System.Int32? RefNumber { get; set; }
        public System.Int32? IPOCompanyNo { get; set; }
        public System.Int32? InternalPurchaseOrderId { get; set; }
        public System.String IPOCompanyName { get; set; }
        public System.String ClientRefNo { get; set; }
        public System.Int32 HubShipToAddressNo { get; set; }
        public bool? isLockUpdateClient { get; set; }

        public System.String ClientName { get; set; }
        /// <summary>
        /// SRMANumberDetail
        /// </summary>
        //[002] start
        public System.String SRMANumberDetail { get; set; }
        //[002] end
        //[003] start
        public System.Int32 SRMAExpediteNotesId { get; set; }
        public System.String EmployeeName { get; set; }
        //[003] end
		#endregion

	}
}