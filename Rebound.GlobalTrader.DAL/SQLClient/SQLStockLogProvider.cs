using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Caching;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL.SqlClient {
	public class SqlStockLogProvider : StockLogProvider {
		/// <summary>
		/// Delete StockLog
		/// Calls [usp_delete_StockLog]
		/// </summary>
		public override bool Delete(System.Int32? stockLogId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_StockLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockLogId", SqlDbType.Int).Value = stockLogId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete StockLog", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_StockLog]
		/// </summary>
		public override Int32 Insert(System.Int32? stockLogTypeNo, System.Int32? stockNo, System.Int32? stockLogReasonNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.String detail, System.String changeNotes, System.Int32? invoiceNo, System.Int32? purchaseOrderNo, System.Int32? goodsInLineNo, System.Int32? goodsInNo, System.Int32? salesOrderLineNo, System.Int32? salesOrderNo, System.Int32? srmaLineNo, System.Int32? crmaLineNo, System.Int32? debitNo, System.Int32? relatedStockNo, System.Int32? actionQuantity, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_StockLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockLogTypeNo", SqlDbType.Int).Value = stockLogTypeNo;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@StockLogReasonNo", SqlDbType.Int).Value = stockLogReasonNo;
				cmd.Parameters.Add("@QuantityInStock", SqlDbType.Int).Value = quantityInStock;
				cmd.Parameters.Add("@QuantityOnOrder", SqlDbType.Int).Value = quantityOnOrder;
				cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = detail;
				cmd.Parameters.Add("@ChangeNotes", SqlDbType.NVarChar).Value = changeNotes;
				cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = invoiceNo;
				cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
				cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
				cmd.Parameters.Add("@GoodsInNo", SqlDbType.Int).Value = goodsInNo;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
				cmd.Parameters.Add("@SRMALineNo", SqlDbType.Int).Value = srmaLineNo;
				cmd.Parameters.Add("@CRMALineNo", SqlDbType.Int).Value = crmaLineNo;
				cmd.Parameters.Add("@DebitNo", SqlDbType.Int).Value = debitNo;
				cmd.Parameters.Add("@RelatedStockNo", SqlDbType.Int).Value = relatedStockNo;
				cmd.Parameters.Add("@ActionQuantity", SqlDbType.Int).Value = actionQuantity;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@StockLogId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@StockLogId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert StockLog", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_StockLog]
        /// </summary>
		public override StockLogDetails Get(System.Int32? stockLogId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_StockLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@StockLogId", SqlDbType.Int).Value = stockLogId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetStockLogFromReader(reader);
					StockLogDetails obj = new StockLogDetails();
					obj.StockLogId = GetReaderValue_Int32(reader, "StockLogId", 0);
					obj.StockLogTypeNo = GetReaderValue_Int32(reader, "StockLogTypeNo", 0);
					obj.StockNo = GetReaderValue_Int32(reader, "StockNo", 0);
					obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
					obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
					obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.RelatedStockNo = GetReaderValue_NullableInt32(reader, "RelatedStockNo", null);
					obj.ActionQuantity = GetReaderValue_NullableInt32(reader, "ActionQuantity", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.CRMALineNo = GetReaderValue_NullableInt32(reader, "CRMALineNo", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.SRMALineNo = GetReaderValue_NullableInt32(reader, "SRMALineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Detail = GetReaderValue_String(reader, "Detail", "");
					obj.ChangeNotes = GetReaderValue_String(reader, "ChangeNotes", "");
					obj.StockLogReasonNo = GetReaderValue_NullableInt32(reader, "StockLogReasonNo", null);
					obj.DebitNo = GetReaderValue_NullableInt32(reader, "DebitNo", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get StockLog", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForStock 
		/// Calls [usp_selectAll_StockLog_for_Stock]
        /// </summary>
		public override List<StockLogDetails> GetListForStock(System.Int32? stockId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_StockLog_for_Stock", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<StockLogDetails> lst = new List<StockLogDetails>();
				while (reader.Read()) {
					StockLogDetails obj = new StockLogDetails();
					obj.StockLogId = GetReaderValue_Int32(reader, "StockLogId", 0);
					obj.StockLogTypeNo = GetReaderValue_Int32(reader, "StockLogTypeNo", 0);
					obj.StockNo = GetReaderValue_Int32(reader, "StockNo", 0);
					obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
					obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
					obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.RelatedStockNo = GetReaderValue_NullableInt32(reader, "RelatedStockNo", null);
					obj.ActionQuantity = GetReaderValue_NullableInt32(reader, "ActionQuantity", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.CRMALineNo = GetReaderValue_NullableInt32(reader, "CRMALineNo", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.SRMALineNo = GetReaderValue_NullableInt32(reader, "SRMALineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Detail = GetReaderValue_String(reader, "Detail", "");
					obj.ChangeNotes = GetReaderValue_String(reader, "ChangeNotes", "");
					obj.StockLogReasonNo = GetReaderValue_NullableInt32(reader, "StockLogReasonNo", null);
					obj.DebitNo = GetReaderValue_NullableInt32(reader, "DebitNo", null);
					obj.StockLogReasonName = GetReaderValue_String(reader, "StockLogReasonName", "");
					obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.RelatedStockPart = GetReaderValue_String(reader, "RelatedStockPart", "");
					obj.UpdatedByName = GetReaderValue_String(reader, "UpdatedByName", "");
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
					obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.DebitNumber = GetReaderValue_NullableInt32(reader, "DebitNumber", null);
					obj.GoodsInCurrencyCode = GetReaderValue_String(reader, "GoodsInCurrencyCode", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get StockLogs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update StockLog
		/// Calls [usp_update_StockLog]
        /// </summary>
		public override bool Update(System.Int32? stockLogId, System.Int32? stockLogTypeNo, System.Int32? stockNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? invoiceNo, System.Int32? purchaseOrderNo, System.Int32? relatedStockNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_StockLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockLogId", SqlDbType.Int).Value = stockLogId;
				cmd.Parameters.Add("@StockLogTypeNo", SqlDbType.Int).Value = stockLogTypeNo;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@QuantityInStock", SqlDbType.Int).Value = quantityInStock;
				cmd.Parameters.Add("@QuantityOnOrder", SqlDbType.Int).Value = quantityOnOrder;
				cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = invoiceNo;
				cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
				cmd.Parameters.Add("@RelatedStockNo", SqlDbType.Int).Value = relatedStockNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update StockLog", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}