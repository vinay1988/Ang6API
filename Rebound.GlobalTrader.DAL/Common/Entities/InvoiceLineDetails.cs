//Marker     Changed by      Date         Remarks
//[002]      Abhinav         11/03/2014   ESMS#:- 103
//[003]      Vinay           20/11/2014   Transfer SO serial no to invoice
// [004]    Shashi Keshar    16/12/2015   batch Reference for cof
// [005]    Aashu Singh      18-06-2018   [REB-12150]: Traceable, Trusted, Non-preferred - to be printed on the package slip
// [006]    Aashu Singh      10-07-2018   [REB-12593]: Show contract number under notes column.
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
	
	public class InvoiceLineDetails {
		
		#region Constructors
		
		public InvoiceLineDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// InvoiceLineId (from Table)
		/// </summary>
		public System.Int32 InvoiceLineId { get; set; }
		/// <summary>
		/// InvoiceNo (from Table)
		/// </summary>
		public System.Int32 InvoiceNo { get; set; }
		/// <summary>
		/// SalesOrderLineNo (from Table)
		/// </summary>
		public System.Int32? SalesOrderLineNo { get; set; }
		/// <summary>
		/// ShippedBy (from Table)
		/// </summary>
		public System.Int32? ShippedBy { get; set; }
		/// <summary>
		/// ShippedDate (from Table)
		/// </summary>
		public System.DateTime? ShippedDate { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CustomerPart (from Table)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// FullPart (from Table)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// Part (from Table)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// DateCode (from Table)
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// ROHS (from Table)
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// ManufacturerNo (from Table)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// PackageNo (from Table)
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// ProductNo (from Table)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// Taxable (from Table)
		/// </summary>
		public System.String Taxable { get; set; }
		/// <summary>
		/// Quantity (from Table)
		/// </summary>
		public System.Int32? Quantity { get; set; }
		/// <summary>
		/// Price (from Table)
		/// </summary>
		public System.Double? Price { get; set; }
		/// <summary>
		/// DatePromised (from Table)
		/// </summary>
		public System.DateTime? DatePromised { get; set; }
		/// <summary>
		/// RequiredDate (from Table)
		/// </summary>
		public System.DateTime? RequiredDate { get; set; }
		/// <summary>
		/// SalesOrderNo (from Table)
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }
		/// <summary>
		/// ServiceNo (from Table)
		/// </summary>
		public System.Int32? ServiceNo { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// FullCustomerPart (from Table)
		/// </summary>
		public System.String FullCustomerPart { get; set; }
		/// <summary>
		/// InvoiceId (from usp_datalistnugget_InvoiceLine)
		/// </summary>
		public System.Int32 InvoiceId { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_datalistnugget_InvoiceLine)
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_datalistnugget_InvoiceLine)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// InvoiceDate (from usp_datalistnugget_InvoiceLine)
		/// </summary>
		public System.DateTime InvoiceDate { get; set; }
		/// <summary>
		/// CompanyName (from usp_datalistnugget_InvoiceLine)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo (from usp_datalistnugget_InvoiceLine)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// CustomerPO (from usp_datalistnugget_InvoiceLine)
		/// </summary>
		public System.String CustomerPO { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_InvoiceLine)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_InvoiceLine)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// SalesOrderNumber (from usp_itemsearch_InvoiceLine)
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }
		/// <summary>
		/// ClientNo (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// DateOrdered (from usp_select_InvoiceLine)
		/// </summary>
		public System.DateTime? DateOrdered { get; set; }
		/// <summary>
		/// SupplierRMANo (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }
		/// <summary>
		/// SupplierRMALineNo (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32? SupplierRMALineNo { get; set; }
		/// <summary>
		/// SupplierRMADate (from usp_select_InvoiceLine)
		/// </summary>
		public System.DateTime? SupplierRMADate { get; set; }
		/// <summary>
		/// Salesman (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32? Salesman { get; set; }
		/// <summary>
		/// SalesmanName (from usp_select_InvoiceLine)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// DivisionNo (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// ContactNo (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32? ContactNo { get; set; }
		/// <summary>
		/// ContactName (from usp_select_InvoiceLine)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_InvoiceLine)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// ProductName (from usp_select_InvoiceLine)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_select_InvoiceLine)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ProductDutyCode (from usp_select_InvoiceLine)
		/// </summary>
		public System.String ProductDutyCode { get; set; }
		/// <summary>
		/// PackageName (from usp_select_InvoiceLine)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_select_InvoiceLine)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_select_InvoiceLine)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_select_InvoiceLine)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// InvoicePaid (from usp_select_InvoiceLine)
		/// </summary>
		public System.Boolean InvoicePaid { get; set; }
		/// <summary>
		/// QuantityShipped (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32 QuantityShipped { get; set; }
		/// <summary>
		/// LandedCost (from usp_select_InvoiceLine)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// LineSource (from usp_select_InvoiceLine)
		/// </summary>
		public System.String LineSource { get; set; }
		/// <summary>
		/// QuantityOrdered (from usp_select_InvoiceLine)
		/// </summary>
		public System.Int32 QuantityOrdered { get; set; }
		/// <summary>
		/// ShippedByName (from usp_select_InvoiceLine)
		/// </summary>
		public System.String ShippedByName { get; set; }
		/// <summary>
		/// LineNotes (from usp_select_InvoiceLine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// CountryOfManufactureName (from usp_selectAll_InvoiceLine_for_Invoice)
		/// </summary>
		public System.String CountryOfManufactureName { get; set; }

        //[002] start
        /// <summary>
        /// ShipASAP
        /// </summary>
        public System.Boolean ShipASAP { get; set; }

        //[002] end
        //[003] code start
        /// <summary>
        /// SOSerialNo
        /// </summary>
        public System.Int16? SOSerialNo { get; set; }
        //[003] code start

        //[004] code start
        /// <summary>
        /// BatchReference
        /// </summary>
        public System.String BatchReference { get; set; }
        //code end

        public System.String ClientName { get; set; }
        public System.Double? ProductDutyRate { get; set; }
        public System.String SerialLineNos { get; set; }
        public System.String MSLLevel { get; set; }
        //[005] start
        /// <summary>
        /// AS9120
        /// </summary>
        public System.Boolean? AS9120 { get; set; }

        /// ProductSource
        /// </summary>
        public System.Byte? ProductSource { get; set; }
        //[005] end
        //[006] start
        public System.String ContractNo { get; set; }
        //[006] end
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }

		#endregion

	}
}