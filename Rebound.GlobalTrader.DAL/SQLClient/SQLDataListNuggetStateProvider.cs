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
	public class SqlDataListNuggetStateProvider : DataListNuggetStateProvider {
		/// <summary>
		/// Delete DataListNuggetState
		/// Calls [usp_delete_DataListNuggetState_All_for_Login]
		/// </summary>
		public override bool DeleteAllForLogin(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_DataListNuggetState_All_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete DataListNuggetState", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete DataListNuggetState
		/// Calls [usp_delete_DataListNuggetState_for_DLN_and_Login]
		/// </summary>
		public override bool DeleteForDLNAndLogin(System.Int32? dataListNuggetNo, System.String subType, System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_DataListNuggetState_for_DLN_and_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DataListNuggetNo", SqlDbType.Int).Value = dataListNuggetNo;
				cmd.Parameters.Add("@SubType", SqlDbType.NVarChar).Value = subType;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete DataListNuggetState", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForDLNAndLogin 
		/// Calls [usp_select_DataListNuggetState_for_DLN_and_Login]
        /// </summary>
		public override DataListNuggetStateDetails GetForDLNAndLogin(System.Int32? dataListNuggetNo, System.String subType, System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_DataListNuggetState_for_DLN_and_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DataListNuggetNo", SqlDbType.Int).Value = dataListNuggetNo;
				cmd.Parameters.Add("@SubType", SqlDbType.NVarChar).Value = subType;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDataListNuggetStateFromReader(reader);
					DataListNuggetStateDetails obj = new DataListNuggetStateDetails();
					obj.DataListNuggetStateID = GetReaderValue_Int32(reader, "DataListNuggetStateID", 0);
					obj.DataListNuggetNo = GetReaderValue_Int32(reader, "DataListNuggetNo", 0);
					obj.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0);
					obj.SubType = GetReaderValue_String(reader, "SubType", "");
					obj.StateText = GetReaderValue_String(reader, "StateText", "");
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get DataListNuggetState", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update DataListNuggetState
		/// Calls [usp_update_DataListNuggetState_for_DLN_and_Login]
        /// </summary>
		public override bool UpdateForDLNAndLogin(System.Int32? dataListNuggetNo, System.String subType, System.Int32? loginNo, System.String stateText) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_DataListNuggetState_for_DLN_and_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DataListNuggetNo", SqlDbType.Int).Value = dataListNuggetNo;
				cmd.Parameters.Add("@SubType", SqlDbType.NVarChar).Value = subType;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@StateText", SqlDbType.NVarChar).Value = stateText;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update DataListNuggetState", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}