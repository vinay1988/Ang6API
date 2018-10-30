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
	
	public class CreditLineDetails {
		
		#region Constructors
		
		public CreditLineDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CreditLineId (from Table)
		/// </summary>
		public System.Int32 CreditLineId { get; set; }
		/// <summary>
		/// FullPart (from Table)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// Part (from usp_selectAll_Allocation)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// ManufacturerNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// DateCode (from usp_selectAll_Allocation)
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// PackageNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// ProductNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// CreditNo (from Table)
		/// </summary>
		public System.Int32 CreditNo { get; set; }
		/// <summary>
		/// Quantity (from Table)
		/// </summary>
		public System.Int32 Quantity { get; set; }
		/// <summary>
		/// Price (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Double Price { get; set; }
		/// <summary>
		/// Taxable (from Table)
		/// </summary>
		public System.Boolean Taxable { get; set; }
		/// <summary>
		/// CustomerPart (from usp_selectAll_Allocation)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// LandedCost (from usp_selectAll_Allocation)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// InvoiceLineNo (from Table)
		/// </summary>
		public System.Int32? InvoiceLineNo { get; set; }
		/// <summary>
		/// CustomerRMALineNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32? CustomerRMALineNo { get; set; }
		/// <summary>
		/// ROHS (from usp_selectAll_Allocation)
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// ServiceNo (from Table)
		/// </summary>
		public System.Int32? ServiceNo { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// FullCustomerPart (from Table)
		/// </summary>
		public System.String FullCustomerPart { get; set; }
		/// <summary>
		/// CreditId (from Table)
		/// </summary>
		public System.Int32 CreditId { get; set; }
		/// <summary>
		/// CreditNumber (from Table)
		/// </summary>
		public System.Int32 CreditNumber { get; set; }
		/// <summary>
		/// CreditDate (from Table)
		/// </summary>
		public System.DateTime CreditDate { get; set; }
		/// <summary>
		/// CompanyName (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// CustomerRMANumber (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.Int32 CustomerRMANumber { get; set; }
		/// <summary>
		/// CustomerRMANo (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }
		/// <summary>
		/// CustomerPO (from usp_selectAll_Allocation)
		/// </summary>
		public System.String CustomerPO { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_select_Credit)
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// InvoiceNo (from Table)
		/// </summary>
		public System.Int32? InvoiceNo { get; set; }
		/// <summary>
		/// ContactName (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// RowNum (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// LineNotes (from usp_select_CreditLine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// PackageName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_selectAll_Allocation)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// ProductName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// RaiserName (from usp_select_Credit)
		/// </summary>
		public System.String RaiserName { get; set; }
		/// <summary>
		/// SalesmanName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// TeamNo (from Table)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_Credit)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// ReferenceDate (from Table)
		/// </summary>
		public System.DateTime ReferenceDate { get; set; }

        public System.Int32 Ipo { get; set; }
        public System.Int32 ParentCreditLineId { get; set; }

        public System.Int32? ClientInvoiceLineId { get; set; }
        public System.Int32 ParentCreditLineNo { get; set; }
        public System.Int32? ClientInvoiceNumber { get; set; }
        public System.Int32? ClientInvoiceNo { get; set; }
        public System.String DutyCode { get; set; }       
		#endregion

	}
}