//Marker     Changed by      Date         Remarks
//[001]      Vinay           04/09/2012   Print Label
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
	
	public abstract class GoodsInLineProvider : DataAccess {
		static private GoodsInLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public GoodsInLineProvider Instance {
			get {
				if (_instance == null) _instance = (GoodsInLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.GoodsInLines.ProviderType));
				return _instance;
			}
		}
		public GoodsInLineProvider() {
			this.ConnectionString = Globals.Settings.GoodsInLines.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForPurchaseOrderLine
		/// Calls [usp_count_GoodsInLine_for_PurchaseOrderLine]
		/// </summary>
		public abstract Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_GoodsInLine]
		/// </summary>
        public abstract List<GoodsInLineDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? receivedBy, System.String airWayBill, System.Boolean? includeInvoiced, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.String supplierInvoice, System.String reference, System.Boolean? recentOnly, System.Boolean? uninspectedOnly, System.Int32? clientSearch, int? IsPoHub, Boolean IsGlobalLogin);
		/// <summary>
		/// DataListNuggetAsReceivedPO
		/// Calls [usp_datalistnugget_GoodsInLine_AsReceivedPO]
		/// </summary>
		public abstract List<GoodsInLineDetails> DataListNuggetAsReceivedPO(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.String partSearch, System.Boolean? recentOnly, System.String cmSearch, System.String contactSearch, System.Int32? buyerSearch, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.String airWayBill, System.String supplierPartSearch, System.String reference,bool? isPoHub);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_GoodsInLine]
		/// </summary>
		public abstract bool Delete(System.Int32? goodsInLineId, System.Int32? updatedBy);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_GoodsInLine]
		/// </summary>
        public abstract Int32 Insert(System.Int32? goodsInNo, System.Int32? purchaseOrderLineNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Double? shipInCost, System.String qualityControlNotes, System.String location, System.Int32? lotNo, System.Int32? productNo, System.Int32? currencyNo, System.Int32? customerRmaLineNo, System.String supplierPart, System.Byte? rohs, System.Int32? countryOfManufacture, System.Boolean? unavailable, System.String notes, System.String changedFields, System.Int32? countingMethodNo, System.Boolean? serialNosRecorded, System.String partMarkings, System.Int32? updatedBy, System.Double? clientPrice, System.Boolean? reqSerialNo);
		/// <summary>
		/// Get
		/// Calls [usp_select_GoodsInLine]
		/// </summary>
		public abstract GoodsInLineDetails Get(System.Int32? goodsInLineId);
		/// <summary>
		/// GetListForCustomerRMA
		/// Calls [usp_selectAll_GoodsInLine_for_CustomerRMA]
		/// </summary>
		public abstract List<GoodsInLineDetails> GetListForCustomerRMA(System.Int32? customerRmaId);
		/// <summary>
		/// GetListForCustomerRMALine
		/// Calls [usp_selectAll_GoodsInLine_for_CustomerRMALine]
		/// </summary>
		public abstract List<GoodsInLineDetails> GetListForCustomerRMALine(System.Int32? customerRmaLineId);
		/// <summary>
		/// GetListForGoodsIn
		/// Calls [usp_selectAll_GoodsInLine_for_GoodsIn]
		/// </summary>
		public abstract List<GoodsInLineDetails> GetListForGoodsIn(System.Int32? goodsInId, System.Int32? pageIndex, System.Int32? pageSize);
		/// <summary>
		/// GetListForPurchaseOrder
		/// Calls [usp_selectAll_GoodsInLine_for_PurchaseOrder]
		/// </summary>
		public abstract List<GoodsInLineDetails> GetListForPurchaseOrder(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_GoodsInLine_for_PurchaseOrderLine]
		/// </summary>
		public abstract List<GoodsInLineDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// Update
		/// Calls [usp_update_GoodsInLine]
		/// </summary>
        public abstract bool Update(System.Int32? goodsInLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Double? shipInCost, System.String qualityControlNotes, System.String location, System.Int32? lotNo, System.Int32? productNo, System.String supplierPart, System.Byte? rohs, System.Int32? countryOfManufacture, System.Int32? currencyNo, System.Boolean? unavailable, System.String changedFields, System.String notes, System.Int32? countingMethodNo, System.Boolean? serialNosRecorded, System.String partMarkings, System.Boolean? updateStock, System.Boolean? updateShipments, System.Int32? updatedBy, System.Double? clientPrice, System.Boolean? reqSerialNo, System.String mslLevel, System.Boolean? printHazardous);
		/// <summary>
		/// UpdateInspect
		/// Calls [usp_update_GoodsInLine_Inspect]
		/// </summary>
		public abstract bool UpdateInspect(System.Int32? goodsInLineId, System.Int32? inspectedBy);
        //[001] code start

        /// <summary>
        /// UpdatePhysicalInspect
        /// Calls [usp_update_GoodsInLine_PhysicalInspect]
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="inspectedBy"></param>
        /// <returns></returns>
        public abstract bool UpdatePhysicalInspect(System.Int32? goodsInLineId, System.Int32? inspectedBy);
        /// <summary>
        /// GetDetailsPrintNiceLabelGoodsInLine
        /// Calls [usp_GetDetails_to_PrintNiceLabel_for_GoodsInLine]
        /// </summary>
        public abstract GoodsInLineDetails GetDetailsPrintNiceLabelGoodsInLine(System.Int32? goodsInLineId);
        //[001] code end
        /// <summary>
        /// usp_update_GoodsInLine_NPRStatus
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="nprPrintStatus"></param>
        /// <returns></returns>
        public abstract bool UpdateNPRStatus(System.Int32? goodsInLineId, System.Boolean? nprPrintStatus);
		#endregion
				
		/// <summary>
		/// Returns a new GoodsInLineDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual GoodsInLineDetails GetGoodsInLineFromReader(DbDataReader reader) {
			GoodsInLineDetails goodsInLine = new GoodsInLineDetails();
			if (reader.HasRows) {
				goodsInLine.GoodsInLineId = GetReaderValue_Int32(reader, "GoodsInLineId", 0); //From: [Table]
				goodsInLine.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0); //From: [Table]
				goodsInLine.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null); //From: [Table]
				goodsInLine.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				goodsInLine.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				goodsInLine.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				goodsInLine.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				goodsInLine.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				goodsInLine.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				goodsInLine.Price = GetReaderValue_Double(reader, "Price", 0); //From: [Table]
				goodsInLine.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null); //From: [Table]
				goodsInLine.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", ""); //From: [Table]
				goodsInLine.Location = GetReaderValue_String(reader, "Location", ""); //From: [Table]
				goodsInLine.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				goodsInLine.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0); //From: [Table]
				goodsInLine.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null); //From: [Table]
				goodsInLine.SupplierPart = GetReaderValue_String(reader, "SupplierPart", ""); //From: [Table]
				goodsInLine.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
				goodsInLine.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null); //From: [Table]
				goodsInLine.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				goodsInLine.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				goodsInLine.InspectedBy = GetReaderValue_NullableInt32(reader, "InspectedBy", null); //From: [Table]
				goodsInLine.DateInspected = GetReaderValue_NullableDateTime(reader, "DateInspected", null); //From: [Table]
				goodsInLine.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null); //From: [Table]
				goodsInLine.SerialNosRecorded = GetReaderValue_NullableBoolean(reader, "SerialNosRecorded", null); //From: [Table]
				goodsInLine.Unavailable = GetReaderValue_NullableBoolean(reader, "Unavailable", null); //From: [Table]
				goodsInLine.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null); //From: [Table]
				goodsInLine.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				goodsInLine.PartMarkings = GetReaderValue_String(reader, "PartMarkings", ""); //From: [Table]
				goodsInLine.FullSupplierPart = GetReaderValue_String(reader, "FullSupplierPart", ""); //From: [Table]
				goodsInLine.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.ReceiverName = GetReaderValue_String(reader, "ReceiverName", ""); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.AirWayBill = GetReaderValue_String(reader, "AirWayBill", ""); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_GoodsInLine]
				goodsInLine.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0); //From: [usp_datalistnugget_GoodsInLine_AsReceivedPO]
				goodsInLine.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [usp_datalistnugget_GoodsInLine_AsReceivedPO]
				goodsInLine.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_datalistnugget_GoodsInLine_AsReceivedPO]
				goodsInLine.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", ""); //From: [usp_datalistnugget_GoodsInLine_AsReceivedPO]
				goodsInLine.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null); //From: [usp_datalistnugget_GoodsInLine_AsReceivedPO]
				goodsInLine.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [usp_datalistnugget_GoodsInLine_AsReceivedPO]
				goodsInLine.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_datalistnugget_GoodsInLine_AsReceivedPO]
				goodsInLine.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [usp_select_GoodsInLine]
				goodsInLine.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.InspectorName = GetReaderValue_String(reader, "InspectorName", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null); //From: [usp_select_GoodsInLine]
				goodsInLine.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null); //From: [usp_select_GoodsInLine]
				goodsInLine.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0); //From: [usp_select_GoodsInLine]
				goodsInLine.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null); //From: [usp_select_GoodsInLine]
				goodsInLine.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_GoodsInLine]
				goodsInLine.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [usp_select_GoodsInLine]
				goodsInLine.Reference = GetReaderValue_String(reader, "Reference", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.LotName = GetReaderValue_String(reader, "LotName", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.PurchaseOrderLineShipInCost = GetReaderValue_Double(reader, "PurchaseOrderLineShipInCost", 0); //From: [usp_select_GoodsInLine]
				goodsInLine.ChangedFields = GetReaderValue_String(reader, "ChangedFields", ""); //From: [usp_select_GoodsInLine]
				goodsInLine.UpdateStock = GetReaderValue_NullableBoolean(reader, "UpdateStock", null); //From: [usp_select_GoodsInLine]
				goodsInLine.UpdateShipments = GetReaderValue_NullableBoolean(reader, "UpdateShipments", null); //From: [usp_select_GoodsInLine]
			}
			return goodsInLine;
		}
	
		/// <summary>
		/// Returns a collection of GoodsInLineDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<GoodsInLineDetails> GetGoodsInLineCollectionFromReader(DbDataReader reader) {
			List<GoodsInLineDetails> goodsInLines = new List<GoodsInLineDetails>();
			while (reader.Read()) goodsInLines.Add(GetGoodsInLineFromReader(reader));
			return goodsInLines;
		}


        public abstract Int32 InsertSerialNo(System.String subGroup, System.String serialNo, System.Int32? goodsInId, System.Int32? goodsInLineId, System.Int32? updatedBy, out System.String validateMessage);

        public abstract Int32 UpdateSerialNo(System.Int32? serialId, System.String subGroup, System.String serialNo, System.Int32? goodsInId, System.String status,System.Int32? goodsInLineId, System.Int32? updatedBy, out System.String validateMessage);


        public abstract List<GoodsInLineDetails> GetDataGrid(System.Int32? goodsInId, System.Int32? goodsInLineId, System.Int32? updatedBy);

        public abstract Int32 InsertAllSerialNo(System.Int32? goodsInId, System.Int32? goodsInLineId, System.Int32? updatedBy, out System.String validateMessage);

        public abstract List<GoodsInLineDetails> GetSerial(System.Int32? goodsInLineId);

        public abstract List<GoodsInLineDetails> AutoSearch(System.String nameSearch, System.String groupName);

        public abstract List<GoodsInLineDetails> DropDown(System.Int32? goodsInLineNo);

        public abstract List<GoodsInLineDetails> AutoSearchGroup(System.String nameSearch);

        public abstract Int32 DeleteSerialNo(System.Int32? serialNoId, System.String status, System.Int32? goodsInId, System.Int32? goodsInLineId, System.Int32? updatedBy);
        /// <summary>
        /// usp_itemsearch_GoodsInSerialNo
        /// </summary>
        public abstract List<GoodsInLineDetails> GISerialSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String giSerialGroup, System.String serialNoLo, System.Int32? serialNoHi, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.Int32? goodsInLineNo);
        /// <summary>
        /// usp_get_AttachedSerialNo
        /// </summary>
        public abstract List<GoodsInLineDetails> GetAttachedSerial(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? goodsInLineNO, System.Int32? salesOrderLineNo, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.Int32? allocationNo);

        /// <summary>
        /// usp_delete_AttachedSerial
        /// </summary>
        public abstract Int32 DeleteAttachedSerial(System.Int32? serialId, System.Int32? goodsInLineId, System.Int32? soLineId, System.Int32? updatedBy, System.Int32? allocationNo);

        /// <summary>
        /// usp_update_SerialBySO
        /// </summary>
        public abstract Int32 UpdateSerialBySO(System.String subGroup, System.Int32? goodsInLineId, System.Int32? soLineId, System.Int32? qtyToShpped, System.Int32? allocatedId,out System.String validateMessage);


        /// <summary>
        /// usp_delete_SerialBySO
        /// </summary>
        public abstract Int32 DeleteSerialBySO(System.Int32? goodsInLineId, System.Int32? soLineId, System.Int32? AllocatedId);
      

        public abstract List<GoodsInLineDetails> GetReasonDetailByPart(System.String part);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsInLineNo"></param>
        /// <returns></returns>
        public abstract List<GoodsInLineDetails> GetShipCostHistory(System.Int32? goodsInLineNo);
      
	}
}