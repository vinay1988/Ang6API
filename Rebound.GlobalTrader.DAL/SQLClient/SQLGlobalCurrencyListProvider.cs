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
	public class SqlGlobalCurrencyListProvider : GlobalCurrencyListProvider {
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_GlobalCurrencyList]
        /// </summary>
		public override List<GlobalCurrencyListDetails> DropDown(System.Boolean? includeSelected, System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_GlobalCurrencyList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@IncludeSelected", SqlDbType.Bit).Value = includeSelected;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<GlobalCurrencyListDetails> lst = new List<GlobalCurrencyListDetails>();
				while (reader.Read()) {
					GlobalCurrencyListDetails obj = new GlobalCurrencyListDetails();
					obj.GlobalCurrencyId = GetReaderValue_Int32(reader, "GlobalCurrencyId", 0);
					obj.GlobalCurrencyName = GetReaderValue_String(reader, "GlobalCurrencyName", "");
					obj.GlobalCurrencyDescription = GetReaderValue_String(reader, "GlobalCurrencyDescription", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get GlobalCurrencyLists", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_GlobalCurrencyList]
		/// </summary>
		public override Int32 Insert(System.String globalCurrencyName, System.String globalCurrencyDescription, System.String symbol, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_GlobalCurrencyList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@GlobalCurrencyName", SqlDbType.NVarChar).Value = globalCurrencyName;
				cmd.Parameters.Add("@GlobalCurrencyDescription", SqlDbType.NVarChar).Value = globalCurrencyDescription;
				cmd.Parameters.Add("@Symbol", SqlDbType.NVarChar).Value = symbol;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@GlobalCurrencyId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@GlobalCurrencyId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert GlobalCurrencyList", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_GlobalCurrencyList]
        /// </summary>
		public override GlobalCurrencyListDetails Get(System.Int32? currencyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_GlobalCurrencyList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = currencyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetGlobalCurrencyListFromReader(reader);
					GlobalCurrencyListDetails obj = new GlobalCurrencyListDetails();
					obj.GlobalCurrencyId = GetReaderValue_Int32(reader, "GlobalCurrencyId", 0);
					obj.GlobalCurrencyName = GetReaderValue_String(reader, "GlobalCurrencyName", "");
					obj.GlobalCurrencyDescription = GetReaderValue_String(reader, "GlobalCurrencyDescription", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Priority = GetReaderValue_Boolean(reader, "Priority", false);
					obj.Symbol = GetReaderValue_String(reader, "Symbol", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get GlobalCurrencyList", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_GlobalCurrencyList]
        /// </summary>
		public override List<GlobalCurrencyListDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_GlobalCurrencyList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<GlobalCurrencyListDetails> lst = new List<GlobalCurrencyListDetails>();
				while (reader.Read()) {
					GlobalCurrencyListDetails obj = new GlobalCurrencyListDetails();
					obj.GlobalCurrencyId = GetReaderValue_Int32(reader, "GlobalCurrencyId", 0);
					obj.GlobalCurrencyName = GetReaderValue_String(reader, "GlobalCurrencyName", "");
					obj.GlobalCurrencyDescription = GetReaderValue_String(reader, "GlobalCurrencyDescription", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Priority = GetReaderValue_Boolean(reader, "Priority", false);
					obj.Symbol = GetReaderValue_String(reader, "Symbol", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get GlobalCurrencyLists", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update GlobalCurrencyList
		/// Calls [usp_update_GlobalCurrencyList]
        /// </summary>
		public override bool Update(System.Int32? globalCurrencyId, System.String globalCurrencyName, System.String globalCurrencyDescription, System.String symbol, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_GlobalCurrencyList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@GlobalCurrencyId", SqlDbType.Int).Value = globalCurrencyId;
				cmd.Parameters.Add("@GlobalCurrencyName", SqlDbType.NVarChar).Value = globalCurrencyName;
				cmd.Parameters.Add("@GlobalCurrencyDescription", SqlDbType.NVarChar).Value = globalCurrencyDescription;
				cmd.Parameters.Add("@Symbol", SqlDbType.NVarChar).Value = symbol;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update GlobalCurrencyList", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}