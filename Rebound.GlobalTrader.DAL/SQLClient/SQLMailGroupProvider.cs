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
	public class SqlMailGroupProvider : MailGroupProvider {
		/// <summary>
		/// Delete MailGroup
		/// Calls [usp_delete_MailGroup]
		/// </summary>
		public override bool Delete(System.Int32? mailGroupId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_MailGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@MailGroupId", SqlDbType.Int).Value = mailGroupId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete MailGroup", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_MailGroup]
		/// </summary>
		public override Int32 Insert(System.Int32? loginNo, System.Int32? clientNo, System.String name, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_MailGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@MailGroupId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@MailGroupId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert MailGroup", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_MailGroup]
        /// </summary>
		public override MailGroupDetails Get(System.Int32? mailGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_MailGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@MailGroupNo", SqlDbType.Int).Value = mailGroupNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetMailGroupFromReader(reader);
					MailGroupDetails obj = new MailGroupDetails();
					obj.MailGroupId = GetReaderValue_Int32(reader, "MailGroupId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailGroup", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_MailGroup_for_Client]
        /// </summary>
		public override List<MailGroupDetails> GetListForClient(System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailGroup_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailGroupDetails> lst = new List<MailGroupDetails>();
				while (reader.Read()) {
					MailGroupDetails obj = new MailGroupDetails();
					obj.MailGroupId = GetReaderValue_Int32(reader, "MailGroupId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailGroups", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForLogin 
		/// Calls [usp_selectAll_MailGroup_for_Login]
        /// </summary>
		public override List<MailGroupDetails> GetListForLogin(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailGroup_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailGroupDetails> lst = new List<MailGroupDetails>();
				while (reader.Read()) {
					MailGroupDetails obj = new MailGroupDetails();
					obj.MailGroupId = GetReaderValue_Int32(reader, "MailGroupId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailGroups", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update MailGroup
		/// Calls [usp_update_MailGroup]
        /// </summary>
		public override bool Update(System.Int32? mailGroupId, System.Int32? loginNo, System.Int32? clientNo, System.String name, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_MailGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@MailGroupId", SqlDbType.Int).Value = mailGroupId;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update MailGroup", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Update MailGroup
        /// Calls [usp_update_MailGroup]
        /// </summary>
        public override Int32? GetQualityMailGroupNo(System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            Int32? QualityMailGroupNo = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_get_QualityMailGroupNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                while (reader.Read())
                {
                    QualityMailGroupNo = GetReaderValue_NullableInt32(reader, "MailGroupId", null);
                }
                return QualityMailGroupNo;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Quality MailGroups", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
	}
}