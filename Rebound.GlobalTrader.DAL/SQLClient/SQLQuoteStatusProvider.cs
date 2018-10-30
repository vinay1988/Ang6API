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
	public class SqlQuoteStatusProvider : QuoteStatusProvider {
		/// <summary>
		/// Delete QuoteStatus
		/// Calls [usp_delete_QuoteStatus]
		/// </summary>
		public override bool Delete(System.Int32? quoteStatusId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_QuoteStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@QuoteStatusId", SqlDbType.Int).Value = quoteStatusId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete QuoteStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_QuoteStatus]
        /// </summary>
		public override List<QuoteStatusDetails> DropDown() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_QuoteStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteStatusDetails> lst = new List<QuoteStatusDetails>();
				while (reader.Read()) {
					QuoteStatusDetails obj = new QuoteStatusDetails();
					obj.QuoteStatusId = GetReaderValue_Int32(reader, "QuoteStatusId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteStatuss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_QuoteStatus]
		/// </summary>
		public override Int32 Insert(System.String name) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_QuoteStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@QuoteStatusId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@QuoteStatusId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert QuoteStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_QuoteStatus]
        /// </summary>
		public override QuoteStatusDetails Get(System.Int32? quoteStatusId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_QuoteStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteStatusId", SqlDbType.Int).Value = quoteStatusId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetQuoteStatusFromReader(reader);
					QuoteStatusDetails obj = new QuoteStatusDetails();
					obj.QuoteStatusId = GetReaderValue_Int32(reader, "QuoteStatusId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_QuoteStatus]
        /// </summary>
		public override List<QuoteStatusDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_QuoteStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteStatusDetails> lst = new List<QuoteStatusDetails>();
				while (reader.Read()) {
					QuoteStatusDetails obj = new QuoteStatusDetails();
					obj.QuoteStatusId = GetReaderValue_Int32(reader, "QuoteStatusId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteStatuss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update QuoteStatus
		/// Calls [usp_update_QuoteStatus]
        /// </summary>
		public override bool Update(System.String name, System.Int32? quoteStatusId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_QuoteStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@QuoteStatusId", SqlDbType.Int).Value = quoteStatusId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update QuoteStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}