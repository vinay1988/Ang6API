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
	public class SqlCustomerRmaLineAllocationProvider : CustomerRmaLineAllocationProvider {
		/// <summary>
		/// Count CustomerRmaLineAllocation
		/// Calls [usp_count_CustomerRMALineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public override Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_CustomerRMALineAllocation_for_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count CustomerRmaLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete CustomerRmaLineAllocation
		/// Calls [usp_delete_CustomerRMALineAllocation]
		/// </summary>
		public override bool Delete(System.Int32? customerRmaLineAllocationId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_CustomerRMALineAllocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRMALineAllocationId", SqlDbType.Int).Value = customerRmaLineAllocationId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete CustomerRmaLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_CustomerRMALineAllocation]
		/// </summary>
		public override Int32 Insert(System.Int32? customerRmaLineNo, System.Int32? invoiceLineAllocationNo, System.Int32? quantity, System.Int32? goodsInLineNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_CustomerRMALineAllocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRMALineNo", SqlDbType.Int).Value = customerRmaLineNo;
				cmd.Parameters.Add("@InvoiceLineAllocationNo", SqlDbType.Int).Value = invoiceLineAllocationNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@CustomerRMALineAllocationId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CustomerRMALineAllocationId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert CustomerRmaLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_CustomerRMALineAllocation]
        /// </summary>
		public override CustomerRmaLineAllocationDetails Get(System.Int32? customerRmaLineAllocationId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CustomerRMALineAllocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRMALineAllocationId", SqlDbType.Int).Value = customerRmaLineAllocationId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCustomerRmaLineAllocationFromReader(reader);
					CustomerRmaLineAllocationDetails obj = new CustomerRmaLineAllocationDetails();
					obj.CustomerRMALineAllocationId = GetReaderValue_Int32(reader, "CustomerRMALineAllocationId", 0);
					obj.CustomerRMALineNo = GetReaderValue_Int32(reader, "CustomerRMALineNo", 0);
					obj.InvoiceLineAllocationNo = GetReaderValue_Int32(reader, "InvoiceLineAllocationNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRmaLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForPurchaseOrderLine 
		/// Calls [usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine]
        /// </summary>
		public override List<CustomerRmaLineAllocationDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId, System.Int32? pageIndex, System.Int32? pageSize) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CustomerRmaLineAllocationDetails> lst = new List<CustomerRmaLineAllocationDetails>();
				while (reader.Read()) {
					CustomerRmaLineAllocationDetails obj = new CustomerRmaLineAllocationDetails();
					obj.CustomerRMALineAllocationId = GetReaderValue_Int32(reader, "CustomerRMALineAllocationId", 0);
					obj.CustomerRMALineNo = GetReaderValue_Int32(reader, "CustomerRMALineNo", 0);
					obj.InvoiceLineAllocationNo = GetReaderValue_Int32(reader, "InvoiceLineAllocationNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
					obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
					obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
					obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Reason = GetReaderValue_String(reader, "Reason", "");
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
					obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
					obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRmaLineAllocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CustomerRmaLineAllocation
		/// Calls [usp_update_CustomerRMALineAllocation]
        /// </summary>
		public override bool Update(System.Int32? customerRmaLineAllocationId, System.Int32? customerRmaLineNo, System.Int32? invoiceLineAllocationNo, System.Int32? quantity, System.Int32? goodsInLineNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CustomerRMALineAllocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRMALineAllocationId", SqlDbType.Int).Value = customerRmaLineAllocationId;
				cmd.Parameters.Add("@CustomerRMALineNo", SqlDbType.Int).Value = customerRmaLineNo;
				cmd.Parameters.Add("@InvoiceLineAllocationNo", SqlDbType.Int).Value = invoiceLineAllocationNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CustomerRmaLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}