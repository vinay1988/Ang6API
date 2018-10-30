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
	public class SqlSalesOrderStatusProvider : SalesOrderStatusProvider {
		/// <summary>
		/// Delete SalesOrderStatus
		/// Calls [usp_delete_SalesOrderStatus]
		/// </summary>
		public override bool Delete(System.Int32? salesOrderStatusId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_SalesOrderStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderStatusId", SqlDbType.Int).Value = salesOrderStatusId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete SalesOrderStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_SalesOrderStatus]
        /// </summary>
		public override List<SalesOrderStatusDetails> DropDown() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_SalesOrderStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderStatusDetails> lst = new List<SalesOrderStatusDetails>();
				while (reader.Read()) {
					SalesOrderStatusDetails obj = new SalesOrderStatusDetails();
					obj.SalesOrderStatusId = GetReaderValue_Int32(reader, "SalesOrderStatusId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderStatuss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SalesOrderStatus]
		/// </summary>
		public override Int32 Insert(System.String name) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SalesOrderStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@SalesOrderStatusId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@SalesOrderStatusId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SalesOrderStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_SalesOrderStatus]
        /// </summary>
		public override SalesOrderStatusDetails Get(System.Int32? salesOrderStatusId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SalesOrderStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderStatusId", SqlDbType.Int).Value = salesOrderStatusId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSalesOrderStatusFromReader(reader);
					SalesOrderStatusDetails obj = new SalesOrderStatusDetails();
					obj.SalesOrderStatusId = GetReaderValue_Int32(reader, "SalesOrderStatusId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_SalesOrderStatus]
        /// </summary>
		public override List<SalesOrderStatusDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderStatusDetails> lst = new List<SalesOrderStatusDetails>();
				while (reader.Read()) {
					SalesOrderStatusDetails obj = new SalesOrderStatusDetails();
					obj.SalesOrderStatusId = GetReaderValue_Int32(reader, "SalesOrderStatusId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderStatuss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SalesOrderStatus
		/// Calls [usp_update_SalesOrderStatus]
        /// </summary>
		public override bool Update(System.String name, System.Int32? salesOrderStatusId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SalesOrderStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@SalesOrderStatusId", SqlDbType.Int).Value = salesOrderStatusId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SalesOrderStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}