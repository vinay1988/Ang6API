
/*
Marker     changed by      date         Remarks
[001]      Pankaj Kumar    05/09/20011  ESMS Ref:13 - Added CompanyRegNo
[002]      Vinay           17/05/2012   This need to add currency notes field
[003]      Vinay           15/10/2012   Upload PDF document for invoices
[004]      Vinay           01/11/2012   Add comma(,) seprated credit notes and CustomerRMA in invoice section
[005]      Vinay           29/11/2012   Apply a bank fee charge to the customers final invoice  
[006]      Aashu           01/06/2018   Quick Jump in Global Warehouse
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
	
	public class InvoiceDetails {
		
		#region Constructors
		
		public InvoiceDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// InvoiceId (from Table)
		/// </summary>
		public System.Int32 InvoiceId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// InvoiceNumber (from Table)
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// SalesOrderNo (from Table)
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }
		/// <summary>
		/// InvoiceDate (from Table)
		/// </summary>
		public System.DateTime InvoiceDate { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// CompanyBillTo (from Table)
		/// </summary>
		public System.String CompanyBillTo { get; set; }
		/// <summary>
		/// CompanyShipTo (from Table)
		/// </summary>
		public System.String CompanyShipTo { get; set; }
		/// <summary>
		/// ShipViaNo (from Table)
		/// </summary>
		public System.Int32 ShipViaNo { get; set; }
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
		/// FreeOnBoard (from Table)
		/// </summary>
		public System.String FreeOnBoard { get; set; }
		/// <summary>
		/// Boxes (from Table)
		/// </summary>
		public System.Int32? Boxes { get; set; }
		/// <summary>
		/// Weight (from Table)
		/// </summary>
		public System.Double? Weight { get; set; }
		/// <summary>
		/// DimensionalWeight (from Table)
		/// </summary>
		public System.Double? DimensionalWeight { get; set; }
		/// <summary>
		/// WeightInPounds (from Table)
		/// </summary>
		public System.Boolean WeightInPounds { get; set; }
		/// <summary>
		/// AirWayBill (from Table)
		/// </summary>
		public System.String AirWayBill { get; set; }
		/// <summary>
		/// ShippedBy (from Table)
		/// </summary>
		public System.Int32? ShippedBy { get; set; }
		/// <summary>
		/// Printed (from Table)
		/// </summary>
		public System.Int32? Printed { get; set; }
		/// <summary>
		/// SupplierRMANo (from Table)
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// ShippingNotes (from Table)
		/// </summary>
		public System.String ShippingNotes { get; set; }
		/// <summary>
		/// Exported (from Table)
		/// </summary>
		public System.Boolean Exported { get; set; }
		/// <summary>
		/// InvoicePaid (from Table)
		/// </summary>
		public System.Boolean InvoicePaid { get; set; }
		/// <summary>
		/// Salesman2 (from Table)
		/// </summary>
		public System.Int32? Salesman2 { get; set; }
		/// <summary>
		/// Salesman2Percent (from Table)
		/// </summary>
		public System.Double Salesman2Percent { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CustomerPO (from Table)
		/// </summary>
		public System.String CustomerPO { get; set; }
		/// <summary>
		/// Salesman (from Table)
		/// </summary>
		public System.Int32? Salesman { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32? ContactNo { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// TermsNo (from Table)
		/// </summary>
		public System.Int32? TermsNo { get; set; }
		/// <summary>
		/// TaxNo (from Table)
		/// </summary>
		public System.Int32? TaxNo { get; set; }
		/// <summary>
		/// ShipToAddressNo (from Table)
		/// </summary>
		public System.Int32? ShipToAddressNo { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// SalesOrderNumber (from Table)
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }
		/// <summary>
		/// DateOrdered (from Table)
		/// </summary>
		public System.DateTime? DateOrdered { get; set; }
		/// <summary>
		/// CofCNotes (from Table)
		/// </summary>
		public System.String CofCNotes { get; set; }
		/// <summary>
		/// BillToAddressNo (from Table)
		/// </summary>
		public System.Int32? BillToAddressNo { get; set; }
		/// <summary>
		/// IncotermNo (from Table)
		/// </summary>
		public System.Int32? IncotermNo { get; set; }
		/// <summary>
		/// DivisionNo2 (from Table)
		/// </summary>
		public System.Int32? DivisionNo2 { get; set; }
		/// <summary>
		/// DateExported (from Table)
		/// </summary>
		public System.DateTime? DateExported { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_Debit)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// SalesmanName (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_Debit)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// RowNum (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }
		/// <summary>
		/// ContactName (from usp_itemsearch_Debit)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// CustomerCode (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.String CustomerCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_Debit)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// Salesman2Name (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.String Salesman2Name { get; set; }
		/// <summary>
		/// TermsName (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// ShippedByName (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.String ShippedByName { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_Debit)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_Debit)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// TaxName (from usp_select_Debit)
		/// </summary>
		public System.String TaxName { get; set; }
		/// <summary>
		/// VATNo (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.String VATNo { get; set; }
		/// <summary>
		/// ShipViaName (from usp_select_GoodsIn)
		/// </summary>
		public System.String ShipViaName { get; set; }
		/// <summary>
		/// InvoiceValue (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.Double? InvoiceValue { get; set; }
		/// <summary>
		/// LandedCostValue (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.Double? LandedCostValue { get; set; }
		/// <summary>
		/// TaxRate (from usp_select_Debit)
		/// </summary>
		public System.Double? TaxRate { get; set; }
		/// <summary>
		/// StatusText (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.String StatusText { get; set; }
		/// <summary>
		/// IncotermName (from usp_datalistnugget_Invoice)
		/// </summary>
		public System.String IncotermName { get; set; }
		/// <summary>
		/// RowCnt (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
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
		/// <summary>
		/// PrintNotes (from usp_select_Invoice_for_Print)
		/// </summary>
		public System.String PrintNotes { get; set; }

        //[001] Code Start
        /// <summary>
        /// CompanyRegNo (from usp_select_Invoice_for_Print)
		/// </summary>
        public System.String CompanyRegNo { get; set; }
        //[001] Code End

        /// <summary>
        /// SalesOrderNo(From tbInvoiceLine) separated by commas
        /// (from usp_select_SalesOrderNos_By_Invoice)
        /// </summary>
        public string SalesOrderNOs { get; set; }

        /// <summary>
        /// SalesOrderNumber(From tbInvoiceLine) separated by commas
        /// (from usp_select_SalesOrderNos_By_Invoice)
        /// </summary>
        public string SalesOrderNumbers { get; set; }

        //[002] code start
        /// <summary>
        /// Currency Notes
        /// </summary>
        public string CurrencyNotes { get; set; }
        //[002] code end
        //[003] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        //[003] code end

        //[004] code start
        public System.String CRMAIds { get; set; }
        public System.String CRMANumbers { get; set; }
        public System.String CreditIds { get; set; }
        public System.String CreditNumbers { get; set; }
        //[004] code end
        //[005] code start
        public System.Double? InvoiceBankFee { get; set; }
        public System.Boolean? IsApplyBankFee { get; set; }
        //[005] code end

        /// <summary>
        /// ExchangeRate(From usp_select_Invoice)
        /// </summary>
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
        /// <summary>
        /// InvoicePaidDate
        /// </summary>
        public System.DateTime? InvoicePaidDate { get; set; }
        /// <summary>
        ///ShipToVatNo
        /// </summary>
        public System.String ShipToVatNo { get; set; }
        /// <summary>
        /// IsSameAsShipCost
        /// </summary>
        public System.Boolean? IsSameAsShipCost { get; set; }
        /// <summary>
        /// ShippingSurchargeValue
        /// </summary>
        public System.Double? ShippingSurchargeValue { get; set; }

        public System.String NotesToInvoice { get; set; }

        public System.String ClientName { get; set; }
        public System.String SerialInvoice { get; set; }
        /// <summary>
        /// InvoiceDetail
        /// </summary>
        public System.String InvoiceDetail { get; set; }	
		#endregion

	}
}