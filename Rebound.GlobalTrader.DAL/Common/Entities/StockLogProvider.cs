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
	
	public abstract class StockLogProvider : DataAccess {
		static private StockLogProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public StockLogProvider Instance {
			get {
				if (_instance == null) _instance = (StockLogProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.StockLogs.ProviderType));
				return _instance;
			}
		}
		public StockLogProvider() {
			this.ConnectionString = Globals.Settings.StockLogs.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_StockLog]
		/// </summary>
		public abstract bool Delete(System.Int32? stockLogId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_StockLog]
		/// </summary>
		public abstract Int32 Insert(System.Int32? stockLogTypeNo, System.Int32? stockNo, System.Int32? stockLogReasonNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.String detail, System.String changeNotes, System.Int32? invoiceNo, System.Int32? purchaseOrderNo, System.Int32? goodsInLineNo, System.Int32? goodsInNo, System.Int32? salesOrderLineNo, System.Int32? salesOrderNo, System.Int32? srmaLineNo, System.Int32? crmaLineNo, System.Int32? debitNo, System.Int32? relatedStockNo, System.Int32? actionQuantity, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_StockLog]
		/// </summary>
		public abstract StockLogDetails Get(System.Int32? stockLogId);
		/// <summary>
		/// GetListForStock
		/// Calls [usp_selectAll_StockLog_for_Stock]
		/// </summary>
		public abstract List<StockLogDetails> GetListForStock(System.Int32? stockId);
		/// <summary>
		/// Update
		/// Calls [usp_update_StockLog]
		/// </summary>
		public abstract bool Update(System.Int32? stockLogId, System.Int32? stockLogTypeNo, System.Int32? stockNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? invoiceNo, System.Int32? purchaseOrderNo, System.Int32? relatedStockNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new StockLogDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual StockLogDetails GetStockLogFromReader(DbDataReader reader) {
			StockLogDetails stockLog = new StockLogDetails();
			if (reader.HasRows) {
				stockLog.StockLogId = GetReaderValue_Int32(reader, "StockLogId", 0); //From: [Table]
				stockLog.StockLogTypeNo = GetReaderValue_Int32(reader, "StockLogTypeNo", 0); //From: [Table]
				stockLog.StockNo = GetReaderValue_Int32(reader, "StockNo", 0); //From: [Table]
				stockLog.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0); //From: [usp_selectAll_Allocation]
				stockLog.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
				stockLog.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null); //From: [Table]
				stockLog.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null); //From: [usp_selectAll_Allocation]
				stockLog.RelatedStockNo = GetReaderValue_NullableInt32(reader, "RelatedStockNo", null); //From: [Table]
				stockLog.ActionQuantity = GetReaderValue_NullableInt32(reader, "ActionQuantity", null); //From: [Table]
				stockLog.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null); //From: [Table]
				stockLog.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null); //From: [usp_selectAll_Allocation]
				stockLog.CRMALineNo = GetReaderValue_NullableInt32(reader, "CRMALineNo", null); //From: [Table]
				stockLog.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null); //From: [usp_selectAll_Allocation]
				stockLog.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null); //From: [Table]
				stockLog.SRMALineNo = GetReaderValue_NullableInt32(reader, "SRMALineNo", null); //From: [Table]
				stockLog.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				stockLog.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				stockLog.Detail = GetReaderValue_String(reader, "Detail", ""); //From: [Table]
				stockLog.ChangeNotes = GetReaderValue_String(reader, "ChangeNotes", ""); //From: [Table]
				stockLog.StockLogReasonNo = GetReaderValue_NullableInt32(reader, "StockLogReasonNo", null); //From: [usp_select_Stock]
				stockLog.DebitNo = GetReaderValue_NullableInt32(reader, "DebitNo", null); //From: [Table]
				stockLog.StockLogReasonName = GetReaderValue_String(reader, "StockLogReasonName", ""); //From: [usp_selectAll_StockLog_for_Stock]
				stockLog.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null); //From: [usp_select_Credit]
				stockLog.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null); //From: [usp_selectAll_Allocation]
				stockLog.RelatedStockPart = GetReaderValue_String(reader, "RelatedStockPart", ""); //From: [usp_selectAll_StockLog_for_Stock]
				stockLog.UpdatedByName = GetReaderValue_String(reader, "UpdatedByName", ""); //From: [usp_selectAll_StockLog_for_Stock]
				stockLog.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null); //From: [Table]
				stockLog.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null); //From: [usp_selectAll_Allocation]
				stockLog.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
				stockLog.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
				stockLog.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null); //From: [usp_selectAll_Allocation]
				stockLog.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null); //From: [usp_selectAll_Allocation]
				stockLog.DebitNumber = GetReaderValue_NullableInt32(reader, "DebitNumber", null); //From: [Table]
				stockLog.GoodsInCurrencyCode = GetReaderValue_String(reader, "GoodsInCurrencyCode", ""); //From: [usp_selectAll_StockLog_for_Stock]
			}
			return stockLog;
		}
	
		/// <summary>
		/// Returns a collection of StockLogDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<StockLogDetails> GetStockLogCollectionFromReader(DbDataReader reader) {
			List<StockLogDetails> stockLogs = new List<StockLogDetails>();
			while (reader.Read()) stockLogs.Add(GetStockLogFromReader(reader));
			return stockLogs;
		}
		
		
	}
}