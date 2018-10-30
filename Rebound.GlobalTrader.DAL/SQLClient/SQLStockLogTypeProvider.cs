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
	public class SqlStockLogTypeProvider : StockLogTypeProvider {
		/// <summary>
		/// Delete StockLogType
		/// Calls [usp_delete_StockLogType]
		/// </summary>
		public override bool Delete(System.Int32? stockLogTypeId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_StockLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockLogTypeId", SqlDbType.Int).Value = stockLogTypeId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete StockLogType", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_StockLogType]
        /// </summary>
		public override List<StockLogTypeDetails> DropDown() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_StockLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<StockLogTypeDetails> lst = new List<StockLogTypeDetails>();
				while (reader.Read()) {
					StockLogTypeDetails obj = new StockLogTypeDetails();
					obj.StockLogTypeId = GetReaderValue_Int32(reader, "StockLogTypeId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get StockLogTypes", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_StockLogType]
		/// </summary>
		public override Int32 Insert(System.String name, System.Int32? parentStockLogTypeNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_StockLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@ParentStockLogTypeNo", SqlDbType.Int).Value = parentStockLogTypeNo;
				cmd.Parameters.Add("@StockLogTypeId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@StockLogTypeId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert StockLogType", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_StockLogType]
        /// </summary>
		public override StockLogTypeDetails Get(System.Int32? stockLogTypeId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_StockLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@StockLogTypeId", SqlDbType.Int).Value = stockLogTypeId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetStockLogTypeFromReader(reader);
					StockLogTypeDetails obj = new StockLogTypeDetails();
					obj.StockLogTypeId = GetReaderValue_Int32(reader, "StockLogTypeId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.ParentStockLogTypeNo = GetReaderValue_NullableInt32(reader, "ParentStockLogTypeNo", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get StockLogType", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update StockLogType
		/// Calls [usp_update_StockLogType]
        /// </summary>
		public override bool Update(System.String name, System.Int32? parentStockLogTypeNo, System.Int32? stockLogTypeId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_StockLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@ParentStockLogTypeNo", SqlDbType.Int).Value = parentStockLogTypeNo;
				cmd.Parameters.Add("@StockLogTypeId", SqlDbType.Int).Value = stockLogTypeId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update StockLogType", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}