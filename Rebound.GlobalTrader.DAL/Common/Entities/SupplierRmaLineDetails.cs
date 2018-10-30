//Marker     Changed by      Date         Remarks
//[001]      Vinay           30/07/2012   Add compulsory incoterms field when create Credit and debit note. :ESMS No:- 105
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
	
	public class SupplierRmaLineDetails {
		
		#region Constructors
		
		public SupplierRmaLineDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SupplierRMALineId (from Table)
		/// </summary>
		public System.Int32 SupplierRMALineId { get; set; }
		/// <summary>
		/// SupplierRMANo (from Table)
		/// </summary>
		public System.Int32 SupplierRMANo { get; set; }
		/// <summary>
		/// PurchaseOrderLineNo (from usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine)
		/// </summary>
		public System.Int32 PurchaseOrderLineNo { get; set; }
		/// <summary>
		/// ReturnDate (from Table)
		/// </summary>
		public System.DateTime ReturnDate { get; set; }

        /// <summary>
        /// Reason
        /// </summary>
        public System.String Reason { get; set; }

        /// <summary>
        /// Reason2
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
		/// FullPart (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// Part (from usp_datalistnugget_CustomerRMALine)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// ManufacturerNo (from usp_datalistnugget_CustomerRMALine)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// DateCode (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// PackageNo (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// ProductNo (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// Quantity (from usp_select_CustomerRMA)
		/// </summary>
		public System.Int32 Quantity { get; set; }
		/// <summary>
		/// Reference (from Table)
		/// </summary>
		public System.String Reference { get; set; }
		/// <summary>
		/// ROHS (from usp_datalistnugget_CustomerRMALine)
		/// </summary>
		public System.Byte ROHS { get; set; }
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
		/// SupplierRMAId (from Table)
		/// </summary>
		public System.Int32 SupplierRMAId { get; set; }
		/// <summary>
		/// SupplierRMANumber (from Table)
		/// </summary>
		public System.Int32 SupplierRMANumber { get; set; }
		/// <summary>
		/// SupplierRMADate (from Table)
		/// </summary>
		public System.DateTime SupplierRMADate { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_itemsearch_SupplierRMA)
		/// </summary>
		public System.Int32 PurchaseOrderNumber { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from Table)
		/// </summary>
		public System.Int32 PurchaseOrderNo { get; set; }
		/// <summary>
		/// AllocatedQuantity (from usp_datalistnugget_SupplierRMALine)
		/// </summary>
		public System.Int32 AllocatedQuantity { get; set; }
		/// <summary>
		/// ContactName (from usp_select_CustomerRMA)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32? ContactNo { get; set; }
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
		/// BuyerName (from usp_itemsearch_SupplierRMA)
		/// </summary>
		public System.String BuyerName { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// PurchaseOrderId (from usp_select_SupplierRMALine)
		/// </summary>
		public System.Int32 PurchaseOrderId { get; set; }
		/// <summary>
		/// DateOrdered (from usp_select_SupplierRMALine)
		/// </summary>
		public System.DateTime DateOrdered { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_select_CustomerRMA)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_CustomerRMA)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_CustomerRMA)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// Buyer (from usp_select_SupplierRMA)
		/// </summary>
		public System.Int32 Buyer { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// FullName (from usp_select_SupplierRMALine)
		/// </summary>
		public System.String FullName { get; set; }
		/// <summary>
		/// ProductName (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// PackageName (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// AuthorisedBy (from Table)
		/// </summary>
		public System.Int32 AuthorisedBy { get; set; }
		/// <summary>
		/// AuthoriserName (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.String AuthoriserName { get; set; }
		/// <summary>
		/// QuantityAllocated (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Int32 QuantityAllocated { get; set; }
		/// <summary>
		/// QuantityShipped (from usp_select_SupplierRMA)
		/// </summary>
		public System.Int32 QuantityShipped { get; set; }
		/// <summary>
		/// Price (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Double Price { get; set; }
		/// <summary>
		/// StockNo (from usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// AllocationId (from usp_select_SupplierRMALine)
		/// </summary>
		public System.Int32? AllocationId { get; set; }
		/// <summary>
		/// QuantityInStock (from usp_select_SupplierRMALine)
		/// </summary>
		public System.Int32? QuantityInStock { get; set; }
		/// <summary>
		/// Location (from usp_select_SupplierRMALine)
		/// </summary>
		public System.String Location { get; set; }
		/// <summary>
		/// Taxable (from usp_select_SupplierRMALine)
		/// </summary>
		public System.Boolean Taxable { get; set; }
		/// <summary>
		/// LineNotes (from usp_select_CustomerRMALine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// WarehouseNo (from Table)
		/// </summary>
		public System.Int32? WarehouseNo { get; set; }
		/// <summary>
		/// WarehouseName (from usp_select_CustomerRMA)
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// LotNo (from usp_select_SupplierRMALine_Allocation)
		/// </summary>
		public System.Int32? LotNo { get; set; }
		/// <summary>
		/// LandedCost (from usp_select_CustomerRMALine)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// GoodsInLineNo (from Table)
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }
		/// <summary>
		/// GoodsInNo (from usp_select_SupplierRMALine_Allocation)
		/// </summary>
		public System.Int32? GoodsInNo { get; set; }
		/// <summary>
		/// CountryOfManufacture (from usp_select_SupplierRMALine_Allocation)
		/// </summary>
		public System.Int32? CountryOfManufacture { get; set; }
		/// <summary>
		/// GoodsInNumber (from usp_select_SupplierRMALine_Allocation)
		/// </summary>
		public System.Int32? GoodsInNumber { get; set; }
		/// <summary>
		/// SupplierNo (from usp_select_SupplierRMALine_Allocation)
		/// </summary>
		public System.Int32 SupplierNo { get; set; }
		/// <summary>
		/// SupplierName (from usp_select_SupplierRMALine_Allocation)
		/// </summary>
		public System.String SupplierName { get; set; }
		/// <summary>
		/// PurchaseOrderLineId (from usp_select_SupplierRMALine_Allocation)
		/// </summary>
		public System.Int32 PurchaseOrderLineId { get; set; }
		/// <summary>
		/// DeliveryDate (from usp_select_SupplierRMALine_Allocation)
		/// </summary>
		public System.DateTime DeliveryDate { get; set; }
		/// <summary>
		/// PurchasePrice (from usp_select_SupplierRMALine_Allocation)
		/// </summary>
		public System.Double PurchasePrice { get; set; }
		/// <summary>
		/// ShipViaName (from usp_selectAll_SupplierRMALine_from_GoodsInLine_for_Docket)
		/// </summary>
		public System.String ShipViaName { get; set; }
        //[0001] code start
        /// <summary>
        /// ShippingNotes (from [usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket])
        /// </summary>
        public System.String ShippingNotes { get; set; }
        //[0001] code end
        //[001] code start
        /// <summary>
        /// SRMAIncotermsNo
        /// </summary>
        public System.Int32? SRMAIncotermsNo { get; set; }
        //[001] code end
        /// <summary>
        /// Reason
        /// </summary>
        public System.String Reason1 { get; set; }
        /// <summary>
        /// Root Cause
        /// </summary>
        public System.String RootCause { get; set; }
        /// <summary>
        /// POSerialNo
        /// </summary>
        public System.Int16? POSerialNo { get; set; }

        public System.Int32? ParentSRMALineNo { get; set; }

        public System.Int32? IPOCompanyNo { get; set; }
        public System.Int32? InternalPurchaseOrderId { get; set; }
        public System.String IPOCompanyName { get; set; }
        public System.String ClientName { get; set; }
        public System.Boolean Avoidable { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }

		#endregion

	}
}