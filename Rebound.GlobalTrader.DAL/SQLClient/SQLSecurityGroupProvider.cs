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
	public class SqlSecurityGroupProvider : SecurityGroupProvider {
		/// <summary>
		/// Delete SecurityGroup
		/// Calls [usp_delete_SecurityGroup]
		/// </summary>
		public override bool Delete(System.Int32? securityGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_SecurityGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete SecurityGroup", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SecurityGroup]
		/// </summary>
		public override Int32 Insert(System.String securityGroupName, System.Int32? clientNo, System.Boolean? inactive, System.Boolean? locked, System.Boolean? administrator, System.Int32? updatedBy,System.Boolean? isGlobal) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SecurityGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityGroupName", SqlDbType.NVarChar).Value = securityGroupName;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@Locked", SqlDbType.Bit).Value = locked;
				cmd.Parameters.Add("@Administrator", SqlDbType.Bit).Value = administrator;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IsGlobal", SqlDbType.Bit).Value = isGlobal;
				cmd.Parameters.Add("@NewID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewID"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SecurityGroup", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SecurityGroup_Clone]
		/// </summary>
		public override Int32 InsertClone(System.Int32? oldSecurityGroupId, System.String securityGroupName, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SecurityGroup_Clone", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@OldSecurityGroupID", SqlDbType.Int).Value = oldSecurityGroupId;
				cmd.Parameters.Add("@SecurityGroupName", SqlDbType.NVarChar).Value = securityGroupName;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewID"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SecurityGroup", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_SecurityGroup]
        /// </summary>
		public override SecurityGroupDetails Get(System.Int32? securityGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SecurityGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSecurityGroupFromReader(reader);
					SecurityGroupDetails obj = new SecurityGroupDetails();
					obj.SecurityGroupId = GetReaderValue_Int32(reader, "SecurityGroupId", 0);
					obj.SecurityGroupName = GetReaderValue_String(reader, "SecurityGroupName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Locked = GetReaderValue_Boolean(reader, "Locked", false);
					obj.Administrator = GetReaderValue_Boolean(reader, "Administrator", false);
					obj.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SecurityGroup", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_SecurityGroup_for_Client]
        /// </summary>
		public override List<SecurityGroupDetails> GetListForClient(System.Int32? clientNo, System.Boolean? isGlobal) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SecurityGroup_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobal", SqlDbType.Bit).Value = isGlobal;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SecurityGroupDetails> lst = new List<SecurityGroupDetails>();
				while (reader.Read()) {
					SecurityGroupDetails obj = new SecurityGroupDetails();
					obj.SecurityGroupId = GetReaderValue_Int32(reader, "SecurityGroupId", 0);
					obj.SecurityGroupName = GetReaderValue_String(reader, "SecurityGroupName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Locked = GetReaderValue_Boolean(reader, "Locked", false);
					obj.Administrator = GetReaderValue_Boolean(reader, "Administrator", false);
					obj.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SecurityGroups", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForLogin 
		/// Calls [usp_selectAll_SecurityGroup_for_Login]
        /// </summary>
		public override List<SecurityGroupDetails> GetListForLogin(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SecurityGroup_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SecurityGroupDetails> lst = new List<SecurityGroupDetails>();
				while (reader.Read()) {
					SecurityGroupDetails obj = new SecurityGroupDetails();
					obj.SecurityGroupId = GetReaderValue_Int32(reader, "SecurityGroupId", 0);
					obj.SecurityGroupName = GetReaderValue_String(reader, "SecurityGroupName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Locked = GetReaderValue_Boolean(reader, "Locked", false);
					obj.Administrator = GetReaderValue_Boolean(reader, "Administrator", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SecurityGroups", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SecurityGroup
		/// Calls [usp_update_SecurityGroup]
        /// </summary>
		public override bool Update(System.Int32? securityGroupId, System.String securityGroupName, System.Int32? clientNo, System.Boolean? locked, System.Boolean? administrator, System.Boolean? inactive, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SecurityGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityGroupId", SqlDbType.Int).Value = securityGroupId;
				cmd.Parameters.Add("@SecurityGroupName", SqlDbType.NVarChar).Value = securityGroupName;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Locked", SqlDbType.Bit).Value = locked;
				cmd.Parameters.Add("@Administrator", SqlDbType.Bit).Value = administrator;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SecurityGroup", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}