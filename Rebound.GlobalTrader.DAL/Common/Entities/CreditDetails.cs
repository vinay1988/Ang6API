/*
Marker     Changed by      Date         Remarks
[002]      Abhinav         06/11/2013   Add VATNO, CuostmerCode in Print document
 * 
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
	
	public class CreditDetails {
		
		#region Constructors
		
		public CreditDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CreditId (from Table)
		/// </summary>
		public System.Int32 CreditId { get; set; }
		/// <summary>
		/// CreditNumber (from Table)
		/// </summary>
		public System.Int32 CreditNumber { get; set; }
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
		/// CreditDate (from Table)
		/// </summary>
		public System.DateTime CreditDate { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// RaisedBy (from Table)
		/// </summary>
		public System.Int32? RaisedBy { get; set; }
		/// <summary>
		/// Salesman (from Table)
		/// </summary>
		public System.Int32 Salesman { get; set; }
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
		/// ShippingCost (from Table)
		/// </summary>
		public System.Double? ShippingCost { get; set; }
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
		/// InvoiceNo (from Table)
		/// </summary>
		public System.Int32? InvoiceNo { get; set; }
		/// <summary>
		/// CustomerRMANo (from Table)
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }
		/// <summary>
		/// ReferenceDate (from Table)
		/// </summary>
		public System.DateTime ReferenceDate { get; set; }
		/// <summary>
		/// CustomerPO (from Table)
		/// </summary>
		public System.String CustomerPO { get; set; }
		/// <summary>
		/// CustomerRMA (from Table)
		/// </summary>
		public System.String CustomerRMA { get; set; }
		/// <summary>
		/// CustomerDebit (from Table)
		/// </summary>
		public System.String CustomerDebit { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// Salesman2 (from Table)
		/// </summary>
		public System.Int32? Salesman2 { get; set; }
		/// <summary>
		/// Salesman2Percent (from Table)
		/// </summary>
		public System.Double Salesman2Percent { get; set; }
		/// <summary>
		/// IncotermNo (from Table)
		/// </summary>
		public System.Int32? IncotermNo { get; set; }
		/// <summary>
		/// DivisionNo2 (from Table)
		/// </summary>
		public System.Int32? DivisionNo2 { get; set; }
		/// <summary>
		/// CompanyName (from usp_select_Credit)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CustomerCode (from usp_select_Credit)
		/// </summary>
		public System.String CustomerCode { get; set; }
		/// <summary>
		/// ContactName (from usp_select_Credit)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_Credit)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_Credit)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// RaiserName (from usp_select_Credit)
		/// </summary>
		public System.String RaiserName { get; set; }
		/// <summary>
		/// SalesmanName (from usp_select_Credit)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_Credit)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_Credit)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// Salesman2Name (from usp_select_Credit)
		/// </summary>
		public System.String Salesman2Name { get; set; }
		/// <summary>
		/// TaxName (from usp_select_Credit)
		/// </summary>
		public System.String TaxName { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_select_Credit)
		/// </summary>
		public System.Int32? InvoiceNumber { get; set; }
		/// <summary>
		/// InvoiceDate (from usp_select_Credit)
		/// </summary>
		public System.DateTime? InvoiceDate { get; set; }
		/// <summary>
		/// SalesOrderNo (from usp_select_Credit)
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }
		/// <summary>
		/// SalesOrderNumber (from usp_select_Credit)
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }
		/// <summary>
		/// CustomerRMANumber (from usp_select_Credit)
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }
		/// <summary>
		/// CustomerRMADate (from usp_select_Credit)
		/// </summary>
		public System.DateTime? CustomerRMADate { get; set; }
		/// <summary>
		/// ShipViaName (from usp_select_Credit)
		/// </summary>
		public System.String ShipViaName { get; set; }
		/// <summary>
		/// CreditValue (from usp_select_Credit)
		/// </summary>
		public System.Double? CreditValue { get; set; }
		/// <summary>
		/// CreditCost (from usp_select_Credit)
		/// </summary>
		public System.Double? CreditCost { get; set; }
		/// <summary>
		/// TaxRate (from usp_select_Credit)
		/// </summary>
		public System.Double? TaxRate { get; set; }
		/// <summary>
		/// IncotermName (from usp_select_Credit)
		/// </summary>
		public System.String IncotermName { get; set; }
		/// <summary>
		/// CompanyTelephone (from usp_select_Credit_for_Print)
		/// </summary>
		public System.String CompanyTelephone { get; set; }
		/// <summary>
		/// CompanyFax (from usp_select_Credit_for_Print)
		/// </summary>
		public System.String CompanyFax { get; set; }
		/// <summary>
		/// ContactEmail (from usp_select_Credit_for_Print)
		/// </summary>
		public System.String ContactEmail { get; set; }
        //[001] start code
        /// </summary>
        public System.Double? CreditNoteBankFee { get; set; }
		/// <summary>
        //[001] end code
        //[001] start code
         /// <summary>
        /// VATNO (from usp_select_PurchaseOrder_for_Print)
        /// </summary>
        public System.String VATNO { get; set; }
        //[001] end code
        public System.Int32? RefNumber { get; set; }
        public int? ClientCreditNo { get; set; }
        public System.Boolean isClientInvoice { get; set; }
        public System.Int32? RefClientNo { get; set; }
        public System.String RefClientName { get; set; }
        public System.Int32? ClientInvoiceNo { get; set; }
        public System.Int32? ClientInvoiceNumber { get; set; }


        public System.String ClientShipTo { get; set; }
        public System.String Telephone { get; set; }
        public System.String Fax { get; set; }
        public System.String ClientCustomerCode { get; set; }
        public System.String Email { get; set; }
        public System.String VAT { get; set; }
        public System.String Tax { get; set; }
        public System.String ClientBillToAdr { get; set; }
        public System.Int32? ClientInvoiceLineNo { get; set; }
        public Boolean isExport { get; set; }
        public System.Double? ExchangeRate { get; set; }
        /// <summary>
        /// LocalCurrencyNo
        /// </summary>
        public System.Int32? LocalCurrencyNo { get; set; }
        /// <summary>
        /// ApplyLocalCurrency
        /// </summary>
        public System.Boolean? ApplyLocalCurrency { get; set; }
        /// <summary>
        /// LocalCurrencyCode
        /// </summary>
        public System.String LocalCurrencyCode { get; set; }

		#endregion

	}
}