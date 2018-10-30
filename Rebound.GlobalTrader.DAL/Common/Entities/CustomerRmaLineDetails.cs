
/*

Marker     changed by      date         Remarks

[001]      Abhinav       17/11/20011   ESMS Ref:25 & 34  - Virtual Stock Update & Closeing of line CRMA

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
	
	public class CustomerRmaLineDetails {
		
		#region Constructors
		
		public CustomerRmaLineDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CustomerRMALineId (from Table)
		/// </summary>
		public System.Int32 CustomerRMALineId { get; set; }
		/// <summary>
		/// CustomerRMANo (from Table)
		/// </summary>
		public System.Int32 CustomerRMANo { get; set; }
		/// <summary>
		/// InvoiceLineNo (from Table)
		/// </summary>
		public System.Int32 InvoiceLineNo { get; set; }
		/// <summary>
		/// ReturnDate (from Table)
		/// </summary>
		public System.DateTime? ReturnDate { get; set; }
		/// <summary>
		/// Reason (from Table)
		/// </summary>
		public System.String Reason { get; set; }

        /// <summary>
        /// Reason1 (from Table)
        /// </summary>
        public System.String Reason1 { get; set; }

        /// <summary>
        /// Reason2 (from Table)
        /// </summary>
        public System.String Reason2 { get; set; }

        /// <summary>
        /// Reason1 Value
        /// </summary>
        public System.String Reason1Val { get; set; }

        /// <summary>
        /// Reason2 Value
        /// </summary>
        public System.String Reason2Val { get; set; }
        
		/// <summary>
		/// Quantity (from usp_select_CustomerRMA)
		/// </summary>
		public System.Int32? Quantity { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CustomerRMAId (from Table)
		/// </summary>
		public System.Int32 CustomerRMAId { get; set; }
		/// <summary>
		/// CustomerRMANumber (from Table)
		/// </summary>
		public System.Int32 CustomerRMANumber { get; set; }
		/// <summary>
		/// CustomerRMADate (from Table)
		/// </summary>
		public System.DateTime CustomerRMADate { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// InvoiceNo (from Table)
		/// </summary>
		public System.Int32? InvoiceNo { get; set; }
		/// <summary>
		/// ROHS (from usp_datalistnugget_CustomerRMALine)
		/// </summary>
		public System.Byte ROHS { get; set; }
		/// <summary>
		/// Part (from usp_datalistnugget_CustomerRMALine)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// ContactName (from usp_select_CustomerRMA)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32? ContactNo { get; set; }
		/// <summary>
		/// ManufacturerNo (from usp_datalistnugget_CustomerRMALine)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_datalistnugget_CustomerRMALine)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// RowNum (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// QuantityReceived (from usp_select_CustomerRMA)
		/// </summary>
		public System.Int32? QuantityReceived { get; set; }
		/// <summary>
		/// SalesmanName (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// InvoiceDate (from usp_select_CustomerRMA)
		/// </summary>
		public System.DateTime InvoiceDate { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_select_CustomerRMA)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// Salesman (from usp_select_CustomerRMA)
		/// </summary>
		public System.Int32 Salesman { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// QuantityAllocated (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Int32? QuantityAllocated { get; set; }
		/// <summary>
		/// ProductNo (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// ProductName (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ProductDutyCode (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String ProductDutyCode { get; set; }
		/// <summary>
		/// FullPart (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// CustomerPart (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// PackageNo (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// DateCode (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// PackageName (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// Price (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Double? Price { get; set; }
		/// <summary>
		/// LandedCost (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// LineNotes (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// InvoiceLineAllocationId (from usp_select_CustomerRMALine_for_Receiving)
		/// </summary>
		public System.Int32 InvoiceLineAllocationId { get; set; }

        // [001] code start
        /// Closed (from Table)
        /// </summary>
        public System.Boolean Closed { get; set; }
        /// <summary>
       /// Shipped Quantity (from usp_select_CustomerRMA)
        /// </summary>
        public System.Int32? QuantityShipped { get; set; }
        /// <summary>
        /// CRMA Quantity (from usp_select_CustomerRMA)
        /// </summary>
        public System.Int32? QuantityCRMA { get; set; }

        /// <summary>
        /// Available Qty for CRMA to add(from usp_select_CustomerRMA)
        /// </summary>
        public System.Int32? QuantityAvailable { get; set; }
        // [001] code end 

        /// <summary>
        /// Stock Id from tbStock
        /// </summary>
        public System.Int32? StockNo { get; set; }

        /// <summary>
        /// CreditIds
        /// </summary>
        public System.String CreditIds { get; set; }
        /// <summary>
        /// CreditNumbers
        /// </summary>
        public System.String CreditNumbers { get; set; }

        /// <summary>
        /// Root Cause
        /// </summary>
        public System.String RootCause { get; set; }

        public System.Int32? ParentCustomerRMALineNo { get; set; }

        public System.String ClientName { get; set; }
        public System.Boolean Avoidable { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
		#endregion

	}
}