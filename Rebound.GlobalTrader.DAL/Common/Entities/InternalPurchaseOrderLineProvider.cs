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
	
	public abstract class InternalPurchaseOrderLineProvider : DataAccess {
		static private InternalPurchaseOrderLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public InternalPurchaseOrderLineProvider Instance {
			get {
				if (_instance == null) _instance = (InternalPurchaseOrderLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.InternalPurchaseOrderLines.ProviderType));
				return _instance;
			}
		}
        public InternalPurchaseOrderLineProvider()
        {
            this.ConnectionString = Globals.Settings.InternalPurchaseOrderLines.ConnectionString;
            this.GTConnectionString = Globals.Settings.InternalPurchaseOrderLines.GTConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_PurchaseOrderLine]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Int32? CountrySearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo, System.Boolean? recentOnly, System.Int32? ClientSearch);
		/// <summary>
		/// DataListNuggetAllForReceiving
		/// Calls [usp_datalistnugget_PurchaseOrderLine_AllForReceiving]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> DataListNuggetAllForReceiving(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo);
		/// <summary>
		/// DataListNuggetReadyToReceive
		/// Calls [usp_datalistnugget_PurchaseOrderLine_ReadyToReceive]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> DataListNuggetReadyToReceive(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_PurchaseOrderLine]
		/// </summary>
		public abstract bool Delete(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_InternalPurchaseOrderLine]
		/// </summary>
        public abstract Int32 Insert(int? fromPurchaseOrderLineNo, System.Int32? purchaseOrderLineId, System.Int32? updatedBy);
		/// <summary>
		/// InsertFromSalesOrderLine
		/// Calls [usp_insert_PurchaseOrderLine_from_SalesOrderLine]
		/// </summary>
		public abstract Int32 InsertFromSalesOrderLine(System.Int32? salesOrderLineId, System.Int32? purchaseOrderNo, System.Int32? updatedBy);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_PurchaseOrderLine]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo);
		/// <summary>
		/// Get
        /// Calls [usp_select_InternalPurchaseOrderLine]
		/// </summary>
        public abstract InternalPurchaseOrderLineDetails Get(System.Int32? internalPurchaseOrderLineId);
		/// <summary>
		/// GetForSupplierRMALine
		/// Calls [usp_select_PurchaseOrderLine_for_SupplierRMALine]
		/// </summary>
        public abstract InternalPurchaseOrderLineDetails GetForSupplierRMALine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// GetListCandidatesForSupplierRMA
		/// Calls [usp_selectAll_PurchaseOrderLine_candidates_for_SupplierRMA]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> GetListCandidatesForSupplierRMA(System.Int32? supplierRmaId);
		/// <summary>
		/// GetListClosedForPurchaseOrder
        /// Calls [usp_selectAll_InternalPurchaseOrderLine_closed_for_InternalPurchaseOrder]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> GetListClosedForPurchaseOrder(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetListForPurchaseOrder
        /// Calls [usp_selectAll_InternalPurchaseOrderLine_for_InternalPurchaseOrder]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> GetListForPurchaseOrder(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetListForSupplierRMA
		/// Calls [usp_selectAll_PurchaseOrderLine_for_SupplierRMA]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> GetListForSupplierRMA(System.Int32? supplierRmaId);
		/// <summary>
		/// GetListOpenForPurchaseOrder
        /// Calls [usp_selectAll_InternalPurchaseOrderLine_open_for_InternalPurchaseOrder]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> GetListOpenForPurchaseOrder(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetListReceivingForPurchaseOrder
		/// Calls [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> GetListReceivingForPurchaseOrder(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetListTodayForClient
		/// Calls [usp_selectAll_PurchaseOrderLine_today_for_Client]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> GetListTodayForClient(System.Int32? clientId, System.Int32? topToSelect);
		/// <summary>
		/// Source
		/// Calls [usp_source_PurchaseOrderLine]
		/// </summary>
        public abstract List<InternalPurchaseOrderLineDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal);
		/// <summary>
		/// Update
        /// Calls [usp_update_InternalPurchaseOrderLine]
		/// </summary>
        public abstract bool Update(System.Int32? internalPurchaseOrderLineId, double? price, string notes, string receivingNotes, double? ShipInCost, System.Int32? ProductNo, System.Int32? updatedBy, System.String mslLevel);
		/// <summary>
		/// UpdateClose
		/// Calls [usp_update_PurchaseOrderLine_Close]
		/// </summary>
		public abstract bool UpdateClose(System.Int32? purchaseOrderLineId, System.Int32? updatedBy);
		/// <summary>
		/// UpdateClosedStatus
		/// Calls [usp_update_PurchaseOrderLine_Closed_Status]
		/// </summary>
		public abstract bool UpdateClosedStatus(System.Int32? purchaseOrderLineNo);
		/// <summary>
		/// UpdatePostOrUnpost
		/// Calls [usp_update_PurchaseOrderLine_Post_or_Unpost]
		/// </summary>
		public abstract bool UpdatePostOrUnpost(System.Int32? purchaseOrderLineId, System.Boolean? posted, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new PurchaseOrderLineDetails instance filled with the DataReader's current record data
		/// </summary>        
        protected virtual InternalPurchaseOrderLineDetails GetPurchaseOrderLineFromReader(DbDataReader reader)
        {
            InternalPurchaseOrderLineDetails purchaseOrderLine = new InternalPurchaseOrderLineDetails();
			if (reader.HasRows) {
				purchaseOrderLine.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0); //From: [Table]
                purchaseOrderLine.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0); //From: [Table]
				purchaseOrderLine.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				purchaseOrderLine.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				purchaseOrderLine.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				purchaseOrderLine.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				purchaseOrderLine.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				purchaseOrderLine.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				purchaseOrderLine.Price = GetReaderValue_Double(reader, "Price", 0); //From: [Table]
				purchaseOrderLine.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue); //From: [Table]
				purchaseOrderLine.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", ""); //From: [Table]
				purchaseOrderLine.Taxable = GetReaderValue_Boolean(reader, "Taxable", false); //From: [Table]
				purchaseOrderLine.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				purchaseOrderLine.Posted = GetReaderValue_Boolean(reader, "Posted", false); //From: [Table]
				purchaseOrderLine.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null); //From: [Table]
				purchaseOrderLine.SupplierPart = GetReaderValue_String(reader, "SupplierPart", ""); //From: [Table]
				purchaseOrderLine.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				purchaseOrderLine.Closed = GetReaderValue_Boolean(reader, "Closed", false); //From: [Table]
				purchaseOrderLine.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
				purchaseOrderLine.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				purchaseOrderLine.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				purchaseOrderLine.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				purchaseOrderLine.FullSupplierPart = GetReaderValue_String(reader, "FullSupplierPart", ""); //From: [Table]
				purchaseOrderLine.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.Status = GetReaderValue_NullableInt32(reader, "Status", null); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.QuantityOutstanding = GetReaderValue_NullableInt32(reader, "QuantityOutstanding", null); //From: [usp_datalistnugget_PurchaseOrderLine]
				purchaseOrderLine.EarliestShipDate = GetReaderValue_NullableDateTime(reader, "EarliestShipDate", null); //From: [usp_datalistnugget_PurchaseOrderLine_AllForReceiving]
				purchaseOrderLine.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null); //From: [usp_itemsearch_PurchaseOrderLine]
				purchaseOrderLine.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", ""); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [usp_select_PurchaseOrderLine]
				purchaseOrderLine.QuantityToReturn = GetReaderValue_NullableInt32(reader, "QuantityToReturn", null); //From: [usp_select_PurchaseOrderLine_for_SupplierRMALine]
				purchaseOrderLine.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.Buyer = GetReaderValue_Int32(reader, "Buyer", 0); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.BuyerName = GetReaderValue_String(reader, "BuyerName", ""); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.FullName = GetReaderValue_String(reader, "FullName", ""); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.Balance = GetReaderValue_NullableDouble(reader, "Balance", null); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.LineValue = GetReaderValue_Double(reader, "LineValue", 0); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				purchaseOrderLine.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [usp_source_PurchaseOrderLine]
				purchaseOrderLine.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null); //From: [usp_source_PurchaseOrderLine]
			}
			return purchaseOrderLine;
		}
	
		/// <summary>
		/// Returns a collection of PurchaseOrderLineDetails objects with the data read from the input DataReader
		/// </summary>                
        protected virtual List<InternalPurchaseOrderLineDetails> GetPurchaseOrderLineCollectionFromReader(DbDataReader reader)
        {
            List<InternalPurchaseOrderLineDetails> internalPurchaseOrderLines = new List<InternalPurchaseOrderLineDetails>();
            while (reader.Read()) internalPurchaseOrderLines.Add(GetPurchaseOrderLineFromReader(reader));
            return internalPurchaseOrderLines;
		}
		
		
	}
}
