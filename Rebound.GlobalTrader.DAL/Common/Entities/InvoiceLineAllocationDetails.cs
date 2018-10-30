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
	
	public class InvoiceLineAllocationDetails {
		
		#region Constructors
		
		public InvoiceLineAllocationDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// InvoiceLineAllocationId (from usp_select_CustomerRMALine_for_Receiving)
		/// </summary>
		public System.Int32 InvoiceLineAllocationId { get; set; }
		/// <summary>
		/// InvoiceLineNo (from Table)
		/// </summary>
		public System.Int32 InvoiceLineNo { get; set; }
		/// <summary>
		/// Quantity (from Table)
		/// </summary>
		public System.Int32 Quantity { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// SalesOrderLineNo (from Table)
		/// </summary>
		public System.Int32? SalesOrderLineNo { get; set; }
		/// <summary>
		/// LotNo (from Table)
		/// </summary>
		public System.Int32? LotNo { get; set; }
		/// <summary>
		/// LandedCost (from usp_selectAll_Allocation)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// SupplierRMALineNo (from Table)
		/// </summary>
		public System.Int32? SupplierRMALineNo { get; set; }
		/// <summary>
		/// WarehouseNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? WarehouseNo { get; set; }
		/// <summary>
		/// Location (from usp_selectAll_Allocation)
		/// </summary>
		public System.String Location { get; set; }
		/// <summary>
		/// GoodsInLineNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }
		/// <summary>
		/// PurchaseOrderLineNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }
		/// <summary>
		/// CountryOfManufactureNo (from Table)
		/// </summary>
		public System.Int32? CountryOfManufactureNo { get; set; }
		/// <summary>
		/// CustomerRMAGoodsInLineNo (from Table)
		/// </summary>
		public System.Int32? CustomerRMAGoodsInLineNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// LineNotes (from usp_select_CreditLine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// CountryOfManufactureName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String CountryOfManufactureName { get; set; }
		/// <summary>
		/// LotName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String LotName { get; set; }
		/// <summary>
		/// WarehouseName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// InvoiceNo (from Table)
		/// </summary>
		public System.Int32 InvoiceNo { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32? ClientNo { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_select_Credit)
		/// </summary>
		public System.Int32? InvoiceNumber { get; set; }
		/// <summary>
		/// InvoiceDate (from usp_select_Credit)
		/// </summary>
		public System.DateTime? InvoiceDate { get; set; }
		/// <summary>
		/// SalesOrderNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }
		/// <summary>
		/// Salesman2 (from Table)
		/// </summary>
		public System.Int32? Salesman2 { get; set; }
		/// <summary>
		/// ShippingCost (from Table)
		/// </summary>
		public System.Double? ShippingCost { get; set; }
		/// <summary>
		/// Freight (from Table)
		/// </summary>
		public System.Double? Freight { get; set; }
		/// <summary>
		/// Salesman2Name (from usp_select_Credit)
		/// </summary>
		public System.String Salesman2Name { get; set; }
		/// <summary>
		/// Salesman2Percent (from Table)
		/// </summary>
		public System.Double Salesman2Percent { get; set; }
		/// <summary>
		/// SalesOrderNumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// CompanyNo (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// CompanyName (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// Part (from usp_selectAll_Allocation)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// DateCode (from usp_selectAll_Allocation)
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// SupplierPart (from usp_selectAll_Allocation)
		/// </summary>
		public System.String SupplierPart { get; set; }
		/// <summary>
		/// ProductNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// PackageNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// ManufacturerNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// ROHS (from usp_selectAll_Allocation)
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// GoodsInNo (from Table)
		/// </summary>
		public System.Int32? GoodsInNo { get; set; }
		/// <summary>
		/// GoodsInNumber (from Table)
		/// </summary>
		public System.Int32? GoodsInNumber { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
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
		/// SalesOrderLineId (from usp_select_InvoiceLineAllocation)
		/// </summary>
		public System.Int32? SalesOrderLineId { get; set; }
		/// <summary>
		/// Price (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Double? Price { get; set; }
		/// <summary>
		/// CustomerPart (from usp_selectAll_Allocation)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// SupplierRMANo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }
		/// <summary>
		/// PurchasePrice (from usp_select_InvoiceLineAllocation)
		/// </summary>
		public System.Double? PurchasePrice { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }
		/// <summary>
		/// SupplierNo (from Table)
		/// </summary>
		public System.Int32? SupplierNo { get; set; }
		/// <summary>
		/// PurchaseCurrencyNo (from usp_select_InvoiceLineAllocation)
		/// </summary>
		public System.Int32? PurchaseCurrencyNo { get; set; }
		/// <summary>
		/// PurchaseCurrencyCode (from usp_select_InvoiceLineAllocation)
		/// </summary>
		public System.String PurchaseCurrencyCode { get; set; }
		/// <summary>
		/// SupplierName (from usp_source_Excess)
		/// </summary>
		public System.String SupplierName { get; set; }
		/// <summary>
		/// Salesman (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? Salesman { get; set; }
		/// <summary>
		/// SalesmanName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// Buyer (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.Int32? Buyer { get; set; }
		/// <summary>
		/// BuyerName (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.String BuyerName { get; set; }
		/// <summary>
		/// QuantityAllocatedToCRMA (from usp_select_InvoiceLineAllocation)
		/// </summary>
		public System.Int32? QuantityAllocatedToCRMA { get; set; }
		/// <summary>
		/// QuantityAllocated (from Table)
		/// </summary>
		public System.Int32? QuantityAllocated { get; set; }
        /// SOSerialNo
        /// </summary>
        public System.Int32? SOSerialNo { get; set; }
        /// <summary>
		/// ClientSupplierNo
		/// </summary>
		public System.Int32? ClientSupplierNo { get; set; }
        /// <summary>
		/// ClientSupplierName
		/// </summary>
        public System.String ClientSupplierName { get; set; }
        /// <summary>
        /// ClientLandedCost (from usp_selectAll_Allocation)
        /// </summary>
        public System.Double? ClientLandedCost { get; set; }
        public System.Int32? InternalPurchaseOrderNo { get; set; }
        public System.Int32? InternalPurchaseOrderNumber { get; set; }
		#endregion

	}
}