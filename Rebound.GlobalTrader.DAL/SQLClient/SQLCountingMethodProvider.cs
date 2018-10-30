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
	public class SqlCountingMethodProvider : CountingMethodProvider {
		/// <summary>
		/// Delete CountingMethod
		/// Calls [usp_delete_CountingMethod]
		/// </summary>
		public override bool Delete(System.Int32? countingMethodId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_CountingMethod", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CountingMethodId", SqlDbType.Int).Value = countingMethodId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete CountingMethod", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_CountingMethod]
        /// </summary>
		public override List<CountingMethodDetails> DropDown() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_CountingMethod", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CountingMethodDetails> lst = new List<CountingMethodDetails>();
				while (reader.Read()) {
					CountingMethodDetails obj = new CountingMethodDetails();
					obj.CountingMethodId = GetReaderValue_Int32(reader, "CountingMethodId", 0);
					obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CountingMethods", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_CountingMethod]
		/// </summary>
		public override Int32 Insert(System.String countingMethodDescription, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_CountingMethod", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CountingMethodDescription", SqlDbType.NVarChar).Value = countingMethodDescription;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@CountingMethodId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CountingMethodId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert CountingMethod", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_CountingMethod]
        /// </summary>
		public override CountingMethodDetails Get(System.Int32? countingMethodId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CountingMethod", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CountingMethodId", SqlDbType.Int).Value = countingMethodId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCountingMethodFromReader(reader);
					CountingMethodDetails obj = new CountingMethodDetails();
					obj.CountingMethodId = GetReaderValue_Int32(reader, "CountingMethodId", 0);
					obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CountingMethod", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_CountingMethod]
        /// </summary>
		public override List<CountingMethodDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CountingMethod", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CountingMethodDetails> lst = new List<CountingMethodDetails>();
				while (reader.Read()) {
					CountingMethodDetails obj = new CountingMethodDetails();
					obj.CountingMethodId = GetReaderValue_Int32(reader, "CountingMethodId", 0);
					obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CountingMethods", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CountingMethod
		/// Calls [usp_update_CountingMethod]
        /// </summary>
		public override bool Update(System.Int32? countingMethodId, System.String countingMethodDescription, System.Boolean? inactive, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CountingMethod", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CountingMethodId", SqlDbType.Int).Value = countingMethodId;
				cmd.Parameters.Add("@CountingMethodDescription", SqlDbType.NVarChar).Value = countingMethodDescription;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CountingMethod", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}