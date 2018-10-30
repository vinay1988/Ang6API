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
	public class SqlCommunicationLogTypeProvider : CommunicationLogTypeProvider {
		/// <summary>
		/// Count CommunicationLogType
		/// Calls [usp_count_CommunicationLogType]
		/// </summary>
		public override Int32 Count() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_CommunicationLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count CommunicationLogType", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete CommunicationLogType
		/// Calls [usp_delete_CommunicationLogType]
		/// </summary>
		public override bool Delete(System.Int32? communicationLogTypeId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_CommunicationLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CommunicationLogTypeId", SqlDbType.Int).Value = communicationLogTypeId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete CommunicationLogType", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_CommunicationLogType]
        /// </summary>
		public override List<CommunicationLogTypeDetails> DropDown() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_CommunicationLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CommunicationLogTypeDetails> lst = new List<CommunicationLogTypeDetails>();
				while (reader.Read()) {
					CommunicationLogTypeDetails obj = new CommunicationLogTypeDetails();
					obj.CommunicationLogTypeId = GetReaderValue_Int32(reader, "CommunicationLogTypeId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CommunicationLogTypes", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_CommunicationLogType]
		/// </summary>
		public override Int32 Insert(System.String name) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_CommunicationLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@CommunicationLogTypeId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CommunicationLogTypeId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert CommunicationLogType", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_CommunicationLogType]
        /// </summary>
		public override CommunicationLogTypeDetails Get(System.Int32? communicationLogTypeId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CommunicationLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CommunicationLogTypeId", SqlDbType.Int).Value = communicationLogTypeId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCommunicationLogTypeFromReader(reader);
					CommunicationLogTypeDetails obj = new CommunicationLogTypeDetails();
					obj.CommunicationLogTypeId = GetReaderValue_Int32(reader, "CommunicationLogTypeId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CommunicationLogType", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_CommunicationLogType]
        /// </summary>
		public override List<CommunicationLogTypeDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CommunicationLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CommunicationLogTypeDetails> lst = new List<CommunicationLogTypeDetails>();
				while (reader.Read()) {
					CommunicationLogTypeDetails obj = new CommunicationLogTypeDetails();
					obj.CommunicationLogTypeId = GetReaderValue_Int32(reader, "CommunicationLogTypeId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CommunicationLogTypes", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CommunicationLogType
		/// Calls [usp_update_CommunicationLogType]
        /// </summary>
		public override bool Update(System.Int32? communicationLogTypeId, System.String name) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CommunicationLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CommunicationLogTypeId", SqlDbType.Int).Value = communicationLogTypeId;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CommunicationLogType", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}