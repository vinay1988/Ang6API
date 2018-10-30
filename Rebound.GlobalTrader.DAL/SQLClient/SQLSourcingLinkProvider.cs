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
	public class SqlSourcingLinkProvider : SourcingLinkProvider {
		/// <summary>
		/// Delete SourcingLink
		/// Calls [usp_delete_SourcingLink]
		/// </summary>
		public override bool Delete(System.Int32? sourcingLinkId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_SourcingLink", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SourcingLinkId", SqlDbType.Int).Value = sourcingLinkId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete SourcingLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SourcingLink]
		/// </summary>
		public override Int32 Insert(System.String sourcingLinkName, System.String url, System.Int32? clientNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SourcingLink", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SourcingLinkName", SqlDbType.NVarChar).Value = sourcingLinkName;
				cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@SourcingLinkId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@SourcingLinkId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SourcingLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_SourcingLink]
        /// </summary>
		public override SourcingLinkDetails Get(System.Int32? sourcingLinkId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SourcingLink", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SourcingLinkId", SqlDbType.Int).Value = sourcingLinkId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSourcingLinkFromReader(reader);
					SourcingLinkDetails obj = new SourcingLinkDetails();
					obj.SourcingLinkId = GetReaderValue_Int32(reader, "SourcingLinkId", 0);
					obj.SourcingLinkName = GetReaderValue_String(reader, "SourcingLinkName", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SourcingLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_SourcingLink_for_Client]
        /// </summary>
		public override List<SourcingLinkDetails> GetListForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SourcingLink_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SourcingLinkDetails> lst = new List<SourcingLinkDetails>();
				while (reader.Read()) {
					SourcingLinkDetails obj = new SourcingLinkDetails();
					obj.SourcingLinkId = GetReaderValue_Int32(reader, "SourcingLinkId", 0);
					obj.SourcingLinkName = GetReaderValue_String(reader, "SourcingLinkName", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SourcingLinks", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SourcingLink
		/// Calls [usp_update_SourcingLink]
        /// </summary>
		public override bool Update(System.Int32? sourcingLinkId, System.String sourcingLinkName, System.String url, System.Int32? clientNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SourcingLink", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SourcingLinkId", SqlDbType.Int).Value = sourcingLinkId;
				cmd.Parameters.Add("@SourcingLinkName", SqlDbType.NVarChar).Value = sourcingLinkName;
				cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SourcingLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}