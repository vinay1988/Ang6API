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
	
	public abstract class EPRProvider : DataAccess {
		static private EPRProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public EPRProvider Instance {
			get {
				if (_instance == null) _instance = (EPRProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.EPR.ProviderType));
				return _instance;
			}
		}
        public EPRProvider()
        {
			this.ConnectionString = Globals.Settings.EPR.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_EPR]
		/// </summary>
		public abstract bool Delete(System.Int32? EPRId);
        //[002] code start
		/// <summary>
		/// Insert
        /// Calls [usp_insert_EPR]
		/// </summary>       
		//public abstract Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? warehouseNo, System.Int32? currencyNo, System.Int32? buyer, System.Int32? shipViaNo, System.String account, System.Int32? termsNo, System.String expediteNotes, System.DateTime? expediteDate, System.Double? totalShipInCost, System.Int32? divisionNo, System.Int32? taxNo, System.String notes, System.String instructions, System.Boolean? paid, System.Boolean? confirmed, System.Int32? importCountryNo, System.String freeOnBoard, System.Int32? statusNo, System.Boolean? closed, System.Int32? incotermNo, System.Int32? updatedBy,System.String airwayBill);
        public abstract Int32 Insert(EPRDetails objEPR);
        //[002] code end
		
        /// <summary>
		/// Get
		/// Calls [usp_select_EPR]
		/// </summary>
		public abstract EPRDetails Get(System.Int32? eprId);
	
       /// <summary>
		/// Get
		/// Calls [usp_select_ListEPR]
		/// </summary>
        public abstract List<EPRDetails> ListEPR(System.Int32? PoId);

        /// <summary>
        /// Update
        /// Calls [usp_Update_EPR]
        /// </summary>
        public abstract bool Update(EPRDetails objEPR);

        /// <summary>
        /// usp_select_EPRLog
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public abstract List<EPRDetails> GetEPRLog(System.Int32? eprId);

		#endregion
				
        ///// <summary>
        ///// Returns a new PurchaseOrderDetails instance filled with the DataReader's current record data
        ///// </summary>        
        //protected virtual PurchaseOrderDetails GetPurchaseOrderFromReader(DbDataReader reader) {
        //    PurchaseOrderDetails purchaseOrder = new PurchaseOrderDetails();
        //    if (reader.HasRows) {
        //        purchaseOrder.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0); //From: [Table]
        //        purchaseOrder.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0); //From: [Table]
        //        purchaseOrder.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
        //        purchaseOrder.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
        //        purchaseOrder.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
        //        purchaseOrder.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue); //From: [Table]
        //        purchaseOrder.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0); //From: [Table]
        //        purchaseOrder.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
        //        purchaseOrder.Buyer = GetReaderValue_Int32(reader, "Buyer", 0); //From: [Table]
        //        purchaseOrder.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [Table]
        //        purchaseOrder.Account = GetReaderValue_String(reader, "Account", ""); //From: [Table]
        //        purchaseOrder.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0); //From: [Table]
        //        purchaseOrder.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", ""); //From: [Table]
        //        purchaseOrder.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null); //From: [Table]
        //        purchaseOrder.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null); //From: [Table]
        //        purchaseOrder.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [Table]
        //        purchaseOrder.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0); //From: [Table]
        //        purchaseOrder.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
        //        purchaseOrder.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
        //        purchaseOrder.Paid = GetReaderValue_Boolean(reader, "Paid", false); //From: [Table]
        //        purchaseOrder.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false); //From: [Table]
        //        purchaseOrder.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null); //From: [Table]
        //        purchaseOrder.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", ""); //From: [Table]
        //        purchaseOrder.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null); //From: [Table]
        //        purchaseOrder.Closed = GetReaderValue_Boolean(reader, "Closed", false); //From: [Table]
        //        purchaseOrder.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
        //        purchaseOrder.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
        //        purchaseOrder.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null); //From: [Table]
        //        purchaseOrder.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null); //From: [Table]
        //        purchaseOrder.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null); //From: [Table]
        //        purchaseOrder.CreatedBy = GetReaderValue_NullableInt32(reader, "CreatedBy", null); //From: [Table]
        //        purchaseOrder.CreateDate = GetReaderValue_NullableDateTime(reader, "CreateDate", null); //From: [Table]
        //        purchaseOrder.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_PurchaseOrder]
        //        purchaseOrder.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_itemsearch_PurchaseOrder]
        //        purchaseOrder.BuyerName = GetReaderValue_String(reader, "BuyerName", ""); //From: [usp_itemsearch_PurchaseOrder]
        //        purchaseOrder.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_PurchaseOrder]
        //        purchaseOrder.LastReceived = GetReaderValue_NullableDateTime(reader, "LastReceived", null); //From: [usp_itemsearch_PurchaseOrder_Received]
        //        purchaseOrder.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.IncotermName = GetReaderValue_String(reader, "IncotermName", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.Approver = GetReaderValue_String(reader, "Approver", ""); //From: [usp_select_PurchaseOrder]
        //        purchaseOrder.CompanyNameForSearch = GetReaderValue_String(reader, "CompanyNameForSearch", ""); //From: [usp_select_PurchaseOrder_for_Page]
        //        purchaseOrder.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", ""); //From: [usp_select_PurchaseOrder_for_Print]
        //        purchaseOrder.CompanyFax = GetReaderValue_String(reader, "CompanyFax", ""); //From: [usp_select_PurchaseOrder_for_Print]
        //        purchaseOrder.ContactEmail = GetReaderValue_String(reader, "ContactEmail", ""); //From: [usp_select_PurchaseOrder_for_Print]
        //        purchaseOrder.OutstandingQuantity = GetReaderValue_NullableInt32(reader, "OutstandingQuantity", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
        //        purchaseOrder.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
        //        purchaseOrder.Balance = GetReaderValue_NullableDouble(reader, "Balance", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
        //        purchaseOrder.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
        //        purchaseOrder.DaysOverdue = GetReaderValue_NullableInt32(reader, "DaysOverdue", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
        //        purchaseOrder.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0); //From: [usp_selectAll_PurchaseOrder_RecentlyReceived]
        //        purchaseOrder.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0); //From: [usp_selectAll_PurchaseOrder_RecentlyReceived]
        //        purchaseOrder.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue); //From: [usp_selectAll_PurchaseOrder_RecentlyReceived]
        //        purchaseOrder.VATNO = GetReaderValue_String(reader, "VATNo", ""); //from usp_select_PurchaseOrder_for_Print 
        //        purchaseOrder.SupplierCode = GetReaderValue_String(reader, "SupplierCode", ""); //from usp_select_PurchaseOrder_for_Print 


        //    }
        //    return purchaseOrder;
        //}
	
        ///// <summary>
        ///// Returns a collection of PurchaseOrderDetails objects with the data read from the input DataReader
        ///// </summary>                
        //protected virtual List<PurchaseOrderDetails> GetPurchaseOrderCollectionFromReader(DbDataReader reader) {
        //    List<PurchaseOrderDetails> purchaseOrders = new List<PurchaseOrderDetails>();
        //    while (reader.Read()) purchaseOrders.Add(GetPurchaseOrderFromReader(reader));
        //    return purchaseOrders;
        //}

        /// <summary>
        /// Insert EPR Email Log
        /// Call [usp_insert_Email_EPR_Log]
        /// </summary>
        /// <param name="nprId"></param>
        /// <param name="details"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract Int32 InsertEmailEPRLog(System.Int32? eprId, System.String details, System.Int32? updatedBy);

        
	}
}