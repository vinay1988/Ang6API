/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for stock section
[002]      Vinay           17/04/2014   CR:- Stock Provision
[003]      Vinay           30/07/2015   ESMS Ticket No: 255
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
using System.Collections.Generic;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class StockProvider : DataAccess {
		static private StockProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public StockProvider Instance {
			get {
				if (_instance == null) _instance = (StockProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Stocks.ProviderType));
				return _instance;
			}
		}
		public StockProvider() {
			this.ConnectionString = Globals.Settings.Stocks.ConnectionString;
            this.GTConnectionString = Globals.Settings.Stocks.GTConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Stock]
		/// </summary>
		public abstract List<StockDetails> AutoSearch(System.Int32? clientId, System.String nameSearch);
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Stock_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Stock]
		/// </summary>
        public abstract List<StockDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Boolean? quarantine, System.String partSearch, System.Int32? lotNo, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.String supplierPartSearch, System.String supplierNameSearch, System.String locationSearch, System.Int32? warehouseNo, System.Boolean? recentOnly, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.Boolean? includeZeroStock, System.Int32? clientSearch, int? isPoHub, Boolean IsGlobalLogin);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Stock]
		/// </summary>
		public abstract bool Delete(System.Int32? stockId);
		/// <summary>
		/// DeleteUnallocatedForLot
		/// Calls [usp_delete_Stock_Unallocated_for_Lot]
		/// </summary>
		public abstract bool DeleteUnallocatedForLot(System.Int32? lotNo);
		/// <summary>
		/// 
		/// Calls [usp_Import_Stock]
		/// </summary>
		/// <summary>
		/// 2
		/// Calls [usp_Import_Stock_2]
		/// </summary>
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Stock]
		/// </summary>
        public abstract Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? warehouseNo, System.Int32? clientNo, System.String qualityControlNotes, System.Int32? purchaseOrderNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaNo, System.Int32? customerRmaLineNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? productNo, System.Double? resalePrice, System.Boolean? unavailable, System.Int32? lotNo, System.Double? landedCost, System.String supplierPart, System.Byte? rohs, System.Int32? packageUnit, System.Int32? stockKeepingUnit, System.String stockLogChangeNotes, System.String location, System.Int32? countryOfManufacture, System.String partMarkings, System.Int32? countingMethodNo, System.Int32? updatedBy, System.Int32? divisionNo, System.String mslLevel);
		/// <summary>
		/// InsertIdentityOff
		/// Calls [usp_insert_Stock_Identity_Off]
		/// </summary>
		public abstract Int32 InsertIdentityOff(System.Int32? stockId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? warehouseNo, System.Int32? clientNo, System.String qualityControlNotes, System.Int32? purchaseOrderNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaNo, System.Int32? customerRmaLineNo, System.Int32? goodsInLineNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? productNo, System.Double? resalePrice, System.Boolean? unavailable, System.Int32? lotNo, System.Double? landedCost, System.String supplierPart, System.Byte? rohs, System.Int32? packageUnit, System.Int32? stockKeepingUnit, System.String stockLogChangeNotes, System.String location, System.Int32? updatedBy);
		/// <summary>
		/// InsertSplit
		/// Calls [usp_insert_Stock_Split]
		/// </summary>
		public abstract Int32 InsertSplit(System.Int32? stockId, System.Int32? quantitySplit, System.String location, System.Int32? updatedBy);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_Stock]
		/// </summary>
        public abstract List<StockDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.Boolean? forRmAs, System.Int32? supplierRmaNo, System.Boolean? includeQuarantined, System.Boolean? includeLotsOnHold, System.Int32? poNoLo, System.Int32? poNoHi, System.Int32? crmaNoLo, System.Int32? crmaNoHi, System.Int32? warehouseNo, System.String location, System.Int32? incLockCustNo);
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_IpoStock]
        /// </summary>
        public abstract List<StockDetails> IpoItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.Boolean? forRmAs, System.Int32? supplierRmaNo, System.Boolean? includeQuarantined, System.Boolean? includeLotsOnHold, System.Int32? poNoLo, System.Int32? poNoHi, System.Int32? crmaNoLo, System.Int32? crmaNoHi, System.Int32? warehouseNo, System.String location, System.Int32? incLockCustNo, int? salesOrderNo, System.Boolean? stopNONIpoStock);      
        /// <summary>
		/// Get
		/// Calls [usp_select_Stock]
		/// </summary>
		public abstract StockDetails Get(System.Int32? stockId);
		/// <summary>
		/// GetForCustomerRMALine
		/// Calls [usp_select_Stock_for_CustomerRMALine]
		/// </summary>
		public abstract StockDetails GetForCustomerRMALine(System.Int32? customerRmaLineId);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Stock_for_Page]
		/// </summary>
		public abstract StockDetails GetForPage(System.Int32? stockId);
		/// <summary>
		/// GetForPurchaseOrderLine
		/// Calls [usp_select_Stock_for_PurchaseOrderLine]
		/// </summary>
		public abstract StockDetails GetForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// GetListForLot
		/// Calls [usp_selectAll_Stock_for_Lot]
		/// </summary>
		public abstract List<StockDetails> GetListForLot(System.Int32? lotId);
        /// <summary>
        /// usp_selectNonZero_Stock_for_Lot
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public abstract List<StockDetails> GetListForNonZeroStockLot(System.Int32? lotId);
		/// <summary>
		/// GetListRelatedStock
		/// Calls [usp_selectAll_Stock_RelatedStock]
		/// </summary>
		public abstract List<StockDetails> GetListRelatedStock(System.Int32? stockNo);
		/// <summary>
		/// Source
		/// Calls [usp_source_Stock]
		/// </summary>
        public abstract List<StockDetails> Source(System.Int32? clientId, System.String partSearch, bool IsServerLocal);

        //[003] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_Stock]
		/// </summary>
        public abstract bool Update(System.Int32? stockId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? warehouseNo, System.Int32? clientNo, System.String qualityControlNotes, System.Int32? purchaseOrderNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaNo, System.Int32? customerRmaLineNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? productNo, System.Double? resalePrice, System.Boolean? unavailable, System.Int32? lotNo, System.Double? landedCost, System.String supplierPart, System.Byte? rohs, System.Int32? packageUnit, System.Int32? stockKeepingUnit, System.Int32? updatedBy, System.String stockLogDetail, System.String stockLogChangeNotes, System.Int32? stockLogReasonNo, System.String location, System.Int32? countryOfManufacture, System.Boolean? updateShipments, System.String partMarkings, System.Int32? countingMethodNo, System.Int32? divisionNo,System.Boolean? isClientUpdate, System.String mslLevel);
        //[003] code end
		/// <summary>
		/// UpdateQuarantined
		/// Calls [usp_update_Stock_Quarantined]
		/// </summary>
		public abstract bool UpdateQuarantined(System.Int32? stockId, System.Boolean? quarantine, System.String location, System.Int32? updatedBy);
		/// <summary>
		/// UpdateTransferLot
		/// Calls [usp_update_Stock_Transfer_Lot]
		/// </summary>
		public abstract bool UpdateTransferLot(System.Int32? oldNotNo, System.Int32? newLotNo);
        // [001] code start
        /// <summary>
        /// Get PDF list for stock
        /// Calls [usp_selectAll_PDF_for_Stock]
        /// </summary>
        /// <param name="SalesOrderId"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetPDFListForStock(System.Int32? StockId);

        /// <summary>
        /// Insert PDF for stock
        /// Calls [usp_insert_StockPDF]
        /// </summary>
        /// <param name="StockId"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? StockId, System.String Caption, System.String FileName, System.Int32? UpdatedBy);
        /// <summary>
        /// Delete stock pdf
        /// Calls[usp_delete_StockPDF]
        /// </summary>
        /// <param name="StockPdfId"></param>
        /// <returns></returns>
        public abstract bool DeleteStockPDF(System.Int32? StockPdfId);
        // [001] code end
        //[002] code start
        /// <summary>
        /// Calls [usp_update_Stock_Provision]
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="landedCost"></param>
        /// <param name="newLandedCost"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract bool UpdateStockProvision(System.Int32? stockId, System.Double? newLandedCost, System.Int32? updatedBy, System.Int32? percentageValue);
        //[002] code end
        public abstract bool UpdateHubLandedCost(System.Int32? stockId, System.Double? newLandedCost, System.Double? resalePrice, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new StockDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual StockDetails GetStockFromReader(DbDataReader reader) {
			StockDetails stock = new StockDetails();
			if (reader.HasRows) {
				stock.StockId = GetReaderValue_Int32(reader, "StockId", 0); //From: [Table]
				stock.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				stock.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				stock.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				stock.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				stock.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				stock.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null); //From: [Table]
				stock.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				stock.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", ""); //From: [Table]
				stock.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null); //From: [Table]
				stock.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null); //From: [Table]
				stock.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0); //From: [Table]
				stock.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0); //From: [Table]
				stock.Location = GetReaderValue_String(reader, "Location", ""); //From: [Table]
				stock.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				stock.ResalePrice = GetReaderValue_NullableDouble(reader, "ResalePrice", null); //From: [Table]
				stock.Unavailable = GetReaderValue_Boolean(reader, "Unavailable", false); //From: [Table]
				stock.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null); //From: [Table]
				stock.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [Table]
				stock.SupplierPart = GetReaderValue_String(reader, "SupplierPart", ""); //From: [Table]
				stock.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
				stock.PackageUnit = GetReaderValue_NullableInt32(reader, "PackageUnit", null); //From: [Table]
				stock.StockKeepingUnit = GetReaderValue_NullableInt32(reader, "StockKeepingUnit", null); //From: [Table]
				stock.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null); //From: [Table]
				stock.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null); //From: [Table]
				stock.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null); //From: [Table]
				stock.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				stock.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				stock.FullSupplierPart = GetReaderValue_String(reader, "FullSupplierPart", ""); //From: [Table]
				stock.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null); //From: [Table]
				stock.PartMarkings = GetReaderValue_String(reader, "PartMarkings", ""); //From: [Table]
				stock.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null); //From: [Table]
				stock.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_datalistnugget_Stock]
				stock.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0); //From: [usp_datalistnugget_Stock]
				stock.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [usp_datalistnugget_Stock]
				stock.LotName = GetReaderValue_String(reader, "LotName", ""); //From: [usp_datalistnugget_Stock]
				stock.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null); //From: [usp_datalistnugget_Stock]
				stock.SupplierName = GetReaderValue_String(reader, "SupplierName", ""); //From: [usp_datalistnugget_Stock]
				stock.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null); //From: [usp_datalistnugget_Stock]
				stock.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null); //From: [usp_datalistnugget_Stock]
				stock.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_Stock]
				stock.PODeliveryDate = GetReaderValue_NullableDateTime(reader, "PODeliveryDate", null); //From: [usp_itemsearch_Stock]
				stock.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null); //From: [usp_itemsearch_Stock]
				stock.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null); //From: [usp_itemsearch_Stock]
				stock.CustomerRMADate = GetReaderValue_NullableDateTime(reader, "CustomerRMADate", null); //From: [usp_itemsearch_Stock]
				stock.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_select_Stock]
				stock.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_select_Stock]
				stock.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_select_Stock]
				stock.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_select_Stock]
				stock.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_select_Stock]
				stock.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_Stock]
				stock.LotCode = GetReaderValue_String(reader, "LotCode", ""); //From: [usp_select_Stock]
				stock.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null); //From: [usp_select_Stock]
				stock.BuyerName = GetReaderValue_String(reader, "BuyerName", ""); //From: [usp_select_Stock]
				stock.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null); //From: [usp_select_Stock]
				stock.GoodsInPrice = GetReaderValue_NullableDouble(reader, "GoodsInPrice", null); //From: [usp_select_Stock]
				stock.GoodsInShipInCost = GetReaderValue_NullableDouble(reader, "GoodsInShipInCost", null); //From: [usp_select_Stock]
				stock.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null); //From: [usp_select_Stock]
				stock.GoodsInCurrencyNo = GetReaderValue_NullableInt32(reader, "GoodsInCurrencyNo", null); //From: [usp_select_Stock]
				stock.StockDate = GetReaderValue_DateTime(reader, "StockDate", DateTime.MinValue); //From: [usp_select_Stock]
				stock.ROHSStatus = GetReaderValue_String(reader, "ROHSStatus", ""); //From: [usp_select_Stock]
				stock.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", ""); //From: [usp_select_Stock]
				stock.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null); //From: [usp_select_Stock]
				stock.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", ""); //From: [usp_select_Stock]
				stock.StockLogDetail = GetReaderValue_String(reader, "StockLogDetail", ""); //From: [usp_select_Stock]
				stock.StockLogChangeNotes = GetReaderValue_String(reader, "StockLogChangeNotes", ""); //From: [usp_select_Stock]
				stock.StockLogReasonNo = GetReaderValue_NullableInt32(reader, "StockLogReasonNo", null); //From: [usp_select_Stock]
				stock.UpdateShipments = GetReaderValue_NullableBoolean(reader, "UpdateShipments", null); //From: [usp_select_Stock]
				stock.RelationType = GetReaderValue_String(reader, "RelationType", ""); //From: [usp_selectAll_Stock_RelatedStock]
				stock.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [usp_source_Stock]
				stock.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null); //From: [usp_source_Stock]
			}
			return stock;
		}
	
		/// <summary>
		/// Returns a collection of StockDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<StockDetails> GetStockCollectionFromReader(DbDataReader reader) {
			List<StockDetails> stocks = new List<StockDetails>();
			while (reader.Read()) stocks.Add(GetStockFromReader(reader));
			return stocks;
        }

        #region Lot stock provision start

        /// <summary>
        /// usp_selectAll_LotStockProvision
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public abstract List<StockDetails> GetListStockProvision(System.Int32? lotId);

        /// <summary>
        /// Insert all stock values againest lot id
        /// usp_insert_LotStockDetails
        /// </summary>
        /// <param name="LotId"> lot id</param>
        /// <param name="Percentage">percentage</param>
        /// <param name="UpdatedBy"> updated by</param>
        /// <returns></returns>
        public abstract Int32 InserLotStock(System.Int32? LotId, System.Double? Percentage, System.Int32? UpdatedBy, Double? TotalPrimaryLandedCost, Double? TotalCurrentLandedCost);
        #endregion

        public abstract List<GoodsInLineDetails> GetSerial(System.Int32? stockId);
    }
}
