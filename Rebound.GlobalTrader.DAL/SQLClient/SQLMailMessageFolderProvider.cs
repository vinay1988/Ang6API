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
	public class SqlMailMessageFolderProvider : MailMessageFolderProvider {
		/// <summary>
		/// Delete MailMessageFolder
		/// Calls [usp_delete_MailMessageFolder]
		/// </summary>
		public override bool Delete(System.Int32? mailMessageFolderNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_MailMessageFolder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@MailMessageFolderNo", SqlDbType.Int).Value = mailMessageFolderNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete MailMessageFolder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_MailMessageFolder]
        /// </summary>
		public override List<MailMessageFolderDetails> DropDown(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_MailMessageFolder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailMessageFolderDetails> lst = new List<MailMessageFolderDetails>();
				while (reader.Read()) {
					MailMessageFolderDetails obj = new MailMessageFolderDetails();
					obj.MailMessageFolderId = GetReaderValue_Int32(reader, "MailMessageFolderId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessageFolders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_MailMessageFolder]
		/// </summary>
		public override Int32 Insert(System.Int32? loginNo, System.String name, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_MailMessageFolder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert MailMessageFolder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_MailMessageFolder]
        /// </summary>
		public override MailMessageFolderDetails Get(System.Int32? mailMessageFolderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_MailMessageFolder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@MailMessageFolderId", SqlDbType.Int).Value = mailMessageFolderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetMailMessageFolderFromReader(reader);
					MailMessageFolderDetails obj = new MailMessageFolderDetails();
					obj.MailMessageFolderId = GetReaderValue_Int32(reader, "MailMessageFolderId", 0);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessageFolder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_MailMessageFolder]
        /// </summary>
		public override List<MailMessageFolderDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailMessageFolder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailMessageFolderDetails> lst = new List<MailMessageFolderDetails>();
				while (reader.Read()) {
					MailMessageFolderDetails obj = new MailMessageFolderDetails();
					obj.MailMessageFolderId = GetReaderValue_Int32(reader, "MailMessageFolderId", 0);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessageFolders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForLogin 
		/// Calls [usp_selectAll_MailMessageFolder_for_Login]
        /// </summary>
		public override List<MailMessageFolderDetails> GetListForLogin(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailMessageFolder_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailMessageFolderDetails> lst = new List<MailMessageFolderDetails>();
				while (reader.Read()) {
					MailMessageFolderDetails obj = new MailMessageFolderDetails();
					obj.MailMessageFolderId = GetReaderValue_Int32(reader, "MailMessageFolderId", 0);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessageFolders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update MailMessageFolder
		/// Calls [usp_update_MailMessageFolder]
        /// </summary>
		public override bool Update(System.Int32? mailMessageFolderId, System.String name, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_MailMessageFolder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@MailMessageFolderId", SqlDbType.Int).Value = mailMessageFolderId;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update MailMessageFolder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}