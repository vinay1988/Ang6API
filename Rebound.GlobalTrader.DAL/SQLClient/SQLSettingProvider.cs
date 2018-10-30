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
	public class SqlSettingProvider : SettingProvider {
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Setting]
		/// </summary>
		public override Int32 Insert(System.Int32? settingItemId, System.Int32? clientId, System.String settingValue, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Setting", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SettingItemID", SqlDbType.Int).Value = settingItemId;
				cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@SettingValue", SqlDbType.NVarChar).Value = settingValue;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewID"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Setting", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Setting]
        /// </summary>
		public override SettingDetails Get(System.Int32? settingId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Setting", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SettingID", SqlDbType.Int).Value = settingId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSettingFromReader(reader);
					SettingDetails obj = new SettingDetails();
					obj.SettingID = GetReaderValue_Int32(reader, "SettingID", 0);
					obj.SettingItemID = GetReaderValue_Int32(reader, "SettingItemID", 0);
					obj.ClientID = GetReaderValue_NullableInt32(reader, "ClientID", null);
					obj.SettingValue = GetReaderValue_String(reader, "SettingValue", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Setting", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetValue 
		/// Calls [usp_select_Setting_Value]
        /// </summary>
		public override SettingDetails GetValue(System.Int32? settingItemId, System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Setting_Value", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SettingItemID", SqlDbType.Int).Value = settingItemId;
				cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSettingFromReader(reader);
					SettingDetails obj = new SettingDetails();
					obj.SettingValue = GetReaderValue_String(reader, "SettingValue", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Setting", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListValues 
		/// Calls [usp_selectAll_Setting_values]
        /// </summary>
		public override List<SettingDetails> GetListValues(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Setting_values", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SettingDetails> lst = new List<SettingDetails>();
				while (reader.Read()) {
					SettingDetails obj = new SettingDetails();
					obj.SettingItemID = GetReaderValue_Int32(reader, "SettingItemID", 0);
					obj.SettingValue = GetReaderValue_String(reader, "SettingValue", "");
					obj.SettingItemName = GetReaderValue_String(reader, "SettingItemName", "");
					obj.DefaultValue = GetReaderValue_String(reader, "DefaultValue", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Settings", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Setting
		/// Calls [usp_update_Setting]
        /// </summary>
		public override bool Update(System.Int32? settingItemId, System.Int32? clientId, System.String settingValue, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Setting", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SettingItemID", SqlDbType.Int).Value = settingItemId;
				cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@SettingValue", SqlDbType.NVarChar).Value = settingValue;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Setting", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}