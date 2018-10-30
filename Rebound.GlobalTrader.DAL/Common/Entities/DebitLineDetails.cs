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
	
	public class DebitLineDetails {
		
		#region Constructors
		
		public DebitLineDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// DebitLineId (from Table)
		/// </summary>
		public System.Int32 DebitLineId { get; set; }
		/// <summary>
		/// DebitNo (from Table)
		/// </summary>
		public System.Int32 DebitNo { get; set; }
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
		/// SupplierPart (from usp_selectAll_Allocation)
		/// </summary>
		public System.String SupplierPart { get; set; }
		/// <summary>
		/// LandedCost (from usp_selectAll_Allocation)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// PurchaseOrderLineNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }
		/// <summary>
		/// SupplierRMALineNo (from Table)
		/// </summary>
		public System.Int32? SupplierRMALineNo { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// ROHS (from usp_selectAll_Allocation)
		/// </summary>
		public System.Byte ROHS { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// ServiceNo (from Table)
		/// </summary>
		public System.Int32? ServiceNo { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// FullSupplierPart (from Table)
		/// </summary>
		public System.String FullSupplierPart { get; set; }
		/// <summary>
		/// DebitId (from Table)
		/// </summary>
		public System.Int32 DebitId { get; set; }
		/// <summary>
		/// DebitNumber (from Table)
		/// </summary>
		public System.Int32 DebitNumber { get; set; }
		/// <summary>
		/// DebitDate (from Table)
		/// </summary>
		public System.DateTime DebitDate { get; set; }
		/// <summary>
		/// CompanyName (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32 SupplierRMANumber { get; set; }
		/// <summary>
		/// SupplierRMANo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// SupplierInvoice (from Table)
		/// </summary>
		public System.String SupplierInvoice { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32 PurchaseOrderNumber { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }
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
		/// DivisionNo (from usp_select_Contact)
		/// </summary>
		public System.Int32 DivisionNo { get; set; }
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
		/// LineNotes (from usp_select_CreditLine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// ProductDutyCode (from usp_selectAll_DebitLine_for_Debit)
		/// </summary>
		public System.String ProductDutyCode { get; set; }

        public System.Int32? ParentDebitLineNo { get; set; }
        public System.Int32? IPOCompanyNo { get; set; }
        public System.Int32? InternalPurchaseOrderId { get; set; }
        public System.String IPOCompanyName { get; set; }
        /// <summary>
        /// ClientName
        /// </summary>
        public System.String ClientName { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
		#endregion

	}
}