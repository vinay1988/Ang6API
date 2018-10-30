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
	public class SqlBackOrderProvider : BackOrderProvider {
		/// <summary>
		/// Delete BackOrder
		/// Calls [usp_delete_BackOrder]
		/// </summary>
		public override bool Delete(System.Int32? salesOrderLineNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_BackOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete BackOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_BackOrder]
		/// </summary>
		public override Int32 Insert(System.Int32? salesOrderLineNo, System.Int32? quantity, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_BackOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@BackOrderID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@BackOrderID"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert BackOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_BackOrder]
        /// </summary>
		public override BackOrderDetails Get(System.Int32? salesOrderLineNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_BackOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetBackOrderFromReader(reader);
					BackOrderDetails obj = new BackOrderDetails();
					obj.SalesOrderLineNo = GetReaderValue_Int32(reader, "SalesOrderLineNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get BackOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_BackOrder]
        /// </summary>
		public override List<BackOrderDetails> GetList(System.Int32? pageIndex, System.Int32? pageSize) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_BackOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<BackOrderDetails> lst = new List<BackOrderDetails>();
				while (reader.Read()) {
					BackOrderDetails obj = new BackOrderDetails();
					obj.SalesOrderLineNo = GetReaderValue_Int32(reader, "SalesOrderLineNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get BackOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update BackOrder
		/// Calls [usp_update_BackOrder]
        /// </summary>
		public override bool Update(System.Int32? salesOrderLineNo, System.Int32? quantity, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_BackOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update BackOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}