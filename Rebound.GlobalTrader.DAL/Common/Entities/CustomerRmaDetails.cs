/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for customerRMA section
[002]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse 
[003]      Aashu Singh     26/06/2018   Save internal log for CRMA
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
	
	public class CustomerRmaDetails {
		
		#region Constructors
		
		public CustomerRmaDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CustomerRMAId (from Table)
		/// </summary>
		public System.Int32 CustomerRMAId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// CustomerRMANumber (from usp_select_Credit)
		/// </summary>
		public System.Int32 CustomerRMANumber { get; set; }
		/// <summary>
		/// InvoiceNo (from Table)
		/// </summary>
		public System.Int32? InvoiceNo { get; set; }
		/// <summary>
		/// AuthorisedBy (from Table)
		/// </summary>
		public System.Int32 AuthorisedBy { get; set; }
		/// <summary>
		/// CustomerRMADate (from usp_select_Credit)
		/// </summary>
		public System.DateTime CustomerRMADate { get; set; }
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
		/// WarehouseNo (from Table)
		/// </summary>
		public System.Int32 WarehouseNo { get; set; }
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
		/// CompanyName (from usp_select_Credit)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// SalesmanName (from usp_select_Credit)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// AuthoriserName (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.String AuthoriserName { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_select_Credit)
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_CustomerRequirement)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_CustomerRequirement)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// WarehouseName (from usp_select_CustomerRMA)
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// ContactName (from usp_select_Credit)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_Credit)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// SalesOrderNo (from usp_select_Credit)
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }
		/// <summary>
		/// SalesOrderNumber (from usp_select_Credit)
		/// </summary>
		public System.Int32 SalesOrderNumber { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// Salesman (from Table)
		/// </summary>
		public System.Int32 Salesman { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_Credit)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_Credit)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// ShipViaName (from usp_select_Credit)
		/// </summary>
		public System.String ShipViaName { get; set; }
		/// <summary>
		/// TaxNo (from Table)
		/// </summary>
		public System.Int32 TaxNo { get; set; }
		/// <summary>
		/// TaxName (from usp_select_Credit)
		/// </summary>
		public System.String TaxName { get; set; }
		/// <summary>
		/// InvoiceDate (from usp_select_Credit)
		/// </summary>
		public System.DateTime InvoiceDate { get; set; }
		/// <summary>
		/// Quantity (from Table)
		/// </summary>
		public System.Int32? Quantity { get; set; }
		/// <summary>
		/// QuantityReceived (from usp_select_CustomerRMA)
		/// </summary>
		public System.Int32? QuantityReceived { get; set; }
		/// <summary>
		/// IncotermName (from usp_select_Credit)
		/// </summary>
		public System.String IncotermName { get; set; }
		/// <summary>
		/// InvoiceCustomerPO (from usp_select_CustomerRMA_for_NewCreditNote)
		/// </summary>
		public System.String InvoiceCustomerPO { get; set; }
		/// <summary>
		/// InvoiceShippingCost (from usp_select_CustomerRMA_for_NewCreditNote)
		/// </summary>
		public System.Double? InvoiceShippingCost { get; set; }
		/// <summary>
		/// InvoiceFreight (from usp_select_CustomerRMA_for_NewCreditNote)
		/// </summary>
		public System.Double? InvoiceFreight { get; set; }
		/// <summary>
		/// Salesman2 (from Table)
		/// </summary>
		public System.Int32? Salesman2 { get; set; }
		/// <summary>
		/// Salesman2Percent (from Table)
		/// </summary>
		public System.Double? Salesman2Percent { get; set; }
		/// <summary>
		/// CompanyTelephone (from usp_select_Credit_for_Print)
		/// </summary>
		public System.String CompanyTelephone { get; set; }
		/// <summary>
		/// CompanyFax (from usp_select_Credit_for_Print)
		/// </summary>
		public System.String CompanyFax { get; set; }
		/// <summary>
		/// CustomerPO (from Table)
		/// </summary>
		public System.String CustomerPO { get; set; }
		/// <summary>
		/// TermsName (from usp_select_CustomerRMA_for_Print)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// ContactEmail (from usp_select_Credit_for_Print)
		/// </summary>
		public System.String ContactEmail { get; set; }
        // [001] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [001] code end
        public System.Int32 TeamNo { get; set; }
        public System.Int32? ClientCustomerRMANo { get; set; }
        public System.Int32? RefNumber { get; set; }
        public System.String ClientName { get; set; }
        public System.Int32? ClientBaseCurrencyID { get; set; }
        public System.String ClientBaseCurrencyCode { get; set; }

        public System.String CustomerRejectionNo { get; set; }

        /// <summary>
        /// CRMANumberDetail (from usp_select_Credit_for_Print)
        /// </summary>
        //[002] start
        public System.String CRMANumberDetail { get; set; }
        //[002] end
        //[003] start
        public System.Int32 CRMAExpediteNotesId { get; set; }
        public System.String EmployeeName { get; set; }
        //[003] end

        #endregion

    }
}