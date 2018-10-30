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
	
	public abstract class InvoiceLineAllocationProvider : DataAccess {
		static private InvoiceLineAllocationProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public InvoiceLineAllocationProvider Instance {
			get {
				if (_instance == null) _instance = (InvoiceLineAllocationProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.InvoiceLineAllocations.ProviderType));
				return _instance;
			}
		}
		public InvoiceLineAllocationProvider() {
			this.ConnectionString = Globals.Settings.InvoiceLineAllocations.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForPurchaseOrderLine
		/// Calls [usp_count_InvoiceLineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public abstract Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_InvoiceLineAllocation]
		/// </summary>
		public abstract bool Delete(System.Int32? invoiceLineAllocationId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_InvoiceLineAllocation]
		/// </summary>
		public abstract Int32 Insert(System.Int32? invoiceLineNo, System.Int32? quantity, System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? lotNo, System.Double? landedCost, System.Int32? supplierRmaLineNo, System.Int32? warehouseNo, System.String location, System.Int32? goodsInLineNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaGoodsInLineNo, System.Int32? countryOfManufactureNo, System.String notes, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_InvoiceLineAllocation]
		/// </summary>
		public abstract InvoiceLineAllocationDetails Get(System.Int32? invoiceLineAllocationId);
		/// <summary>
		/// GetCandidateForCustomerRMA
		/// Calls [usp_select_InvoiceLineAllocation_candidate_for_CustomerRMA]
		/// </summary>
		public abstract InvoiceLineAllocationDetails GetCandidateForCustomerRMA(System.Int32? invoiceLineAllocationId, System.Int32? customerRmaId);
		/// <summary>
		/// GetListCandidatesForCustomerRMA
		/// Calls [usp_selectAll_InvoiceLineAllocation_candidates_for_CustomerRMA]
		/// </summary>
		public abstract List<InvoiceLineAllocationDetails> GetListCandidatesForCustomerRMA(System.Int32? customerRmaId);
		/// <summary>
		/// GetListForGoodsInLine
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_GoodsInLine]
		/// </summary>
		public abstract List<InvoiceLineAllocationDetails> GetListForGoodsInLine(System.Int32? goodsInLineId);
		/// <summary>
		/// GetListForInvoiceLine
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_InvoiceLine]
		/// </summary>
		public abstract List<InvoiceLineAllocationDetails> GetListForInvoiceLine(System.Int32? invoiceLineId);
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public abstract List<InvoiceLineAllocationDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// GetListForSupplierRMALine
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_SupplierRMALine]
		/// </summary>
		public abstract List<InvoiceLineAllocationDetails> GetListForSupplierRMALine(System.Int32? supplierRmaLineId);
		/// <summary>
		/// Update
		/// Calls [usp_update_InvoiceLineAllocation]
		/// </summary>
		public abstract bool Update(System.Int32? invoiceLineAllocationId, System.Int32? invoiceLineNo, System.Int32? quantity, System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? lotNo, System.Double? landedCost, System.Int32? supplierRmaLineNo, System.Int32? warehouseNo, System.String location, System.Int32? goodsInLineNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaGoodsInLineNo, System.Int32? countryOfManufactureNo, System.String notes, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new InvoiceLineAllocationDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual InvoiceLineAllocationDetails GetInvoiceLineAllocationFromReader(DbDataReader reader) {
			InvoiceLineAllocationDetails invoiceLineAllocation = new InvoiceLineAllocationDetails();
			if (reader.HasRows) {
				invoiceLineAllocation.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0); //From: [usp_select_CustomerRMALine_for_Receiving]
				invoiceLineAllocation.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0); //From: [Table]
				invoiceLineAllocation.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				invoiceLineAllocation.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [Table]
				invoiceLineAllocation.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null); //From: [Table]
				invoiceLineAllocation.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null); //From: [Table]
				invoiceLineAllocation.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null); //From: [Table]
				invoiceLineAllocation.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.Location = GetReaderValue_String(reader, "Location", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				invoiceLineAllocation.CountryOfManufactureNo = GetReaderValue_NullableInt32(reader, "CountryOfManufactureNo", null); //From: [Table]
				invoiceLineAllocation.CustomerRMAGoodsInLineNo = GetReaderValue_NullableInt32(reader, "CustomerRMAGoodsInLineNo", null); //From: [Table]
				invoiceLineAllocation.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				invoiceLineAllocation.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				invoiceLineAllocation.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				invoiceLineAllocation.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_CreditLine]
				invoiceLineAllocation.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", ""); //From: [usp_select_GoodsInLine]
				invoiceLineAllocation.LotName = GetReaderValue_String(reader, "LotName", ""); //From: [usp_select_GoodsInLine]
				invoiceLineAllocation.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0); //From: [Table]
				invoiceLineAllocation.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null); //From: [Table]
				invoiceLineAllocation.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null); //From: [usp_select_Credit]
				invoiceLineAllocation.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null); //From: [usp_select_Credit]
				invoiceLineAllocation.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null); //From: [Table]
				invoiceLineAllocation.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null); //From: [Table]
				invoiceLineAllocation.Freight = GetReaderValue_NullableDouble(reader, "Freight", null); //From: [Table]
				invoiceLineAllocation.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", ""); //From: [usp_select_Credit]
				invoiceLineAllocation.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0); //From: [Table]
				invoiceLineAllocation.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				invoiceLineAllocation.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [usp_list_Activity_by_Client_with_filter]
				invoiceLineAllocation.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_list_Activity_by_Client_with_filter]
				invoiceLineAllocation.Part = GetReaderValue_String(reader, "Part", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.SupplierPart = GetReaderValue_String(reader, "SupplierPart", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null); //From: [Table]
				invoiceLineAllocation.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null); //From: [Table]
				invoiceLineAllocation.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.SalesOrderLineId = GetReaderValue_NullableInt32(reader, "SalesOrderLineId", null); //From: [usp_select_InvoiceLineAllocation]
				invoiceLineAllocation.Price = GetReaderValue_NullableDouble(reader, "Price", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				invoiceLineAllocation.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_list_Activity_by_Client_with_filter]
				invoiceLineAllocation.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null); //From: [usp_select_InvoiceLineAllocation]
				invoiceLineAllocation.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null); //From: [Table]
				invoiceLineAllocation.PurchaseCurrencyNo = GetReaderValue_NullableInt32(reader, "PurchaseCurrencyNo", null); //From: [usp_select_InvoiceLineAllocation]
				invoiceLineAllocation.PurchaseCurrencyCode = GetReaderValue_String(reader, "PurchaseCurrencyCode", ""); //From: [usp_select_InvoiceLineAllocation]
				invoiceLineAllocation.SupplierName = GetReaderValue_String(reader, "SupplierName", ""); //From: [usp_source_Excess]
				invoiceLineAllocation.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_selectAll_Allocation]
				invoiceLineAllocation.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
				invoiceLineAllocation.BuyerName = GetReaderValue_String(reader, "BuyerName", ""); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
				invoiceLineAllocation.QuantityAllocatedToCRMA = GetReaderValue_NullableInt32(reader, "QuantityAllocatedToCRMA", null); //From: [usp_select_InvoiceLineAllocation]
				invoiceLineAllocation.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null); //From: [Table]
			}
			return invoiceLineAllocation;
		}
	
		/// <summary>
		/// Returns a collection of InvoiceLineAllocationDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<InvoiceLineAllocationDetails> GetInvoiceLineAllocationCollectionFromReader(DbDataReader reader) {
			List<InvoiceLineAllocationDetails> invoiceLineAllocations = new List<InvoiceLineAllocationDetails>();
			while (reader.Read()) invoiceLineAllocations.Add(GetInvoiceLineAllocationFromReader(reader));
			return invoiceLineAllocations;
		}
		
		
	}
}