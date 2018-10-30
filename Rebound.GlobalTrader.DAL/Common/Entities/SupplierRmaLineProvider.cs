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
	
	public abstract class SupplierRmaLineProvider : DataAccess {
		static private SupplierRmaLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SupplierRmaLineProvider Instance {
			get {
				if (_instance == null) _instance = (SupplierRmaLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SupplierRmaLines.ProviderType));
				return _instance;
			}
		}
		public SupplierRmaLineProvider() {
			this.ConnectionString = Globals.Settings.SupplierRmaLines.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForPurchaseOrderLine
		/// Calls [usp_count_SupplierRMALine_for_PurchaseOrderLine]
		/// </summary>
		public abstract Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_SupplierRMALine]
		/// </summary>
        public abstract List<SupplierRmaLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo, System.Boolean? includeShipped, System.Boolean? recentOnly, System.Boolean? PohubOnly, System.Int32? clientSearch, Boolean IsGlobalLogin);
		/// <summary>
		/// DataListNuggetReadyToShip
		/// Calls [usp_datalistnugget_SupplierRMALine_ReadyToShip]
		/// </summary>
        public abstract List<SupplierRmaLineDetails> DataListNuggetReadyToShip(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo, System.Int32? clientSearch, Boolean IsGlobalLogin);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SupplierRMALine]
		/// </summary>
		public abstract bool Delete(System.Int32? supplierRmaLineId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SupplierRMALine]
		/// </summary>
        public abstract Int32 Insert(System.Int32? supplierRmaNo, System.Int32? purchaseOrderLineNo, System.DateTime? returnDate, System.String reason, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? productNo, System.Int32? quantity, System.String reference, System.Byte? rohs, System.String notes, System.String Reason1, System.String Reason2, System.String rootCause, System.Int32? updatedBy, out int supplierRMAId, out int supplierRMANumber, System.Boolean? avoidable, System.Boolean? printHazardous);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_SupplierRMALine]
		/// </summary>
		public abstract List<SupplierRmaLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_SupplierRMALine]
		/// </summary>
		public abstract SupplierRmaLineDetails Get(System.Int32? supplierRmaLineId);
		/// <summary>
		/// GetAllocation
		/// Calls [usp_select_SupplierRMALine_Allocation]
		/// </summary>
		public abstract SupplierRmaLineDetails GetAllocation(System.Int32? supplierRmaLineId, System.Int32? allocationId);
		/// <summary>
		/// GetShip
		/// Calls [usp_select_SupplierRMALine_Ship]
		/// </summary>
		public abstract SupplierRmaLineDetails GetShip(System.Int32? supplierRmaLineId);
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_SupplierRMALine_for_PurchaseOrderLine]
		/// </summary>
		public abstract List<SupplierRmaLineDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// GetListForSupplierRMA
		/// Calls [usp_selectAll_SupplierRMALine_for_SupplierRMA]
		/// </summary>
		public abstract List<SupplierRmaLineDetails> GetListForSupplierRMA(System.Int32? supplierRmaId);
		/// <summary>
		/// GetListShipForSupplierRMA
		/// Calls [usp_selectAll_SupplierRMALine_Ship_for_SupplierRMA]
		/// </summary>
		public abstract List<SupplierRmaLineDetails> GetListShipForSupplierRMA(System.Int32? supplierRmaId);
		/// <summary>
		/// GetListFromGoodsInLineForDocket
		/// Calls [usp_selectAll_SupplierRmaLine_from_GoodsInLine_for_Docket]
		/// </summary>
		public abstract List<SupplierRmaLineDetails> GetListFromGoodsInLineForDocket(System.Int32? goodsInLineNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_SupplierRMALine]
		/// </summary>
        public abstract bool Update(System.Int32? supplierRmaLineId, System.String reason, System.Int32? quantity, System.String reference, System.Byte? rohs, System.String notes, System.String Reason1, System.String Reason2, System.String rootCause, System.Int32? updatedBy, System.Boolean? avoidable, System.Boolean? printHazardous);

		#endregion
				
		/// <summary>
		/// Returns a new SupplierRmaLineDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SupplierRmaLineDetails GetSupplierRmaLineFromReader(DbDataReader reader) {
			SupplierRmaLineDetails supplierRmaLine = new SupplierRmaLineDetails();
			if (reader.HasRows) {
				supplierRmaLine.SupplierRMALineId = GetReaderValue_Int32(reader, "SupplierRMALineId", 0); //From: [Table]
				supplierRmaLine.SupplierRMANo = GetReaderValue_Int32(reader, "SupplierRMANo", 0); //From: [Table]
				supplierRmaLine.PurchaseOrderLineNo = GetReaderValue_Int32(reader, "PurchaseOrderLineNo", 0); //From: [usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine]
				supplierRmaLine.ReturnDate = GetReaderValue_DateTime(reader, "ReturnDate", DateTime.MinValue); //From: [Table]
				supplierRmaLine.Reason = GetReaderValue_String(reader, "Reason", ""); //From: [Table]
				supplierRmaLine.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.Part = GetReaderValue_String(reader, "Part", ""); //From: [usp_datalistnugget_CustomerRMALine]
				supplierRmaLine.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [usp_datalistnugget_CustomerRMALine]
				supplierRmaLine.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [usp_select_CustomerRMA]
				supplierRmaLine.Reference = GetReaderValue_String(reader, "Reference", ""); //From: [Table]
				supplierRmaLine.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [usp_datalistnugget_CustomerRMALine]
				supplierRmaLine.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				supplierRmaLine.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				supplierRmaLine.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				supplierRmaLine.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0); //From: [Table]
				supplierRmaLine.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0); //From: [Table]
				supplierRmaLine.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue); //From: [Table]
				supplierRmaLine.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_CustomerRMA]
				supplierRmaLine.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				supplierRmaLine.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0); //From: [usp_itemsearch_SupplierRMA]
				supplierRmaLine.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0); //From: [Table]
				supplierRmaLine.AllocatedQuantity = GetReaderValue_Int32(reader, "AllocatedQuantity", 0); //From: [usp_datalistnugget_SupplierRMALine]
				supplierRmaLine.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_select_CustomerRMA]
				supplierRmaLine.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null); //From: [Table]
				supplierRmaLine.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_datalistnugget_CustomerRMALine]
				supplierRmaLine.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_CustomerRMA]
				supplierRmaLine.BuyerName = GetReaderValue_String(reader, "BuyerName", ""); //From: [usp_itemsearch_SupplierRMA]
				supplierRmaLine.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				supplierRmaLine.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0); //From: [usp_select_SupplierRMALine]
				supplierRmaLine.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue); //From: [usp_select_SupplierRMALine]
				supplierRmaLine.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [usp_select_CustomerRMA]
				supplierRmaLine.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_CustomerRMA]
				supplierRmaLine.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_CustomerRMA]
				supplierRmaLine.Buyer = GetReaderValue_Int32(reader, "Buyer", 0); //From: [usp_select_SupplierRMA]
				supplierRmaLine.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null); //From: [Table]
				supplierRmaLine.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.FullName = GetReaderValue_String(reader, "FullName", ""); //From: [usp_select_SupplierRMALine]
				supplierRmaLine.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0); //From: [Table]
				supplierRmaLine.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", ""); //From: [usp_itemsearch_CustomerRMA]
				supplierRmaLine.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0); //From: [usp_select_SupplierRMA]
				supplierRmaLine.Price = GetReaderValue_Double(reader, "Price", 0); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine]
				supplierRmaLine.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null); //From: [usp_select_SupplierRMALine]
				supplierRmaLine.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null); //From: [usp_select_SupplierRMALine]
				supplierRmaLine.Location = GetReaderValue_String(reader, "Location", ""); //From: [usp_select_SupplierRMALine]
				supplierRmaLine.Taxable = GetReaderValue_Boolean(reader, "Taxable", false); //From: [usp_select_SupplierRMALine]
				supplierRmaLine.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null); //From: [Table]
				supplierRmaLine.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [usp_select_CustomerRMA]
				supplierRmaLine.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null); //From: [usp_select_SupplierRMALine_Allocation]
				supplierRmaLine.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [usp_select_CustomerRMALine]
				supplierRmaLine.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null); //From: [Table]
				supplierRmaLine.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null); //From: [usp_select_SupplierRMALine_Allocation]
				supplierRmaLine.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null); //From: [usp_select_SupplierRMALine_Allocation]
				supplierRmaLine.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null); //From: [usp_select_SupplierRMALine_Allocation]
				supplierRmaLine.SupplierNo = GetReaderValue_Int32(reader, "SupplierNo", 0); //From: [usp_select_SupplierRMALine_Allocation]
				supplierRmaLine.SupplierName = GetReaderValue_String(reader, "SupplierName", ""); //From: [usp_select_SupplierRMALine_Allocation]
				supplierRmaLine.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0); //From: [usp_select_SupplierRMALine_Allocation]
				supplierRmaLine.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue); //From: [usp_select_SupplierRMALine_Allocation]
				supplierRmaLine.PurchasePrice = GetReaderValue_Double(reader, "PurchasePrice", 0); //From: [usp_select_SupplierRMALine_Allocation]
				supplierRmaLine.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_selectAll_SupplierRMALine_from_GoodsInLine_for_Docket]
			}
			return supplierRmaLine;
		}
	
		/// <summary>
		/// Returns a collection of SupplierRmaLineDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SupplierRmaLineDetails> GetSupplierRmaLineCollectionFromReader(DbDataReader reader) {
			List<SupplierRmaLineDetails> supplierRmaLines = new List<SupplierRmaLineDetails>();
			while (reader.Read()) supplierRmaLines.Add(GetSupplierRmaLineFromReader(reader));
			return supplierRmaLines;
		}
		
		
	}
}