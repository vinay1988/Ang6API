using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class AllocationProvider : DataAccess {
		static private AllocationProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public AllocationProvider Instance {
			get {
				if (_instance == null) _instance = (AllocationProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Allocations.ProviderType));
				return _instance;
			}
		}
		public AllocationProvider() {
			this.ConnectionString = Globals.Settings.Allocations.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Allocation]
		/// </summary>
		public abstract bool Delete(System.Int32? allocationId, System.Int32? updatedBy);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Allocation]
		/// </summary>
        public abstract Int32 Insert(System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy, System.Boolean? createSONonIPO);
        /// <summary>
        /// Insert
        /// Calls [usp_insert_AllocationExt]
        /// </summary>
        public abstract Int32 InsertNew(System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy, System.Boolean? updateSOIsIPO);

        /// <summary>
        /// Insert
        /// Calls [usp_insert_IPOAllocation]
        /// </summary>
        public abstract Int32 InsertIPO(System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy,System.Boolean? createSONonIPO);

		/// <summary>
		/// Get
		/// Calls [usp_select_Allocation]
		/// </summary>
		public abstract AllocationDetails Get(System.Int32? allocationId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Allocation]
		/// </summary>
		public abstract List<AllocationDetails> GetList();
		/// <summary>
		/// GetListForCustomerRMALine
		/// Calls [usp_selectAll_Allocation_for_CustomerRMALine]
		/// </summary>
		public abstract List<AllocationDetails> GetListForCustomerRMALine(System.Int32? customerRmaLineId);
		/// <summary>
		/// GetListForGoodsInLine
		/// Calls [usp_selectAll_Allocation_for_GoodsInLine]
		/// </summary>
		public abstract List<AllocationDetails> GetListForGoodsInLine(System.Int32? goodsInLineId);
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_Allocation_for_PurchaseOrderLine]
		/// </summary>
		public abstract List<AllocationDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// GetListForSalesOrderLine
		/// Calls [usp_selectAll_Allocation_for_SalesOrderLine]
		/// </summary>
		public abstract List<AllocationDetails> GetListForSalesOrderLine(System.Int32? salesOrderLineId);
		/// <summary>
		/// GetListForStock
		/// Calls [usp_selectAll_Allocation_for_Stock]
		/// </summary>
		public abstract List<AllocationDetails> GetListForStock(System.Int32? stockId);
		/// <summary>
		/// GetListForSupplierRMALine
		/// Calls [usp_selectAll_Allocation_for_SupplierRMALine]
		/// </summary>
		public abstract List<AllocationDetails> GetListForSupplierRMALine(System.Int32? supplierRmaLineId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Allocation]
		/// </summary>
		public abstract bool Update(System.Int32? allocationId, System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy);
		/// <summary>
		/// UpdateAfterIncreaseGIQuantity
		/// Calls [usp_update_Allocation_AfterIncreaseGIQuantity]
		/// </summary>
		public abstract bool UpdateAfterIncreaseGIQuantity(System.Int32? goodsInLineNo, System.Int32? oldQuantity, System.Int32? newQuantity, System.Int32? updatedBy);
		/// <summary>
		/// UpdateAfterPartialReceive
		/// Calls [usp_Update_Allocation_AfterPartialReceive]
		/// </summary>
		public abstract bool UpdateAfterPartialReceive(System.Int32? goodsInLineNo, System.Int32? goodsInNo, System.Int32? quantityInserted, System.Int32? quantityOnOrderChange, System.Int32? updatedBy);
		/// <summary>
		/// UpdateCleanUp
		/// Calls [usp_update_Allocation_CleanUp]
		/// </summary>
		public abstract bool UpdateCleanUp();

		#endregion
				
		/// <summary>
		/// Returns a new AllocationDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual AllocationDetails GetAllocationFromReader(DbDataReader reader) {
			AllocationDetails allocation = new AllocationDetails();
			if (reader.HasRows) {
				allocation.AllocationId = GetReaderValue_Int32(reader, "AllocationId", 0); //From: [Table]
				allocation.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [Table]
				allocation.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null); //From: [Table]
				allocation.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0); //From: [Table]
				allocation.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null); //From: [Table]
				allocation.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				allocation.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				allocation.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_selectAll_Allocation]
				allocation.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null); //From: [usp_selectAll_Allocation]
				allocation.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null); //From: [usp_selectAll_Allocation]
				allocation.Part = GetReaderValue_String(reader, "Part", ""); //From: [usp_selectAll_Allocation]
				allocation.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [usp_selectAll_Allocation]
				allocation.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_selectAll_Allocation]
				allocation.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_selectAll_Allocation]
				allocation.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [usp_selectAll_Allocation]
				allocation.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_selectAll_Allocation]
				allocation.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_selectAll_Allocation]
				allocation.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [usp_selectAll_Allocation]
				allocation.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_selectAll_Allocation]
				allocation.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_selectAll_Allocation]
				allocation.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [usp_selectAll_Allocation]
				allocation.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [usp_selectAll_Allocation]
				allocation.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [usp_selectAll_Allocation]
				allocation.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0); //From: [usp_selectAll_Allocation]
				allocation.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null); //From: [usp_selectAll_Allocation]
				allocation.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [usp_selectAll_Allocation]
				allocation.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null); //From: [usp_selectAll_Allocation]
				allocation.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null); //From: [usp_selectAll_Allocation]
				allocation.PurchaseOrderLineId = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineId", null); //From: [usp_selectAll_Allocation]
				allocation.BuyPrice = GetReaderValue_NullableDouble(reader, "BuyPrice", null); //From: [usp_selectAll_Allocation]
				allocation.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null); //From: [usp_selectAll_Allocation]
				allocation.BuyCurrencyNo = GetReaderValue_NullableInt32(reader, "BuyCurrencyNo", null); //From: [usp_selectAll_Allocation]
				allocation.BuyCurrencyCode = GetReaderValue_String(reader, "BuyCurrencyCode", ""); //From: [usp_selectAll_Allocation]
				allocation.SupplierCompanyNo = GetReaderValue_NullableInt32(reader, "SupplierCompanyNo", null); //From: [usp_selectAll_Allocation]
				allocation.SupplierCompanyName = GetReaderValue_String(reader, "SupplierCompanyName", ""); //From: [usp_selectAll_Allocation]
				allocation.CustomerCompanyNo = GetReaderValue_NullableInt32(reader, "CustomerCompanyNo", null); //From: [usp_selectAll_Allocation]
				allocation.CustomerCompanyName = GetReaderValue_String(reader, "CustomerCompanyName", ""); //From: [usp_selectAll_Allocation]
				allocation.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null); //From: [usp_selectAll_Allocation]
				allocation.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null); //From: [usp_selectAll_Allocation]
				allocation.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null); //From: [usp_selectAll_Allocation]
				allocation.CustomerPO = GetReaderValue_String(reader, "CustomerPO", ""); //From: [usp_selectAll_Allocation]
				allocation.SellPrice = GetReaderValue_NullableDouble(reader, "SellPrice", null); //From: [usp_selectAll_Allocation]
				allocation.SellCurrencyNo = GetReaderValue_NullableInt32(reader, "SellCurrencyNo", null); //From: [usp_selectAll_Allocation]
				allocation.SellCurrencyCode = GetReaderValue_String(reader, "SellCurrencyCode", ""); //From: [usp_selectAll_Allocation]
				allocation.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null); //From: [usp_selectAll_Allocation]
				allocation.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [usp_selectAll_Allocation]
				allocation.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null); //From: [usp_selectAll_Allocation]
				allocation.Shipped = GetReaderValue_NullableBoolean(reader, "Shipped", null); //From: [usp_selectAll_Allocation]
				allocation.Location = GetReaderValue_String(reader, "Location", ""); //From: [usp_selectAll_Allocation]
				allocation.SupplierPart = GetReaderValue_String(reader, "SupplierPart", ""); //From: [usp_selectAll_Allocation]
				allocation.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				allocation.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				allocation.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				allocation.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				allocation.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				allocation.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				allocation.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				allocation.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				allocation.Price = GetReaderValue_NullableDouble(reader, "Price", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				allocation.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
				allocation.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
				allocation.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
				allocation.QuantityOnOrder = GetReaderValue_NullableInt32(reader, "QuantityOnOrder", null); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
			}
			return allocation;
		}
	
		/// <summary>
		/// Returns a collection of AllocationDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<AllocationDetails> GetAllocationCollectionFromReader(DbDataReader reader) {
			List<AllocationDetails> allocations = new List<AllocationDetails>();
			while (reader.Read()) allocations.Add(GetAllocationFromReader(reader));
			return allocations;
		}
		
		
	}
}