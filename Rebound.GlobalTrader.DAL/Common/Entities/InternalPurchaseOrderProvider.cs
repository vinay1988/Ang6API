/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for Purchage Order section
[002]      Vinay           17/01/2014   ESMS Ticket No : 95
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
	
	public abstract class InternalPurchaseOrderProvider : DataAccess {
		static private InternalPurchaseOrderProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public InternalPurchaseOrderProvider Instance {
			get {
                if (_instance == null) _instance = (InternalPurchaseOrderProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.InternalPurchaseOrders.ProviderType));
				return _instance;
			}
		}
        public InternalPurchaseOrderProvider()
        {
            this.ConnectionString = Globals.Settings.InternalPurchaseOrders.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_PurchaseOrder_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_PurchaseOrder_for_Company]
		/// </summary>
		public abstract Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed);
		/// <summary>
		/// CountOpenForCompany
		/// Calls [usp_count_PurchaseOrder_open_for_Company]
		/// </summary>
		public abstract Int32 CountOpenForCompany(System.Int32? companyId);
		/// <summary>
		/// CountReceivingForClient
		/// Calls [usp_count_PurchaseOrder_receiving_for_Client]
		/// </summary>
		public abstract Int32 CountReceivingForClient(System.Int32? clientId);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_PurchaseOrder]
		/// </summary>
		public abstract bool Delete(System.Int32? purchaseOrderId);
        //[002] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_PurchaseOrder]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? warehouseNo, System.Int32? currencyNo, System.Int32? buyer, System.Int32? shipViaNo, System.String account, System.Int32? termsNo, System.String expediteNotes, System.DateTime? expediteDate, System.Double? totalShipInCost, System.Int32? divisionNo, System.Int32? taxNo, System.String notes, System.String instructions, System.Boolean? paid, System.Boolean? confirmed, System.Int32? importCountryNo, System.String freeOnBoard, System.Int32? statusNo, System.Boolean? closed, System.Int32? incotermNo, System.Int32? updatedBy,System.String airwayBill);
        //[002] code end
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_PurchaseOrder]
		/// </summary>
		public abstract List<InternalPurchaseOrderDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo);
		/// <summary>
		/// ItemSearchReceived
		/// Calls [usp_itemsearch_PurchaseOrder_Received]
		/// </summary>
        public abstract List<InternalPurchaseOrderDetails> ItemSearchReceived(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_InternalPurchaseOrder]
		/// </summary>
        public abstract InternalPurchaseOrderDetails Get(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetByNumber
		/// Calls [usp_select_PurchaseOrder_by_Number]
		/// </summary>
        public abstract InternalPurchaseOrderDetails GetByNumber(System.Int32? purchaseOrderNumber, System.Int32? clientNo);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_PurchaseOrder_for_Page]
		/// </summary>
        public abstract InternalPurchaseOrderDetails GetForPage(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetForPrint
        /// Calls [usp_select_InternalPurchaseOrder_for_Print]
		/// </summary>
        public abstract InternalPurchaseOrderDetails GetForPrint(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetIDByNumber
        /// Calls [usp_select_InternalPurchaseOrder_ID_by_Number]
		/// </summary>
        public abstract InternalPurchaseOrderDetails GetIDByNumber(System.Int32? internalPurchaseOrderNumber, System.Int32? clientNo);
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_PurchaseOrder_NextNumber]
		/// </summary>
        public abstract InternalPurchaseOrderDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// GetStatus
		/// Calls [usp_select_PurchaseOrder_Status]
		/// </summary>
        public abstract InternalPurchaseOrderDetails GetStatus(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetListDueForClient
		/// Calls [usp_selectAll_PurchaseOrder_due_for_Client]
		/// </summary>
        public abstract List<InternalPurchaseOrderDetails> GetListDueForClient(System.Int32? clientId, System.Int32? topToSelect);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_PurchaseOrder_for_Company]
		/// </summary>
        public abstract List<InternalPurchaseOrderDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed);
		/// <summary>
		/// GetListOpenForCompany
		/// Calls [usp_selectAll_PurchaseOrder_open_for_Company]
		/// </summary>
        public abstract List<InternalPurchaseOrderDetails> GetListOpenForCompany(System.Int32? companyId);
		/// <summary>
		/// GetListOpenForLogin
		/// Calls [usp_selectAll_PurchaseOrder_open_for_Login]
		/// </summary>
        public abstract List<InternalPurchaseOrderDetails> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect);
		/// <summary>
		/// GetListOverdueForCompany
		/// Calls [usp_selectAll_PurchaseOrder_overdue_for_Company]
		/// </summary>
        public abstract List<InternalPurchaseOrderDetails> GetListOverdueForCompany(System.Int32? companyId);
		/// <summary>
		/// GetListOverdueForLogin
		/// Calls [usp_selectAll_PurchaseOrder_overdue_for_Login]
		/// </summary>
        public abstract List<InternalPurchaseOrderDetails> GetListOverdueForLogin(System.Int32? loginId, System.Int32? topToSelect);
		/// <summary>
		/// GetListRecentlyReceived
		/// Calls [usp_selectAll_PurchaseOrder_RecentlyReceived]
		/// </summary>
        public abstract List<InternalPurchaseOrderDetails> GetListRecentlyReceived(System.Int32? clientId, System.Int32? topToSelect);
        //[002] code start
		/// <summary>
		/// Update
        /// Calls [usp_update_InternalPurchaseOrder]
		/// </summary>
        public abstract bool Update(System.Int32? internalPOId, System.Int32? currencyNo, System.Int32? contactNo, System.Int32? buyer, System.Int32? divisionNo, System.Int32? updatedBy);
        //[002] code end
		/// <summary>
		/// UpdateApprove
		/// Calls [usp_update_PurchaseOrder_Approve]
		/// </summary>
		public abstract bool UpdateApprove(System.Int32? purchaseOrderId, System.Int32? approvedBy, System.Boolean? approve);
		/// <summary>
		/// UpdateClose
		/// Calls [usp_update_PurchaseOrder_Close]
		/// </summary>
		public abstract bool UpdateClose(System.Int32? purchaseOrderId, System.Int32? updatedBy);
        // [001] code start
        /// <summary>
        /// Get PDF list for purchase order 
        /// Calls [usp_selectAll_PDF_for_PurchaseOrder]
        /// </summary>
        /// <param name="PurchaseOrderId"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetPDFListForPurchageOrder(System.Int32? PurchaseOrderId);
        /// <summary>
        /// Insert PDF for purchase order
        /// Calls [usp_insert_PurchaseOrderPDF]
        /// </summary>
        /// <param name="PurchaseOrderId"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? PurchaseOrderId, System.String Caption, System.String FileName, System.Int32? UpdatedBy);
        /// <summary>
        /// Delete purchase order pdf
        /// Calls[usp_delete_PurchaseOrderPDF]
        /// </summary>
        /// <param name="PurchaseOrderPdfId"></param>
        /// <returns></returns>
        public abstract bool DeletePurchaseOrderPDF(System.Int32? PurchaseOrderPdfId);

        public abstract Int32 InsertExpedite(System.Int32? purchaseOrderId, System.String expediteNotes, System.Int32? UpdatedBy);
        // [001] code end
        /// usp_dropdownlist_IPO
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>

        public abstract List<InternalPurchaseOrderDetails> IPODropDownList(System.Int32? docId);
		#endregion
				
		/// <summary>
		/// Returns a new PurchaseOrderDetails instance filled with the DataReader's current record data
		/// </summary>        
        protected virtual InternalPurchaseOrderDetails GetPurchaseOrderFromReader(DbDataReader reader)
        {
            InternalPurchaseOrderDetails purchaseOrder = new InternalPurchaseOrderDetails();
			if (reader.HasRows) {
				purchaseOrder.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0); //From: [Table]
				purchaseOrder.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0); //From: [Table]
				purchaseOrder.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				purchaseOrder.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				purchaseOrder.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
				purchaseOrder.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue); //From: [Table]
				purchaseOrder.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0); //From: [Table]
				purchaseOrder.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
				purchaseOrder.Buyer = GetReaderValue_Int32(reader, "Buyer", 0); //From: [Table]
				purchaseOrder.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [Table]
				purchaseOrder.Account = GetReaderValue_String(reader, "Account", ""); //From: [Table]
				purchaseOrder.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0); //From: [Table]
				purchaseOrder.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", ""); //From: [Table]
				purchaseOrder.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null); //From: [Table]
				purchaseOrder.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null); //From: [Table]
				purchaseOrder.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [Table]
				purchaseOrder.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0); //From: [Table]
				purchaseOrder.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				purchaseOrder.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
				purchaseOrder.Paid = GetReaderValue_Boolean(reader, "Paid", false); //From: [Table]
				purchaseOrder.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false); //From: [Table]
				purchaseOrder.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null); //From: [Table]
				purchaseOrder.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", ""); //From: [Table]
				purchaseOrder.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null); //From: [Table]
				purchaseOrder.Closed = GetReaderValue_Boolean(reader, "Closed", false); //From: [Table]
				purchaseOrder.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				purchaseOrder.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				purchaseOrder.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null); //From: [Table]
				purchaseOrder.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null); //From: [Table]
				purchaseOrder.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null); //From: [Table]
				purchaseOrder.CreatedBy = GetReaderValue_NullableInt32(reader, "CreatedBy", null); //From: [Table]
				purchaseOrder.CreateDate = GetReaderValue_NullableDateTime(reader, "CreateDate", null); //From: [Table]
				purchaseOrder.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_PurchaseOrder]
				purchaseOrder.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_itemsearch_PurchaseOrder]
				purchaseOrder.BuyerName = GetReaderValue_String(reader, "BuyerName", ""); //From: [usp_itemsearch_PurchaseOrder]
				purchaseOrder.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_PurchaseOrder]
				purchaseOrder.LastReceived = GetReaderValue_NullableDateTime(reader, "LastReceived", null); //From: [usp_itemsearch_PurchaseOrder_Received]
				purchaseOrder.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null); //From: [usp_select_PurchaseOrder]
				purchaseOrder.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null); //From: [usp_select_PurchaseOrder]
				purchaseOrder.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null); //From: [usp_select_PurchaseOrder]
				purchaseOrder.IncotermName = GetReaderValue_String(reader, "IncotermName", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null); //From: [usp_select_PurchaseOrder]
				purchaseOrder.Approver = GetReaderValue_String(reader, "Approver", ""); //From: [usp_select_PurchaseOrder]
				purchaseOrder.CompanyNameForSearch = GetReaderValue_String(reader, "CompanyNameForSearch", ""); //From: [usp_select_PurchaseOrder_for_Page]
				purchaseOrder.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", ""); //From: [usp_select_PurchaseOrder_for_Print]
				purchaseOrder.CompanyFax = GetReaderValue_String(reader, "CompanyFax", ""); //From: [usp_select_PurchaseOrder_for_Print]
				purchaseOrder.ContactEmail = GetReaderValue_String(reader, "ContactEmail", ""); //From: [usp_select_PurchaseOrder_for_Print]
				purchaseOrder.OutstandingQuantity = GetReaderValue_NullableInt32(reader, "OutstandingQuantity", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
				purchaseOrder.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
				purchaseOrder.Balance = GetReaderValue_NullableDouble(reader, "Balance", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
				purchaseOrder.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
				purchaseOrder.DaysOverdue = GetReaderValue_NullableInt32(reader, "DaysOverdue", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
				purchaseOrder.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0); //From: [usp_selectAll_PurchaseOrder_RecentlyReceived]
				purchaseOrder.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0); //From: [usp_selectAll_PurchaseOrder_RecentlyReceived]
				purchaseOrder.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue); //From: [usp_selectAll_PurchaseOrder_RecentlyReceived]
                purchaseOrder.VATNO = GetReaderValue_String(reader, "VATNo", ""); //from usp_select_PurchaseOrder_for_Print 
                purchaseOrder.SupplierCode = GetReaderValue_String(reader, "SupplierCode", ""); //from usp_select_PurchaseOrder_for_Print 


			}
			return purchaseOrder;
		}
	
		/// <summary>
		/// Returns a collection of PurchaseOrderDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<InternalPurchaseOrderDetails> GetPurchaseOrderCollectionFromReader(DbDataReader reader) {
            List<InternalPurchaseOrderDetails> internalPurchaseOrders = new List<InternalPurchaseOrderDetails>();
            while (reader.Read()) internalPurchaseOrders.Add(GetPurchaseOrderFromReader(reader));
            return internalPurchaseOrders;
		}
		
		
	}
}