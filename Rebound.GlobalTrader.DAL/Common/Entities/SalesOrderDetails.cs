/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for sales order section
[002]      Vinay           23/05/2012   This need to add currency notes
[003]      Abhinav         15/01/2013   Add Bank Fee Term
[004]      Pankaj          10/09/2013   Add property IsSORPDFAvailable
[005]      Vinay           22/01/2014   CR:- Add AS9120 Requirement in GT application
[006]      Aashu Singh     03/07/2018   Add customer order value nugget on broker and sales tab
[007]      Aashu Singh      01/06/2018   Quick Jump in Global Warehouse 
[008]      Aashu Singh      22-Aug-2018  REB-12161:credit card payments
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
	
	public class SalesOrderDetails {
		
		#region Constructors
		
		public SalesOrderDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SalesOrderId (from Table)
		/// </summary>
		public System.Int32 SalesOrderId { get; set; }
		/// <summary>
		/// SalesOrderNumber (from Table)
		/// </summary>
		public System.Int32 SalesOrderNumber { get; set; }
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
		/// DateOrdered (from Table)
		/// </summary>
		public System.DateTime DateOrdered { get; set; }
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
		public System.Int32 TermsNo { get; set; }
		/// <summary>
		/// ShipToAddressNo (from Table)
		/// </summary>
		public System.Int32? ShipToAddressNo { get; set; }
		/// <summary>
		/// ShipViaNo (from Table)
		/// </summary>
		public System.Int32? ShipViaNo { get; set; }
		/// <summary>
		/// Account (from Table)
		/// </summary>
		public System.String Account { get; set; }
		/// <summary>
		/// Freight (from Table)
		/// </summary>
		public System.Double Freight { get; set; }
		/// <summary>
		/// CustomerPO (from Table)
		/// </summary>
		public System.String CustomerPO { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32 DivisionNo { get; set; }
		/// <summary>
		/// TaxNo (from Table)
		/// </summary>
		public System.Int32 TaxNo { get; set; }
		/// <summary>
		/// ShippingCost (from Table)
		/// </summary>
		public System.Double? ShippingCost { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// Paid (from Table)
		/// </summary>
		public System.Boolean Paid { get; set; }
		/// <summary>
		/// StatusNo (from Table)
		/// </summary>
		public System.Int32? StatusNo { get; set; }
		/// <summary>
		/// Closed (from Table)
		/// </summary>
		public System.Boolean Closed { get; set; }
		/// <summary>
		/// SaleTypeNo (from Table)
		/// </summary>
		public System.Int32? SaleTypeNo { get; set; }
		/// <summary>
		/// Salesman2 (from Table)
		/// </summary>
		public System.Int32? Salesman2 { get; set; }
		/// <summary>
		/// Salesman2Percent (from Table)
		/// </summary>
		public System.Double Salesman2Percent { get; set; }
		/// <summary>
		/// AuthorisedBy (from Table)
		/// </summary>
		public System.Int32? AuthorisedBy { get; set; }
		/// <summary>
		/// DateAuthorised (from Table)
		/// </summary>
		public System.DateTime? DateAuthorised { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CurrencyDate (from Table)
		/// </summary>
		public System.DateTime? CurrencyDate { get; set; }
		/// <summary>
		/// IncotermNo (from Table)
		/// </summary>
		public System.Int32? IncotermNo { get; set; }
		/// <summary>
		/// CreatedBy (from Table)
		/// </summary>
		public System.Int32? CreatedBy { get; set; }
		/// <summary>
		/// CreateDate (from Table)
		/// </summary>
		public System.DateTime? CreateDate { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// ContactName (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// SalesmanName (from usp_select_Quote)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// RowNum (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// ShippingCharge (from usp_select_SalesOrder)
		/// </summary>
		public System.Boolean? ShippingCharge { get; set; }
		/// <summary>
		/// CreditLimit (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.Double CreditLimit { get; set; }
		/// <summary>
		/// Balance (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.Double Balance { get; set; }
		/// <summary>
		/// CustomerCode (from usp_select_SalesOrder)
		/// </summary>
		public System.String CustomerCode { get; set; }
		/// <summary>
		/// VATNo (from usp_select_SalesOrder)
		/// </summary>
		public System.String VATNo { get; set; }
		/// <summary>
		/// SOCurrencyNo (from usp_select_SalesOrder)
		/// </summary>
		public System.Int32 SOCurrencyNo { get; set; }
		/// <summary>
		/// SOCurrencyCode (from usp_select_SalesOrder)
		/// </summary>
		public System.String SOCurrencyCode { get; set; }
		/// <summary>
		/// SOCurrencyDescription (from usp_select_SalesOrder)
		/// </summary>
		public System.String SOCurrencyDescription { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// Salesman2Name (from usp_select_SalesOrder)
		/// </summary>
		public System.String Salesman2Name { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_SalesOrder)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// Team2No (from usp_select_SalesOrder)
		/// </summary>
		public System.Int32? Team2No { get; set; }
		/// <summary>
		/// TermsName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// InAdvance (from usp_select_SalesOrder)
		/// </summary>
		public System.Boolean? InAdvance { get; set; }
		/// <summary>
		/// ShipViaName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String ShipViaName { get; set; }
		/// <summary>
		/// PickUp (from usp_select_SalesOrder)
		/// </summary>
		public System.String PickUp { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// TaxName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String TaxName { get; set; }
		/// <summary>
		/// TaxRate (from usp_select_PurchaseOrder)
		/// </summary>
		public System.Double? TaxRate { get; set; }
		/// <summary>
		/// Authoriser (from usp_select_SalesOrder)
		/// </summary>
		public System.String Authoriser { get; set; }
		/// <summary>
		/// CompanyOnStop (from usp_select_Quote)
		/// </summary>
		public System.Boolean? CompanyOnStop { get; set; }
		/// <summary>
		/// IncotermName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String IncotermName { get; set; }
		/// <summary>
		/// LineSubTotal (from usp_select_SalesOrder)
		/// </summary>
		public System.Double? LineSubTotal { get; set; }
		/// <summary>
		/// TotalTax (from usp_select_SalesOrder)
		/// </summary>
		public System.Double? TotalTax { get; set; }
		/// <summary>
		/// TotalValue (from usp_select_SalesOrder)
		/// </summary>
		public System.Double? TotalValue { get; set; }
		/// <summary>
		/// CompanyTelephone (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String CompanyTelephone { get; set; }
		/// <summary>
		/// CompanyFax (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String CompanyFax { get; set; }
		/// <summary>
		/// ContactEmail (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String ContactEmail { get; set; }
		/// <summary>
		/// SalesOrderValue (from usp_select_SalesOrder_ValueSummary)
		/// </summary>
		public System.Double? SalesOrderValue { get; set; }
		/// <summary>
		/// SalesOrderValueIncFreight (from usp_select_SalesOrder_ValueSummary)
		/// </summary>
		public System.Double? SalesOrderValueIncFreight { get; set; }
		/// <summary>
		/// CompanyId (from usp_selectAll_SalesOrder_open_for_Login)
		/// </summary>
		public System.Int32 CompanyId { get; set; }
		/// <summary>
		/// Quantity (from usp_selectAll_SalesOrder_open_for_Login)
		/// </summary>
		public System.Int32 Quantity { get; set; }
		/// <summary>
		/// QuantityAllocated (from usp_selectAll_SalesOrder_open_for_Login)
		/// </summary>
		public System.Int32 QuantityAllocated { get; set; }
		/// <summary>
		/// DatePromised (from usp_selectAll_SalesOrder_open_for_Login)
		/// </summary>
		public System.DateTime DatePromised { get; set; }
		/// <summary>
		/// DaysOverdue (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.Int32? DaysOverdue { get; set; }
		/// <summary>
		/// InvoiceId (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Int32 InvoiceId { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// InvoiceLineId (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Int32? InvoiceLineId { get; set; }
		/// <summary>
		/// InvoiceDate (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.DateTime InvoiceDate { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }
		/// <summary>
		/// SalesOrderNo (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }
		/// <summary>
		/// SalesOrderLineNo (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Int32? SalesOrderLineNo { get; set; }
		/// <summary>
		/// FullCompanyName (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.String FullCompanyName { get; set; }
		/// <summary>
		/// Price (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Double? Price { get; set; }
		/// <summary>
		/// FullPart (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// FullCustomerPart (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.String FullCustomerPart { get; set; }
		/// <summary>
		/// Part (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// ROHS (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Byte ROHS { get; set; }
		/// <summary>
		/// CustomerPart (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// DateCode (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// InvoicePaid (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Boolean InvoicePaid { get; set; }
		/// <summary>
		/// Inactive (from usp_selectAll_SalesOrder_shipped_recently_for_Login)
		/// </summary>
		public System.Boolean? Inactive { get; set; }

        /// <summary>
        /// Company registration no (from usp_select_SalesOrder_for_Print)
        /// </summary>
        public System.String CompanyRegNo { get; set; }
        // [001] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [001] code end

        //[002] code start
        public System.String CurrencyNotes { get; set; }
        //[002] code end

        //[003] code start
        public System.Double? InvoiceBankFee { get; set; }
        public System.Boolean? IsApplyBankFee { get; set; }
        //[003] code end        

        //[004] code start
        /// <summary>
        /// IsSORPDFAvailable
        /// </summary>
        public System.Boolean? IsSORPDFAvailable { get; set; }
        // [004] code end
        //[005] code start
        /// <summary>
        /// AS9120
        /// </summary>
        public System.Boolean? AS9120 { get; set; }
        //[005] code end
        /// <summary>
        /// CompanyType
        /// </summary>
        public System.String CompanyType { get; set; }
        /// <summary>
        /// Traceability
        /// </summary>
        public System.Boolean? Traceability { get; set; }
        /// <summary>
        /// IsSameAsShipCost
        /// </summary>
        public System.Boolean? IsSameAsShipCost { get; set; }

        public bool IsFromIPO { get; set; }
        public int IpoCount { get; set; }
        /// <summary>
        /// IsAgency
        /// </summary>
        public System.Boolean? IsAgency { get; set; }
        /// <summary>
        /// UKAuthorisedBy
        /// </summary>
        public System.Int32? UKAuthorisedBy { get; set; }
        /// <summary>
        /// UKAuthorisedDate
        /// </summary>
        public System.DateTime? UKAuthorisedDate { get; set; }
        /// <summary>
        /// UKAuthoriserName
        /// </summary>
        public System.String UKAuthoriserName { get; set; }
        /// <summary>
        /// IsCurrencyInSameFaimly
        /// </summary>
        public System.Boolean? IsCurrencyInSameFaimly { get; set; }

        public System.String ConsolidateStatus { get; set; }

        public System.Boolean? IsConsolidated { get; set; }

        public System.String ClientName { get; set; }

        public System.Int32? SentOrder { get; set; }
        public System.Double? ActualCreditLimit { get; set; }
        /// <summary>
        /// SalesOrderNumberDetail
        /// </summary>
        //[006] start
        public System.String SalesOrderNumberDetail { get; set; }
        //[006] end
        //[006] start
        public System.Double? AvailableCreditLimit { get; set; }
        public System.String RowCSS { get; set; }
        //[008] start
        public System.Boolean IsPaidByCreditCard { get; set; }
        //[008] end
		#endregion

	}
}
