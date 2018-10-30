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
	public class SqlSecurityGroupSecurityFunctionPermissionProvider : SecurityGroupSecurityFunctionPermissionProvider {
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission]
		/// </summary>
		public override Int32 Insert(System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SecurityGroupSecurityFunctionPermission", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cmd.Parameters.Add("@SecurityFunctionNo", SqlDbType.Int).Value = securityFunctionNo;
				cmd.Parameters.Add("@IsAllowed", SqlDbType.Bit).Value = isAllowed;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SecurityGroupSecurityFunctionPermission", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission_DenyAllButAdminsForNewFunction]
		/// </summary>
		public override Int32 InsertDenyAllButAdminsForNewFunction(System.Int32? securityFunctionId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SecurityGroupSecurityFunctionPermission_DenyAllButAdminsForNewFunction", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityFunctionID", SqlDbType.Int).Value = securityFunctionId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@DummyReturn", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@DummyReturn"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SecurityGroupSecurityFunctionPermission", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission_StandardPermissions]
		/// </summary>
		public override Int32 InsertStandardPermissions(System.Int32? securityGroupNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SecurityGroupSecurityFunctionPermission_StandardPermissions", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SecurityGroupSecurityFunctionPermission", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_SecurityGroupSecurityFunctionPermission]
        /// </summary>
		public override SecurityGroupSecurityFunctionPermissionDetails Get(System.Int32? securityGroupSecurityFunctionPermissionId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SecurityGroupSecurityFunctionPermission", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SecurityGroupSecurityFunctionPermissionId", SqlDbType.Int).Value = securityGroupSecurityFunctionPermissionId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSecurityGroupSecurityFunctionPermissionFromReader(reader);
					SecurityGroupSecurityFunctionPermissionDetails obj = new SecurityGroupSecurityFunctionPermissionDetails();
					obj.SecurityGroupSecurityFunctionPermissionId = GetReaderValue_Int32(reader, "SecurityGroupSecurityFunctionPermissionId", 0);
					obj.SecurityGroupNo = GetReaderValue_Int32(reader, "SecurityGroupNo", 0);
					obj.SecurityFunctionNo = GetReaderValue_Int32(reader, "SecurityFunctionNo", 0);
					obj.IsAllowed = GetReaderValue_Boolean(reader, "IsAllowed", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SecurityGroupSecurityFunctionPermission", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetByGroupAndFunction 
		/// Calls [usp_select_SecurityGroupSecurityFunctionPermission_by_Group_and_Function]
        /// </summary>
		public override SecurityGroupSecurityFunctionPermissionDetails GetByGroupAndFunction(System.Int32? securityGroupNo, System.Int32? securityFunctionNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SecurityGroupSecurityFunctionPermission_by_Group_and_Function", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cmd.Parameters.Add("@SecurityFunctionNo", SqlDbType.Int).Value = securityFunctionNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSecurityGroupSecurityFunctionPermissionFromReader(reader);
					SecurityGroupSecurityFunctionPermissionDetails obj = new SecurityGroupSecurityFunctionPermissionDetails();
					obj.SecurityGroupSecurityFunctionPermissionId = GetReaderValue_Int32(reader, "SecurityGroupSecurityFunctionPermissionId", 0);
					obj.SecurityGroupNo = GetReaderValue_Int32(reader, "SecurityGroupNo", 0);
					obj.SecurityFunctionNo = GetReaderValue_Int32(reader, "SecurityFunctionNo", 0);
					obj.IsAllowed = GetReaderValue_Boolean(reader, "IsAllowed", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SecurityGroupSecurityFunctionPermission", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SecurityGroupSecurityFunctionPermission
		/// Calls [usp_update_SecurityGroupSecurityFunctionPermission]
        /// </summary>
		public override bool Update(System.Int32? securityGroupSecurityFunctionPermissionId, System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SecurityGroupSecurityFunctionPermission", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityGroupSecurityFunctionPermissionId", SqlDbType.Int).Value = securityGroupSecurityFunctionPermissionId;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cmd.Parameters.Add("@SecurityFunctionNo", SqlDbType.Int).Value = securityFunctionNo;
				cmd.Parameters.Add("@IsAllowed", SqlDbType.Bit).Value = isAllowed;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SecurityGroupSecurityFunctionPermission", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_GlobalSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public override Int32 GlobalPermissionInsert(System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_GlobalSecurityGroupSecurityFunctionPermission", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
                cmd.Parameters.Add("@SecurityFunctionNo", SqlDbType.Int).Value = securityFunctionNo;
                cmd.Parameters.Add("@IsAllowed", SqlDbType.Bit).Value = isAllowed;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert SecurityGroupSecurityFunctionPermission", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update SecurityGlobalGroupSecurityFunctionPermission
        /// Calls [usp_update_GlobalSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public override bool GlobalPermissionUpdate(System.Int32? securityGroupSecurityFunctionPermissionId, System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GlobalSecurityGroupSecurityFunctionPermission", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SecurityGroupSecurityFunctionPermissionId", SqlDbType.Int).Value = securityGroupSecurityFunctionPermissionId;
                cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
                cmd.Parameters.Add("@SecurityFunctionNo", SqlDbType.Int).Value = securityFunctionNo;
                cmd.Parameters.Add("@IsAllowed", SqlDbType.Bit).Value = isAllowed;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SecurityGroupSecurityFunctionPermission", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_BulkSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public override Int32 Insert(System.Int32? securityGroupNo, System.String xmlPermission, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_BulkSecurityGroupSecurityFunctionPermission", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
                cmd.Parameters.Add("@Permissions", SqlDbType.Xml).Value = xmlPermission;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                ExecuteNonQuery(cmd);
                return 1;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert SecurityGroupSecurityFunctionPermission", sqlex);
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