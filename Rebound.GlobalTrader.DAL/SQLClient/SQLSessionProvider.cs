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
	public class SqlSessionProvider : SessionProvider {
		/// <summary>
		/// Count Session
		/// Calls [usp_count_Session]
		/// </summary>
		public override Int32 Count() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Session", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Session", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Session
		/// Calls [usp_count_Session_for_Login]
		/// </summary>
		public override Int32 CountForLogin(System.Int32? loginNo, System.String sessionName) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Session_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@SessionName", SqlDbType.NVarChar).Value = sessionName;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Session", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Session
		/// Calls [usp_delete_Session]
		/// </summary>
		public override bool Delete(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Session", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Session", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Session]
        /// </summary>
		public override SessionDetails Get(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Session", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSessionFromReader(reader);
					SessionDetails obj = new SessionDetails();
					obj.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0);
					obj.SessionName = GetReaderValue_String(reader, "SessionName", "");
					obj.SessionTimestamp = GetReaderValue_DateTime(reader, "SessionTimestamp", DateTime.MinValue);
					obj.StartTime = GetReaderValue_DateTime(reader, "StartTime", DateTime.MinValue);
					obj.IPAddress = GetReaderValue_String(reader, "IPAddress", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Session", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_Session]
        /// </summary>
		public override List<SessionDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Session", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SessionDetails> lst = new List<SessionDetails>();
				while (reader.Read()) {
					SessionDetails obj = new SessionDetails();
					obj.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0);
					obj.SessionName = GetReaderValue_String(reader, "SessionName", "");
					obj.SessionTimestamp = GetReaderValue_DateTime(reader, "SessionTimestamp", DateTime.MinValue);
					obj.StartTime = GetReaderValue_DateTime(reader, "StartTime", DateTime.MinValue);
					obj.IPAddress = GetReaderValue_String(reader, "IPAddress", "");
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.ServerIP = GetReaderValue_String(reader, "ServerIP", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Sessions", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Session
		/// Calls [usp_update_Session_ClearOldSessions]
        /// </summary>
		public override bool UpdateClearOldSessions() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Session_ClearOldSessions", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Session", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}