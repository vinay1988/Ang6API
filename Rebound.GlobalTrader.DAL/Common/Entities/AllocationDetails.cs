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
	
	public class AllocationDetails {
		
		#region Constructors
		
		public AllocationDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// AllocationId (from Table)
		/// </summary>
		public System.Int32 AllocationId { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// SalesOrderLineNo (from Table)
		/// </summary>
		public System.Int32? SalesOrderLineNo { get; set; }
		/// <summary>
		/// QuantityAllocated (from Table)
		/// </summary>
		public System.Int32 QuantityAllocated { get; set; }
		/// <summary>
		/// SupplierRMALineNo (from Table)
		/// </summary>
		public System.Int32? SupplierRMALineNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// SalesmanName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// SupplierRMANo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }
		/// <summary>
		/// Part (from usp_selectAll_Allocation)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// ProductNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// ProductName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ManufacturerNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// PackageNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// PackageName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_selectAll_Allocation)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// DateCode (from usp_selectAll_Allocation)
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// ROHS (from usp_selectAll_Allocation)
		/// </summary>
		public System.Byte ROHS { get; set; }
		/// <summary>
		/// LandedCost (from usp_selectAll_Allocation)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// QuantityInStock (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32 QuantityInStock { get; set; }
		/// <summary>
		/// WarehouseNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? WarehouseNo { get; set; }
		/// <summary>
		/// WarehouseName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }
		/// <summary>
		/// PurchaseOrderLineId (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderLineId { get; set; }
		/// <summary>
		/// BuyPrice (from usp_selectAll_Allocation)
		/// </summary>
		public System.Double? BuyPrice { get; set; }
		/// <summary>
		/// DeliveryDate (from usp_selectAll_Allocation)
		/// </summary>
		public System.DateTime? DeliveryDate { get; set; }
		/// <summary>
		/// BuyCurrencyNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? BuyCurrencyNo { get; set; }
		/// <summary>
		/// BuyCurrencyCode (from usp_selectAll_Allocation)
		/// </summary>
		public System.String BuyCurrencyCode { get; set; }
		/// <summary>
		/// SupplierCompanyNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SupplierCompanyNo { get; set; }
		/// <summary>
		/// SupplierCompanyName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String SupplierCompanyName { get; set; }
		/// <summary>
		/// CustomerCompanyNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? CustomerCompanyNo { get; set; }
		/// <summary>
		/// CustomerCompanyName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String CustomerCompanyName { get; set; }
		/// <summary>
		/// Salesman (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? Salesman { get; set; }
		/// <summary>
		/// SalesOrderNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }
		/// <summary>
		/// SalesOrderNumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }
		/// <summary>
		/// CustomerPO (from usp_selectAll_Allocation)
		/// </summary>
		public System.String CustomerPO { get; set; }
		/// <summary>
		/// SellPrice (from usp_selectAll_Allocation)
		/// </summary>
		public System.Double? SellPrice { get; set; }
		/// <summary>
		/// SellCurrencyNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SellCurrencyNo { get; set; }
		/// <summary>
		/// SellCurrencyCode (from usp_selectAll_Allocation)
		/// </summary>
		public System.String SellCurrencyCode { get; set; }
		/// <summary>
		/// DatePromised (from usp_selectAll_Allocation)
		/// </summary>
		public System.DateTime? DatePromised { get; set; }
		/// <summary>
		/// CustomerPart (from usp_selectAll_Allocation)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// GoodsInLineNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }
		/// <summary>
		/// Shipped (from usp_selectAll_Allocation)
		/// </summary>
		public System.Boolean? Shipped { get; set; }
		/// <summary>
		/// Location (from usp_selectAll_Allocation)
		/// </summary>
		public System.String Location { get; set; }
		/// <summary>
		/// SupplierPart (from usp_selectAll_Allocation)
		/// </summary>
		public System.String SupplierPart { get; set; }
		/// <summary>
		/// CustomerRMALineNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32? CustomerRMALineNo { get; set; }
		/// <summary>
		/// PurchaseOrderLineNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }
		/// <summary>
		/// ReturnDate (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.DateTime? ReturnDate { get; set; }
		/// <summary>
		/// SupplierRMADate (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.DateTime? SupplierRMADate { get; set; }
		/// <summary>
		/// CompanyNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// CompanyName (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// Price (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Double? Price { get; set; }
		/// <summary>
		/// ExpediteDate (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.DateTime? ExpediteDate { get; set; }
		/// <summary>
		/// CustomerRMANo (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }
		/// <summary>
		/// CustomerRMANumber (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }
		/// <summary>
		/// QuantityOnOrder (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.Int32? QuantityOnOrder { get; set; }
        /// <summary>
        /// SOSerialNo
        /// </summary>
        public System.Int16? SOSerialNo { get; set; }
        /// <summary>
        /// POSerialNo
        /// </summary>
        public System.Int16? POSerialNo { get; set; }


        public int? InternalPurchaseOrderId { get; set; }

        public int? InternalPurchaseOrderNo { get; set; }

        public int? IPOSupplier { get; set; }

        public string IPOSupplierName { get; set; }

        /// <summary>
        /// ClientLandedCost (from usp_selectAll_Allocation)
        /// </summary>
        public System.Double? ClientLandedCost { get; set; }

        public System.Boolean? ShipASAP { get; set; }
		#endregion

	}
}