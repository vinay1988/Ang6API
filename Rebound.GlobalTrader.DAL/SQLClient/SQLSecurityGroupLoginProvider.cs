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
	public class SqlSecurityGroupLoginProvider : SecurityGroupLoginProvider {
		/// <summary>
		/// Delete SecurityGroupLogin
		/// Calls [usp_delete_SecurityGroupLogin]
		/// </summary>
		public override bool Delete(System.Int32? loginNo, System.Int32? securityGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_SecurityGroupLogin", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete SecurityGroupLogin", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete SecurityGroupLogin
		/// Calls [usp_delete_SecurityGroupLogin_for_SecurityGroup]
		/// </summary>
		public override bool DeleteForSecurityGroup(System.Int32? securityGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_SecurityGroupLogin_for_SecurityGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete SecurityGroupLogin", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SecurityGroupLogin]
		/// </summary>
		public override Int32 Insert(System.Int32? securityGroupNo, System.Int32? loginNo, System.Int32? updatedBy,System.Boolean? isGlobal) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SecurityGroupLogin", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IsGlobal", SqlDbType.Bit).Value = isGlobal;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SecurityGroupLogin", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSecurityGroup 
		/// Calls [usp_selectAll_SecurityGroupLogin_for_SecurityGroup]
        /// </summary>
		public override List<SecurityGroupLoginDetails> GetListForSecurityGroup(System.Int32? securityGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SecurityGroupLogin_for_SecurityGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SecurityGroupLoginDetails> lst = new List<SecurityGroupLoginDetails>();
				while (reader.Read()) {
					SecurityGroupLoginDetails obj = new SecurityGroupLoginDetails();
					obj.SecurityGroupLoginId = GetReaderValue_Int32(reader, "SecurityGroupLoginId", 0);
					obj.SecurityGroupNo = GetReaderValue_Int32(reader, "SecurityGroupNo", 0);
					obj.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					obj.KeyLogin = GetReaderValue_Boolean(reader, "KeyLogin", false);
					obj.Administrator = GetReaderValue_Boolean(reader, "Administrator", false);
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SecurityGroupLogins", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SecurityGroupLogin
		/// Calls [usp_update_SecurityGroupLogin]
        /// </summary>
		public override bool Update(System.Int32? securityGroupNo, System.Int32? loginNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SecurityGroupLogin", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SecurityGroupLogin", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}